using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.ComlexTypes;
using DevFramework.Entities.Concrete;

namespace DevFramework.Northwind.Business.Abstract
{
   public interface IUserService
   {
       User GetByUserNameAndPassword(string userName, string password); // burda method başarılı ise Userı getir dedik eğer baştaki user olmasaydı bool olsaydı true false dönerdi user burda sadece sonuçtur
       List<UserRoleItem> GetUserRoles(User user); // burda da Method  başarılı şse liste döner
   }
}
