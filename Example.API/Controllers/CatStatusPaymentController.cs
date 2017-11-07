using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Example.Domain.IServices;

namespace Example.API.Controllers
{
    /// <summary>
    /// Controlador con CRUD para catalogo de estado de pago
    /// </summary>
    public class CatStatusPaymentController : ApiController
    {
        /// <summary>
        /// variable que contiene la interfaz del servicio de Estado de pago
        /// </summary>
        private IServiceStatusPayment serviceStatusPayment;

        /// <summary>
        /// Constructor de la clase es Estado de pago
        /// </summary>
        /// <param name="serviceStatusPayment"></param>
        public CatStatusPaymentController(IServiceStatusPayment serviceStatusPayment)
        {
            this.serviceStatusPayment = serviceStatusPayment;
        }

        /// <summary>
        /// Método de prueba para realizar una consulta al repositorio de Estado de pago
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            var result = await this.serviceStatusPayment.GetFist();

            return this.Ok(result);
        }
    }
}
