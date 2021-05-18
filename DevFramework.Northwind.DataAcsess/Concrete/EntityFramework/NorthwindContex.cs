using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.DataAcsess.Concrete.EntityFramework.Mapping;

namespace DevFramework.Northwind.DataAcsess.Concrete.EntityFramework
{  
    // Not: mapping=veri tabanı ile nesnenizin bağlantısını kurar Product da olanlar nesnelerimiz
    // ctor public in yanında cllasın ismi olmalı ve aynı zamanda ctor her objenin ilk üretlidiği anda(newlendii anda) çağırılan fonsiyonlarıdır
   public class NorthwindContex:DbContext
    {
        public NorthwindContex()
        {
            Database.SetInitializer<NorthwindContex>(null); //hazır bir veri tabanı kullandığımız için mygrassion ı kapatıyoruz biz veri tabanı hazırladık sen gidip veritabanında bişey oluşturma çünkü map ile yaptık tabloları
        }                                                           // ilk çalışmada  bir veri tabanı yoksa oluşturur demek
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles{ get; set; } // concrete olan
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)  // Mapi ayağakalıdrdık  
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }
        
    }
}
