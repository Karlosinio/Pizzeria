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

        private int quantityAddDelete = 0;
        public int QuantityAddDelete
        {
            get
            {
                return quantityAddDelete;
            }
            set
            {
                if (value != quantityAddDelete)
                {
                    quantityAddDelete = value;
                    RaisePropertyChanged("QuantityAddDelete");
                }
            }
        }

        public CartEditVM(Object product)
        {
            SelectedProductToEdit = (ProductDTO) product;
            SelectedProductToEditName = SelectedProductToEdit.Name;

            Components = new ObservableCollection<ComponentDTO>();

            if (SelectedProductToEdit.Component != null)
                foreach (var item in SelectedProductToEdit.Component)
                    Components.Add(item);

            DeleteAll = new DelegateCommand(Delete_Component_From_Product);
            Delete = new DelegateCommand(DeleteComponentFromCart);
            Back = new DelegateCommand(Back_To_Basket);
            AddQuantity = new DelegateCommand(AddQuantityToProduct);
            Button_Add_Quantity = new DelegateCommand(Button_Add_Quantity_Change);
            Button_Delete_Quantity = new DelegateCommand(Button_Delete_Quantity_Change);
        }

        public ICommand DeleteAll { get; }
        public ICommand Delete { get; }
        public ICommand Back { get; }
        public ICommand AddQuantity { get; }
        public ICommand Button_Add_Quantity { get; }
        public ICommand Button_Delete_Quantity { get; }

        private void Button_Add_Quantity_Change()
        {
            QuantityAddDelete++;
        }

        private void Button_Delete_Quantity_Change()
        {
            if (quantityAddDelete > 0)
            {
                QuantityAddDelete--;
            }

        }

        public void Back_To_Basket()
        {

        }

        private void AddQuantityToProduct()
        {
            if (SelectedComponent != null)
            {
                SelectedComponent.Quantity += QuantityAddDelete;
                var index = Components.IndexOf(SelectedComponent);
                Components.Insert(index, SelectedComponent);
                Components.RemoveAt(index + 1);
                

                RaisePropertyChanged("Components");
            }

        }

        public void Delete_Component_From_Product()
        {
            if (SelectedComponent != null)
                Components.Remove(SelectedComponent);
                
        }

        private void DeleteComponentFromCart()
        {
            if (SelectedComponent != null)
                if (SelectedComponent.Quantity == QuantityAddDelete)
                    Delete_Component_From_Product();
                else if (SelectedComponent.Quantity > QuantityAddDelete)
                {
                    SelectedComponent.Quantity -= QuantityAddDelete;
                    var index = Components.IndexOf(SelectedComponent);
                    Components.Insert(index, SelectedComponent);
                    Components.RemoveAt(index + 1);

                    RaisePropertyChanged("Components");
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
