using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class Address
    {
        public int _id;
        public string _street;
        public string _postalCode;
        public string _city;
        public string _number;

        public Address(int id, string street, string number, string postalCode, string city)
        {
            _id = id;
            _street = street;
            _number = number;
            _postalCode = postalCode;
            _city = city;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }
}