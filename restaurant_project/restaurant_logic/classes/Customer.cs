using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_logic.classes
{
    public class Customer
    {
        string _name;
        string _address;
        Order _currentOrder;
        public string Name { get; set; }
        public string Address { get; set; }
        public Order CurrentOrder { get; set; }

        public Customer(string name, string address)
        {
            throw new NotImplementedException();
        }

        public void PlaceOrder(List<Dish> dishes)
        {
            throw new NotImplementedException();
        }
    }
}
