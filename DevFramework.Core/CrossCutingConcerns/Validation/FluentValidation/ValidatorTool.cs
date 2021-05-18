using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace DevFramework.Core.CrossCutingConcerns.Validation.FluentValidation
{
   public class ValidatorTool
   {
       // Buraya ProductValidator gelebilir ya da
       // CategoryValidator gelebilir ancak bunların 
       // Bunların herbiri aslında FluentValidation dan gelen
       // Ivalidator dır yani Ivalidator onları base dir.
       // ve neyi validate edicen bir nesneyi o yüzden object yazdık
        public static void FluentValidate(IValidator validator, object entity) 
       {
           var result = validator.Validate(entity);
           if (result.Errors.Count>0)
           {
               throw new ValidationException(result.Errors);
               
           }
       }

   }
}
