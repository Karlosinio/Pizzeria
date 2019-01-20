using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class Component : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private double _price;
        private bool _available;
        private bool _vegan;

        public bool IsSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Component()
        {

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
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public bool Available
        {
            get { return _available; }
            set { _available = value; }
        }
        public bool Vegan
        {
            get { return _vegan; }
            set { _vegan = value; }
        }
    }
}
