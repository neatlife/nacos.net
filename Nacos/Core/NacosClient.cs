using System;
using System.Threading;
using Com.Alibaba.Nacos.Failover;
using Com.Alibaba.Nacos.Request.Config;
using Com.Alibaba.Nacos.Util;

namespace Com.Alibaba.Nacos.Core
{
    public class NacosClient
    {
       public static string Get(string env, string dataId, string group, string tenant)
       {
            GetConfigRequest getConfigRequest = new GetConfigRequest();
            getConfigRequest.DataId = dataId;
            getConfigRequest.Group = group;
            getConfigRequest.Tenant = tenant;

            string config;
            
            try
            {
                var response = getConfigRequest.DoRequest();
                config = response.Content;
                LocalConfigInfoProcessor.SaveSnapshot(env, dataId, group, tenant, config);
            }
            catch (Exception e)
            {
                LogUtil.Error("获取配置异常，开始从本地获取配置, message: " + e.Message);
                config = LocalConfigInfoProcessor.GetFailover(env, dataId, group, tenant);
                config = string.IsNullOrEmpty(config) ? LocalConfigInfoProcessor.GetSnapshot(env, dataId, group, tenant) : config;
            }

            return config;
       }
       
       public static void Listener(string env, string dataId, string group, string config, string tenant = "")
       {
            int loop = 0;
            do
            {
                loop++;
                
                ListenerConfigRequest listenerConfigRequest = new ListenerConfigRequest();
                listenerConfigRequest.DataId = dataId;
                listenerConfigRequest.Group = group;
                listenerConfigRequest.Tenant = tenant;
                listenerConfigRequest.ContentMD5 = Md5Util.Md5(config);

                try
                {
                    var response = listenerConfigRequest.DoRequest();
                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        // 配置发生了变化
                        config = Get(env, dataId, group, tenant);
                        LogUtil.Info("found changed config: " + config);

                        // 保存最新的配置
                        LocalConfigInfoProcessor.SaveSnapshot(env, dataId, group, tenant, config);
                    }
                }
                catch (Exception e)
                {
                    LogUtil.Error("listener请求异常, e: " + e.Message);
                    // 短暂休息会儿
                    Thread.Sleep(500);
                }
                LogUtil.Info("listener loop count: " + loop);
            } while (true);
       }
       
       public static bool Publish(string dataId, string group, string content, string tenant = "")
       {
            PublishConfigRequest publishConfigRequest = new PublishConfigRequest();
            publishConfigRequest.DataId = dataId;
            publishConfigRequest.Group = group;
            publishConfigRequest.Tenant = tenant;
            publishConfigRequest.Content = content;

            var response = publishConfigRequest.DoRequest();
            return "ok".Equals(response.Content);
       }

       public static bool Delete(string dataId, string group, string tenant)
       {
            DeleteConfigRequest deleteConfigRequest = new DeleteConfigRequest();
            deleteConfigRequest.DataId = dataId;
            deleteConfigRequest.Group = group;
            deleteConfigRequest.Tenant = tenant;

            var response = deleteConfigRequest.DoRequest();
            return "ok".Equals(response.Content);
       }
    }
}


























