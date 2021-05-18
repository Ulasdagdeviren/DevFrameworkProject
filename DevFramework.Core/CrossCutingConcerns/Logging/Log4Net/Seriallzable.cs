using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCutingConcerns.Logging.Log4Net
{
    [Serializable]
    public class Seriallzable // log formatına bir nesnenin dönüştürülebilmesi için yazdık
    {
        private LoggingEvent _loggingEvent; // log datasının kendisini barındırır

        public Seriallzable(LoggingEvent loggingEvent) 
        {
            _loggingEvent = loggingEvent;
        }
        public string UserName => _loggingEvent.UserName; // log işlemine sebek olana kişi kimdir bilgisi tut
        public object MessageObject => _loggingEvent.MessageObject;
        //hangi method hangi objelerle çalıştı
    }
}
