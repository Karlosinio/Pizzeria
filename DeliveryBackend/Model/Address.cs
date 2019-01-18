using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryBackend.Model
{
    public class Address
    {
        public int id { get; set; }
        public string name { get; set; }
        public int nip { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string street { get; set; }

        public Address(string Name, int Nip, string City, string PostalCode, string Street)
        {
            name = Name;
            nip = Nip;
            city = City;
            postalCode = PostalCode;
            street = Street;
        }
    }
}
