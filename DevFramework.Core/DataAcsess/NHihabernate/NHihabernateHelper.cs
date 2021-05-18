using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace DevFramework.Core.DataAcsess.NHihabernate// NOT Nhibernate de Idisponsable oluşturmamızın nedeni NHibernate bir ORM dir ver veri tabanı ile ilişkili mesela biz veritabanından mağazayı sorgulayıp çektiğimizde 10 bin ürünün ihtiyaç olsada olmasa da çekip getirecek
{
    // NOT: NHbiernate entityframework gibi managet den inidirilir
   public abstract class NHihabernateHelper:IDisposable  // disbosable=tek kullanımlık demek türkçesi agenel anlamamı bellek/kaynak yönetimi anlamına gelir abstract kullandık çünkü aynı anlamada kullanılacaklar var
   {
       private static ISessionFactory _sessionFactory; // burda demek istenilen Oracle için imlemantosyon gönderdisysek onun sqlserver ise sqlserver için bir konfigürasyon gönderilecektir


       public virtual ISessionFactory SessionFactory // method değil de özellik olarak tanımladık
       {
           get
           {
               return _sessionFactory ?? (_sessionFactory = İnitializeFactory());
           }
       }

       protected abstract ISessionFactory İnitializeFactory(); // bunu imlepmente eden ortama göre değişkenlik gösterir

       public virtual ISession OpenSession() //contexi açmaya Isessionu yani ihtiyaç var
       {
           return SessionFactory.OpenSession();
       }

       

       public void Dispose()// bazı oluştruduğumuz nesneler bellekte fazla yer kaplar using gibi kullanımı vardır ancak method çağılması gerektiği için dispose kullanılır.
        {
            GC.SuppressFinalize(this);//Garbage collector(çöp toplayıcı)
        }
    }
}
