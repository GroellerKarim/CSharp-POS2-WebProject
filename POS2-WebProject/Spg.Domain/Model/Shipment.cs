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

        public Shipment(Customer customer, List<ProductItem> products, States state)
        {
            Customer = customer;
            _products = products;
            State = state;
        }

        public int Id { get; init; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        private List<ProductItem> _products = new();
        public virtual IReadOnlyList<ProductItem> ProductItems =>  _products;

        public States State { get; set; } 

    }
}
