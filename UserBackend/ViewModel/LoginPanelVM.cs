using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
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
        public string Answer { get; set; }

        public ICommand RegisterButton { get;  protected set; }
        

        public LoginPanelVM()
        {
//            Name = "aaaa";
            RegisterButton = new DelegateCommand(Register);
        }

        public void Register()
        {
            //TODo

//            Address a1 = new Address("Test address", "City", "12-345", "Street 1");
//            Question q1 = new Question(,"question1");

            string adr = "{{\"name\": \"Test address\",\"street\": \"Street 1\"}}";
            string qeust = "{{\"id\": 1,\"question\":\"question1\"}}";

            UserManager um = new UserManager();
//            um.Create(Nick, Name, Surname, a1, q1, Answer, Password);
            um.Create(Nick, Name, Surname, adr, qeust, Answer, Password);
//            Name = "bbb";
//            NotifyPropertyChanged("Name");
        }
    }
}
