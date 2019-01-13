using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using User.Model;
using User.Service;

namespace User.ViewModel
{
    public class LoginPanelVM : BaseViewModel
    {
        private Question _selectedQuestion;
        private string _name;
        private string _surname;
        private string _nick;
        private string _phone;
        private string _email;
        private string _email2;
        private string _answer;
        private string _passwordInput1;
        private string _passwordInput2;


        public ICommand RegisterButton { get;  protected set; }
        public ICommand LoginButton { get; protected set; }

        
        public LoginPanelVM()
        {
            QuestionManager qm = new QuestionManager();
            Questions = qm.GetAllQuestions();
            RegisterButton = new DelegateCommand(Register);
            LoginButton = new DelegateCommand(Login);
        }

        public void Register()
        {
            Validation();

            if (!error)
            {
                Address a1 = new Address();
                Question q1 = SelectedQuestion;
                UserManager um = new UserManager();
                um.Create(Nick, Name, Surname, Email, Phone,a1, q1, Answer, Password);
//                um.Create(Nick, Name, Surname, adr, qeust, Answer, Password);
                MessageBox.Show("Zarejestrowano konto!\nMożesz się zalogować");
                //todo obsluga bledu polaczenia
                //todo czyszczenie hasła
                ClearValues();
            }
        }
        
        public void Login()
        {
            UserManager um = new UserManager();
           // um.Login(Nick, Password);
            UserData.id = um.Login(Nick, Password);
        }
        
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
                errorMsg = errorMsg + "NUMER TELEFONU jest polem obowiązkowy\n";
                
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
            if (string.IsNullOrEmpty(Password))
            {
                error = true;
                errorMsg = errorMsg + "HASŁO jest polem obowiązkowym\n";
                
            }

            if (Password != null)
            {
                if (Password2 != Password3)
                {
                    error = true;
                    errorMsg = errorMsg + "Podane HASŁA muszą być jednakowe!";
                }
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

        private void ClearValues()
        {
            Name = String.Empty;
            Surname = String.Empty;
            Nick = String.Empty;
            Phone = String.Empty;
            Email = String.Empty;
            Email2 = String.Empty;
            PasswordInput1 = String.Empty;
            PasswordInput2 = String.Empty;
            Answer = String.Empty;
            SelectedQuestion = null;
        }

        public string PasswordInput2
        {
            get => _passwordInput2;
            set
            {
                _passwordInput2 = value;
                NotifyPropertyChanged(nameof(PasswordInput2));
            }
        }

        public string PasswordInput1
        {
            get => _passwordInput1;
            set
            {
                _passwordInput1 = value;
                NotifyPropertyChanged(nameof(PasswordInput1));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            } 
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                NotifyPropertyChanged(nameof(Surname));
            }
        }

        public string Nick
        {
            get => _nick;
            set
            {
                _nick = value;
                NotifyPropertyChanged(nameof(Nick));
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                NotifyPropertyChanged(nameof(Phone));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                NotifyPropertyChanged(nameof(Email));
            }
        }

        public string Email2
        {
            get => _email2;
            set
            {
                _email2 = value;
                NotifyPropertyChanged(nameof(Email2));
            }
        }

        public string Password { get; set; }
        public string Password2 { get; set; }   
        public string Password3 { get; set; }
        public string Nick2 { get; set; }

        public string Answer    
        {
            get => _answer;
            set 
            {
                _answer = value;
                NotifyPropertyChanged(nameof(Answer));
            }
        }

        private bool error { get; set; }

        public List<Question> Questions { get; set; }

        public Question SelectedQuestion
        {
            get => _selectedQuestion;
            set
            {
                _selectedQuestion = value;
                NotifyPropertyChanged(nameof(SelectedQuestion));
            }
        }
        
    }
}
