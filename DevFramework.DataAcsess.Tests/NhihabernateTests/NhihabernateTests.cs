using DevFramework.Northwind.DataAcsess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAcsess.Concrete.NHibernate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.DataAcsess.Tests.NhihabernateTests
{
    [TestClass]
    public class NhihabernateTests
    {
        [TestMethod]
        public void Get_all_returns_all_products() // GetAll u çağırdağımda bütün ürünler listelenmelidir
        {
            NHProductDal productDal=new NHProductDal(new SqlServerHelper());   //result=sonuç demektir
            var result = productDal.GetList();
            Assert.AreEqual(80,result.Count); //Select COUNT(*) From Products datanın new queysinde sorgu yaptık
            //ardınadan confi dossyasını kendimiz ekledik veri tabanına erişmek için
        }
        [TestMethod]
        public void Get_all_with_parameter_filtered_products() //filtreli ürünler
        {
            NHProductDal productDal = new NHProductDal(new SqlServerHelper());
            var result = productDal.GetList(p=>p.ProductName.Contains("ab"));// Select COUNT(*) From Products where ProductName like '%ab%'
            Assert.AreEqual(4, result.Count); 
            
        }
    }
}
