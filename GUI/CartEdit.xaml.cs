using System;
using System.Windows;
using System.Windows.Controls;
using CartViewModel;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy CartEdit.xaml
    /// </summary>
    public partial class CartEdit : Window
    {
        private CartVM cartDataContext;

        public CartEdit(Object product, object cartDataContext)
        {
            InitializeComponent();
            DataContext = new CartEditVM(product);
            this.cartDataContext = (CartVM) cartDataContext;
        }

        public object SelectedProductToEdit { get; set; }
        private void Odswiez(object sender, RoutedEventArgs e)
        {
            this.InvalidateVisual();
        }
        private void Button_Back_To_Cart(object sender, RoutedEventArgs e)
        {

            var button = (Button)sender;
            var cartEditVM = (CartEditVM) button.DataContext;
            var editedProduct = cartEditVM.SelectedProductToEdit;

            var index = cartDataContext.Products.IndexOf(editedProduct);

            cartDataContext.Products.Insert(index, editedProduct);
            cartDataContext.Products.RemoveAt(index +1);

            var carWindow = new Cart
            {
                DataContext = cartDataContext
            };
            carWindow.Show();
            Close();
            
        }

        
    }
}
