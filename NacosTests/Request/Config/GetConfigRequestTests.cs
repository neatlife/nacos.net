using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.Alibaba.Nacos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Alibaba.Nacos.Request.Config;
using NacosTests;
using RestSharp;

namespace Com.Alibaba.Nacos.Core.Tests
{
    [TestClass()]
    public class GetConfigRequestTests : TestCase
    {
        [TestMethod()]
        public void DoRequestTest()
        {
            GetConfigRequest getConfigRequest = new GetConfigRequest();
            getConfigRequest.DataId = "LARAVEL";
            getConfigRequest.Group = "DEFAULT_GROUP";
            getConfigRequest.Tenant = "";

            var response = getConfigRequest.DoRequest();
            Assert.IsInstanceOfType(response, typeof(IRestResponse));
            Console.WriteLine(response.Content);
        }
    }
}