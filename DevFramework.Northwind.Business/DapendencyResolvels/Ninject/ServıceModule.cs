using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Utilities.Common;
using DevFramework.Northwind.Business.Abstract;
using Ninject.Modules;

namespace DevFramework.Northwind.Business.DapendencyResolvels.Ninject
{
   public class ServıceModule:NinjectModule // bundaki sebep biz Ninject IProductService istediğimizde bize ProductService ver demiştik 
    {                         // O yüzden WCF de IĞroduct service i takan yoktu burda onu belirticez
        public override void Load()
        {
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChanel()); // bir method çağırımı yapıcağız
        }
    }
}
