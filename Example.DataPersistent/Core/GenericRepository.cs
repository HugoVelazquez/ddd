using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Example.Domain.IRepositories;

namespace Example.DataPersistent.Core
{
    /// <summary>
    /// Clase que se encarga de realizar las operaciones en la base de datos
    /// </summary>
    /// <typeparam name="T">Entidad del modelo</typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await this.Get(null, null);
        }

        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>>[] filters = null,
            Expression<Func<TEntity, object>> sorting = null
            )
        {
            var query = this.DbSet.AsQueryable();

            if (!object.Equals(null, filters))
            {
                foreach (var fiter in filters)
                {
                    query = query.Where(fiter);
                }
            }

            if (!object.Equals(null, sorting))
            {
                query.OrderBy(sorting);
            }
            
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(object id)
        {
            return await this.DbSet.FindAsync(id);
        }

        public virtual async void Insert(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual async void Update(TEntity entity)
        {
            this.DbSet.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
