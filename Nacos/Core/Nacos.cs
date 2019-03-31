namespace Com.Alibaba.Nacos.Core
{
    public class Nacos
    {

        private static Nacos client;
        
        public static Nacos init()
        {
            if (client == null)
            {
                client = new Nacos();
            }

            return client;
        }
        
        public string runOnce()
        {
            return NacosClient.Get(NacosConfig.Env, NacosConfig.DataId, NacosConfig.Group, NacosConfig.Tenant);
        }

        public void listener()
        {
            NacosClient.Listener(NacosConfig.Env, NacosConfig.DataId, NacosConfig.Group, NacosConfig.Tenant);
        }
        
    }
}