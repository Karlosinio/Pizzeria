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

            var recentFiveOrders = orderService.GetRecentNOrders(5, userID);
            var allOrder_product = order_productService.GetAll();
            var allOrder_component = order_componentService.GetAll();

            int i = 0;
            do
            {
                var orderId = recentFiveOrders[i].Id;

                var list = allOrder_product.Where(x => x.Order.Id == orderId).ToList();

                int j = 0;
                List<ComponentDTO> components = new List<ComponentDTO>();

                while (j < list.Count && Products.Count < 5)
                {
                    var prod = list[j];

                    components.Clear();
                    foreach(var order_component in allOrder_component)
                    {
                        if (order_component.Order.Id == orderId) {
                                if (prod.ProductIdInOrder == order_component.ProductIdInOrder)
                                {
                                    components.Add(new ComponentDTO { Component = order_component.Component, Quantity = order_component.Quantity });
                                }
                        }
                    }
                    j++;
                    Products.Add(new ProductDTO { Id = prod.Product.Id, Available = prod.Product.Available, Component = components, Category = prod.Product.Category, Name = prod.Product.Name, Price = prod.Product.Price, Quantity = prod.Quantity });

                }
                i++;
            } while (Products.Count < 5);



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
