using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xbmc2S.RT.UPnP
{
    public abstract class UPnPDevice
    {

        private const string URN_Device = "{urn:schemas-upnp-org:device-1-0}"; 
        private const string URN_ConnectionManager = "urn:schemas-upnp-org:service:ConnectionManager:1";

        private static readonly string vbCrLf = Environment.NewLine;

        protected async Task<List<XElement>> DoSsdpDiscoveryDialogAsync(Uri deviceLocation, Uri localUri, IProgress<string> progress)
        {
            var desc_request = MakeRawGetRequest(deviceLocation);
            XDocument desc_response = await GetXmlAsync(deviceLocation);
            FriendlyName = desc_response.Element(URN_Device + "root").Element(URN_Device + "device").Element(URN_Device + "friendlyName").Value;
            var desc_services =
                desc_response.Element(URN_Device + "root")
                             .Element(URN_Device + "device")
                             .Element(URN_Device + "serviceList")
                             .Elements(URN_Device + "service").ToList();
            ConnectionManagerControlUrl = GetServiceUri(deviceLocation, desc_services, URN_ConnectionManager);
            if (ConnectionManagerControlUrl==null) throw new NotSupportedException();
            LocalUri = localUri;
            return desc_services;
        }


        protected Task<XDocument> GetXmlAsync(Uri requestUri)
        {
            return Platform.Current.GetXmlAsync(requestUri);
        }

        public Uri LocalUri { get; set; }

        public Uri ConnectionManagerControlUrl { get; set; }

        public string FriendlyName { get; set; }

        private Tuple<Uri, string> MakeRawGetRequest(Uri requestUri)
        {
            var s = "GET " + requestUri.PathAndQuery + " HTTP/1.1" + vbCrLf +
                    "Host: " + requestUri.Host + ":" + requestUri.Port +
                    vbCrLf + vbCrLf;
            return Tuple.Create(requestUri, s);
        }

        protected static Uri GetServiceUri(Uri deviceLocation, IEnumerable<XElement> desc_services, string schema)
        {
            return (from service in desc_services
                    where
                        service.Element(URN_Device + "serviceType").Value ==
                        schema
                    select new Uri(deviceLocation, service.Element(URN_Device + "controlURL").Value))
                .FirstOrDefault();
        }
    }
}