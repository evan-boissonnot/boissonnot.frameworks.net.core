using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Boissonnot.Framework.Core.Logging
{
    /// <summary>
    /// Provider pour fournir un logger
    /// </summary>
    public class Log4NetProvider : ILoggerProvider
    {
        #region Fields
        private readonly string _log4NetConfigFile;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers =
            new ConcurrentDictionary<string, Log4NetLogger>();
        #endregion

        #region Constructors
        public Log4NetProvider(string log4NetConfigFile)
        {
            this._log4NetConfigFile = log4NetConfigFile;
        }
        #endregion

        #region Public methods
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        public void Dispose()
        {
            this._loggers.Clear();
        }
        #endregion

        #region Internal methods
        private Log4NetLogger CreateLoggerImplementation(string name)
        {
            return new Log4NetLogger(name, Parselog4NetConfigFile(_log4NetConfigFile));
        }

        private static XmlElement Parselog4NetConfigFile(string filename)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(filename));
            return log4netConfig["log4net"];
        }
        #endregion
    }
}
