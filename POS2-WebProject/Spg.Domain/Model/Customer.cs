using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Domain.Model
{

    public enum Gender { MALE = 0, FEMALE = 1, DIVERSE = 2}

    public class Customer
    {

        protected Customer() { }

        public Customer(string firstName, string lastName, string eMail, string password, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            Password = password;
            Address = address;
        }

        public int Id { get; init; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string EMail { get; private set; }

        public string Password { get; private set; }

        public Address Address { get; private set; }

        private List<Shipment> _shipments = new();
        public virtual IReadOnlyList<Shipment> Shipments => _shipments;

        private List<ProductItem> _inCart = new();
        public virtual IReadOnlyList<ProductItem> ProductItems => _inCart;

        public Shipment CartToShipment()
        {
            if (_inCart.Count > 0)
            {
                Shipment shipment = new Shipment(this, States.InPayment);
                shipment.AddProductItems(_inCart);

                _shipments.Add(shipment);
                return shipment;
            }
            else
            {
                throw new Exception("Nothing in Cart!");
            }
        }

        public Shipment AddShipment(Shipment shipment)
        {
            if(shipment != null)
            {
                _shipments.Add(shipment);
                return shipment;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddShipments(List<Shipment> shipments)
        {
            if(shipments != null)
            {
                foreach(Shipment shipment in shipments)
                    AddShipment(shipment);
            }
        }

        public ProductItem AddToCart(ProductItem productItem)
        {
            if(productItem != null)
            {
                _inCart.Add(productItem);
                return productItem;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddListToCart(List<ProductItem> productItems)
        {
            if(productItems != null)
            {
                foreach(ProductItem productItem in productItems)
                    AddToCart(productItem);
            }
        }

        public void RemoveProductItem(ProductItem productItem)
        {
            ProductItem item = _inCart.FirstOrDefault(s => s.Id == productItem.Id);
            if(item != null)
            {
                item.Product.Stock += item.Count;
                _inCart.Remove(item);
            }
        }

        public string ChangePassword(string password)
        {
            Password = password;
            return Password;
        }

    }
}
