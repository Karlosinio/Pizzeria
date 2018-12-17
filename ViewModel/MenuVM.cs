using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MenuModel;
using ServiceNS;

namespace MenuViewModel
{
    public class MenuVM : INotifyPropertyChanged
    {
        #region DataContext
        public ObservableCollection<product> pizzas { get; set; }
        public string PathVariable { get; set; }
        //public Visibility ChangeControlVisibility { get; set; } = Visibility.Hidden;
        public ICommand Click_Koszyk { get; }
        public ICommand Click_Konto { get; }
        public Service service = new Service();
        #endregion

        #region constructors
        public MenuVM()
        {
            pizzas = service.GetProducts();
            //Click_Button = new RelayCommand(LoadDLL);
            //Click_Browse = new RelayCommand(Browse);
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
        #endregion

        #region private

        #endregion
    }
}
