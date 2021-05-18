using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAcsess;
using DevFramework.Core.DataAcsess.EntityFramework;
using DevFramework.Core.DataAcsess.NHihabernate;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAcsess.Abstract;
using DevFramework.Northwind.DataAcsess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAcsess.Concrete.NHibernate;
using Ninject.Modules;

namespace DevFramework.Northwind.Business.DapendencyResolvels.Ninject
{
   public class BusinessModüle:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope(); //biri senden IProductService isterse ona ProductManager ver Insingletonscope ekleme sebebeimiz sürekli newleme olacağı için performans arrtışı amaçlı teke indiridilir
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope(); // InSingletonScope() neslerin tek bir defa üretilmesini sağlar
            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQeryableRepository<>)); //Managerde Queryable ın kim olduğu belli değil o yüzden yazdık
            Bind<DbContext>().To<NorthwindContex>(); // üstteki bize contex soruyor hangi contex ile çalışacağım derse diye yazdık

            Bind<NHihabernateHelper>().To<SqlServerHelper>();
        }
    }
}
