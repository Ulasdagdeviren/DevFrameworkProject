using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;

namespace DevFramework.Core.CrossCutingConcerns.Logging.Log4Net.Layouts
{
   public class JsonLayout:LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent=new Seriallzable(loggingEvent); // message ve username buraya geçer seriazable a geçer
            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented); // Json a geçirmemiz lazım yukarıdakini
            writer.WriteLine(json); // bunu burda TextWriter a yazıyoruz
            // özetle logeventini jsona çevirim textwriter a göndermek bizim amacımızdı yani writer veri tabanı 
            // oldğu zman veri tabanına ,console output olduğunda oraya ya da metin dosyası ise oraya yazdırıacak nesneyi içerir 
        }
    }
}
