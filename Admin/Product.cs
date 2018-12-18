using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class Product
    {
        public int _id;
        public string _name;
        public string _price;
        public string _components;
        public string _category;
        public bool _available;

        public Product(int id, string name, string price, string components, string category, bool available)
        {
            _id = id;
            _name = name;
            _price = price;
            _components = components;
            _category = category;
            _available = available;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Components
        {
            get { return _components; }
            set { _components = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
    }
}