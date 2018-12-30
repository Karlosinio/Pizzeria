using CartViewModel;
using DeliveryBackend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryViewModel
{
    public class DeliveryVM : BaseViewModel
    {
        public string Street { get; set; }
        public int Number { get; set; }

        public string City { get; set; }
        public string PostalCode { get; set; }

        public DeliveryVM()
        {
            Street = "Dziunia";
            Number = 69;
            City = "Siankowo";
            PostalCode = "96-997";

            ToPayment = new DelegateCommand(AddAddress);

        }
        //TODO Nadpisz adres
        private void AddAddress()
        {
            AddressManager manager = new AddressManager();
            // manager.Create("test", 1234, Street, City, PostalCode);
            
        }

        public ICommand ToPayment { get; private set; }


    }
}
