using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public Question Question { get; set; }
        public string Answer { get; set; }
        public bool Active { get; set; }
        public bool LoggedIn { get; set; }
        public bool Admin { get; set; }
        public bool AbleToChangePassword { get; set; }

        
//        public User(string Nick, string Name, string Surname, string a, string q, string Answer, string Password)
//        {
//            nick = Nick;
//            name = Name;
//            surname = Surname;
//            _address = a;
//            //            email = Email;
//            //            phone = Phone;
//            _question = q;
//            answer = Answer;
//            password = Password;
//        }
//        
//        public User(string Nick, string Name, string Surname, string Phone, string Email, Address a, Question q, string Answer, string Password)
//        {
//            nick = Nick;
//            name = Name;
//            surname = Surname;
//            address = a;
//            email = Email;
//            phone = Phone;
//            question = q;
//            answer = Answer;
//            password = Password;
//
//        }
//        
//        public User(int Id, string Nick, string Name, string Surname, string Phone, string Email, Address a, Question q,
//            bool Active, bool LoggedIn, bool Admin, bool AbleToChangePassword, string CreateTimestamp, string UpdateTimestamp)
//        {
//            id = Id;
//            name = Name;
//            surname = Surname;
//            email = Email;
//            phone = Phone;
//            nick = Nick;
//            address = a;
//            question = q;
//            createTimestamp = CreateTimestamp;
//            updateTimestamp = UpdateTimestamp;
//            active = Active;
//            loggedIn = LoggedIn;
//            admin = Admin;
//            ableToChangePassword = AbleToChangePassword;
//        }
//
//        public User(string Nick, string Password)
//        {
//            nick = Nick;
//            password = Password;
//        }
//
//        public User()
//        {
//            
//        }

    }
   

}
