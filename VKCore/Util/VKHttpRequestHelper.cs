using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using VKCore.API.Core;
using VKCore.API.SDK;
using HttpClient = Windows.Web.Http.HttpClient;

namespace VKCore.Util
{
    public class VKHttpResult
    {
        public bool IsSucceeded { get; set; }

        public string Data { get; set; }
    }

    public static class VKHttpRequestHelper
    {

        const int BUFFER_SIZE = 5000;

        class RequestState
        {
            // This class stores the State of the request.           
            public StringBuilder requestData;
            public List<byte> readBytes;
            public byte[] BufferRead;
            public HttpWebRequest request;
            public HttpWebResponse response;
            public Stream streamResponse;
            public Action<VKHttpResult> resultCallback;
            public DateTime startTime;
            public bool httpError;

            public RequestState()
            {
                BufferRead = new byte[BUFFER_SIZE];
                requestData = new StringBuilder("");
                readBytes = new List<byte>(1024);
                request = null;
                streamResponse = null;
                startTime = DateTime.Now;
            }
        }


        private static IVKLogger Logger
        {
            get { return VKSDK.Logger; }
        }

        public static async void DispatchHTTPRequest(
            string baseUri,
            Dictionary<string, string> parameters,
            Action<VKHttpResult> resultCallback)
        {
            try
            {
                Logger.Info(">>> VKHttpRequestHelper starting http request. baseUri = {0}; parameters = {1}", baseUri, GetAsLogString(parameters));

            }
            catch (Exception)
            {
                
              
            }
        
           

            try
            {
                var filter = new HttpBaseProtocolFilter();
                
                filter.AutomaticDecompression = true;

                var httpClient = new HttpClient(filter);
                
                HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(parameters);
                
                var result = await httpClient.PostAsync(new Uri(baseUri, UriKind.Absolute),
                    content);

                var resultStr = await result.Content.ReadAsStringAsync();

                SafeInvokeCallback(resultCallback, result.IsSuccessStatusCode, resultStr);



            }
            catch (Exception exc)
            {
                Logger.Error("VKHttpRequestHelper.DispatchHTTPRequest failed.", exc);
                SafeInvokeCallback(resultCallback, false, null);

            }
        }

     
       public static async void Upload(string uri, StorageFile data,  Action<VKHttpResult> resultCallback, Action<bool> progressCallback = null)
            {

                try
              {
                    progressCallback?.Invoke(true);
                    HttpMultipartContent form = new HttpMultipartContent();
                    var fileStream = await data.OpenReadAsync();
                    HttpStreamContent streamContent = new HttpStreamContent(fileStream.AsStreamForRead().AsInputStream());
                    form.Headers.ContentLength = fileStream.Size;
                    form.Add(streamContent);
                    byte[] fileBytes = await ReadFileToByteArray(data);
                    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                    MultipartContent content = new System.Net.Http.MultipartFormDataContent();
                    var file1 = new ByteArrayContent(fileBytes);
                    file1.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "file1",
                        FileName = data.Name,
                    };
                    content.Add(file1);
                    System.Net.Http.HttpResponseMessage response = await client.PostAsync(uri, content);

                    var raw_response = await response.Content.ReadAsByteArrayAsync();
                    var r2 = Encoding.UTF8.GetString(raw_response, 0, raw_response.Length);
                    if (r2[0] == '\uFEFF')
                    {
                        r2 = r2.Substring(1);
                    }
                    Logger.Info(r2);
                  progressCallback?.Invoke(false);
                  SafeInvokeCallback(resultCallback, response.IsSuccessStatusCode, r2);

                }
                catch (Exception exc)
                {
                    Logger.Error("VKHttpRequestHelper.Upload failed.", exc);

                    SafeInvokeCallback(resultCallback, false, null);


                }
            }
   
         
        public static async Task<byte[]> ReadFileToByteArray(StorageFile file)
        {
            byte[] fileBytes = null;
            using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
            {
                fileBytes = new byte[stream.Size];
                using (DataReader reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(fileBytes);
                }
            }

            return fileBytes;
        }

        private static void SafeInvokeCallback(Action<VKHttpResult> action, bool p, string stringContent)
        {          
            try
            {
                action(new VKHttpResult { IsSucceeded =  p, Data =  stringContent});
            }
            catch (Exception exc)
            {
                Logger.Error("VKHttpRequestHelper.SafeInvokeCallback failed.", exc);
            }
        }

        private static string ConvertDictionaryToQueryString(Dictionary<string, string> parameters, bool escapeString)
        {
            if (parameters == null || parameters.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var kvp in parameters)
            {
                if (kvp.Key == null ||
                    kvp.Value == null)
                {
                    continue;
                }

                if (sb.Length > 0)
                {
                    sb = sb.Append("&");
                }

                string valueStr = escapeString ? Uri.EscapeDataString(kvp.Value) : kvp.Value;

                sb = sb.AppendFormat(
                    "{0}={1}",
                    kvp.Key,
                    valueStr);
            }

            return sb.ToString();
        }

        private static string GetAsLogString(Dictionary<string, string> parameters)
        {
            string result = "";
            foreach (var kvp in parameters)
            {
                result += kvp.Key + " = " + kvp.Value + Environment.NewLine;
            }
            return result;
        }
    }
}
