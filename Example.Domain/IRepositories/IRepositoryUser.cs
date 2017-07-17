using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.IRepositories
{
    public interface IRepositoryUser
    {
        Task<string> Get();
    }
}
