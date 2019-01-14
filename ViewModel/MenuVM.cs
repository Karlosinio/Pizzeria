using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MenuModel;
using ServiceNS;
using CartBackend.Common.DTO;
using System.Collections.Generic;

namespace MenuViewModel
{
    public class MenuVM : INotifyPropertyChanged
    {
        #region DataContext
        public ObservableCollection<product> pizzas { get; set; }
       // public ICommand Click_Koszyk { get; }
        public ICommand Click_Konto { get; }
        public Service service = new Service();

        public product SelectedProduct { get; set; }
        public ObservableCollection<ProductDTO> cartProducts { get; set; }
        #endregion

        #region constructors
        public MenuVM()
        {
            pizzas = service.GetProducts();
            if (cartProducts == null)
                cartProducts = new ObservableCollection<ProductDTO>();
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
        #endregion
    }
}
