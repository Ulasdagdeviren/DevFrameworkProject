using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;

namespace DevFramework.Core.Utilities.Mvc.infrastructure
{
   public class NinjectControllerFactory:DefaultControllerFactory
   {
       private IKernel _kernal;

       public NinjectControllerFactory(params INinjectModule[] modules) // globalasaxa tek bir modül gönermiyecez
       {
           _kernal = new StandardKernel(modules); // params olduğu için izstediğimiz modülü ekleyebiliriz
       }

       // siz conttreler ı balattığınızda adresten aalan aruting vs aconttreller ı bulup onu newleyen budur
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)// controller işlemini yapan kod bundan ibaret
        {
            return controllerType==null?null:(IController)_kernal.Get(controllerType); // controlellertype null mı değilse onu IControllera çevir örnek olarak productconttreler
            // system.Web çözümlernir
        }
    }
}
