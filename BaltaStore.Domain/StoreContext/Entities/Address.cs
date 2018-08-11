using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities {
    public class Address :Notifiable {

        public Address (
            string street,
            string number,
            string complement,
            string district,
            string city,
            string state,
            string country,
            string zipcode,
            EAddressType type
            ) {
                Street = street;
                Number = number;
                Complement = complement;
                District = district;
                State = state;
                Country = country;
                City = city;
                ZipCode = zipcode;
                Tyoe = type;
        }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string State { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Tyoe { get; set; }

        public override string ToString(){
            return $"{Street}, { Number } - { City } / { State}";
        }
    }
}