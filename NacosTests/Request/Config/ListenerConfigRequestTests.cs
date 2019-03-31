using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Com.Alibaba.Nacos.Request.Config;
using NacosTests;
using RestSharp;

namespace Com.Alibaba.Nacos.Core.Tests
{
    [TestClass()]
    public class ListenerConfigRequestTests : TestCase
    {
        [TestMethod()]
        public void DoRequestTest()
        {
            ListenerConfigRequest listenerConfigRequest = new ListenerConfigRequest();
            listenerConfigRequest.DataId = "LARAVEL";
            listenerConfigRequest.Group = "DEFAULT_GROUP";
            listenerConfigRequest.Tenant = "";
            listenerConfigRequest.ContentMD5 = "ddf41f9b16c588e0f6a185f4c82bf61d";

            var response = listenerConfigRequest.DoRequest();
            Assert.IsInstanceOfType(response, typeof(IRestResponse));
            Console.WriteLine(response.Content);
        }
    }
}