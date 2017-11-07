using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Domain.Entity;

namespace Example.Domain.IServices
{
    public interface IServiceStatusPayment
    {
        Task<IEnumerable<CATESTATUSPAGO>> GetFist();
    }
}
