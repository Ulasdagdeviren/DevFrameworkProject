using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace DevFramework.Core.CrossCutingConcerns.Logging.Log4Net.Loggers
{
   public class DatabaseLogger:LoggerService
    {
        public DatabaseLogger() : base(LogManager.GetLogger("DatabaseLogger")) // logger bilgisini configrasyon dosyasına yazacağım databaselogger isimli loggerdan al 
        {
        }
    }
}
