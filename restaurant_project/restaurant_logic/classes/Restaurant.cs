using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace restaurant_logic.classes
{
    public delegate bool CheckDishPrice(Dish dish);

    public class Restaurant
    {
        private List<Dish> _menu;
        private List<Order> _orders;

        public Restaurant()
        {
            _menu = new List<Dish>();
            _orders = new List<Order>();
            InitializeMenu();
        }
        
        public List<Dish> Menu
        {
            get => _menu;
            private set => _menu = value;
        }

        public List<Order> Orders
        {
            get => _orders;
            private set => _orders = value;
        }

        private void InitializeMenu()
        {
            _menu.Add(new Dish("Pasta Carbonara", 12.99, DishType.Pasta, "Creamy pasta dish with bacon and cheese."));
            _menu.Add(new Dish("Chicken Caesar Salad", 9.99, DishType.Salad, "Classic salad with romaine lettuce, grilled chicken, croutons, and Caesar dressing."));
            _menu.Add(new Dish("Tomato Basil Soup", 6.99, DishType.Soup, "Delicious soup made with ripe tomatoes, fresh basil, and herbs."));
        }

        public void UpdateMenu(List<Dish> newMenu)
        {
            _menu = newMenu;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            int count = 0;
            foreach (Dish dish in _menu)
            {
                Console.WriteLine($"{++count}. {dish.Name} - ${dish.Price} ({dish.Description})");
            }
        }

        public void PerformActionOnMenu(Action<Dish> action)
        {
            foreach (var dish in Menu)
            {
                action(dish);
            }
        }

        public List<Dish> GetExpensiveDishes(CheckDishPrice checkDishPriceDelegate)
        {
            Predicate<Dish> predicate = new (checkDishPriceDelegate);
            return Menu.FindAll(predicate);
        }

    }
}
