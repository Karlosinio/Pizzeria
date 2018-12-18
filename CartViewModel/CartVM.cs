using CartBackend;
using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using CartBackend.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CartViewModel
{
    public class CartVM : INotifyPropertyChanged
    {
        public ObservableCollection<ProductDTO> Products { get; set; }
        private List<Order_Product> listOfProducts { get; set; }
        public double Price { get; set; }
        public ProductDTO SelectedProduct { get; set; }

        public CartVM()
        {
            Products = new ObservableCollection<ProductDTO>
            {
                new ProductDTO { Id=1, Name = "cos", Price=20}
            };
            Price = 20;

            Delete = new DelegateCommand(DeleteProductFromCart);

        }

        public ICommand Delete { get; }
        public ICommand Order { get; }

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
            Products.Add(product);
            Price += product.Price;
            RaisePropertyChanged("Price");
        }

        public List<Order_Product> GetOrderProducts()
        {
            //tutaj przełączenie między oknami, do zamówień powinno pójść lista Products
            var mapper = AutoMapperCfg.GetProductMapper();

            List<Order_Product> list = new List<Order_Product>();
            var id = 0;
            foreach (var e in Products)
                list.Add(new Order_Product {ProductIdInOrder = id++, Product = mapper.Map<Product>(e) });

            return list;
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
