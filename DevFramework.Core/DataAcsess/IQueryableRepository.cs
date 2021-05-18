using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAcsess
{
  public  interface IQueryableRepository<T> where  T:class,IEntity,new()
    {
        IQueryable<T> Table { get; } // IQoeryable tamamen operasyonlar select olduğu için tek bir imlemantasyon yapılır genelde table ismiyle oluşturulur read only şekilde yapılır.
                                     // // aynı zamanda IQUARYABLE SORGU OLUŞTURMAK İÇİN KULLANILIR IQueryable  LINQ for Database için yani veritabanından sorgulanan değerler için kullanılıyor. ... //
                                     // IQueryable ile LINQ sorgusu yapıldığında ise veritabanı üzerinde çalıştırılacak sorguda tüm filtreler yeralacak ve sadece istenen kayıtlar yüklenecektir
    }
}
