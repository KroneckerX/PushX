using PushX.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PushX.Servers
{
    /*
    *   PUSH MESSAGE SERVER     -     PushX
    *
    *  - Create instance:
    *  - Set API key
    *  - Set settings
    *  - Send message
    *
    */

    public class GCMPushServer : Server
    {
        internal static IWebProxy nullProxy = null;
        internal PushServerSettings _settings = null;
        internal string _apiKey = null;
        internal bool isActive = true;

        /// <summary>
        /// Event that fires on successful sending
        /// </summary>
        public event PushServerEventHandler onSuccess = null;

        /// <summary>
        /// Event that fires when sending interrupts
        /// </summary>
        public event PushServerErrorEventHandler onError = null;

        /// <summary>
        /// Gets and sets server status
        /// </summary>
        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }

        internal GCMPushServer()
        {

        }

        /// <summary>
        /// Send message to GCM server
        /// </summary>
        /// <param name="message">represents message</param>
        /// <returns></returns>
        public string Send(IGCM message)
        {
            return _send(message);
        }

        /// <summary>
        /// Send message to GCM server asynchronously
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<string> SendAsync(IGCM message)
        {

            string data = message.ToJson();


            return await _sendAsync(message);
        }

        private string _send(IGCM message)
        {
            try
            {
                string data = message.ToJson();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_settings.Server);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add(string.Format("Authorization:key={0}", _apiKey));
                request.Proxy = nullProxy;

                var requestStream = request.GetRequestStream();
                using (var swriter = new StreamWriter(requestStream))
                {
                    swriter.Write(data);
                    swriter.Flush();
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();

                string responseStr = null;

                using (var sreader = new StreamReader(responseStream))
                {
                    responseStr = sreader.ReadToEnd();
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    OnSuccess(message, responseStr);
                }
                else
                {
                    Exception ex = new Exception(responseStr);
                    throw ex;
                }

                return responseStr;
            }
            catch (Exception ex)
            {
                OnError(message, ex);
                return null;
            }
        }

        private async Task<string> _sendAsync(IGCM message)
        {
            try
            {
                string data = message.ToJson();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_settings.Server);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add(string.Format("Authorization:key={0}", _apiKey));
                request.Proxy = nullProxy;

                var requestStream = request.GetRequestStream();
                using (var swriter = new StreamWriter(requestStream))
                {
                    swriter.Write(data);
                    swriter.Flush();
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();

                string responseStr = null;

                using (var sreader = new StreamReader(responseStream))
                {
                    responseStr = sreader.ReadToEnd();
                }

                OnSuccess(message, responseStr);

                return responseStr;
            }
            catch (Exception ex)
            {
                OnError(message, ex);
                return null;
            }
        }

        protected void OnSuccess(IGCM message, string response)
        {
            if (onSuccess != null)
            {
                onSuccess(_Key, new PushServerEventArgs() { SendingData = message, Response = response});
            }
        }

        protected void OnError(IGCM message, Exception ex)
        {
            if (onError != null)
            {
                onError(_Key, new PushServerErrorEventArgs() { SendingData = message, Exception = ex });
            }
        }

        /// <summary>
        /// Set server settings
        /// </summary>
        public void SetSettings(PushServerSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Set api key specified to server
        /// </summary>
        /// <param name="apiKey"></param>
        public void SetApiKey(string apiKey)
        {
            _apiKey = apiKey;
        }
    }
}
