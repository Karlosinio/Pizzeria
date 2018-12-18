using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class Order
    {
        public int _id;
        public User _user;
        public double _price;
        public string _comment;
        public string _status;
        public string _payment;
        public ObservableCollection<Product> _products;

        public Order()
        {
            _status = "TEST STATUS";
            _products = new ObservableCollection<Product>();
        }

        public Order(int id, User user, double price, string comment, string status, string payment)
        {
            _id = id;
            _user = user;
            _price = price;
            _comment = comment;
            _status = status;
            _payment = payment;

            _products = new ObservableCollection<Product>();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }
    }
}
