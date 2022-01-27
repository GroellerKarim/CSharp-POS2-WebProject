using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Domain.Model
{
    public class Category
    {
        protected Category() { }

        public Category(string name)
        {
            Name = name;
        }

        public int Id { get; init; }
        public string Name { get; private set; }

        private List<Product> _products = new();
        public virtual List<Product> Products => _products;


        public Product AddProduct(Product product)
        {
            if(product != null) 
            {
                product.CategoryId = Id;
                _products.Add(product);
                return product;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public Product RemoveProduct(Product product)
        {
            if(product != null)
            {
                _products.Remove(product);
                return product;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

    }
}
