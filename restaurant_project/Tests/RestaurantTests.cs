using restaurant_logic.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class RestaurantTests
    {
        [TestMethod]
        public void Restaurant_DisplayMenu_ReturnsCorrectMenu()
        {
            Restaurant restaurant = new Restaurant();

            string menuText = CaptureConsoleOutput(() => restaurant.DisplayMenu());

            Assert.IsTrue(menuText.Contains("Caesar Salad - $9.99"));
            Assert.IsTrue(menuText.Contains("Spaghetti Carbonara - $12.50"));
        }

        private string CaptureConsoleOutput(System.Action action)
        {
            using (System.IO.StringWriter stringWriter = new System.IO.StringWriter())
            {
                System.Console.SetOut(stringWriter);

                action();

                return stringWriter.ToString();
            }
        }
    }
}
