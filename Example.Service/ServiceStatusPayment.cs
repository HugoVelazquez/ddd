using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Example.Domain.Dto;
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
        /// Contructor de la clase/// <summary>
        /// Convierte el objeto del tipo origen especificado al objeto del tipo destino requerido.
        /// </summary>
        /// <typeparam name="TSourceEntity">Tipo del objeto de origen.</typeparam>
        /// <typeparam name="TDestinationEntity">Tipo del objeto de destino.</typeparam>
        /// <param name="source">Objeto que sera convertido.</param>
        /// <returns>Un objeto del tipo destino requerido con el estado del objeto origen.</returns>
        public TDestinationEntity Convert<TSourceEntity, TDestinationEntity>(TSourceEntity source)
        {
            var result = Mapper.Map<TSourceEntity, TDestinationEntity>(source);
            return result;
        }
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
        public async Task<List<PaymentStatusDto>> GetFist()
        {
            var result = await this.unitOfWork.Repository<CATESTATUSPAGO>().Get();
            if (!object.Equals(null, result))
            {
                return ObjectMapper.GetMapping().Convert<List<CATESTATUSPAGO>, List<PaymentStatusDto>>(result.ToList());
            }

            return null;
        }
    }
}
