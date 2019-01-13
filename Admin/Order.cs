using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class Order : INotifyPropertyChanged
    {
        public int _id;
        public User _user;
        public double _price;
        public string _comment;
        public string _status;
        public string _payment;
        public string _timestamp;
        public ObservableCollection<Product> _products;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Order()
        {
            _products = new ObservableCollection<Product>();
        }


        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public Order(int id, User user, double price, string comment, string status, string payment, string orderTimestamp)
        {
            _id = id;
            _user = user;
            _price = price;
            _comment = comment;
            _status = OrderManager.zarejestrowane;
            _payment = payment;
            _timestamp = DateTime.Now.ToString();

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
            set { _status = value; NotifyPropertyChanged("Status"); }
        }
        public string Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }
        public string OrderTimestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; NotifyPropertyChanged("OrderTimestamp"); }
        }
    }
}
