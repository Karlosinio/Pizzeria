﻿using System;
using System.Windows.Forms;
using System.Windows.Input;
using User.Model;
using User.Service;

namespace User.ViewModel
{
    public class UserPanelVM : BaseViewModel
    {
        private string _login;
        private string _imie;
        private string _nazwisko;
        private string _tel;
        private string _mail;
        private string _mail2;

        private bool error { get; set; }
        public ICommand SaveButton { get;  protected set; }
        public ICommand RetriveButton { get;  protected set; }

        
        public UserPanelVM()
        {
            RetriveButton = new DelegateCommand(DisplayUser);
            SaveButton = new DelegateCommand(Save);

        }

        public void DisplayUser()
        {
            UserManager um = new UserManager();
            Model.User responseUser = um.Get(UserData.id);
//            Console.WriteLine(responseUser.);
            Login = responseUser.Nick;
            Imie = responseUser.Name;
            Nazwisko = responseUser.Surname;
            Tel = responseUser.Phone;
            Mail = responseUser.Email;
        }
        
        public void Save()
        {
            Validation();
            if (!error)
            {
//                Address a1 = new Address() {City = AdrMiasto, Street = AdrUlica, PostalCode = AdrKod};
                UserManager um = new UserManager();
//                um.Update(UserData.id, Imie, Nazwisko, a1, Tel, Mail);
                um.Update(UserData.id, Imie, Nazwisko,  Tel, Mail);
                MessageBox.Show("Zmiany zostały zapisane!");
                //wpis do 'interfejsu'
                UserData.name = Imie;
                UserData.surname = Nazwisko;
                UserData.email = Mail;
                UserData.phone = Tel;
            }
        }

        private void Validation()
        {
            error = false;
            string errorMsg = "";

            if (string.IsNullOrEmpty(Imie))
            {
                error = true;
                errorMsg = errorMsg + "IMIĘ jest polem obowiązkowym\n";
                
            }
            if (string.IsNullOrEmpty(Tel))
            {
                error = true;
                errorMsg = errorMsg + "NUMER TELEFONU jest polem obowiązkowy\n";
                
            }
            if (Tel != null)
            {
                if (!IsDigitsOnly(Tel) || !Tel.Length.Equals(9))
                {
                    error = true;
                    errorMsg = errorMsg + "NUMER TELEFONU jest niepoprawny\n";
                
                }
            }
            if (string.IsNullOrEmpty(Mail))
            {
                error = true;
                errorMsg = errorMsg + "MAIL jest polem obowiązkowym\n";
                
            }
            if (Mail != Mail2)
            {
                error = true;
                errorMsg = errorMsg + "Podane MAILE muszą być jednakowe!\n";
            }
            
            if (error)
            {
                MessageBox.Show(errorMsg);
            }
        }
        
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                NotifyPropertyChanged(nameof(Login));
            }
        }

        public string Imie
        {
            get => _imie;
            set
            {
                _imie = value;
                NotifyPropertyChanged(nameof(Imie));
            }
        }

        public string Nazwisko
        {
            get => _nazwisko;
            set
            {
                _nazwisko = value;
                NotifyPropertyChanged(nameof(Nazwisko));
            }
        }

        public string Tel
        {
            get => _tel;
            set
            {
                _tel = value;
                NotifyPropertyChanged(nameof(Tel));
            }
        }

        public string Mail
        {
            get => _mail;
            set
            {
                _mail = value;
                NotifyPropertyChanged(nameof(Mail));
            }
        }

        public string Mail2
        {
            get => _mail2;
            set
            {
                _mail2 = value;
                NotifyPropertyChanged(nameof(Mail2));
            }
        }

//        public string Haslo { get; set; }
      
    }
}