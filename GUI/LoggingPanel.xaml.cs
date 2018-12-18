using System.Windows;
using User.ViewModel;


namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy LoggingPanel.xaml
    /// </summary>
    public partial class LoggingPanel : Window
    {
        public LoggingPanel()
        {
            InitializeComponent();
            DataContext = new LoginPanelVM();
       
        }

  

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
