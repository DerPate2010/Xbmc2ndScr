using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace XBMCRPC.Methods
{
   public partial class Input
   {
        private readonly Client _client;
          public Input(Client client)
          {
              _client = client;
          }

        async public Task<string> Back()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.Back", jArgs);
            return jRet;
        }

        async public Task<string> ContextMenu()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.ContextMenu", jArgs);
            return jRet;
        }

        async public Task<string> Down()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.Down", jArgs);
            return jRet;
        }

        async public Task<string> ExecuteAction(XBMCRPC.Input.Action action=0)
        {
            var jArgs = new JObject();
             if (action != null)
             {
                 var jpropaction = JToken.FromObject(action, _client.Serializer);
                 jArgs.Add(new JProperty("action", jpropaction));
             }
            var jRet = await _client.GetData<string>("Input.ExecuteAction", jArgs);
            return jRet;
        }

        async public Task<string> Home()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.Home", jArgs);
            return jRet;
        }

        async public Task<string> Info()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.Info", jArgs);
            return jRet;
        }

        async public Task<string> Left()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.Left", jArgs);
            return jRet;
        }

        async public Task<string> Right()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.Right", jArgs);
            return jRet;
        }

        async public Task<string> Select()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.Select", jArgs);
            return jRet;
        }

        async public Task<string> SendText(string text=null, bool done=false)
        {
            var jArgs = new JObject();
             if (text != null)
             {
                 var jproptext = JToken.FromObject(text, _client.Serializer);
                 jArgs.Add(new JProperty("text", jproptext));
             }
             if (done != null)
             {
                 var jpropdone = JToken.FromObject(done, _client.Serializer);
                 jArgs.Add(new JProperty("done", jpropdone));
             }
            var jRet = await _client.GetData<string>("Input.SendText", jArgs);
            return jRet;
        }

        async public Task<string> ShowCodec()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.ShowCodec", jArgs);
            return jRet;
        }

        async public Task<string> ShowOSD()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.ShowOSD", jArgs);
            return jRet;
        }

        async public Task<string> Up()
        {
            var jArgs = new JObject();
            var jRet = await _client.GetData<string>("Input.Up", jArgs);
            return jRet;
        }

        public delegate void OnInputFinishedDelegate(string sender=null);
        public event OnInputFinishedDelegate OnInputFinished;
        internal void RaiseOnInputFinished(string sender=null)
        {
            if (OnInputFinished != null)
            {
                OnInputFinished.BeginInvoke(sender, null, null);
            }
        }
   public class OnInputRequesteddataType
   {
       public string title {get;set;}
       public string type {get;set;}
       public string value {get;set;}
   }

        public delegate void OnInputRequestedDelegate(string sender=null, OnInputRequesteddataType data=null);
        public event OnInputRequestedDelegate OnInputRequested;
        internal void RaiseOnInputRequested(string sender=null, OnInputRequesteddataType data=null)
        {
            if (OnInputRequested != null)
            {
                OnInputRequested.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
