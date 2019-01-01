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
using Component = CartBackend.Common.Models.Component;


namespace CartViewModel
{
    public class CartVM : INotifyPropertyChanged
    {
        public ObservableCollection<ProductDTO> Products { get; set; }
        private List<Order_Product> ListOfProducts { get; set; }
        private double price = 0;
        public double Price { get {
                return price;
            } set {
                if(value != price)
                {
                    price = value;
                    RaisePropertyChanged("Price");
                }
            } }
        public ProductDTO SelectedProduct { get; set; }

        public CartVM()
        {
            Component comp = new Component
            {
                Id = 1,
                Name = "sss",
                Price = 33
            };

            ComponentDTO dto = new ComponentDTO
            {
                Component = comp,
                Quantity = 3
            };
            Component comp2 = new Component
            {
                Id = 2,
                Name = "ssasdasds",
                Price = 337
            };

            ComponentDTO dto2 = new ComponentDTO
            {
                Component = comp2,
                Quantity = 2
            };
            Component comp3 = new Component
            {
                Id = 3,
                Name = "sssasdasd",
                Price = 332
            };

            ComponentDTO dto3 = new ComponentDTO
            {
                Component = comp3,
                Quantity = 7
            };

            List<ComponentDTO> list = new List<ComponentDTO>
            {
                dto,
                dto2,
                dto3
            };
            Price = 0;
            Products = new ObservableCollection<ProductDTO>
            {
                new ProductDTO { Id=1, Name = "cos", Price=20, Component = list},
                new ProductDTO { Id=2, Name = "adasd", Price=20 },
                new ProductDTO { Id=3, Name = "cofgdfgs", Price=20 },
                new ProductDTO { Id=4, Name = "casgfgos", Price=45, Component = list },
                new ProductDTO { Id=5, Name = "cdghfgdhos", Price=3 },
                new ProductDTO { Id=6, Name = "asadasdcos", Price=200},
            };
            
            foreach(var product in Products)
            {
                if(product.Component != null)
                {
                    foreach (var component in product.Component)
                    {
                        Price += component.Component.Price;
                        RaisePropertyChanged("Price");

                    }
                }

                Price += product.Price;
                RaisePropertyChanged("Price");

            }
            Delete = new DelegateCommand(DeleteProductFromCart);
            Edit = new DelegateCommand(EditProductFromCart);
        }

        public ICommand Delete { get; }
        public ICommand Order { get; }
        public ICommand Edit { get; }

        private void EditProductFromCart()
        {
        }

        private void DeleteProductFromCart()
        {
            if(SelectedProduct != null)
            {
                Price -= SelectedProduct.Price;
                RaisePropertyChanged("Price");
                Products.Remove(SelectedProduct);
            }

        }

        //przeznaczone dla menu lub z ktorego miejsca będą dodawane produkty do koszyka
        public void AddProduct(ProductDTO product)
        {
            //check if product isn't in the cart already
            if (Products.Contains(product))
            {
                product.Quantity++;
                var id = Products.Where(x => x.Equals(product)).FirstOrDefault().Id;
                Products[id] = product;
            }
            else
            {
                Products.Add(product);
            }

            Price += product.Price;
            RaisePropertyChanged("Price");
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
