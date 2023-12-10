using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace restaurant_logic.classes
{
    public class Restaurant
    {
        private List<Dish> _menu;
        private List<Order> _orders;

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

        public Restaurant()
        {
            _menu = new List<Dish>();
            _orders = new List<Order>();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            _menu.Add(new Dish("Pasta Carbonara", 12.99, DishType.Pasta));
            _menu.Add(new Dish("Chicken Caesar Salad", 9.99, DishType.Salad));
            _menu.Add(new Dish("Tomato Basil Soup", 6.99, DishType.Soup));
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
                Console.WriteLine($"{++count}. {dish.Name} - ${dish.Price}");
            }
        }
    }
}
