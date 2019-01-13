using System;
using System.Windows.Input;
using User.Service;

namespace User.ViewModel
{
    public class UserPanelVM : BaseViewModel
    {
        public string Login { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Mail2 { get; set; }
//        public string Haslo { get; set; }
        public string AdrUlica { get; set; }
        public string AdrNumer { get; set; }
        public string AdrKod { get; set; }
        public string AdrMiasto { get; set; }

        public ICommand SaveButton { get;  protected set; }
        public ICommand RetriveButton { get;  protected set; }

        
        public UserPanelVM()
        {
//            Name = "aaaa";
            RetriveButton = new DelegateCommand(DisplayUser);

        }

        public void DisplayUser()
        {
            UserManager um = new UserManager();
            Model.User responseUser = um.Get("2");
//            Console.WriteLine(responseUser.);
            Login = responseUser.nick;
            Imie = responseUser.name;
            Nazwisko = responseUser.surname;
            Tel = responseUser.phone;
            Mail = responseUser.email;
            AdrUlica = responseUser.address.street;
//            AdrNumer = responseUser.address.;
            AdrKod = responseUser.address.postalCode;
            AdrMiasto = responseUser.address.city;
            
            NotifyPropertyChanged("Login");
            NotifyPropertyChanged("Imie");
            NotifyPropertyChanged("Nazwisko");
            NotifyPropertyChanged("Mail");
            NotifyPropertyChanged("AdrUlica");
            NotifyPropertyChanged("AdrKod");
            NotifyPropertyChanged("AdrMiasto");

        }
    }
}