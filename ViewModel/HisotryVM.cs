using CartBackend.Common.Models;
using CartBackend.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuViewModel
{
    public class HisotryVM : INotifyPropertyChanged
    {

        ObservableCollection<OrderViewItem> Orders { get; set; }

        public HisotryVM(int userID)
        {
            var service = new BaseService<Order>();
            var listOfOrders = service.GetAll().Where(x => x.User.Id == userID).ToList();
            Orders = new ObservableCollection<OrderViewItem>();

            foreach (var e in listOfOrders)
                Orders.Add(new OrderViewItem(e));
            

        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }

        #endregion

    }


    public class OrderViewItem {

        public int Id { get; set; }
        public string Comment { get; set; }
        public bool Deleted { get; set; }
        public bool DiscountUsed { get; set; }
        public float Price { get; set; }
        public string Date { get; set; }
        public Discount Discount { get; set; }
        public User User { get; set; }


        public OrderViewItem(Order order)
        {
            Id = order.Id;
            Comment = order.Comment;
            Deleted = order.Deleted;
            DiscountUsed = order.DiscountUsed;
            Price = order.Price;
            Date = new DateTime(order.OrderTimestamp).ToShortDateString();
            Discount = order.Discount;
            User = order.User;
        }
    }
}
