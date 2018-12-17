using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using CartBackend.Configuration;
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
        private BaseRepository<OrderComponent> _orderComponentRepository = new BaseRepository<OrderComponent>();
        private BaseRepository<Order_Product> _orderProductRepository = new BaseRepository<Order_Product>();
        private BaseRepository<Product> _productRepository = new BaseRepository<Product>();
        #endregion

        public void Insert (OrderDTO order)
        {
            var mapper = AutoMapperCfg.GetProductMapper();
            var pureOrder = order.Order;

            try
            {
                var orderID = base.Insert(pureOrder);

                foreach (var orderProduct in order.Products)
                {
                    orderProduct.Quantity = 1;

                    var tmpOrder = base.GetByID(orderID);
                    orderProduct.Order = tmpOrder;

                    _orderProductRepository.Insert(orderProduct);

                }

            }
            catch(Exception e)
            {
                //ex handler
            }
        }
    }
}
