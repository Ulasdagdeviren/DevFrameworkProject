using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspect.PostSharp.PerformanceCounterAspect
{[Serializable]
   public class PerformanceCounterAspect:OnMethodBoundaryAspect
   { // amacım bir methodunu başlangıcından sonuna kadar ki süreyi tutmak istiyorum performans kaybı var mı diye
       private int _interval; // Arada geçen süren
       [NonSerialized]
       private Stopwatch _stopwatch;// Kronometre, StopWatch serileştirelemez

       public PerformanceCounterAspect(int interval=5)
       {
           _interval = interval;
       }

       public override void RuntimeInitialize(MethodBase method)
       {
           _stopwatch = Activator.CreateInstance<Stopwatch>();

       }

       public override void OnEntry(MethodExecutionArgs args) // methodun girişi
       {
           _stopwatch.Start();
           base.OnEntry(args);
       }

       public override void OnExit(MethodExecutionArgs args)
       {
           _stopwatch.Stop();
           if (_stopwatch.Elapsed.TotalSeconds>_interval) // elapsed geçen süre 
           {
               Debug.WriteLine("Performance: {0}.{1}->>{2}",args.Method.DeclaringType.FullName,args.Method.Name
               ,_stopwatch.Elapsed.TotalSeconds);
           }
           _stopwatch.Reset();
           base.OnExit(args);
       }
   }
}
