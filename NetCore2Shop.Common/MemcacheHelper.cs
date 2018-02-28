using System;
using System.Collections.Generic;
using System.Text;
using Memcached.ClientLibrary;

namespace NetCore2Shop.Common
{
    public class MemcacheHelper
    {
        private static readonly MemcachedClient mc = null;

        static MemcacheHelper()
        {
            string[] serverList = {"127.0.0.1:11211"};//要将地址写到配置文件中。
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverList);
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();

            //获取客户端实例
            mc = new MemcachedClient();
            mc.EnableCompression = false;
        }

        /// <summary>
        /// 向Memcache中添加数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time">过期时间</param>
        public static void Set(string key, object value, DateTime time)
        {
            mc.Set(key, value, time);
        }

        /// <summary>
        /// 获取Memcache中的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return mc.Get(key);
        }

        /// <summary>
        /// 删除Memcache中的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Delete(string key)
        {
            if (mc.KeyExists(key))
            {
                return mc.Delete(key);
            }
            return false;
        }
    }
}
