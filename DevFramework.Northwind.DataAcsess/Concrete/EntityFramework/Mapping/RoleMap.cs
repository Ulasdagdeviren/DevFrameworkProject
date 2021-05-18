using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;

namespace DevFramework.Northwind.DataAcsess.Concrete.EntityFramework.Mapping
{
   public class RoleMap:EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable(@"Roles", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
        }
    }
}
