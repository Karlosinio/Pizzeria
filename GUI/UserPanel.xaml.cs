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
using User.ViewModel;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        public UserPanel()
        {
            InitializeComponent();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new Menu();
            newWindow.Show();
            Close();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            // TO DO - logic
            DataContext = new UserPanelVM();
        }
        
        private void Button_Retrive(object sender, RoutedEventArgs e)
        {
            // TO DO - logic
            DataContext = new UserPanelVM();
        }
    }
}
