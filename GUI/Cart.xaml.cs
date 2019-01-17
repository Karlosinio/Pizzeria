using CartViewModel;
using MenuViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using User.Model;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        public Cart()
        {
            InitializeComponent();
        }

        private void Button_Back_Menu(object sender, RoutedEventArgs e)
        {
            var newWindow = new Menu();
            var button = (Button)sender;
            var cartDataContext = (CartVM)button.DataContext;

            var vm = new MenuVM();
            vm.cartProducts = cartDataContext.Products;

            newWindow.DataContext = vm;
            newWindow.Show();
            Close();
        }

        private void Button_Delivery(object sender, RoutedEventArgs e)
        {
            var newWindow = new Delivery();
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

            // TUTAJ123
            var user_ID = UserData.id;

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
