using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Com.Alibaba.Nacos.Core
{
    public class NacosConfig
    {
        /**
         * 项目名
         */
        public static string Name => "nacos-client";
        
        /**
         * 环境
         */
        public static string Env => GetAppSetting("Nacos.Env");
        
        /**
         * nacos服务器地址
         */
        public static string Host => GetAppSetting("Nacos.Host");

        /**
         * 配置 ID
         */
        public static string DataId => GetAppSetting("Nacos.DataId");

        /**
         * 配置分组。
         */
        public static string Group => GetAppSetting("Nacos.Group");

        /**
         * 租户信息，对应 Nacos 的命名空间字段。
         */
        public static string Tenant => GetAppSetting("Nacos.Tenant");
        
        /**
         * 是否调试模式
         *
         * @var
         */
        public static bool IsDebug { get; set; } = false;

        /**
         * 长轮询等待时间, 默认30秒
         */
        public static int LongPullingTimeout => int.Parse(GetAppSetting("Nacos.LongPullingTimeout", "30000"));

        /**
         * 快照文件存放目录
         */
        public static string SnapshotPath { get; set; } = "nacos/config";

        public static string GetAppSetting(string key)
        {
            string defaultValue = "";
            return GetAppSetting(key, defaultValue);
        }
        
        public static string GetAppSetting(string key, string defaultValue)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            return defaultValue;
        }
    }
}
