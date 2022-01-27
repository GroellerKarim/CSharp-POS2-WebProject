using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Domain.Model
{
    public class Product
    {
        public Product(string name,string content, decimal price, decimal tax, int stock, Category category)
        {
            Name = name;
            Content = content;
            Price = price;
            Tax = tax;
            Stock = stock;
            Category = category;
        }

        public int Id { get; init; } 
        public string Name { get; private set; }
        public string Content { get; private set; }
        public decimal Price { get; private set; }
        public decimal Tax { get; private set; }
        public int Stock { get;  set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
