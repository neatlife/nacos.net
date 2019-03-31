using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.Alibaba.Nacos.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Com.Alibaba.Nacos.Util.Tests
{
    [TestClass()]
    public class HttpUtilTests
    {
        [TestMethod()]
        public void requestTest()
        {
            Dictionary<string, string> body = new Dictionary<string, string>();
            body.Add("dataId", "LARAVEL");
            body.Add("group", "DEFAULT_GROUP");
            IRestResponse response = HttpUtil.request("/nacos/v1/cs/configs", Method.GET, body);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
            Console.WriteLine("statusCode: " + (int) response.StatusCode);
            Assert.IsInstanceOfType(response.Content, typeof(string));
        }
    }
}