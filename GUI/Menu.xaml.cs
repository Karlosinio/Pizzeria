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
        }
    }
}
