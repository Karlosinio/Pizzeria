using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CartBackend.Common.DTO;
using CartViewModel;
using MenuViewModel;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {

        public CartVM cartContext = new CartVM();

        public Menu()
        {
            InitializeComponent();
            if(DataContext == null)
                DataContext = new MenuViewModel.MenuVM();
            if(cartContext.Products == null)
                cartContext.Products = new ObservableCollection<ProductDTO>();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            var newWindow = new LoggingPanel();
            newWindow.Show();
            Close();
        }

        private void Button_UserPanel(object sender, RoutedEventArgs e)
        {
            var newWindow = new UserPanel();
            newWindow.Show();
            Close();
        }

        private void Button_History(object sender, RoutedEventArgs e)
        {
            int user_id = UserData.id;
            var newWindow = new History(user_id);
            newWindow.Show();
        }

        private void Button_RateApp(object sender, RoutedEventArgs e)
        {
            var newWindow = new RateApp();
            newWindow.Show();
        }

        private void Button_Cart(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dc = (MenuVM)button.DataContext;

            cartContext.Products = dc.cartProducts;

            var newWindow = new Cart();
            newWindow.DataContext = cartContext;
            newWindow.Show();
            Close();
        }

        private void Button_Add_To_Cart(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dc = (MenuVM) button.DataContext;

            if(dc.SelectedProduct != null)
            {
                var selectedProduct = dc.SelectedProduct;

                ProductDTO prod = new ProductDTO
                {
                    Available = selectedProduct.available,
                    Category = selectedProduct.category,
                    Components = selectedProduct.components,
                    Id = selectedProduct.id,
                    Name = selectedProduct.name,
                    Price = selectedProduct.price,
                    Quantity = 1
                };

                dc.cartProducts.Add(prod);

                cartContext.Products.Add(prod);
            }
        }
    }
}
