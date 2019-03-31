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
    public class EncodeUtilTests
    {
        [TestMethod()]
        public void encode()
        {
            Assert.IsNotNull(EncodeUtil.OneEncode);
            Assert.IsNotNull(EncodeUtil.TwoEncode); ;
        }
    }
}