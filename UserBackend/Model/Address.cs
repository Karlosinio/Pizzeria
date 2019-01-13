using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Model
{
    public class Address
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nip { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string street { get; set; }

        public Address(string Name,  string City, string PostalCode, string Street)
        {
            name = Name;
//            nip = Nip;
            city = City;
            postalCode = PostalCode;
            street = Street;
        }
        
        public Address(int Id, string Name,  string Nip, string City, string PostalCode, string Street)
        {
            id = Id;
            name = Name;
            nip = Nip;
            city = City;
            postalCode = PostalCode;
            street = Street;
        }
    }

    
}
