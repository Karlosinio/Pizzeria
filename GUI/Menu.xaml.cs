using System.Windows;
using MenuViewModel;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            DataContext = new MenuViewModel.MenuVM();
          //  DataContext = new User.ViewModel.MenuVM();
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
            var newWindow = new History();
            newWindow.Show();
        }

        private void Button_RateApp(object sender, RoutedEventArgs e)
        {
            var newWindow = new RateApp();
            newWindow.Show();
        }

        private void Button_Cart(object sender, RoutedEventArgs e)
        {
            var newWindow = new Cart();
            newWindow.Show();
            Close();
        }

        private void Button_Add_To_Cart(object sender, RoutedEventArgs e)
        {
            // TO DO - logic
        }
    }
}
