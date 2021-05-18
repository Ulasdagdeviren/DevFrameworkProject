using System;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAcsess.Abstract;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {   [ExpectedException(typeof(ValidationException))] //bu testten bir hata beklediğimiz için bunu yazdık
        [TestMethod]
        public void Product_Validator_Check()
        {
           // Mock<IProductDal> mock=new Mock<IProductDal>();
           //// ProductManager manager=new ProductManager(mock.Object); //test yazarken biriyle uğraşırken diğerini çağırmassın mesala manager ile test yaparken data ya gidemessin o yüzden moq kullanırız  mock.object yazarken de new efproduct yazılamaz çünkü aykırı olur
           // manager.Add(new Product());


        }
    }
}
