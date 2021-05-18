using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Entities.Concrete
{
   public class UserRole :IEntity // bu ise tamamen User Role tablosu için kullanılacak
    {
        
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
