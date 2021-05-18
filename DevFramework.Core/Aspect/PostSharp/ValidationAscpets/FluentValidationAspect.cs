using System;
using System.Linq;
using DevFramework.Core.CrossCutingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspect.PostSharp.ValidationAscpets
{
    [Serializable]
   public class FluentValidationAspect:OnMethodBoundaryAspect
    {
        Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args) //on entry methoda girdiğinde diğer ovverride larda method hata verdiği zaman vs şeklinde ovverride edebilirsin
        {
            var Validator =(IValidator) Activator.CreateInstance(_validatorType); // Bir örnek oluştur 
            var entitiytype = _validatorType.BaseType.GetGenericArguments()[0]; // burda base type FluentValidation (iş katmanındaki) İnherit aldığı Abstract tır böylece ordan Product a erişir  _validator örnek (product) genericargument bir Array döndürür
            var entities = args.Arguments.Where(t =>t.GetType() == entitiytype); // args çalıştırılan methodla ilgili bilgi almamızı sağlar ve burada yazdığımız tipi Product olanları yakalamak
            foreach (var entity in entities)                                                    // Vae GetType yani tüm parametrelerinin argümanlarını gez
            {
                ValidatorTool.FluentValidate(Validator,entity); //biz static yaptığımız için validatortooldan sonra Fluntvalidate methodu geldi çünkü callasın bir methodo yaptık
            }

        }

        

        
    }
}
