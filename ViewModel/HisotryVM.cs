using CartBackend.Common.Models;
using CartBackend.Services;
using GUI.ViewItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuViewModel
{
    public class HistoryVM : INotifyPropertyChanged
    {

        public ObservableCollection<OrderViewItem> Orders { get; set; }

        public HistoryVM(int userID)
        {
            var service = new BaseService<Order>();
            var listOfOrders = service.GetAll().Where(x => x.User.Id == userID).ToList();
            Orders = new ObservableCollection<OrderViewItem>();

            foreach (var e in listOfOrders)
                Orders.Add(new OrderViewItem(e));

            RaisePropertyChanged("Orders");
            

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
