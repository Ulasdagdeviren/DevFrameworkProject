using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAcsess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,Tcontex>:IEntityRepository<TEntity> where TEntity:class,IEntity,new() 
       where Tcontex:DbContext,new()
    {
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var contex=new Tcontex())
            {
                return filter == null ? contex.Set<TEntity>().ToList() : contex.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var contex=new Tcontex())
            {
                return contex.Set<TEntity>().SingleOrDefault(filter);// tek bir nesne dödüreceğiz o yüzden single or defould kullnadık
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var contex=new Tcontex())
            {
                var Added = contex.Entry(entity); // entry=giriş demektir
                Added.State = EntityState.Added;
                contex.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var contex=new Tcontex())
            {
                var Updated = contex.Entry(entity);
                Updated.State = EntityState.Modified;
                contex.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var contex=new Tcontex())
            {
                var Deleted = contex.Entry(entity);
                Deleted.State = EntityState.Deleted;
                contex.SaveChanges();
                
            }
        }
    }
}
