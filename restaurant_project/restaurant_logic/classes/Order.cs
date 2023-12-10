using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_logic.classes
{
    public class Order
    {
        Customer _customer;
        public List<Dish> OrderedDishes { get; set; }
        public Customer Customer { get; set; }

        public Order(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void AddDishToOrder(Dish dish)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void ConfirmOrder()
        {
            throw new NotImplementedException();
        }
    }
}
