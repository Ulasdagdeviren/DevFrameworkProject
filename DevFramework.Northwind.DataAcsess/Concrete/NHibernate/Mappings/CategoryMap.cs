using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace DevFramework.Northwind.DataAcsess.Concrete.NHibernate.Mappings
{
  public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryID");
            Map(x => x.CategoryName).Column("CategoryName");
        }
    }
}
