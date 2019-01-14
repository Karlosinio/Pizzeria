using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string question { get; set; }
        public override string ToString()
        {
            return question;
        }

//        public Question(int Id, string Question)
//        {
//            id = Id;
//            question = Question;
//        }
//
//        public Question()
//        {
//            
//        }
    }
}
