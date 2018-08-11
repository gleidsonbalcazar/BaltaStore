using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.ValueObjects;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities {
    public class Customer : Notifiable{

        private readonly IList<Address> _addressess;

        public Customer (Name name, Document document, Email email, string phone) {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addressess = new List<Address>();
        }
        
        public Name Name {get; private set;}
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addressess  =>_addressess.ToArray();

        public void AddAddress(Address address){
            //validar endereco
            _addressess.Add(address);
        }

        public override string ToString () {
            return Name.ToString();
        }
    }
}