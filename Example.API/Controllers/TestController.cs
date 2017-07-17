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
    /// Clase de pruebas, implementando IoC, DI y swagger
    /// </summary>
    public class TestController : ApiController
    {
        private readonly IServiceUser serviceUser;

        /// <summary>
        /// Constructor de la clase <see cref="TestController"/>
        /// </summary>
        /// <param name="serviceUser">Interfaz para injectar Servicio de ServiceUser/></param>
        public TestController(IServiceUser serviceUser)
        {
            this.serviceUser = serviceUser;
        }

        /// <summary>
        /// Método de prueba para implementar DI, IoC e interfaz de swagger
        /// </summary>
        /// <returns>Regresa una cadena con el nombre de usuario</returns>
        public async Task<IHttpActionResult> Get()
        {
            var result = await this.serviceUser.Get();

            return this.Ok(result);
        }
    }
}
