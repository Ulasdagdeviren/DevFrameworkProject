using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCutingConcerns.Logging.Log4Net
{[Serializable]
   public class LoggerService //çalışma ortamında debug loglar vs burdan yöneticez ve diğeri farklı ortamlarda farklı loglama tekniklerini kullanabiliriz
    {                       // Biz logları json formatında tutarız 
        private ILog _log;

        public LoggerService(ILog log)
        {
            _log = log;
        }
     public bool IsInfoEnabled => _log.IsInfoEnabled; //loglama ortamında bilgi seviyesindeki loglar açık mı

        public bool IsDebugEnabled => _log.IsDebugEnabled; //bir kişi şu methodu şu saatte şu parametrelerle çağırdı
        public bool IsWarnedEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsFatalEnabled;

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(logMessage); // logladık messajı al ilgili yere işle
            }
        }

        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logMessage);
            }
            
        }
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(logMessage); // logladık messajı al ilgili yere işle
            }
        }
        public void Warn(object logMessage)
        {
            if (IsWarnedEnabled)
            {
                _log.Warn(logMessage); // logladık messajı al ilgili yere işle
            }
        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(logMessage); // logladık messajı al ilgili yere işle
            }
        }
    }
}
