using CartBackend;
using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Component = CartBackend.Common.Models.Component;

namespace CartViewModel
{
    public class CartEditVM : INotifyPropertyChanged
    {
        public ComponentDTO SelectedComponent { get; set; }
        public ObservableCollection<ComponentDTO> Components { get; set; }
        public List<ComponentDTO> ListOfComponents { get; set; }
        public ProductDTO SelectedProductToEdit { get; set; }
        public String SelectedProductToEditName { get; set; }

        public CartEditVM(Object product)
        {
            SelectedProductToEdit = (ProductDTO) product;
            SelectedProductToEditName = SelectedProductToEdit.Name;

            Components = new ObservableCollection<ComponentDTO>();

            if (SelectedProductToEdit.Component != null)
                foreach (var item in SelectedProductToEdit.Component)
                    Components.Add(item);

            Delete = new DelegateCommand(Delete_Component_From_Product);
            Back = new DelegateCommand(Back_To_Basket);
        }

        public ICommand Delete { get; }
        public ICommand Back { get; }

        public void Back_To_Basket()
        {

        }

        public void Delete_Component_From_Product()
        {
            if (SelectedComponent != null)
            {

                if (SelectedComponent.Quantity == 1)
                    Components.Remove(SelectedComponent);
                else
                {
                    SelectedComponent.Quantity -= 1;
                    var index = Components.IndexOf(SelectedComponent);
                    Components.Insert(index, SelectedComponent);
                    Components.RemoveAt(index + 1);
                    RaisePropertyChanged("Components");
                }

            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
        #endregion
    }
}
