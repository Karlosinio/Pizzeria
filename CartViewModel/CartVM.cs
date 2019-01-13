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

        public ProductDTO SelectedProduct { get; set; }

        public CartVM()
        {
            Component comp = new Component
            {
                Id = 1,
                Name = "sss",
                Price = 33
            };

            Component comp4 = new Component
            {
                Id = 4,
                Name = "sss",
                Price = 33
            };

            ComponentDTO dto4 = new ComponentDTO
            {
                Component = comp4,
                Quantity = 33
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

            List<ComponentDTO> list2 = new List<ComponentDTO>
            {
                dto4
            };



            Price = 0;
            Products = new ObservableCollection<ProductDTO>
            {
                new ProductDTO { Id=1, Name = "cos", Price=20, Component = list, Quantity = 1},
                new ProductDTO { Id=2, Name = "adasd", Price=20, Quantity = 1 },
                new ProductDTO { Id=3, Name = "cofgdfgs", Price=20, Quantity = 1 },
                new ProductDTO { Id=4, Name = "casgfgos", Price=45, Component = list2, Quantity = 1 },
                new ProductDTO { Id=5, Name = "cdghfgdhos", Price=3, Quantity = 1 },
                new ProductDTO { Id=6, Name = "asadasdcos", Price=200, Quantity = 1},
            };
            
            foreach(var product in Products)
            {
                if (product.Quantity >0 )
                    if(product.Component != null)
                    {
                        foreach (var component in product.Component)
                        {
                            Price += component.Component.Price;
                            RaisePropertyChanged("Price");

                        }
                    }
                if (product.Quantity > 0)
                {
                    Price += product.Price;
                    RaisePropertyChanged("Price");
                }
                    

            }
            DeleteAll = new DelegateCommand(DeleteAllProductFromCart);
            //Edit = new DelegateCommand(EditProductFromCart);
            Delete = new DelegateCommand(DeleteProductFromCart);
            AddQuantity = new DelegateCommand(AddQuantityToProduct);
            Button_Add_Quantity = new DelegateCommand(Button_Add_Quantity_Change);
            Button_Delete_Quantity = new DelegateCommand(Button_Delete_Quantity_Change);
        }

        public ICommand DeleteAll { get; }
        public ICommand Order { get; }
        public ICommand Edit { get; }
        public ICommand Delete { get; }
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

        private void AddQuantityToProduct()
        {
            if (SelectedProduct != null)
            {
                Price += SelectedProduct.Price * QuantityAddDelete;
                RaisePropertyChanged("Price");

                SelectedProduct.Quantity += QuantityAddDelete;
                var index = Products.IndexOf(SelectedProduct);
                Products.Insert(index, SelectedProduct);
                Products.RemoveAt(index + 1);
                RaisePropertyChanged("Products");
            }
            
        }
        
        public List<ProductDTO> GetProducts()
        {
            var list = new List<ProductDTO>(Products);
            return list;
        }

        public Order GetOrder()
        {
            return ListOfProducts.First().Order;
        }

        private void DeleteProductFromCart()
        {
            if (SelectedProduct != null)
                if (SelectedProduct.Quantity == QuantityAddDelete)
                    DeleteAllProductFromCart();
                else if (SelectedProduct.Quantity> QuantityAddDelete)
                {
                    Price -= SelectedProduct.Price * QuantityAddDelete;
                    RaisePropertyChanged("Price");

                    SelectedProduct.Quantity -= QuantityAddDelete;
                    var index = Products.IndexOf(SelectedProduct);
                    Products.Insert(index, SelectedProduct);
                    Products.RemoveAt(index + 1);

                    RaisePropertyChanged("Products");
                }


        }

        private void DeleteAllProductFromCart()
        {
            if (SelectedProduct != null)
            {
                Price -= SelectedProduct.Price * SelectedProduct.Quantity;
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
