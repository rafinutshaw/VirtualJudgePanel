using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJP_Entity;
using VJP_Interface;

namespace VJP_Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        VJPDBContext context = new VJPDBContext();

        public int Delete(int id)
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            context.Set<TEntity>().Remove(entity);

            return context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public int Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);

            return context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            this.context.Entry<TEntity>(entity).State = EntityState.Modified;
            return this.context.SaveChanges();
        }
    }
}
