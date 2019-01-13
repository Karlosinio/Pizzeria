using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Newtonsoft.Json;
using User.Model;
using User.Service;

namespace User.ViewModel
{
    public class LoginPanelVM : BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nick { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }   
        public string Password3 { get; set; }
        public string Questions { get; set; }
        public string Answer { get; set; }
        private bool error { get; set; }

<<<<<<< HEAD
        public ICommand RegisterButton { get; protected set; }
        public ICommand LoginButton { get; protected set; }
=======
        public ICommand RegisterButton { get;  protected set; }
>>>>>>> 1e92f37ab74d18754a7434a75a11f2d1478ebef4

       
        public LoginPanelVM()
        {
//            Name = "aaaa";
            RegisterButton = new DelegateCommand(Register);
            LoginButton = new DelegateCommand(Login);
        }

        public void Register()
        {
            Validation();
            //TODo
//            Address a1 = new Address("Test address", "City", "12-345", "Street 1");
//            Question q1 = new Question(,"question1");

            string adr = "{{\"name\": \"Test address\",\"street\": \"Street 1\"}}";
            string qeust = "{{\"id\": 1,\"question\":\"question1\"}}";

            if (!error)
            {
                UserManager um = new UserManager();
//            um.Create(Nick, Name, Surname, a1, q1, Answer, Password);
                um.Create(Nick, Name, Surname, adr, qeust, Answer, Password);
                
            }
//            Name = "bbb";
//            NotifyPropertyChanged("Name");
        }
<<<<<<< HEAD
        public void Login()
        {
            UserManager um = new UserManager();
            um.Login(Nick, Password);
        }
    
=======
        
        public void Validation()
        {
            error = false;
            string errorMsg = "";
            if (string.IsNullOrEmpty(Name))
            {
                error = true;
                errorMsg = errorMsg + "IMIĘ jest polem obowiązkowym\n";
                
            }
            if (string.IsNullOrEmpty(Nick))
            {
                error = true;
                errorMsg = errorMsg + "LOGIN jest polem obowiązkowym\n";
                
            }
            if (string.IsNullOrEmpty(Phone))
            {
                error = true;
                errorMsg = errorMsg + "NUMER TELEFONU jest polem obowiązkowym\n";
                
            }
            if (Phone != null)
            {
                if (!IsDigitsOnly(Phone) || !Phone.Length.Equals(9))
                {
                    error = true;
                    errorMsg = errorMsg + "NUMER TELEFONU jest niepoprawny\n";
                
                }
            }
            if (string.IsNullOrEmpty(Email))
            {
                error = true;
                errorMsg = errorMsg + "MAIL jest polem obowiązkowym\n";
                
            }
            if (Email != Email2)
            {
                error = true;
                errorMsg = errorMsg + "Podane MAILE muszą być jednakowe!\n";
            }
            if (Password2 != Password3)
            {
                error = true;
                errorMsg = errorMsg + "Podane HASŁA muszą być jednakowe!";
            }
            MessageBox.Show(errorMsg);
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
>>>>>>> 1e92f37ab74d18754a7434a75a11f2d1478ebef4
    }
    
}
