using CartViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for CartOrderHistory.xaml
    /// </summary>
    public partial class CartOrderHistory : Window
    {
        private CartVM cartDataContext;
        public CartOrderHistory(object cartDataContext, int userID = 2)
        {
            InitializeComponent();
            this.cartDataContext = (CartVM)cartDataContext;
        }

        private void Add_To_Cart(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dataContext = (OrderHistoryVM) button.DataContext;
            if(dataContext.SelectedProduct != null)
                cartDataContext.AddProduct(dataContext.SelectedProduct);
        }

        private void Back_To_Cart(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
