using restaurant_logic;
using restaurant_logic.classes;

namespace Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void Customer_PlaceOrder_OrdersDishes()
        {
            Customer customer = new Customer("John", "123 Main St");
            List<Dish> dishes = new List<Dish>
        {
            new Dish { Name = "Caesar Salad", Price = 9.99, Type = DishType.Salad },
            new Dish { Name = "Spaghetti Carbonara", Price = 12.50, Type = DishType.Pasta }
        };

            customer.PlaceOrder(dishes);

            Assert.AreEqual(dishes.Count, customer.CurrentOrder.OrderedDishes.Count);

            Assert.AreEqual("John", customer.CurrentOrder.Customer.Name);
        }
    }   
}