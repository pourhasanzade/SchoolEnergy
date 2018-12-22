using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RobokaBimeBazar.Utility
{
    public static class Api
    {
        public static async Task<T> GetAsync<T>(string url, Dictionary<string, string> headers = null) where T : class
        {

            var apiResult = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpWebRequest.Headers.Add(header.Key, header.Value);
                }
            }

            using (var response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                apiResult = await reader.ReadToEndAsync();
            }

            return string.IsNullOrEmpty(apiResult) ? null : JsonConvert.DeserializeObject<T>(apiResult);
        }

        public static async Task<T> PostAsync<T>(string url, object body = null, Dictionary<string, string> headers = null) where T : class
        {

            var apiResult = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpWebRequest.Headers.Add(header.Key, header.Value);
                }
            }

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(body,
                    Newtonsoft.Json.Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                //var json = JsonConvert.SerializeObject(body);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }


            using (var response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                apiResult = await reader.ReadToEndAsync();
            }

            return string.IsNullOrEmpty(apiResult) ? null : JsonConvert.DeserializeObject<T>(apiResult);
        }

        public static async Task<T> PutAsync<T>(string url, object body = null, Dictionary<string, string> headers = null) where T : class
        {

            var apiResult = "";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpWebRequest.Headers.Add(header.Key, header.Value);
                }
            }

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                if (url.Contains("bime"))
                {
                    var json = JsonConvert.SerializeObject(body);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                else
                {
                    var json = JsonConvert.SerializeObject(body,
                        Newtonsoft.Json.Formatting.None,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }


            using (var response = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                apiResult = await reader.ReadToEndAsync();
            }

            return string.IsNullOrEmpty(apiResult) ? null : JsonConvert.DeserializeObject<T>(apiResult);
        }
    }
}
