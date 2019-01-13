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
    /// Logika interakcji dla klasy Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void MoneyRB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CardRB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void OnlineRB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BlikRB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Back_Menu(object sender, RoutedEventArgs e)
        {
            var newWindow = new Menu();
            newWindow.Show();
            Close();
        }

        private void Button_Back_Cart(object sender, RoutedEventArgs e)
        {
            var newWindow = new Cart();
            newWindow.Show();
            Close();
        }

        private void Button_Back_Delivery(object sender, RoutedEventArgs e)
        {
            var newWindow = new Delivery();
            newWindow.Show();
            Close();
        }

        private void Button_Pay(object sender, RoutedEventArgs e)
        {
            // TO DO - logic

            MessageBox.Show("Zamówienie przyjęte");

            var newWindow = new Menu();
            newWindow.Show();
            Close();
        }
    }
}
