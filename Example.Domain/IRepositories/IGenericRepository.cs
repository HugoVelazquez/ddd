using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get();

        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>>[] filters = null,
            Expression<Func<TEntity, object>> sorting = null
            );

        Task<TEntity> GetById(object id);

        void Insert(TEntity entity);

        void Update(TEntity entity);
    }
}
