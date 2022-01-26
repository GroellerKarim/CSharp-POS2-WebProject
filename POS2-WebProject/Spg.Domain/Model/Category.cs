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

        public Category(string name, List<Product> products)
        {
            Name = name;
            _products = products;
        }

        public int Id { get; init; }
        public string Name { get; private set; }

        private List<Product> _products = new();
        public virtual List<Product> Products => _products;

    }
}
