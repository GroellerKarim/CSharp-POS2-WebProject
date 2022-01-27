using Spg.Domain.Model;
using Spg.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {

        private readonly WebDbContext _dbContext;

        public CustomerService(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Customer customer)
        {
            Customer? c = GetbyId(customer.Id);
            if(c != null)
            {
                _dbContext.Customers.Remove(c);
                await _dbContext.SaveChangesAsync();
            }
            
        }

        public Customer? GetbyEMail(string email)
        {
            Customer? customer = (from customers in _dbContext.Customers
                                where customers.EMail == email
                                select customers).FirstOrDefault();
            return customer;
        }

        public Customer? GetbyId(int id)
        {
            Customer? customer = (from customers in _dbContext.Customers
                                  where customers.Id == id
                                  select customers).FirstOrDefault(); 
            return customer;
        }

        public async Task UpdatePasswordByEmail(string password, string email)
        {
            Customer? customer = GetbyEMail(email);
            if(customer != null)
            {
                customer.ChangePassword(password);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
