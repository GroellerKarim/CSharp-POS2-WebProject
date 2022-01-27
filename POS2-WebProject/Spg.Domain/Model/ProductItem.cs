using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Domain.Model
{
    public class ProductItem
    {

        protected ProductItem() { }

        public ProductItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public int Id { get; init; }
        public int ProductId { get; set; }
        public Product Product { get; set; }   
        public int Count { get; private set; }

    }
}
