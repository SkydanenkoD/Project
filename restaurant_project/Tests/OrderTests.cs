using Microsoft.VisualStudio.TestTools.UnitTesting;
using restaurant_logic;
using restaurant_logic.classes;
using System;

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
            Dish dish = new Dish("Caesar Salad", 9.99, DishType.Salad, "Salad");

            order.AddDishToOrder(dish);

            Assert.AreEqual(1, order.OrderedDishes.Count);
        }

        [TestMethod]
        public void Order_CalculateTotalPrice_ReturnsTotalPrice()
        {
            Customer customer = new Customer("Alice", "456 Elm St");
            Order order = new Order(customer);
            Dish dish1 = new Dish("Spaghetti Carbonara", 12.50, DishType.Pasta, "Pasta");
            Dish dish2 = new Dish("Tiramisu", 7.99, DishType.Dessert, "Tasty");

            order.AddDishToOrder(dish1);
            order.AddDishToOrder(dish2);

            double expectedTotalPrice = 20.49;
            double actualTotalPrice = order.CalculateTotalPrice();

            Assert.AreEqual(expectedTotalPrice, Math.Round(actualTotalPrice, 2));
        }


        [TestMethod]
        public void Order_UpdateOrderStatus_InvokesEvent()
        {
            Customer customer = new Customer("Bob", "789 Oak St");
            Order order = new Order(customer);

            bool eventRaised = false;

            order.OrderStatusChanged += (sender, args) => { eventRaised = true; };

            order.UpdateOrderStatus(OrderStatus.InProgress);

            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Order_CreateWithNullCustomer_ThrowsArgumentNullException()
        {
            Order order = new Order(null);
        }
    }
}
