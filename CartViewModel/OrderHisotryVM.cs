using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using CartBackend.Services;
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
    public class OrderHistoryVM : INotifyPropertyChanged
    {
        public ObservableCollection<ProductDTO> Products { get; set; }
        public ObservableCollection<ProductDTO> ProductsToAddToCart { get; set; }
        public ProductDTO SelectedProduct { get; set; }

        public OrderHistoryVM(int userID)
        {
            Products = new ObservableCollection<ProductDTO>();


            //var orderServce = new OrderService();
            var orderService= new OrderService();
            var order_productService = new BaseService<Order_Product>();
            var order_componentService = new BaseService<Order_Component>();

            var lastOrders = orderService.GetRecentNOrders(5, userID);
            var allOrder_product = order_productService.GetAll();

            for(int i = 0; i< lastOrders.Count && Products.Count < 5; i++)
            {
                var order = lastOrders[i];

                var order_productList = allOrder_product.Where(x => x.Order.Id == order.Id).ToList();

                for(int j =0; j< order_productList.Count && Products.Count < 5; j++)
                {
                    var product = order_productList[j].Product;
                    Products.Add(new ProductDTO
                    {
                        Id = product.Id,
                        Available = product.Available,
                        Category = product.Category,
                        Components = product.Components,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = order_productList[j].Quantity
                    });
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
