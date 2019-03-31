using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.Alibaba.Nacos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NacosTests;

namespace Com.Alibaba.Nacos.Core.Tests
{
    [TestClass()]
    public class NacosConfigTests : TestCase
    {
        private static string host = "http://127.0.0.1:8848";
        private static string env ="dev";
        private static string dataId ="LARAVEL";
        private static string group ="DEFAULT_GROUP";
        private static string tenant = "";

        [TestMethod()]
        public void GetAppSettingTest()
        {
            Assert.AreEqual(host, NacosConfig.Host);
            Assert.AreEqual(env, NacosConfig.Env);
            Assert.AreEqual(dataId, NacosConfig.DataId);
            Assert.AreEqual(group, NacosConfig.Group);
            Assert.AreEqual(tenant, NacosConfig.Tenant);
        }
    }
}