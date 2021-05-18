using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject.Modules;

namespace DevFramework.Northwind.Business.DapendencyResolvels.Ninject
{
   public class AutoMapperModule:NinjectModule
    {
        public override void Load() // bütün o mappingleri create edicez
        {
            Bind<IMapper>().ToConstant(CreateConfiguration().CreateMapper()).InSingletonScope(); // IMapper dedik ki bunu bir sabite bağla yani CreateConfigiration ı IMapper bağlamış olduk
                                                                              // Ve sondada her enjecsiyonda tekrar tekrar çağırılmasın dedik  Insıngleton -Scope        
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config=new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(GetType().Assembly); // 500 tane configirasyon olurusa ayıramam bunu için gruplaştırıyoruz ve assembyl içindeki profile olan herşeyi ekle
            });
            return config;
        }
    }
}
