using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.Business.ValidationRules_iş_süreçleri_için_doğrulama_kuralları_.FluentValidation_araç_;
using FluentValidation;
using Ninject.Modules;

namespace DevFramework.Northwind.Business.DapendencyResolvels.Ninject
{
   public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
