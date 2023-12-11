using System;
using System.Collections.Generic;

namespace restaurant_logic.classes
{
    public class Order
    {
        private Customer _customer;
        private OrderStatus _status;

        public event EventHandler<OrderStatusEventArgs> OrderStatusChanged;

        public Order(Customer customer)
        {
            Customer = customer;
            OrderedDishes = new List<Dish>();
            _status = OrderStatus.Pending;
        }

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

        public OrderStatus Status
        {
            get => _status;
            private set
            {
                _status = value;
                OnOrderStatusChanged(new OrderStatusEventArgs(_status));
            }
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

        public List<Dish> FindDishes(Predicate<Dish> predicate)
        {
            return OrderedDishes.FindAll(predicate);
        }

        public void UpdateOrderStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }

        protected virtual void OnOrderStatusChanged(OrderStatusEventArgs e)
        {
            OrderStatusChanged?.Invoke(this, e);
        }
    }
}
