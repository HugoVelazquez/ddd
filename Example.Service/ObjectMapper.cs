using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Example.Domain.Dto;
using Example.Domain.Entity;

namespace Example.Service
{
    public class ObjectMapper
    {
        /// <summary>
        /// Miembro Static que se carga inmediatamente cuando se crea la instancia por primera vez.
        /// </summary>
        private static readonly ObjectMapper Instance = new ObjectMapper();

        public ObjectMapper()
        {
            this.GenerateMaps();
        }

        /// <summary>
        /// Método que se encarga de regresar la instancia seleccionada
        /// </summary>
        /// <returns></returns>
        public static ObjectMapper GetMapping()
        {
            return Instance;
        }


        /// <summary>
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

        private void GenerateMaps()
        {
            Mapper.Initialize(cnf =>
            {
                cnf.CreateMap<CATESTATUSPAGO, PaymentStatusDto>()
                    .ForMember(c => c.Id, opt => opt.MapFrom(c => c.IDCATESTATUSPAGO))
                    .ForMember(c => c.Description, opt => opt.MapFrom(c => c.DESCRIPCION));
            });
                
        }
    }
}
