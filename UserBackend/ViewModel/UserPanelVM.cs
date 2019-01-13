using System.Windows.Input;
using User.Service;

namespace User.ViewModel
{
    public class UserPanelVM
    {
        public string Login { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Haslo { get; set; }
        public string AdrUlica { get; set; }
        public string AdrNumer { get; set; }
        public string AdrKod { get; set; }
        public string AdrMiasto { get; set; }
        public ICommand SaveButton { get;  protected set; }

        
        public UserPanelVM()
        {
//            Name = "aaaa";
            
        }

        public void Save()
        {
            
        }
    }
}