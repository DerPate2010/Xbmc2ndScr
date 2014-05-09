using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xbmc2S.RT.UPnP
{
    public abstract class UPnPService
    {

        private static readonly string vbCrLf = Environment.NewLine;


        protected Tuple<Uri, string> MakeRawSoapRequest(Uri requestUri, XElement soapAction, string[] args)
        {
            var soapSchema = soapAction.Name.NamespaceName;
            var soapVerb = soapAction.Name.LocalName;
            var argpairs = new List<Tuple<string, string>>();
            for (int i = 0; i < args.Length - 1; i = i + 2)
            {
                argpairs.Add(Tuple.Create(args[i], args[i + 1]));
            }

            // Format of how to make UPnP SOAP requests is described here:  http://upnp.org/specs/arch/UPnP-arch-DeviceArchitecture-v1.0.pdf
            var s = "<?xml version=\"1.0\"?>" + vbCrLf +
                    "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
                    vbCrLf +
                    "  <s:Body>" + vbCrLf +
                    "    <u:" + soapVerb + " xmlns:u=\"" + soapSchema + "\">" + vbCrLf +
                    string.Join(vbCrLf,(argpairs.Select(arg => (new XElement(arg.Item1,arg.Item2)).ToString())).Concat(new[] { "" })) +
                    "    </u:" + soapVerb + ">" + vbCrLf +
                    "  </s:Body>" + vbCrLf +
                    "</s:Envelope>" + vbCrLf;

            var tuple = new MyTuple(requestUri, s);
            tuple.soapSchema = soapSchema;
            tuple.soapVerb = soapVerb;
            return tuple;
        }

        protected Task<XElement> GetSoapAsync(Tuple<Uri, string> seturiRequest)
        {
            return Platform.Current.GetSoapAsync(seturiRequest);
        }
    }
}