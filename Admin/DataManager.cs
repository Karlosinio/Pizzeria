using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Admin
{
    public class DataManager : INotifyPropertyChanged
    {
        private ObservableCollection<Order> _orders;
        private Order _currentOrder;

        public ICommand GetOrdersCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DataManager()
        {
            _orders = new ObservableCollection<Order>();
            GetOrdersCommand = new RelayCommand(CommandParameter => getOrders());

            createTestData();
            //populateOrders();
        }

        private void createTestData()
        {
            Address a1 = new Address(1, "Zgierska 10", "10", "98-456", "Wypizdow");
            Address a2 = new Address(2, "Chujowa 15", "2a", "90-098", "Nowy Jork");
            User u1 = new User(1, "Jan", "Zagłoba", "123123123", a1);
            User u2 = new User(2, "Wojciech", "Mann", "999999999", a2);
            Order o1 = new Order(1, u1, 19.20, "smaczne", "ukończone", "gotówka");
            Order o2 = new Order(2, u2, 99.99, "rzygalem", "ukończone", "przelew");
            Product p1 = new Product(1, "Wypasiona", "12,30", "szynka, bekon, tłuszcz", "męska", true);
            Product p2 = new Product(2, "Zajebista", "15,00", "salami, brokuły, homary, wieloryb, murzyn", "męska", true);
            o1.Products.Add(p1);
            o1.Products.Add(p2);
            o2.Products.Add(p2);

            _orders = new ObservableCollection<Order>
            {
                o1,
                o2
            };
        }

        private void populateOrders()
        {
            ObservableCollection<Order> fetchedOrders = getOrders();
            _orders = fetchedOrders;
            ObservableCollection<OrderProduct> fetchedOrderProducts = getOrderProducts();
            foreach(OrderProduct p in fetchedOrderProducts)
            {
                foreach(Order o in _orders)
                {
                    if(p._order.Id == o.Id)
                    {
                        o.Products.Add(p._product);
                    }
                }
            }
        }
        private ObservableCollection<Order> getOrders()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/orders/get_all");
                return JsonConvert.DeserializeObject<ObservableCollection<Order>>(json);
            }
        }
        private ObservableCollection<OrderProduct> getOrderProducts()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/order_products/get_all");
                return JsonConvert.DeserializeObject<ObservableCollection<OrderProduct>>(json);
            }
        }
        private void sortOrders()
        {

        }

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                if (value != null)
                    _orders = new ObservableCollection<Order>(value);
                else
                    _orders = new ObservableCollection<Order>();
            }
        }
        public Order CurrentOrder
        {
            get { return _currentOrder; }
            set
            {
                _currentOrder = value;
                OnPropertyChanged("CurrentOrder");
            }
        }
    }

}
