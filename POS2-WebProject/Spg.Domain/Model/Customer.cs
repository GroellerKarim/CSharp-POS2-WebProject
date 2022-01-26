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

        public Customer(string firstName, string lastName, string eMail, string password, Address address, List<Shipment> shipments, List<ProductItem> inCart)
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            Password = password;
            Address = address;
            _shipments = shipments;
            _inCart = inCart;
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

    }
}
