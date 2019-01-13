using System;
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
        private string _adrUlica;
        private string _adrNumer;
        private string _adrKod;
        private string _adrMiasto;

        public ICommand SaveButton { get;  protected set; }
        public ICommand RetriveButton { get;  protected set; }

        
        public UserPanelVM()
        {
            RetriveButton = new DelegateCommand(DisplayUser);
            SaveButton = new DelegateCommand(Save);

        }

        public void Save()
        {
            //todo zapis do bazy && wpis do 'interfejsu'
            UserData.nick = Login;
        }
        
        public void DisplayUser()
        {
            UserManager um = new UserManager();
            Model.User responseUser = um.Get(UserData.id.ToString());
//            Console.WriteLine(responseUser.);
            Login = responseUser.Nick;
            Imie = responseUser.Name;
            Nazwisko = responseUser.Surname;
            Tel = responseUser.Phone;
            Mail = responseUser.Email;
            AdrUlica = responseUser.Address.Street;
            AdrKod = responseUser.Address.PostalCode;
            AdrMiasto = responseUser.Address.City;
            
//            NotifyPropertyChanged("Login");
//            NotifyPropertyChanged("Imie");
//            NotifyPropertyChanged("Nazwisko");
//            NotifyPropertyChanged("Mail");
//            NotifyPropertyChanged("AdrUlica");
//            NotifyPropertyChanged("AdrKod");
//            NotifyPropertyChanged("AdrMiasto");

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

        public string Mail2 { get; set; }

//        public string Haslo { get; set; }
        public string AdrUlica
        {
            get => _adrUlica;
            set 

            {
                _adrUlica = value;
                NotifyPropertyChanged(nameof(AdrUlica));
            }
        }

        public string AdrNumer
        {
            get => _adrNumer;
            set 
            {
                _adrNumer = value;
                NotifyPropertyChanged(nameof(AdrNumer));
            }
        }

        public string AdrKod
        {
            get => _adrKod;
            set
            {
                _adrKod = value;
                NotifyPropertyChanged(nameof(AdrKod));
            }
        }

        public string AdrMiasto
        {
            get => _adrMiasto;
            set
            {
                _adrMiasto = value;
                NotifyPropertyChanged(nameof(AdrMiasto));
            }
        }
    }
}