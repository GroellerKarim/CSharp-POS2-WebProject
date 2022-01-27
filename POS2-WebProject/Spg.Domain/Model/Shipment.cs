using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Domain.Model
{

    public enum States { InPayment, InShipping, Shipped, Error }

    public class Shipment
    {

        protected Shipment() { }

        public Shipment(Customer customer, States state)
        {
            Customer = customer;
            State = state;
        }

        public int Id { get; init; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        private List<ProductItem> _products = new();
        public virtual IReadOnlyList<ProductItem> ProductItems =>  _products;

        public States State { get; set; } 

        public ProductItem AddProductItem(ProductItem product)
        {
            if(product != null)
            {
                _products.Add(product);
                return product;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddProductItems(List<ProductItem> products)
        {
            if(products != null)
            {
                foreach(ProductItem productItem in products)
                    AddProductItem(productItem);
            }
        }

    }
}
