using restaurant_logic.classes;
using restaurant_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Order_AddDishToOrder_AddsDish()
        {
            Customer customer = new Customer("John", "123 Main St");
            Order order = new Order(customer);
            Dish dish = new Dish { Name = "Caesar Salad", Price = 9.99, Type = DishType.Salad };

            order.AddDishToOrder(dish);

            Assert.AreEqual(1, order.OrderedDishes.Count);
        }
    }
}
