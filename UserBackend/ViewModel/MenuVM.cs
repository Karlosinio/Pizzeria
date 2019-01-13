using System.Windows.Input;
using User.Service;

namespace User.ViewModel
{
    public class MenuVM
    {
        public ICommand UserPanel { get;  protected set; }

        
        public MenuVM()
        {
            
            UserPanel = new DelegateCommand(DisplayUser);
        }

        public void DisplayUser()
        {
            UserManager um = new UserManager();
            um.Get("2");
        }
    }
}