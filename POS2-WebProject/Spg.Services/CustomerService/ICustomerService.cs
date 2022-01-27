using Spg.Domain.Model;
using Spg.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Services.CustomerService
{
    public interface ICustomerService
    {

        Task Create(Customer customer);
        Customer? GetbyId(int id);
        Customer? GetbyEMail(string email);
        Task UpdatePasswordByEmail(string password, string email);
        Task Delete(Customer customer);

    }
}
