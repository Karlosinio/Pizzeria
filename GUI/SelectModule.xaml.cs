using System.Windows;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy RestorePassword.xaml
    /// </summary>
    public partial class SelectModule : Window
    {
        public SelectModule()
        {
            InitializeComponent();
        }

        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            var newWindow = new Menu();
            Close();
            newWindow.Show();
        }

        private void Button_Admin(object sender, RoutedEventArgs e)
        {
            var newWindow = new Orders();
            Close();
            newWindow.Show();
        }

        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            var newWindow = new LoggingPanel();
            Close();
            newWindow.Show();
        }
    }
}
