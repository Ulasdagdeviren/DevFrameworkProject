using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Common
{
    public class WcfProxy<T> // biz bunu generic yaptık çünkü IProduct Service ICategoryService vs için kullanabilirim 
    {
        // http://localhost:50015/{0}.svc // amacımız T ne ise o yerine onu yaz CategoryService vs
        // IProductService olarak gelir biz o yüzden Substring diyeren I attık ProductService olarak kaldı
        public static T CreateChanel()
        {
            // Bir clientin Service sine ulaşmak için Servisin ABC ni ulaşmamız lazım
            string baseAddress = ConfigurationManager.AppSettings["ServiceAddress"]; // web config den okuyacağız
            string address = string.Format(baseAddress, typeof(T).Name.Substring(1));// amacımız htt://localhost:50015/ProductService.svc dosyasındaki Product Service yazan kısmı sürekli değiştirmek

            var binding =new BasicHttpBinding();
            var channel =new ChannelFactory<T>(binding,address); // T contract alıyoruz böylece Channel üretiliyor

            return channel.CreateChannel(); // Bu ise bize IProductService türünde bir channel üretiyor
        } // Base adress http://localhost:50015/{0}.svc bu hali 0 olan yerede virgülden sonrası
    } // En son olarak Mvc de WebConfig de key oalrak YUkarıda yazdığımz adressi gönderiyoruz
}
