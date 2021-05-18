using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Entities.Concrete
{
   public class Role:IEntity // veritabanı nesnesi
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
