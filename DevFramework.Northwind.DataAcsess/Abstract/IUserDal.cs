using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAcsess;
using DevFramework.Entities.ComlexTypes;
using DevFramework.Entities.Concrete;

namespace DevFramework.Northwind.DataAcsess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
   {
       List<UserRoleItem> GetUserRoles(User user);
   }
}
