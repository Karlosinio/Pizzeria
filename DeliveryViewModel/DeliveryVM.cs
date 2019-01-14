using CartViewModel;
using DeliveryBackend.Model;
using DeliveryBackend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using User.Model;

namespace DeliveryViewModel
{
    public class DeliveryVM : BaseViewModel
    {
        public CartVM CartModel { get; set; }
        public DeliveryBackend.Model.Address AddressModel { get; set; } = new DeliveryBackend.Model.Address("Brak", 123,"Brak","Brak","Brak");
        public DeliveryBackend.Model.Address NewAddress { get; set; } = new DeliveryBackend.Model.Address();
        /*
        public string Street { get; set; }
        public int Number { get; set; }

        public string City { get; set; }
        public string PostalCode { get; set; }
        */
        public double Price { get; set; }
        public bool btn1 { get; set; } = false;
        public bool btn2 { get; set; } = false;
        public bool delBtn { get; set; } = false;
        public bool flag { get; set; } = false;


        public DeliveryVM(CartVM vm)
        {
            CartModel = vm;
            UserData.address = new User.Model.Address()
            {
                Id = 1
            };
            GetUserAddress();
            /*
            Street = "Dziunia";
            Number = 69;
            City = "Siankowo";
            PostalCode = "96-997";
            */
            Price = vm.Price;
            ToPayment = new DelegateCommand(AddAddress);

        }

        public void GetUserAddress()
        {
            AddressManager add = new AddressManager();
            AddressModel = add.Get(UserData.address.Id);
        }

        //TODO Nadpisz adres
        public void AddAddress()
        {
            if (delBtn == true)
            {
                return;
            }
            else
            {
                AddressManager manager = new AddressManager();
                //DeliveryBackend.Model.Address add = new DeliveryBackend.Model.Address("test", Number, City, PostalCode, Street);

                NewAddress.id = UserData.address.Id;
                //AddressModel = add;

                manager.Update(UserData.address.Id, NewAddress);
                //manager.Create(add);
            }

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
