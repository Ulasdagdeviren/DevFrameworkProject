using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAcsess
{
  public  interface IEntityRepository <T> where T:class,IEntity,new()    // T= Generic oluşturduk 
  {
      List<T> GetList(Expression<Func<T, bool>> filter=null); // istersem datanın tümü istersem datanın where koşuluyla belirtilmiş kısmını getirmek istiyoruz burda çoklu liste
      T Get(Expression<Func<T, bool>> filter); // tekli liste de dödürebiliriz
      T Add(T entity);
      T Update(T entity);
      void Delete(T entity);//

  }
}
