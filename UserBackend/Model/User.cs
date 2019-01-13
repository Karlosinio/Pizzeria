using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Model
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string nick { get; set; }
        public string password { get; set; }
        public Address address { get; set; }
        public Question question { get; set; }
        public string answer { get; set; }
        public bool active { get; set; }
        public bool loggedIn { get; set; }
        public bool admin { get; set; }
        public bool ableToChangePassword { get; set; }
        public DateTime createTimestamp { get; set; }
        public DateTime updateTimestamp { get; set; }

        
        public string _address { get; set; }
        public string _question { get; set; }


        public User(string Nick, string Name, string Surname, string a, string q, string Answer, string Password)
        {
            nick = Nick;
            name = Name;
            surname = Surname;
            _address = a;
            //            email = Email;
            //            phone = Phone;
            _question = q;
            answer = Answer;
            password = Password;
        }
        
        public User(string Nick, string Name, string Surname, string Phone, string Email, Address a, Question q, string Answer, string Password)
        {
            nick = Nick;
            name = Name;
            surname = Surname;
            address = a;
            email = Email;
            phone = Phone;
            question = q;
            answer = Answer;
            password = Password;

        }
        
        public User(int Id, string Nick, string Name, string Surname, string Phone, string Email, Address a, Question q,
            bool Active, bool LoggedIn, bool Admin, bool AbleToChangePassword, DateTime CreateTimestamp, DateTime UpdateTimestamp)
        {
            id = Id;
            name = Name;
            surname = Surname;
            email = Email;
            phone = Phone;
            nick = Nick;
            address = a;
            question = q;
            createTimestamp = CreateTimestamp;
            updateTimestamp = UpdateTimestamp;
            active = Active;
            loggedIn = LoggedIn;
            admin = Admin;
            ableToChangePassword = AbleToChangePassword;
        }

        public User(string Nick, string Password)
        {
            nick = Nick;
            password = Password;
        }

        public User()
        {
            
        }

    }
   

}
