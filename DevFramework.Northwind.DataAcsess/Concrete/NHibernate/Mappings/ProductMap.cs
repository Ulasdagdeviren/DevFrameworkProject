using DevFramework.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DevFramework.Northwind.DataAcsess.Concrete.NHibernate.Mappings
{
   public class ProductMap:ClassMap<Product> //classMap fluentNhibernate den geliyor biz dataacssese bunu ekledik
    {

        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();
            Id(x => x.ProdcutId).Column("ProductID");
            Map(x => x.CategoryId).Column("CategoryID");

            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice");

        }
    }
}
