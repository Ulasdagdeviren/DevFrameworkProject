using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevFramework.Entities.Concrete;

namespace DevFramework.Northwind.Business.Mappings.AutoMapper.Profiles
{
   public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, Product>(); // temel serileştirmeyi çözmek için biz bu mappingi yapıyoruz   bu olmazsa program 
                                            //serileştirme hatası verir
        }
    }
}
