using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_logic
{
    public interface IDish
    {
        string Name { get; set; }
        double Price { get; set; }
        DishType Type { get; set; }
        string Description { get; set; }
    }
}
