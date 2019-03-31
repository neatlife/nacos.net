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
    public class DeleteConfigRequestTests : TestCase
    {
        [TestMethod()]
        public void DoRequestTest()
        {
            DeleteConfigRequest deleteConfigRequest = new DeleteConfigRequest();
            deleteConfigRequest.DataId = "LARAVEL1";
            deleteConfigRequest.Group = "DEFAULT_GROUP";
            deleteConfigRequest.Tenant = "";

            var response = deleteConfigRequest.DoRequest();
            Assert.IsInstanceOfType(response, typeof(IRestResponse));
            Console.WriteLine("content: " + response.Content);
            Assert.IsNotNull(response.Content);
        }
    }
}