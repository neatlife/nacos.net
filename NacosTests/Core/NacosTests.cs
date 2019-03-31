using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.Alibaba.Nacos.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Alibaba.Nacos.Failover;
using NacosTests;

namespace Com.Alibaba.Nacos.Core.Tests
{
    [TestClass()]
    public class NacosTests : TestCase
    {
        [TestMethod()]
        public void RunOnceTest()
        {
            string config = Nacos.init().runOnce();
            Assert.IsTrue(!string.IsNullOrEmpty(config));
            Assert.IsTrue(LocalConfigInfoProcessor.GetSnapshotFile(NacosConfig.Env, NacosConfig.DataId, NacosConfig.Group, NacosConfig.Tenant).Exists);
        }
        
        [TestMethod()]
        public void ListenerTest()
        {
            Nacos.init().listener();
        }
    }
}