using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Example.DataPersistent.Model;
using Example.Domain.IRepositories;

namespace Example.DataPersistent.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FINANTIALEntities Context;

        private TransactionScope transactionScope;

        /// <summary>
        /// Campo reservado para el disposable
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Diccionario que contiene las instancias de los repositorios
        /// </summary>
        private Dictionary<string, object> repositories;

        /// <summary>
        /// Contructor de la clase <see cref="UnitOfWork"/>
        /// </summary>
        /// <param name="context">Contexto del modelo EF</param>
        public UnitOfWork(FINANTIALEntities context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Método que genera el repositorio generico
        /// </summary>
        /// <typeparam name="T">Entidad de modelo</typeparam>
        /// <returns>Retorna una instancia del repositorio</returns>
        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;
            if (!this.repositories.ContainsKey(type))
            {
                var repositoryInstance = Activator.CreateInstance(typeof(GenericRepository<T>), new object[] { this.Context });
                this.repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)this.repositories[type];
        }

        /// <summary>
        /// Método que se encarga de reaizar el commit de la transacción
        /// </summary>
        public void SaveChange()
        {
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Método que se encarga de reaizar el commit de la transacción asincrona
        /// </summary>
        /// <returns>Retorna true si se realizo con exito, de lo contrario false</returns>
        public async Task<bool> SaveChangeAsync()
        {
            return await this.Context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Método que se encarga de completar la transacción
        /// </summary>
        public void Commit()
        {
            this.transactionScope.Complete();
        }

        /// <summary>
        /// Método que se encarga de generar una transacción
        /// </summary>
        /// <param name="isolationLevel">Objeto que contiene el nivel de isolacion para la transacción</param>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            this.transactionScope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions
                    {
                        IsolationLevel = isolationLevel,
                        Timeout = TransactionManager.MaximumTimeout
                    });
        }

        /// <summary>
        /// Disposable para liberar los recursos de la clase
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposable para liberar los recursos de la clase
        /// </summary>
        /// <param name="disposing">Bandera para liberar los recursos</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                    if (!object.Equals(null, this.transactionScope))
                    {
                        this.transactionScope.Dispose();
                    }
                }

                this.disposed = true;
            }
        }
    }
}
