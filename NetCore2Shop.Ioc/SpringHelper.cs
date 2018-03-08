using System;
using System.Collections.Generic;
using System.Text;
using Spring.Context;
using Spring.Context.Support;

namespace NetCore2Shop.Ioc
{
    public class SpringHelper
    {
        #region Spring容器上下文 + IApplicationContext SpringContext
        /// <summary>
        /// Spring容器上下文
        /// </summary>
        private static IApplicationContext SpringContext => ContextRegistry.GetContext();
        #endregion

        #region 获取配置文件配置的对象 + T GetObject<T>(string objName) where T : clasee
        /// <summary>
        /// 获取配置文件配置的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objName"></param>
        /// <returns></returns>
        public static T GetObject<T>(string objName) where T : class => (T)SpringContext.GetObject(objName); 
        #endregion
    }
}
