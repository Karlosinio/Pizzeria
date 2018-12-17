using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Services
{
    public class OrderService
    {
        #region repositories
        private BaseRepository<Order> _orderRepository = new BaseRepository<Order>();
        private BaseRepository<OrderComponent> _orderComponentRepository = new BaseRepository<OrderComponent>();
        #endregion
    }
}
