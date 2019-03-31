using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.Alibaba.Nacos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Alibaba.Nacos.Request.Config;
using Com.Alibaba.Nacos.Util;
using NacosTests;
using RestSharp;

namespace Com.Alibaba.Nacos.Core.Tests
{
    [TestClass()]
    public class PublishConfigRequestTests : TestCase
    {
        [TestMethod()]
        public void DoRequestTest()
        {
            PublishConfigRequest publishConfigRequest = new PublishConfigRequest();
            publishConfigRequest.DataId = "LARAVEL1";
            publishConfigRequest.Group = "DEFAULT_GROUP";
            publishConfigRequest.Tenant = "";
            publishConfigRequest.Content = FileUtil.Read("env-example");

            var response = publishConfigRequest.DoRequest();
            Assert.IsInstanceOfType(response, typeof(IRestResponse));
            Console.WriteLine(response.Content);
        }
    }
}