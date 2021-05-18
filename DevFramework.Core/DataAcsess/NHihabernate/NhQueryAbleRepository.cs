using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAcsess.NHihabernate
{
   public class NhQueryAbleRepository<T>:IQueryableRepository<T> where  T:class,IEntity,new()
   {
       private NHihabernateHelper _helper;
       private IQueryable<T> _entities;

       public NhQueryAbleRepository(NHihabernateHelper helper)
       {
           _helper = helper;
       }

       public IQueryable<T> Table
       {
           get
           {
               return this.Entities;
           }
       }

       protected virtual IQueryable<T> Entities
       {
           get
           {
               if (_entities==null)
               {
                   _entities = _helper.OpenSession().Query<T>();
               }

               return _entities;
           }
       }
   }
}
