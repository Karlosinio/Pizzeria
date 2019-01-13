using System.Windows;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy RestorePassword.xaml
    /// </summary>
    public partial class RestorePassword : Window
    {
        public RestorePassword()
        {
            InitializeComponent();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
