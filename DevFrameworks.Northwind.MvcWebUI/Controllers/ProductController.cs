using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.Business.Abstract;
using DevFrameworks.Northwind.MvcWebUI.Models;

namespace DevFrameworks.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        // SOLİD in D harfi burda prdouctmanagerı newletmiyor o yüzden field kullanılır
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products=_service.GetAll()
            };
            return View(model);  // Burda view a bir model göneriğ ürünleri listelememiz gerekiyor
        }

        public string Added()
        {
            _service.Add(new Product
            {
                CategoryId = 1, ProductName = "Gsm", QuantityPerUnit = "1", UnitPrice = 21
            });
            return "Added";
        }

        public string AddUpdate()
        {
            _service.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "Computer",
                QuantityPerUnit = "1",
                UnitPrice = 2
            }, new Product
            {
                CategoryId = 1,
                ProductName = "Computer",
                QuantityPerUnit = "1",
                UnitPrice = 30,  // burası eğer 10 ise validation dan geçemeyecek kural yazmıştık çünkü veri tabanına birşey yazılmaz herşey aynı kalır
                ProdcutId = 2
            });
            return "Done"; // sonuç oalrak heç güncelleme hem ekleme yaıcak 2 numaralı ürün güncellenecek sona üstteki eklenecek Products table na
        }
    }
}