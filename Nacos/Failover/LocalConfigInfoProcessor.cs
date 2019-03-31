using System.IO;
using Com.Alibaba.Nacos.Core;
using Com.Alibaba.Nacos.Util;

namespace Com.Alibaba.Nacos.Failover
{
    public class LocalConfigInfoProcessor : Processor
    {

        public static string GetFailover(string serverName, string dataId, string group, string tenant)
        {
            FileInfo failoverFile = GetFileoverFile(serverName, dataId, group, tenant);
            if (!failoverFile.Exists)
            {
                return null;
            }

            return FileUtil.Read(failoverFile.FullName);
        }

        public static FileInfo GetFileoverFile(string serverName, string dataId, string group, string tenant)
        {
            string failoverFile = NacosConfig.SnapshotPath + ds + serverName + "_nacos" + ds;
            if (!string.IsNullOrEmpty(tenant))
            {
                failoverFile = failoverFile + "config-data-tenant" + ds + tenant + ds;
            }
            else
            {
                failoverFile = failoverFile + "config-data" + ds;
            }
            return new FileInfo(failoverFile + dataId);
        }
        
        /**
         * 获取本地缓存文件内容。NULL表示没有本地文件或抛出异常。
         */
        public static string GetSnapshot(string name, string dataId, string group, string tenant)
        {
            FileInfo snapshotFile = GetSnapshotFile(name, dataId, group, tenant);
            if (!snapshotFile.Exists)
            {
                return null;
            }

            return FileUtil.Read(snapshotFile.FullName);
        }

        public static FileInfo GetSnapshotFile(string envName, string dataId, string group, string tenant)
        {
            string snapshotFile = NacosConfig.SnapshotPath + ds + envName + "_nacos" + ds;
            if (!string.IsNullOrEmpty(tenant))
            {
                snapshotFile = snapshotFile + "snapshot-tenant" + ds + tenant + ds;
            }
            else
            {
                snapshotFile = snapshotFile + "snapshot" + ds;
            }

            return new FileInfo(snapshotFile + dataId);
        }

        public static void SaveSnapshot(string envName, string dataId, string group, string tenant, string config)
        {
            FileInfo snapshotFile = GetSnapshotFile(envName, dataId, group, tenant);
            if (string.IsNullOrEmpty(config) )
            {
                if (snapshotFile.Exists)
                {
                    snapshotFile.Delete();
                }
            }
            else
            {
                if (snapshotFile.Directory != null && !snapshotFile.Directory.Exists)
                {
                    snapshotFile.Directory.Create();
                }
                FileUtil.Write(snapshotFile.FullName, config);
            }
        }
    }
}






















