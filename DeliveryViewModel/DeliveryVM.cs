using CartViewModel;
using DeliveryBackend.Model;
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
        public CartVM CartModel { get; set; }
        public Address AddressModel { get; set; } = new Address("Brak", 123,"Brak","Brak","Brak");

        public string Street { get; set; }
        public int Number { get; set; }

        public string City { get; set; }
        public string PostalCode { get; set; }

        public double Price { get; set; }
        public bool btn1 { get; set; } = false;
        public bool btn2 { get; set; } = false;
        public bool flag { get; set; } = false;


        public DeliveryVM(CartVM vm)
        {
            CartModel = vm;
            Street = "Dziunia";
            Number = 69;
            City = "Siankowo";
            PostalCode = "96-997";
            Price = vm.Price;
            ToPayment = new DelegateCommand(AddAddress);

        }
        //TODO Nadpisz adres
        public void AddAddress()
        {
            AddressManager manager = new AddressManager();
            Address add = new Address("test", 1234, Street, City, PostalCode);
            AddressModel = add;
            manager.Create(add);
        }

        public void CheckRadios1()
        {
            btn1 = true;
            btn2 = false;
            if(flag==true)
            {
                Price = Price - 4;
            }
            NotifyPropertyChanged("Price");
        }
        public void CheckRadios2()
        {
            btn1 = false;
            btn2 = true;
            flag = true;
            Price = Price + 4;
            NotifyPropertyChanged("Price");
        }

        public int CheckDelivery()
        {
            if(btn1==true)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        public ICommand ToPayment { get; private set; }


    }
}
