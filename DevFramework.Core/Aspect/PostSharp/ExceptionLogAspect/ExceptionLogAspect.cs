using System;
using System.Reflection;
using DevFramework.Core.CrossCutingConcerns.Logging.Log4Net;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspect.PostSharp.ExceptionLogAspect
{[Serializable]
   public class ExceptionLogAspect:OnExceptionAspect
   {
       [NonSerialized]
       private LoggerService _loggerService;

       private readonly Type _logType;

       public ExceptionLogAspect(Type logType=null)
       {
           _logType = logType;
       }

       public override void RuntimeInitialize(MethodBase method)
       {
           if (_logType!=null)
           {
               if (_logType.BaseType!=typeof(LoggerService))
               {
                   throw new Exception("Wrong logger type");
               }

               _loggerService = (LoggerService) Activator.CreateInstance(_logType);
           }
           base.RuntimeInitialize(method);
       }

       public override void OnException(MethodExecutionArgs args)
       {
           if (_loggerService!=null)
           {
               _loggerService.Error(args.Exception);
           }
       }
   }
}
