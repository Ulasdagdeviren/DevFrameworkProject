using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAcsess.NHihabernate
{
  public  class NhEntityRepositoryBase<Tentity>:IEntityRepository<Tentity> where Tentity:class,IEntity,new()
  {
      private NHihabernateHelper _helper;

      public NhEntityRepositoryBase(NHihabernateHelper helper)
      {
          _helper = helper;
      }

        public Tentity Add(Tentity entity)
        {
            using (var session= _helper.OpenSession())
            {
                session.Save(entity);
            }

            return entity;
        }

        public void Delete(Tentity entity)
        {
            using (var session=_helper.OpenSession())
            {
                session.Delete(entity);
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (var session=_helper.OpenSession())
            {
                return session.Query<Tentity>().SingleOrDefault(filter);  //query=sorgu
            }
        }

        public List<Tentity> GetList(Expression<Func<Tentity, bool>> filter = null)
        {
            using (var session=_helper.OpenSession())
            {
                return filter == null
                    ? session.Query<Tentity>().ToList()
                    : session.Query<Tentity>().Where(filter).ToList();
            }
        }

        public Tentity Update(Tentity entity)
        {
            using (var session=_helper.OpenSession())
            {
                session.Update(entity);
            }

            return entity;
        }
    }
}
