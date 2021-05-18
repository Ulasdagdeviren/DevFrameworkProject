using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCutingConcerns.Logging
{
   public class LogParameter
    {
        public string Name { get; set; } // method parametresinin name,type
        public string Type { get; set; } // Product mesele class olan
        public object Value { get; set; } //türünün ne olduğunu bilmediğimiz için object veririz yani güncellenmeye çalışan productun içinde ne var class olan değil
    }
}
