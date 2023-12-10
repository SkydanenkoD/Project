using Microsoft.VisualStudio.TestTools.UnitTesting;
using restaurant_logic;
using restaurant_logic.classes;
using System;

namespace Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void Customer_PlaceOrder_OrdersDishes()
        {
            Customer customer = new Customer("John", "123 Main St");
            Assert.IsNotNull(customer.CurrentOrder);

            var dishes = new List<Dish>
            {
                new Dish ("Caesar Salad", 9.99, DishType.Salad),
                new Dish ("Spaghetti Carbonara", 12.50, DishType.Pasta)
            };

            customer.PlaceOrder(dishes);

            Assert.AreEqual(dishes.Count, customer.CurrentOrder.OrderedDishes.Count);
            Assert.AreEqual("John", customer.CurrentOrder.Customer.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Customer_CreateWithEmptyName_ThrowsArgumentException()
        {
            Customer customer = new Customer("", "123 Main St");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Customer_CreateWithNullAddress_ThrowsArgumentException()
        {
            Customer customer = new Customer("John", null);
        }
    }
}
