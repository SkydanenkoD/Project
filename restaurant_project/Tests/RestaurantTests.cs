using Microsoft.VisualStudio.TestTools.UnitTesting;
using restaurant_logic;
using restaurant_logic.classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class RestaurantTests
    {
        [TestMethod]
        public void Restaurant_Menu_HasCorrectValue()
        {
            Restaurant restaurant = new Restaurant();

            Dish dish1 = new Dish("Pasta Carbonara", 12.99, DishType.Pasta, "Creamy pasta dish with bacon and cheese.");
            Dish dish2 = new Dish("Chicken Caesar Salad", 9.99, DishType.Salad, "Classic salad with romaine lettuce, grilled chicken, croutons, and Caesar dressing.");
            Dish dish3 = new Dish("Tomato Basil Soup", 6.99, DishType.Soup, "Delicious soup made with ripe tomatoes, fresh basil, and herbs.");

            bool dish1Exists = restaurant.Menu.Any(d => d.Name == dish1.Name && d.Price == dish1.Price && d.Type == dish1.Type && d.Description == dish1.Description);
            bool dish2Exists = restaurant.Menu.Any(d => d.Name == dish2.Name && d.Price == dish2.Price && d.Type == dish2.Type && d.Description == dish2.Description);
            bool dish3Exists = restaurant.Menu.Any(d => d.Name == dish3.Name && d.Price == dish3.Price && d.Type == dish3.Type && d.Description == dish3.Description);
            
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
                new Dish("Margherita Pizza", 14.99, DishType.Steak, "Steak"),
                new Dish("Tiramisu", 7.50, DishType.Dessert, "Tasty")
            };

            restaurant.UpdateMenu(newMenu);

            Assert.AreEqual(2, restaurant.Menu.Count);
            Assert.IsTrue(restaurant.Menu.Contains(newMenu[0]));
            Assert.IsTrue(restaurant.Menu.Contains(newMenu[1]));

            Assert.IsFalse(restaurant.Menu.Any(dish => dish.Name == "Pasta Carbonara"));
            Assert.IsFalse(restaurant.Menu.Any(dish => dish.Name == "Chicken Caesar Salad"));
            Assert.IsFalse(restaurant.Menu.Any(dish => dish.Name == "Tomato Basil Soup"));
        }
    }
}
