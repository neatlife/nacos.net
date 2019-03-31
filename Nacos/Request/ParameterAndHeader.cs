using System.Collections.Generic;

namespace Com.Alibaba.Nacos.Request
{
    public class ParameterAndHeader
    {
        public Dictionary<string, string> parameterList = new Dictionary<string, string>();
        
        public Dictionary<string, string> headers = new Dictionary<string, string>();
    }
}