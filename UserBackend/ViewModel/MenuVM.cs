using System.Windows.Input;
using User.Model;
using User.Service;

namespace User.ViewModel
{
    public class MenuVM : BaseViewModel
    {
        public int ID;

        public ICommand RetriveButton { get;  protected set; }
        public ICommand LogoutButton { get; protected set; }

        public MenuVM()
        {
            LogoutButton = new DelegateCommand(Logout);

        }
        public void Logout()
        {
            
            UserManager um = new UserManager();
            UserData.id = ID;
            um.Logout(ID);

        }



    }

    
}