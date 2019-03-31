using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Alibaba.Nacos.Core;
using Com.Alibaba.Nacos.Util;
using RestSharp;

namespace Com.Alibaba.Nacos.Request.Config
{
    public class PublishConfigRequest : ConfigRequest
    {
        protected new string Uri = "/nacos/v1/cs/configs";
        
        protected new Method Verb = Method.POST;

        public string Content { get; set; }
    }
}
