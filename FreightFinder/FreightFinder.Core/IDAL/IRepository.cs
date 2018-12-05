using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FreightFinder.Core.IDAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(dynamic id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> QueryObjectGraph(Expression<Func<TEntity, bool>> filter, string child1, string child2=null, string child3=null);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
