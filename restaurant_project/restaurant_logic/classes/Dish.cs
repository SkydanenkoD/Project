using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_logic.classes
{
    public class Dish : IDish
    {
        string _name;
        double _price;
        DishType _type;
        public string Name { get; set; }
        public double Price { get; set; }
        public DishType Type { get; set; }
        public Dish()
        {
            throw new NotImplementedException();
        }
    }
}
