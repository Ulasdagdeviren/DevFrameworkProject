using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DapendencyResolvels.Ninject;
using DevFramework.Northwind.Business.ServiceContracts.Wcf;

/// <summary>
/// Summary description for ProductDetailService
/// </summary>
public class ProductDetailService:IProductDetailService
{
    private IProductService _productService = InstanceFactory.GetInstance<IProductService>(); // parametreli ctor yazamadığımız için böyle yaptık
    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }
}