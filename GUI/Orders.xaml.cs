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
    /// Logika interakcji dla klasy Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void RegisteredRB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void StartedRB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ReadyRB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void FinishedRB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Products();
            //Close();
            newWindow.Show();
        }

        private void lvUsers_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            Orderss.Items.SortDescriptions.Add(
            new System.ComponentModel.SortDescription("OrderTimestamp",
                 System.ComponentModel.ListSortDirection.Ascending));
        }
    }
}
