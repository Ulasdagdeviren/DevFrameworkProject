using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DevFramework.Northwind.Business.DapendencyResolvels.Ninject
{
   public class InstanceFactory
    {
        public static T GetInstance<T>()// biz MessageHandler kısmında ctor injection yapmımız sıkıntı olduğu için INstance ureticez
        {
            var kernel= new StandardKernel(new BusinessModüle(),new AutoMapperModule());// biz bunu tamamen business Modüle ile yapıyoruz
            return kernel.Get<T>(); // bu da baan T türünde kernelden sana gönderdiğim T için bana bir nesne üret
        }
    }
}
