using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Com.Alibaba.Nacos.Request.Config
{
    public class GetConfigRequest : ConfigRequest
    {
        protected new string Uri = "/nacos/v1/cs/configs";
        
        protected new Method Verb = Method.GET;
    }
}
