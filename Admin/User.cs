using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class User
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public string _surname { get; set; }
        public string _phone { get; set; }
        public Address _address { get; set; }
        public string _fullName { get; set; }

        public User(int id, string name, string surname, string phone, Address address)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _phone = phone;
            _address = address;
            _fullName = name + " " + surname;
        }

        public string fullName()
        {
            return _name + " " + _surname;
        }
    }
}