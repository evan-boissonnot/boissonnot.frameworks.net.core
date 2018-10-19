using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boissonnot.Framework.Core.Logging
{
    /// <summary>
    /// Extension pour le program de démarrage
    /// </summary>
    public static class Log4netExtensions
    {
        #region Public methods
        /// <summary>
        /// Ajoute le logger pour log4net
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="log4NetConfigFile"></param>
        /// <returns></returns>
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile)
        {
            factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
            return factory;
        }

        /// <summary>
        /// Ajoute le logger pour log4net
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory)
        {
            factory.AddProvider(new Log4NetProvider("log4net.config"));
            return factory;
        }
        #endregion
    }
}
