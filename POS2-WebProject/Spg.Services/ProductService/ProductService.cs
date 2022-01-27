using Spg.Domain.Model;
using Spg.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly WebDbContext _dbContext;

        public ProductService(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            Product? product = GetProductById(id);
            if(product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Product? GetProductById(int id)
        {
            Product? p = (from product in _dbContext.Products
                                where product.Id== id 
                                select product).FirstOrDefault();
            return p;
        }

        public Product? GetProductByName(string name)
        {
            Product? p = (from product in _dbContext.Products
                          where product.Name== name
                          select product).FirstOrDefault();
            return p;
        }

        public async Task UpdateContentById(string content, int id)
        {
            Product? p = GetProductById(id);
            if(p != null)
            {
                p.UpdateContent(content);
                await _dbContext.SaveChangesAsync();   
            }
        }
    }
}
