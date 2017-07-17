using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.IServices
{
    public interface IServiceUser
    {
        Task<string> Get();
    }
}
