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
        public string answer { get; set; }
        public string nick { get; set; }
//        public Address address { get; set; }
        public string password { get; set; }
//        public Question question { get; set; }
        public bool active { get; set; }
        public bool loggedIn { get; set; }
        public bool admin { get; set; }
        public bool ableToChangePassword { get; set; }

        //
        public string address { get; set; }
        public string question { get; set; }

        

//        public User(string Nick, string Name, string Surname, Address a, Question q, string Answer, string Password)
        public User(string Nick, string Name, string Surname, string a, string q, string Answer, string Password)
        {
            nick = Nick;
            name = Name;
            surname = Surname;
            address = a;
//            email = Email;
//            phone = Phone;
            question = q;
            answer = Answer;
            password = Password;

        }

        public User(string Nick, string Password)
        {
            nick = Nick;
            password = Password;
        }

    }
}
