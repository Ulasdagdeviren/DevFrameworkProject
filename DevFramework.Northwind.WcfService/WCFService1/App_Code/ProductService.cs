using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DapendencyResolvels.Ninject;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService:IProductService // bizim yazığımız bir interface di güzel olan şey şu arayüzümü ister business da istediğim zamn servis den .ıkarabilirim
{
    public ProductService() // neden buraya IProductServici enjecte etmedik sebebi soap da parametreli ctor yoktur
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();// ProductManagerı newlemek yerine böle yazdık
    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public Product Add(Product product)
    {
        return _productService.Add(product);
    }

    public Product Update(Product product)
    {
        return _productService.Update(product);
    }

    public void TransactionalOperation(Product product, Product product2)
    { 
        _productService.TransactionalOperation(product, product2);
    }
}