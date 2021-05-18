using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAcsess.EntityFramework;
using DevFramework.Entities.ComlexTypes;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.DataAcsess.Abstract;

namespace DevFramework.Northwind.DataAcsess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContex>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (NorthwindContex context = new NorthwindContex())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles on ur.UserId equals user.Id
                             where ur.UserId == user.Id  // kullancı ile gelen Id ye eşittri dedik sağdaki
                             select new UserRoleItem { RoleName = r.Name };
                return result.ToList();

            }
        }
    }
}
