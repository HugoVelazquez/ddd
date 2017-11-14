using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Domain.Dto;
using Example.Domain.Entity;

namespace Example.Domain.IServices
{
    public interface IServiceStatusPayment
    {
        Task<List<PaymentStatusDto>> GetFist();
    }
}
