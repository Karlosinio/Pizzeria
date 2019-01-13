using CartViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        public CartVM kart2;

        public Cart()
        {
            InitializeComponent();
            kart2= new CartVM();
            DataContext = kart2;
        }

        public Cart(CartVM vm)
        {
            InitializeComponent();
            kart2 = vm;
            DataContext = vm;
        }

        private void Button_Back_Menu(object sender, RoutedEventArgs e)
        {
            var newWindow = new Menu();
            newWindow.Show();
            Close();
        }

        private void Button_Delivery(object sender, RoutedEventArgs e)
        {
            var newWindow = new Delivery(kart2);
            newWindow.Show();
            Close();
        }

        private void Button_Delete_From_Cart(object sender, RoutedEventArgs e)
        {
        }

        private void Previous_Orders(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var cartDataContext = button.DataContext;
            var user_ID = 2;

            var newWindow = new CartOrderHistory(cartDataContext)
            {
                DataContext = new OrderHistoryVM(user_ID)
            };
            newWindow.Show();
        }

        private void Edit_Product(object sender, RoutedEventArgs e)
        {
            if (ListOfProducts.SelectedItem != null)
            {
                var button = (Button)sender;
                var cartDataContext = button.DataContext;
                var newWindow = new CartEdit(ListOfProducts.SelectedItem, cartDataContext);
                this.IsEnabled = false;
                Close();
                newWindow.Show();
            }
        }
    }
}
