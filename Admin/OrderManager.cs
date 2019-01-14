using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System;

namespace Admin
{
    public class OrderManager : INotifyPropertyChanged
    {
        public static string zarejestrowane = "zarejestrowane";
        public static string rozpoczete = "rozpoczete";
        public static string gotowe = "gotowe";
        public static string zakonczone = "zakonczone";

        private ObservableCollection<Order> _orders;
        private ObservableCollection<string> _statuses;

        private Order _currentOrder;
        private string _currentStatus;

        public ICommand GetOrdersCommand { get; set; }
        public ICommand SetStatusCommand { get; set; }
        public ICommand SortOrdersCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public OrderManager()
        {
            _orders = new ObservableCollection<Order>();
            _statuses = new ObservableCollection<string>();
            _statuses.Add(zarejestrowane);
            _statuses.Add(rozpoczete);
            _statuses.Add(gotowe);
            _statuses.Add(zakonczone);

            GetOrdersCommand = new RelayCommand(CommandParameter => getOrders());
            SetStatusCommand = new RelayCommand(CommandParameter => setStatus());
            SortOrdersCommand = new RelayCommand(CommandParameter => sortOrders());
            //createTestData();
            populateOrders();
        }

        private void createTestData()
        {
            Address a1 = new Address(1, "Zgierska 10", "10", "98-456", "Dalekość");
            Address a2 = new Address(2, "Długa 15", "2a", "90-098", "Nowy Jork");
            User u1 = new User(1, "Jan", "Zagłoba", "123123123", a1);
            User u2 = new User(2, "Wojciech", "Mann", "999999999", a2);
            Order o1 = new Order(1, u1, 19.20, "smaczne", "ukończone", "gotówka", "1223");
            Order o2 = new Order(2, u2, 99.99, "blee :((", "ukończone", "przelew", "2332");
            Product p1 = new Product(1, "Wypasiona", "12,30", "szynka, bekon, tłuszcz", "męska", true);
            Product p2 = new Product(2, "Zajesmaczna", "15,00", "salami, brokuły, homary, wieloryb, murzyn", "męska", true);
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
            foreach(OrderProduct op in fetchedOrderProducts)
            {
                foreach(Order o in _orders)
                {
                    if(o.Status == null)
                    {
                        o.Status = zarejestrowane;
                    }
                    if(op._order.Id == o.Id)
                    {
                        op._product.Quantity = op._quantity;
                        o.Products.Add(op._product);

                    }
                }
            }
        }
        private ObservableCollection<Order> getOrders()
        {
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/orders/get_all");
                return JsonConvert.DeserializeObject<ObservableCollection<Order>>(json);
            }
        }
        private ObservableCollection<OrderProduct> getOrderProducts()
        {
            using (WebClient wc = new WebClient() { Encoding = Encoding.UTF8 })
            {
                string json = wc.DownloadString("http://127.0.0.1:8080/server/api/order_products/get_all");
                return JsonConvert.DeserializeObject<ObservableCollection<OrderProduct>>(json);
            }
        }
        private void sortOrders()
        {
            Orders = new ObservableCollection<Order>(Orders.OrderBy(x => x.Status).ToList());
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
        public ObservableCollection<string> Statuses
        {
            get { return _statuses; }
            set
            {
                if (value != null)
                    _statuses = new ObservableCollection<string>(value);
                else
                    _statuses = new ObservableCollection<string>();
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
        public string CurrentStatus
        {
            get { return _currentStatus; }
            set
            {
                _currentStatus = value;
                OnPropertyChanged("CurrentStatus");
            }
        }
        public void setStatus()
        {
            if(_currentOrder == null)
            {
                return;
            }
            _currentOrder.Status = _currentStatus;
            DateTime timestamp = DateTime.Now;
            double minutes = 0;
            if(_currentStatus.Equals(rozpoczete))
            {
                int pizza_count = _currentOrder.Products.Count;
                if (pizza_count == 1)
                {
                    minutes = 25;
                }
                else
                {
                    pizza_count -= 1;
                    minutes = 25 + pizza_count * 15;
                }
                timestamp = timestamp.AddMinutes(minutes);
            }
            if(_currentStatus.Equals(zakonczone))
            {
                _orders.Remove(_currentOrder);
                return;
            }
            _currentOrder.OrderTimestamp = timestamp.ToString();
        }
    }
}
