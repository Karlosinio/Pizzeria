using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Admin
{
    public class ProductManager : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _products;
        private ObservableCollection<string> _categories;
        private ObservableCollection<Component> _components;
        private Product _currentProduct;

        public ICommand GetProductsCommand { get; set; }
        public ICommand CreateNewProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand CheckIfAvailableCommand { get; set; }
        private string newProductName;
        private string newProductPrice;
        private string newProductCategory;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProductManager()
        {
            CheckIfAvailableCommand = new RelayCommand(CommandParameter => checkIfAvailable());
            CreateNewProductCommand = new RelayCommand(CommandParameter => createNewProduct());
            DeleteProductCommand = new RelayCommand(CommandParameter => deleteProduct());
            _products = new ObservableCollection<Product>();
            _products = getProducts();
            _categories = getCategories(_products);
            _components = getComponents();
        }
        private ObservableCollection<string> getCategories(ObservableCollection<Product> n)
        {
            ObservableCollection<string> _categories = new ObservableCollection<string>();
            foreach (Product i in n)
            {
                if (!_categories.Contains(i.Category))
                    _categories.Add(i.Category);
            }
            return _categories;
        }

        private ObservableCollection<Component> getComponents()
        {
            
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/components/get_all/");
                var l= JsonConvert.DeserializeObject<ObservableCollection<Component>>(json).ToList<Component>();
                return new ObservableCollection<Component>(l.GroupBy(p => p.Name).Select(g => g.First()).ToList());
            }
        }
        private void checkIfAvailable()
        {
            int exist = 0;
            foreach (string name in CurrentProduct.Components)
            {
                exist = 0;
                foreach (Component c in Components)
                {
                    if (name.Trim() == c.Name)
                    {
                        exist = 1;
                        if (c.Available == false)
                        {
                            System.Windows.Forms.MessageBox.Show("Produkt zawiera niedostępny składnik: " + c.Name);
                            return;
                        }
                    }
                }
                if (exist == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Błąd: Brak informacji w bazie danych o składniku: " + name.Trim());
                    return;
                }
            }
            System.Windows.Forms.MessageBox.Show("Produkt jest dostępny.");
        }

        private ObservableCollection<Product> getProducts()
        {
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/products/get_all/");
                return JsonConvert.DeserializeObject<ObservableCollection<Product>>(json);
            }
        }


        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                if (value != null)
                    _products = new ObservableCollection<Product>(value);
                else
                    _products = new ObservableCollection<Product>();
            }
        }
        public ObservableCollection<Component> Components
        {
            get { return _components; }
            set
            {
                if (value != null)
                    _components = new ObservableCollection<Component>(value);
                else
                    _components = new ObservableCollection<Component>();
            }
        }
        public Product CurrentProduct
        {
            get { return _currentProduct; }
            set
            {
                _currentProduct = value;
                OnPropertyChanged("CurrentProduct");
            }
        }

        public string NewProductCategory { get => newProductCategory; set => newProductCategory = value; }
        public string NewProductPrice { get => newProductPrice; set => newProductPrice = value; }
        public string NewProductName { get => newProductName; set => newProductName = value; }


        private void deleteProduct()
        {
            int id = CurrentProduct.Id;
            HttpWebRequest request =
             (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/products/{id}");
            request.Method = "DELETE";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }



        private void createNewProduct()
        {
            string skladniki = "";
            foreach (Component c in Components)
            {

                if (c.IsSelected)
                {
                    skladniki += c.Name;
                    skladniki += ", ";
                }
            }

            string sz = $"{{\"name\": \"{newProductName}\",\"price\": \"{newProductPrice}\",\"components\": \"{skladniki}\",\"category\": \"{newProductCategory}\",\"available\": true}}";
            HttpWebRequest request =
              (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/server/api/products/");
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(sz);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


        }
    }
}
