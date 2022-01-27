using Spg.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Services.ProductService
{
    public interface IProductService
    {
        Task Create(Product product);
        Product? GetProductById(int id);
        Product? GetProductByName(string name);
        Task UpdateContentById(string content, int id);
        Task DeleteById(int id);

    }
}
