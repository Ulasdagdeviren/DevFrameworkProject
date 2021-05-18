using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCutingConcerns.Logging
{
   public class LogDetail
    {
        public string FullName { get; set; } // namespace i barındıran sınıfa karşılık gelcek
        public string MethodName { get; set; }//class daki hangi method
        public List<LogParameter> Parameters { get; set; } //o methodun birden fazla parametresi olabilir
    }
}
