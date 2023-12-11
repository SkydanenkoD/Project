using System;
using System.Collections.Generic;

namespace restaurant_logic.classes
{
    public class Customer
    {
        private string _name;
        private string _address;
        private Order _currentOrder;

        public Customer(string name, string address)
        {
            Name = name;
            Address = address;
            _currentOrder = new Order(this);
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address cannot be null or empty.");
                }
                _address = value;
            }
        }

        public Order CurrentOrder
        {
            get => _currentOrder;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "CurrentOrder cannot be null.");
                }
                _currentOrder = value;
            }
        }

        

        public void PlaceOrder(List<Dish> dishes)
        {
            _currentOrder.OrderedDishes = dishes;
            _currentOrder.ConfirmOrder();
        }
    }
}
