using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAcsess.NHihabernate;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.DataAcsess.Abstract;

namespace DevFramework.Northwind.DataAcsess.Concrete.NHibernate
{
   public class NhCategoryDal:NhEntityRepositoryBase<Category>,ICategoryDal
    {
        public NhCategoryDal(NHihabernateHelper helper) : base(helper)
        {

        }
    }
}
