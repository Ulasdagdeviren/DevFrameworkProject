using DevFramework.Core.DataAcsess;
using DevFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.ComlexTypes;

namespace DevFramework.Northwind.DataAcsess.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
