using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAcsess.EntityFramework
{
   public class EfQeryableRepository<T>:IQueryableRepository<T> where T:class,IEntity,new()       //IQueryable data da bir sorgu oluşturur
   {
       private DbContext _context; //sadece db contex değilde farklı oralarak abc contex de kullanılabilir ö yüzden yazdık
       private IDbSet<T> _entities;

       public EfQeryableRepository(DbContext context)
       {
           _context = context;
       }

       public IQueryable<T> Table => this.Entities; // bir tabloya abone olup o tablo üzerinde queryable(sorgulanabilir) yapmamızı sağlayacak bu aslında
       // //get
       //{                                                    // this ile bir methodu çağırmak istiyorsak methodu kapatmadan kullanmalıyız oda get ile olur.
       //    return this.Entities;                              
       //} dır

      protected virtual IDbSet<T> Entities  //IDbset yalnızca bir inteface ama ne olduğu belli değil dolayısyla benim burda onu çağıracak bir impelmantosyana ihtiyac var onu bakşa çağıran olmasın diye protected için kullanıdk virtual ise imza
       {
           get
           {
               if (_entities==null)
               {
                   _entities = _context.Set<T>();  // contex olarak ne göderirsem set diyip T ye abone ol
               }

               return _entities; //null değilse aynı tabloyu döndür
           }
           
       }
       
}
}
