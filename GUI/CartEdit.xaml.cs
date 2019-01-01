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
using CartViewModel;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy CartEdit.xaml
    /// </summary>
    public partial class CartEdit : Window
    {
        private Window CardWindow;

        public CartEdit(Object product, Window window)
        {
            InitializeComponent();
            DataContext = new CartEditVM(product);
            this.CardWindow = window;
        }

        public object SelectedProductToEdit { get; set; }
        private void Odswiez(object sender, RoutedEventArgs e)
        {
            this.InvalidateVisual();
        }
        private void Button_Back_To_Cart(object sender, RoutedEventArgs e)
        {

            //var newWindow = new Cart();
            // newWindow.Show();
            //this.Controls.Clear();
            this.CardWindow.IsEnabled = true;
            this.CardWindow.UpdateLayout();
            Close();
            
        }

        
    }
}
