using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Model
{
    public class Question
    {
        public int id { get; set; }
        public string question { get; set; }

        public Question(int Id, string Question)
        {
            id = Id;
            question = Question;
        }
    }
}
