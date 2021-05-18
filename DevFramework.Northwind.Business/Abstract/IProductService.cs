using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;

namespace DevFramework.Northwind.Business.Abstract
{
    [ServiceContract]
   public interface IProductService  //WCF üzerinden den de servis edebilecek bir sistem de yapmış olduk
   {
       // bunu WCF de kullanabilmemiz için çeşitli çözümlemeler yapmamız gerekiyor
       [OperationContract] // her bir methodun operasyon olduğunu söyledik
       List<Product> GetAll();

       [OperationContract]
        Product GetById(int id);

        [OperationContract]
        Product Add(Product product);

        [OperationContract]
        Product Update(Product product);

        [OperationContract]
        void TransactionalOperation(Product product,Product product2);// bunu birine para havale edeceğimizde hata oldursa parayı geri verme gibi düşünülebilir
                                                                    
   }
}
