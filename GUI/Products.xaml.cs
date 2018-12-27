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
    /// Logika interakcji dla klasy Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Button_Orders(object sender, RoutedEventArgs e)
        {
            var newWindow = new Orders();
            newWindow.Show();
            Close();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            // TO DO - logic
        }
    }
}
