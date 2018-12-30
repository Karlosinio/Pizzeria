using ServiceNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MenuViewModel
{
    public class RatingsVM : INotifyPropertyChanged
    {
        #region DataContext
        public Double AvgRating { set; get; }
        public static int Rate { set; get; }
        public ICommand Click_SendRate { get; }
        public static Action CloseAction { get; set; }
        public Service service = new Service();
        #endregion

        #region constructors
        public RatingsVM()
        {
            AvgRating = service.GetAverageRating();
            Click_SendRate = new RelayCommand(MVSendRate);
        }
        #endregion

        #region ICommand
        public void MVSendRate()
        {
            service.SendRate(Rate, 4); //user id to change
            CloseAction();
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
        #endregion
    }
}
