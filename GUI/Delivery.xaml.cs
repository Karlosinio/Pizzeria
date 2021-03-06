﻿using CartViewModel;
using DeliveryViewModel;
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
    /// Logika interakcji dla klasy Delivery.xaml
    /// </summary>
    public partial class Delivery : Window
    {
        public CartVM cart;
        public DeliveryVM del;

        public Delivery(CartVM kart)
        {
            InitializeComponent();
            cart = kart;
            del = new DeliveryVM(cart);
            DataContext = new DeliveryVM(cart);

        }

        private void Delivery1RB_Checked(object sender, RoutedEventArgs e)
        {
            ((DeliveryVM)DataContext).CheckRadios1();
        }

        private void Delivery2RB_Checked(object sender, RoutedEventArgs e)
        {
            ((DeliveryVM)DataContext).CheckRadios2();
        }

        private void Address1RB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Address2RB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BackMenuB_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Menu();
            newWindow.Show();
            Close();
        }

        private void BackCartB_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Cart();
            newWindow.Show();
            Close();
        }

        private void ToPaymentB_Click(object sender, RoutedEventArgs e)
        {
            ((DeliveryVM)DataContext).AddAddress();
            cart.Price = ((DeliveryVM)DataContext).Price;
            var newWindow = new Payment(cart, del) ;
            newWindow.Show();
            Close();
        }
    }
}
