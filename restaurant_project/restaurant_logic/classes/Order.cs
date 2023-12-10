using System;
using System.Collections.Generic;

namespace restaurant_logic.classes
{
    public class Order
    {
        private Customer _customer;

        public List<Dish> OrderedDishes { get; set; }
        public Customer Customer
        {
            get => _customer;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer cannot be null.");
                }
                _customer = value;
            }
        }

        public Order(Customer customer)
        {
            Customer = customer;
            OrderedDishes = new List<Dish>();
        }

        public void AddDishToOrder(Dish dish)
        {
            OrderedDishes.Add(dish);
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (var dish in OrderedDishes)
            {
                totalPrice += (double)dish.Price;
            }
            return totalPrice;
        }

        public void ConfirmOrder()
        {
            Console.WriteLine("Order confirmed for customer: " + Customer.Name);
        }
    }
}
