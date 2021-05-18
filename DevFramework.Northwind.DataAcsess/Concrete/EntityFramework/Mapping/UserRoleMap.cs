using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;

namespace DevFramework.Northwind.DataAcsess.Concrete.EntityFramework.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable(@"UserRole", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.RoleId).HasColumnName("RoleId");
            Property(x => x.UserId).HasColumnName("UserId");
        }
    }
}
