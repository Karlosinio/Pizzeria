using System.Windows;
using User.ViewModel;
using System;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using User.Model;

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

        private void Button_RestPass(object sender, RoutedEventArgs e)
        {
            var newWindow = new RestorePassword();
            newWindow.Show();
        }

        private void Button_Log(object sender, RoutedEventArgs e)
        {
            var newWindow = new SelectModule();
            Close();
            newWindow.Show();
        }

        private void TextBox_TextChanged_2(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

       private void poleHasla_pb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            podaneHaslo_tb.Text = (sender as PasswordBox).Password; 
        }

        private void poleHasla_pb_PasswordChanged1(object sender, RoutedEventArgs e)
        {
            podaneHaslo_tb1.Text = (sender as PasswordBox).Password;
        }
        private void poleHasla_pb_PasswordChanged2(object sender, RoutedEventArgs e)
        {
            podaneHaslo_tb2.Text = (sender as PasswordBox).Password;
        }

        private string MD5(string Value)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }

        private void Hash_TextChanged1(object sender, TextChangedEventArgs e)
        {

        }
        private void Hash_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void podaneHaslo_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Hash_MD5.Text = MD5(podaneHaslo_tb.Text);
        }
        private void podaneHaslo_tb_TextChanged1(object sender, TextChangedEventArgs e)
        {
            Hash_MD51.Text = MD5(podaneHaslo_tb1.Text);
        }


    }
    public static class PasswordBoxAssistant 
        {
            public static readonly DependencyProperty BoundPassword =
                DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxAssistant), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

            public static readonly DependencyProperty BindPassword = DependencyProperty.RegisterAttached(
                "BindPassword", typeof(bool), typeof(PasswordBoxAssistant), new PropertyMetadata(false, OnBindPasswordChanged));

            private static readonly DependencyProperty UpdatingPassword =
                DependencyProperty.RegisterAttached("UpdatingPassword", typeof(bool), typeof(PasswordBoxAssistant), new PropertyMetadata(false));

            private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                PasswordBox box = d as PasswordBox;

                // only handle this event when the property is attached to a PasswordBox
                // and when the BindPassword attached property has been set to true
                if (d == null || !GetBindPassword(d))
                {
                    return;
                }

                // avoid recursive updating by ignoring the box's changed event
                box.PasswordChanged -= HandlePasswordChanged;

                string newPassword = (string)e.NewValue;

                if (!GetUpdatingPassword(box))
                {
                    box.Password = newPassword;
                }

                box.PasswordChanged += HandlePasswordChanged;
            }

            private static void OnBindPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
            {
                // when the BindPassword attached property is set on a PasswordBox,
                // start listening to its PasswordChanged event

                PasswordBox box = dp as PasswordBox;

                if (box == null)
                {
                    return;
                }

                bool wasBound = (bool)(e.OldValue);
                bool needToBind = (bool)(e.NewValue);

                if (wasBound)
                {
                    box.PasswordChanged -= HandlePasswordChanged;
                }

                if (needToBind)
                {
                    box.PasswordChanged += HandlePasswordChanged;
                }
            }

            private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
            {
                PasswordBox box = sender as PasswordBox;

                // set a flag to indicate that we're updating the password
                SetUpdatingPassword(box, true);
                // push the new password into the BoundPassword property
                SetBoundPassword(box, box.Password);
                SetUpdatingPassword(box, false);
            }

            public static void SetBindPassword(DependencyObject dp, bool value)
            {
                dp.SetValue(BindPassword, value);
            }

            public static bool GetBindPassword(DependencyObject dp)
            {
                return (bool)dp.GetValue(BindPassword);
            }

            public static string GetBoundPassword(DependencyObject dp)
            {
                return (string)dp.GetValue(BoundPassword);
            }

            public static void SetBoundPassword(DependencyObject dp, string value)
            {
                dp.SetValue(BoundPassword, value);
            }

            private static bool GetUpdatingPassword(DependencyObject dp)
            {
                return (bool)dp.GetValue(UpdatingPassword);
            }

            private static void SetUpdatingPassword(DependencyObject dp, bool value)
            {
                dp.SetValue(UpdatingPassword, value);
            }
        }


    
}




