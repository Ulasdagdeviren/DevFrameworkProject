using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAcsess.EntityFramework;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.DataAcsess.Abstract;

namespace DevFramework.Northwind.DataAcsess.Concrete.EntityFramework
{
   public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContex>,ICategoryDal
    {
    }
}
