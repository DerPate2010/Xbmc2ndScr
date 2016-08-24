using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
#pragma warning disable CS0108

namespace XBMCRPC.Methods
{
   public partial class Input
   {
        private readonly Client _client;
          public Input(Client client)
          {
              _client = client;
          }

                /// <summary>
                /// Goes back in GUI
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Back()
        {
            return await _client.GetData<string>("Input.Back",null);
        }

                /// <summary>
                /// Shows the context menu
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> ContextMenu()
        {
            return await _client.GetData<string>("Input.ContextMenu",null);
        }

                /// <summary>
                /// Navigate down in GUI
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Down()
        {
            return await _client.GetData<string>("Input.Down",null);
        }

                /// <summary>
                /// Execute a specific action
                /// </summary>
                /// <param name="action"> REQUIRED </param>
                /// <returns>string</returns>
        public async Task<string> ExecuteAction(XBMCRPC.Input.Action? action=null)
        {
             var jArgs = new JObject();

             if (action == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null action");
              }
             else
              {
                 var jpropaction = JToken.FromObject(action, _client.Serializer);
                 jArgs.Add(new JProperty("action", jpropaction));
              }
            return await _client.GetData<string>("Input.ExecuteAction", jArgs);
        }

                /// <summary>
                /// Goes to home window in GUI
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Home()
        {
            return await _client.GetData<string>("Input.Home",null);
        }

                /// <summary>
                /// Shows the information dialog
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Info()
        {
            return await _client.GetData<string>("Input.Info",null);
        }

                /// <summary>
                /// Navigate left in GUI
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Left()
        {
            return await _client.GetData<string>("Input.Left",null);
        }

                /// <summary>
                /// Navigate right in GUI
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Right()
        {
            return await _client.GetData<string>("Input.Right",null);
        }

                /// <summary>
                /// Select current item in GUI
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Select()
        {
            return await _client.GetData<string>("Input.Select",null);
        }

                /// <summary>
                /// Send a generic (unicode) text
                /// </summary>
                /// <param name="text"> REQUIRED Unicode text</param>
                /// <param name="done"> Whether this is the whole input or not (closes an open input dialog if true).</param>
                /// <returns>string</returns>
        public async Task<string> SendText(string text=null, bool? done=null)
        {
             var jArgs = new JObject();

             if (text == null)
              {
                 throw new global::System.ArgumentException("Parameter cannot be null text");
              }
             else
              {
                 var jproptext = JToken.FromObject(text, _client.Serializer);
                 jArgs.Add(new JProperty("text", jproptext));
              }
             if (done != null)
             {
                 var jpropdone = JToken.FromObject(done, _client.Serializer);
                 jArgs.Add(new JProperty("done", jpropdone));
             }
            return await _client.GetData<string>("Input.SendText", jArgs);
        }

                /// <summary>
                /// Show codec information of the playing item
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> ShowCodec()
        {
            return await _client.GetData<string>("Input.ShowCodec",null);
        }

                /// <summary>
                /// Show the on-screen display for the current player
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> ShowOSD()
        {
            return await _client.GetData<string>("Input.ShowOSD",null);
        }

                /// <summary>
                /// Navigate up in GUI
                /// </summary>
                /// <returns>string</returns>
        public async Task<string> Up()
        {
            return await _client.GetData<string>("Input.Up",null);
        }

        public delegate void OnInputFinishedDelegate(string sender=null, object data=null);
        public event OnInputFinishedDelegate OnInputFinished;
        internal void RaiseOnInputFinished(string sender=null, object data=null)
        {
            if (OnInputFinished != null)
            {
                OnInputFinished.BeginInvoke(sender, data, null, null);
            }
        }

        public delegate void OnInputRequestedDelegate(string sender=null, XBMCRPC.Input.OnInputRequested_data data=null);
        public event OnInputRequestedDelegate OnInputRequested;
        internal void RaiseOnInputRequested(string sender=null, XBMCRPC.Input.OnInputRequested_data data=null)
        {
            if (OnInputRequested != null)
            {
                OnInputRequested.BeginInvoke(sender, data, null, null);
            }
        }
   }
}
