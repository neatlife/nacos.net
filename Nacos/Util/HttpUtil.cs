using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Com.Alibaba.Nacos.Core;
using RestSharp;

namespace Com.Alibaba.Nacos.Util
{
    public class HttpUtil
    {
        public static IRestResponse request(string uri, Method method, Dictionary<string, string> body)
        {
            return request(uri, method, body, new Dictionary<string, string>());
        }

        public static IRestResponse request(string uri, Method method, Dictionary<string, string> body, Dictionary<string, string> headers)
        {
           try
            {
                var client = GetClient();
                
                var request = new RestRequest(uri, method);

                if (method.Equals(Method.GET))
                {
                    foreach (var entry in body)
                    {
                        request.AddQueryParameter(entry.Key, entry.Value);
                    }
                }
                else
                {
                    request.AddHeader("content-type", "application/x-www-form-urlencoded");
                    foreach (var entry in body)
                    {
                        request.AddParameter(entry.Key, entry.Value, ParameterType.GetOrPost);
                    }
                }

                foreach (var entry in headers)
                {
                    request.AddHeader(entry.Key, entry.Value);
                }

                return client.Execute(request);
            }
            catch (Exception ex)
            {
                throw new HttpRequestFailedException(ex.HResult, "http请求异常");
            }
        }

        private static RestClient GetClient()
        {
            var client = new RestClient(NacosConfig.Host);
            return client;
        }
    }

    public class HttpRequestFailedException : Exception
    {
        public HttpRequestFailedException(int code, string message) : base(message)
        {
            HResult = code;
        }
    }
}
