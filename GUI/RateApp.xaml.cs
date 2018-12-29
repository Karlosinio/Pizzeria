using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logika interakcji dla klasy RateApp.xaml
    /// </summary>
    public partial class RateApp : Window
    {
        public RateApp()
        {
            InitializeComponent();
            DataContext = new MenuViewModel.RatingsVM();
            MenuViewModel.RatingsVM.CloseAction = new Action(this.Close);
        }

        private void RB_1(object sender, RoutedEventArgs e)
        {
            MenuViewModel.RatingsVM.Rate = 1;
        }

        private void RB_2(object sender, RoutedEventArgs e)
        {
            MenuViewModel.RatingsVM.Rate = 2;
        }

        private void RB_3(object sender, RoutedEventArgs e)
        {
            MenuViewModel.RatingsVM.Rate = 3;
        }

        private void RB_4(object sender, RoutedEventArgs e)
        {
            MenuViewModel.RatingsVM.Rate = 4;
        }

        private void RB_5(object sender, RoutedEventArgs e)
        {
            MenuViewModel.RatingsVM.Rate = 5;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
