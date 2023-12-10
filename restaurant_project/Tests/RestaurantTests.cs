using Microsoft.VisualStudio.TestTools.UnitTesting;
using restaurant_logic;
using restaurant_logic.classes;
using System;

namespace Tests
{
    [TestClass]
    public class RestaurantTests
    {
        [TestMethod]
        public void Restaurant_Menu_HasCorrectValue()
        {
            Restaurant restaurant = new Restaurant();

            Dish dish1 = new Dish("Pasta Carbonara", 12.99, DishType.Pasta);
            Dish dish2 = new Dish("Chicken Caesar Salad", 9.99, DishType.Salad);
            Dish dish3 = new Dish("Tomato Basil Soup", 6.99, DishType.Soup);

            bool dish1Exists = restaurant.Menu.Any(d => d.Name == dish1.Name && d.Price == dish1.Price && d.Type == dish1.Type);
            bool dish2Exists = restaurant.Menu.Any(d => d.Name == dish2.Name && d.Price == dish2.Price && d.Type == dish2.Type);
            bool dish3Exists = restaurant.Menu.Any(d => d.Name == dish3.Name && d.Price == dish3.Price && d.Type == dish3.Type);

            Assert.IsTrue(dish1Exists);
            Assert.IsTrue(dish2Exists);
            Assert.IsTrue(dish3Exists);
        }

        [TestMethod]
        public void Restaurant_UpdateMenu_NewMenuReplacesExistingMenu()
        {
            Restaurant restaurant = new Restaurant();

            List<Dish> newMenu = new List<Dish>
            {
                new Dish("Margherita Pizza", 14.99, DishType.Steak),
                new Dish("Tiramisu", 7.50, DishType.Dessert)
            };

            restaurant.UpdateMenu(newMenu);

            Assert.AreEqual(2, restaurant.Menu.Count);
            Assert.IsTrue(restaurant.Menu.Contains(newMenu[0]));
            Assert.IsTrue(restaurant.Menu.Contains(newMenu[1]));
        }
    }
}
