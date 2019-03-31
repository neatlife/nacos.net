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
    public class ListenerConfigRequest : ConfigRequest
    {
        protected new string Uri = "/nacos/v1/cs/configs/listener";
        
        protected new Method Verb = Method.POST;

        /**
         * 监听数据报文。格式为 dataId^2Group^2contentMD5^2tenant^1或者dataId^2Group^2contentMD5^1。
         */
        private const string ListeningConfigsFormat = "{0}{1}{2}{3}{4}{5}{6}{7}";
        
        /**
         * 监听数据报文
         * @var
         */
        public string ListeningConfigs =>
            string.Format(
                ListeningConfigsFormat,
                DataId,
                EncodeUtil.TwoEncode,
                Group,
                EncodeUtil.TwoEncode,
                ContentMD5,
                EncodeUtil.TwoEncode,
                Tenant,
                EncodeUtil.OneEncode
            );

        /**
         * 配置内容 MD5 值
         */
        public string ContentMD5 { get; set; }

        /**
         * 长轮询等待时间, 默认30秒
         */
        public int LongPullingTimeout => NacosConfig.LongPullingTimeout;
    }
}
