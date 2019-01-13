﻿using CartViewModel;
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
    /// Logika interakcji dla klasy Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        public Cart()
        {
            InitializeComponent();
            DataContext = new CartVM();
        }

        private void Button_Back_Menu(object sender, RoutedEventArgs e)
        {
            var newWindow = new Menu();
            newWindow.Show();
            Close();
        }

        private void Button_Delivery(object sender, RoutedEventArgs e)
        {
            var newWindow = new Delivery();
            newWindow.Show();
            Close();
        }

        private void Button_Delete_From_Cart(object sender, RoutedEventArgs e)
        {

        }
    }
}
