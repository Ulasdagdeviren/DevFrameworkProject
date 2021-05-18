using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAcsess.EntityFramework;
using DevFramework.Entities.ComlexTypes;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.DataAcsess.Abstract;

namespace DevFramework.Northwind.DataAcsess.Concrete.EntityFramework
{
   public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContex>,IProductDal  //Nhiberante veya başka ORM de bu IProductDalı imlemte edicek bu SOLİD in D harfine karşılık gelir
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthwindContex contex = new NorthwindContex())
            {
                var result = from p in contex.Products
                             join c in contex.Categories on p.CategoryId equals c.CategoryId
                             select new ProductDetail
                             {
                                 ProductId = p.ProdcutId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}
