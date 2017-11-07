using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Domain.Entity;
using Example.Domain.IRepositories;
using Example.Domain.IServices;

namespace Example.Service
{
    /// <summary>
    /// Clase que contiene las operaciones de estatus de pago
    /// </summary>
    public class ServiceStatusPayment : IServiceStatusPayment
    {
        /// <summary>
        /// interfaz de Unit of Work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="unitOfWork">Interfaz que será asignada a la variable local</param>
        public ServiceStatusPayment(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Método que consulta el catalogo de los estatus de pago
        /// </summary>
        /// <returns>Regresa una tarea que contiene una lista de <see cref="CATESTATUSPAGO"/></returns>
        public async Task<IEnumerable<CATESTATUSPAGO>> GetFist()
        {
            var result = await this.unitOfWork.Repository<CATESTATUSPAGO>().Get();
            if (object.Equals(null, result))
            {
                return null;
            }
            return result;
        }
    }
}
