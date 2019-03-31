using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Alibaba.Nacos.Core;
using Com.Alibaba.Nacos.Util;

namespace Com.Alibaba.Nacos.Failover
{
    public class Processor
    {
        protected static string ds = Path.DirectorySeparatorChar.ToString();
        
        /**
         * 清除snapshot目录下所有缓存文件。
         */
        public static void cleanAllSnapshot()
        {
            FileUtil.DeleteFiles(NacosConfig.SnapshotPath);
        }

        public static void cleanEnvSnapshot(string envName)
        {
            string envSnapshotPath = NacosConfig.SnapshotPath + ds + envName + "_nacos" + ds;
            FileUtil.DeleteFiles(envSnapshotPath);
        }
    }
}
