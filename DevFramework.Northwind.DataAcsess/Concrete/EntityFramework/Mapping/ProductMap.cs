using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;

namespace DevFramework.Northwind.DataAcsess.Concrete.EntityFramework.Mapping
{
   public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(x => x.ProdcutId);
            Property(x => x.ProdcutId).HasColumnName("ProductId"); //kolonları bağlama aynı xml de olan ok işaretleri gibi
            Property(x => x.CategoryId).HasColumnName("CategoryId");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");
        }
    }
}
