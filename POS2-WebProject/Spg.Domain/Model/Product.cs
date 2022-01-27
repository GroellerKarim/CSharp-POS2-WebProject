using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Domain.Model
{
    public class Product
    {
        public Product(string name,string content, string price, decimal tax, int stock, Category category)
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
        public string Price { get; private set; }
        public decimal Tax { get; private set; }
        public int Stock { get;  set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public void UpdateContent(string content)
        {
            Content = content;
        }

    }
}
