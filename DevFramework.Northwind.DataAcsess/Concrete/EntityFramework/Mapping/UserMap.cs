﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;

namespace DevFramework.Northwind.DataAcsess.Concrete.EntityFramework.Mapping
{
   public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"User", @"dbo");
            HasKey(x => x.Id);
            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.LastName).HasColumnName("LastName");
            Property(x => x.Password).HasColumnName("Password");
            Property(x => x.UserName).HasColumnName("UserName");
            Property(x => x.FirstName).HasColumnName("FirstName");

        }
    }
}
