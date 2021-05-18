using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;

namespace DevFramework.Northwind.Business.ServiceContracts.Wcf
{
    [ServiceContract]
    public interface IProductDetailService //yalnızca istediklerimi göstermek için bunu yazdık gidip IProductService dokunmayalım
        {
            [OperationContract] // her bir methodun operasyon olduğunu söyledik
            List<Product> GetAll();
        }
}
