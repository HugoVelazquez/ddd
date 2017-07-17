using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Domain;
using Example.Domain.IRepositories;

namespace Example.DataPersistent
{
    public class RepositoryUser : IRepositoryUser
    {
        public async Task<string> Get()
        {
            return await Task.FromResult("Es una prueba");
        }
    }
}
