using System;
using System.Collections.Generic;
using System.Reflection;
using restaurant_logic;
using restaurant_logic.classes;

namespace restaurant_interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurant restaurant = new ();
            Customer customer = new ("John Doe", "123 Main St");

            int choice;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Make an order");
                Console.WriteLine("2 - Show current order");
                Console.WriteLine("3 - Display menu");
                Console.WriteLine("4 - Update menu");
                Console.WriteLine("5 - Show staff members");
                Console.WriteLine("6 - Show expensive dishes");
                Console.WriteLine("7 - Perform an action on menu");
                Console.WriteLine("8 - Find dishes under or equal to a maximum price:"); 
                Console.WriteLine("9 - Update order status");
                Console.WriteLine("0 - Exit");

                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        restaurant.DisplayMenu();
                        bool addToOrder = true;
                        List<Dish> order = new ();

                        do
                        {
                            Console.WriteLine("Enter dish number to add to order (or 0 to finish adding):");
                            if (int.TryParse(Console.ReadLine(), out int dishNumber) && dishNumber >= 0 && dishNumber <= restaurant.Menu.Count)
                            {
                                if (dishNumber == 0)
                                {
                                    addToOrder = false;
                                    break;
                                }
                                order.Add(restaurant.Menu[dishNumber - 1]);
                                Console.WriteLine("Dish added to the order.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid dish number.");
                            }
                            Console.WriteLine();
                        } while (addToOrder);

                        if (order.Count > 0)
                        {
                            customer.PlaceOrder(order);
                        }
                        else
                        {
                            Console.WriteLine("Order wasn't confirmed.");
                        }
                        break;

                    case 2:
                        if (customer.CurrentOrder != null)
                        {
                            Console.WriteLine("Current Order:");
                            foreach (Dish dish in customer.CurrentOrder.OrderedDishes)
                            {
                                Console.WriteLine($"{dish.Name} - ${dish.Price}");
                            }
                            Console.WriteLine($"Total Price: ${customer.CurrentOrder.CalculateTotalPrice()}");
                        }
                        else
                        {
                            Console.WriteLine("No current order.");
                        }
                        break;

                    case 3:
                        restaurant.DisplayMenu();
                        break;

                    case 4:
                        Console.WriteLine("Enter new menu item name:");
                        string? newItemName = Console.ReadLine();
                        Console.WriteLine("Enter new menu item price:");
                        if (double.TryParse(Console.ReadLine(), out double newItemPrice))
                        {
                            Console.WriteLine("Enter new menu item type (Salad, Pasta, Soup, Steak, Dessert):");
                            if (Enum.TryParse(Console.ReadLine(), out DishType newItemType))
                            {
                                Console.WriteLine("Enter a desciption for an item:");
                                string? newItemDescription = Console.ReadLine();
                                restaurant.Menu.Add(new Dish(newItemName, newItemPrice, newItemType, newItemDescription));
                                Console.WriteLine("Menu updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid dish type.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid price.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Staff Members:");
                        List<Staff> staffMembers = new List<Staff>
                        {
                            new Chef { Name = "Gordon Ramsay", Age = 50 },
                            new Waiter { Name = "John", Age = 25 },
                            new Waiter { Name = "Emily", Age = 30 }
                        };

                        foreach (Staff staff in staffMembers)
                        {
                            staff.DisplayInfo(staff);
                        }
                        break;

                    case 6:
                        Console.WriteLine("Expensive Dishes:");
                        List<Dish> expensiveDishes = restaurant.GetExpensiveDishes(dish => dish.Price > 10.0);
                        foreach (var dish in expensiveDishes)
                        {
                            Console.WriteLine($"{dish.Name} - ${dish.Price}");
                        }
                        break;

                    case 7:
                        Console.WriteLine("Performing an operation on the menu:");
                        Console.WriteLine("Choose an action:");
                        Console.WriteLine("1 - Add 'Special Offer!' to dish description");
                        Console.WriteLine("2 - Update dish price");
                        Console.Write("Enter your choice: ");
                        if (int.TryParse(Console.ReadLine(), out int actionChoice))
                        {
                            switch (actionChoice)
                            {
                                case 1:
                                    restaurant.PerformActionOnMenu(dish =>
                                    {
                                        Console.WriteLine($"Processing dish: {dish.Name}");
                                        dish.Description += " - Special Offer!";
                                    });
                                    Console.WriteLine("Menu items updated successfully.");
                                    break;
                                case 2:
                                    Console.Write("Enter the percentage to increase the price by: ");
                                    if (double.TryParse(Console.ReadLine(), out double percentage))
                                    {
                                        restaurant.PerformActionOnMenu(dish =>
                                        {
                                            Console.WriteLine($"Processing dish: {dish.Name}");
                                            double increase = dish.Price * (percentage / 100);
                                            dish.Price += increase;
                                        });
                                        Console.WriteLine("Menu prices updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input for price increase.");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                        }
                        break;

                    case 8:
                        Console.Write("Enter a maximum price to find dishes:");
                        if (double.TryParse(Console.ReadLine(), out double maxPrice))
                        {
                            Predicate<Dish> pricePredicate = dish => dish.Price <= maxPrice;
                            List<Dish> foundDishes = customer.CurrentOrder.FindDishes(pricePredicate);

                            Console.WriteLine($"Dishes found under or equal to ${maxPrice}:");
                            foreach (var dish in foundDishes)
                            {
                                Console.WriteLine($"{dish.Name} - ${dish.Price}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid price.");
                        }
                        break;

                    case 9:
                        if (customer.CurrentOrder.OrderedDishes.Count > 0)
                        {
                            Console.WriteLine("Enter the new order status (InProgress, Completed, Canceled):");
                            if (Enum.TryParse(Console.ReadLine(), out OrderStatus newStatus))
                            {
                                customer.CurrentOrder.UpdateOrderStatus(newStatus);
                                Console.WriteLine("Order status updated.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid order status.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No active order to update status.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Thank you for your order. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine("===============================================");

            } while (choice != 0);
        }
    }
}
