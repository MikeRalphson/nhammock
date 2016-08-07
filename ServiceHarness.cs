using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace NHammock.Core
{
    public static class ServiceHarness
    {
        public static string Post<T>(string uri, T request)
        {
            return MakeRequest<T>(uri, "POST", request);
        }

        public static TResponse Post<TRequest, TResponse>(string uri, TRequest request)
        {
            return Post<TRequest, TResponse>(uri, request, null);
        }

        public static TResponse Post<TRequest, TResponse>(string uri, TRequest request, WebProxy proxy)
        {
            string raw = Post<TRequest>(uri, request);
            return Serializer.Deserialize<TResponse>(raw);
        }

        internal static string Get(string uri)
        {
            return Serializer.Serialize(MakeRequest(uri, "GET", (object)null));
        }

        internal static T Get<T>(string uri)
        {
            return Serializer.Deserialize<T>(MakeRequest(uri, "GET", (object)null));
        }

        public static TResponse Get<TRequest, TResponse>(string uri, TRequest request) where TRequest : IQueryStringSerializable
        {
            string completeUri = QueryStringConcat(uri, request.SerializeToQueryString());
            return Serializer.Deserialize<TResponse>(MakeRequest<TRequest>(completeUri, "GET", request));
        }

        private static string MakeRequest<T>(string uri, string method, T request)
        {
            return MakeRequest<T>(uri, method, request, null);
        }

        private static string MakeRequest<T>(string uri, string method, T request, WebProxy proxy)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.AllowAutoRedirect = true;
            webRequest.Method = method;

            if (!string.Equals("GET", method))
            {
                using (Stream s = webRequest.GetRequestStream())
                {
                    string requestBody = Serializer.Serialize(request);
                    byte[] requestBodyBytes = UTF8Encoding.UTF8.GetBytes(requestBody);
                    s.Write(requestBodyBytes, 0, requestBodyBytes.Length);
                }
            }

            if (proxy != null)
            {
                webRequest.Proxy = proxy;
            }

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        string text = sr.ReadToEnd();
                        Console.WriteLine(text);
                        return text;
                    }
                }
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        private static string QueryStringConcat(string uri, string queryString)
        {
            if (uri.IndexOf('?') > -1)
            {
                if (uri.EndsWith("&"))
                {
                    return string.Concat(uri, queryString);
                }
                else
                {
                    return string.Concat(uri, "&", queryString);
                }
            }
            else
            {
                return string.Concat(uri, "?", queryString);
            }
        }
    }
}
