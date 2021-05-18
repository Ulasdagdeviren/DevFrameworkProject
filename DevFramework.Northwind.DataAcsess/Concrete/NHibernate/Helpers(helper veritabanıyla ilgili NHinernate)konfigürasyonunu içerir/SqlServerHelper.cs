using System.Reflection;
using DevFramework.Core.DataAcsess.NHihabernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DevFramework.Northwind.DataAcsess.Concrete.NHibernate
{
   public class SqlServerHelper:NHihabernateHelper
    {
        protected override ISessionFactory İnitializeFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c =>
                    c.FromConnectionStringWithKey("NorthwindContex")))
                .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())).BuildSessionFactory();// witkey veritabanı ismi şifre gibi de girebilirsiniz
            //mappingleri asseply den bul mevcut essembly (executeassebly) en son sesion döndürülür
        }
    }
}
