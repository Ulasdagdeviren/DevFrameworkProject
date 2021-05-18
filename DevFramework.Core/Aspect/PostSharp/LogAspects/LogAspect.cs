using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCutingConcerns.Logging;
using DevFramework.Core.CrossCutingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace DevFramework.Core.Aspect.PostSharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method,TargetMemberAttributes = MulticastAttributes.Instance)] // kullancağımız aspecti productmanager da en tepeye yazıp tüm methodları ctor vs etkilenmesini istiyorsak bnu yazarız
                                // nesne örneklerinin metodlarına uygula ctor a uygulama
    public class LogAspect:OnMethodBoundaryAspect
    {
      
        private Type _loggerType;
        private LoggerService _loggerService;  // gelebilecek şetlerin türü çok fazlaysa nesnel çalışılır 

        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method) // bir instance üretmek için bundan yararlanırız yani method log aspecti görünce ınstance üret
        {
            if (_loggerType.BaseType!=typeof(LoggerService)) // prduct managerde log aspectin yanındaki typeof içi database logger ya da flie logger dışında ise hata ver
            {
                throw new Exception("Wrong logger type");
            }

            _loggerService = (LoggerService) Activator.CreateInstance(_loggerType); 
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args) // kim, ne zaman,hangi methodu çağırdı demek için onentry kullanılır
        {                                                       // üstteki logları info şeklinde tutmak istediğimizde

            if (!_loggerService.IsInfoEnabled) // isinfoenabled durumda değilse loglama yapma
            {
                return;
            }

            try
            {
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name, // mesele burda şehirse
                    Type = t.ParameterType.Name, // tipi strig gibi düşün
                    Value = args.Arguments.GetArgument(i) // i burda iterator 0.erguman 1.erguman
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters
                };
                _loggerService.Info(logDetail);
            }
            catch (Exception )
            {
               
            }
           
        }
    }
}
