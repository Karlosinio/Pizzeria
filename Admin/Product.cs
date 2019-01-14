using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class Product : INotifyPropertyChanged
    {
        public int _id;
        public string _name;
        public string _price;
        public ObservableCollection<string> _components;
        public string _category;
        public bool _available;
        public int _quantity;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Product(int id, string name, string price, string components, string category, bool available)
        {
            _id = id;
            _name = name;
            _price = price;
            _components = new ObservableCollection<string>(components.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
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
        public ObservableCollection<string> Components
        {
            get { return _components; }
            set { _components = value; OnPropertyChanged("Components"); }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}