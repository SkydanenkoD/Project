using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_logic.classes
{
    public class Restaurant
    {
        List<Dish> _menu;
        private List<Order> _orders;
        public List<Dish> Menu { get; private set; }
        public List<Order> Orders { get; }

        public Restaurant()
        {
            throw new NotImplementedException();
        }

        private void InitializeMenu()
        {
            throw new NotImplementedException();
        }

        public void UpdateMenu()
        {
            throw new NotImplementedException();
        }
        
        public void DisplayMenu()
        {
            throw new NotImplementedException();
        }

    }
}
