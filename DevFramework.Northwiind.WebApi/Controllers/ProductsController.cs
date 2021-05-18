using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.Business.Abstract;

namespace DevFramework.Northwiind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        // api dışında bir kod yazamamalıyız
        // yükleridiğimiz paketler = 1-Webapicontrib.IOC.ninject 2-ninject.mvc5 en sondakini global asax gibi düşün
        private IProductService _service;

        public ProductsController(IProductService service) // bizden productservice istiyor vermediğimiz için hata verir
        {
            _service = service;
        }

        public List<Product> Get()
        {
            return _service.GetAll();
        }
    }
}
