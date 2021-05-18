using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAcsess.NHihabernate;
using DevFramework.Entities.ComlexTypes;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.DataAcsess.Abstract;
using DevFramework.Northwind.DataAcsess.Concrete.EntityFramework;

namespace DevFramework.Northwind.DataAcsess.Concrete.NHibernate
{
   public class NHProductDal:NhEntityRepositoryBase<Product>,IProductDal  //Entityframework de complex tipde böyle çalışılır 
    {
       private NHihabernateHelper _nHihabernateHelper;
        public NHProductDal(NHihabernateHelper helper) : base(helper)// base yani NHEntityrepositorybase e helper ı göndermiş olduk  ve helper set olacak
        {
            _nHihabernateHelper = helper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nHihabernateHelper.OpenSession()) 
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
                             select new ProductDetail
                             {
                                 ProductId = p.ProdcutId,
                                 CategoryName = c.CategoryName,
                                 ProductName = p.ProductName
                             };
                return result.ToList();
            }
            
        }
    }
}
