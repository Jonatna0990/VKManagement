using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using LastFmLib.Extension;
using Newtonsoft.Json.Linq;

namespace LastFmLib.Core
{
    internal class CoreRequest
    {
        private readonly Uri _uri;
        private readonly string _method;
        private readonly Dictionary<string, string> _parameters;
        private readonly Dictionary<string, string> _postParameters;

        public CoreRequest(Uri uri)
        {
            _uri = uri;
            _method = "GET";
        }

        public CoreRequest(Uri uri, Dictionary<string, string> parameters, string method = "GET", Dictionary<string, string> postParameters = null)
        {
            _uri = uri;
            _method = method;
            _parameters = parameters;
            _postParameters = postParameters;
        }

        public async Task<JObject> Execute()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            bool internet = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;

           

            var uri = GetFullUri(_parameters);
            var request = WebRequest.CreateHttp(uri);
            request.Method = _method;

            Debug.WriteLine("Invoking " + uri);

            JObject response = null;

            var httpClient = new HttpClient();

           
                HttpResponseMessage responseMessage = await httpClient.GetAsync(uri);
                string content = await responseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                    response = JObject.Parse(content);
            
            return response;
        }

        private Uri GetFullUri(Dictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                var paramStr = string.Join("&",
                                           parameters.Select(
                                               kp => string.Format("{0}={1}", Uri.EscapeDataString(kp.Key), Uri.EscapeDataString(kp.Value))));

                return new Uri(string.Concat(_uri, "&", paramStr));
            }

            return _uri;
        }
    }
}
