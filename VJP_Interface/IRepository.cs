using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJP_Entity;

namespace VJP_Interface
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        List<TEntity> GetAll();

        TEntity Get(int id);

        int Insert(TEntity entity);

        int Update(TEntity entity);

        int Delete(int id);
    }
}
