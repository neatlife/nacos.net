using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Com.Alibaba.Nacos.Util;

namespace Com.Alibaba.Nacos.Request.Config
{
    public class ConfigRequest : Request
    {
        /**
         * 租户信息，对应 Nacos 的命名空间字段。
         */
        public string Tenant {
            get;
            set;
        }

        /**
         * 配置 ID
         */
        public string DataId { get; set; }

        /**
         * 配置分组。
         */
        public string Group { get; set; }
        
        protected override ParameterAndHeader getParameterAndHeader()
        {
            ParameterAndHeader parameterAndHeader = new ParameterAndHeader
            {
                parameterList = new Dictionary<string, string>(), headers = new Dictionary<string, string>()
            };

            foreach (KeyValuePair<string, object> property in ReflectionUtil.getProperties(this))
            {
                var propertyName = CaseUtil.ToCamelCase(property.Key);
                var propertyValue = string.Format("{0}", property.Value);

                if (propertyName == "longPullingTimeout")
                {
                    parameterAndHeader.headers["Long-Pulling-Timeout"] = propertyValue;
                }
                else if (propertyName == "listeningConfigs")
                {
                    parameterAndHeader.parameterList["Listening-Configs"] = propertyValue;
                }
                else
                {
                    parameterAndHeader.parameterList[propertyName] = propertyValue;
                }
            }
            return parameterAndHeader;
        }
    }
}
