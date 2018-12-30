using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using CartBackend.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Services
{
    public class OrderService : BaseService<Order>
    {
        #region repositories
        private BaseRepository<Order_Component> _orderComponentRepository = new BaseRepository<Order_Component>();
        private BaseRepository<Order_Product> _orderProductRepository = new BaseRepository<Order_Product>();
        #endregion

        public void Insert (OrderDTO order)
        {
            var pureOrder = order.Order;

            try
            {
                var orderID = base.Insert(pureOrder);
                pureOrder.Id = orderID;

                int productIDInOrder = 0;
                foreach(var productDTO in order.Products)
                {
                    productIDInOrder++;
                    var order_product = new Order_Product
                    {
                        Product = new Product { Id = productDTO.Id },
                        Order = pureOrder,
                        ProductIdInOrder = productIDInOrder,
                        Quantity = productDTO.Quantity
                    };

                    //insert
                    var order_productID = _orderProductRepository.Insert(order_product);
                    order_product.Id = order_productID;


                    if (productDTO.Component != null)
                    {
                        var product = new Product { Id = productDTO.Id };
                        foreach (var componentDTO in productDTO.Component)
                        {
                            var order_component = new Order_Component
                            {
                                Component = new Component { Id = componentDTO.Component.Id },
                                Order = pureOrder,
                                ProductIdInOrder = productIDInOrder,
                                Product = product,
                                Quantity = componentDTO.Quantity
                            };

                            var order_componentID = _orderComponentRepository.Insert(order_component);
                        }
                    }

                }

            }
            catch(Exception e)
            {
                //ex handler
            }
        }
    }
}
