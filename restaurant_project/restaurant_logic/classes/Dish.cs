using System;

namespace restaurant_logic.classes
{
    public class Dish : IDish, IComparable<Dish>, ICloneable
    {
        private string _name;
        private double _price;
        private DishType _type;
        private string _description;

        public Dish(string name, double price, DishType type, string description)
        {
            Name = name;
            Price = price;
            Type = type;
            _description = description;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                _price = value;
            }
        }

        public DishType Type
        {
            get => _type;
            set => _type = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public int CompareTo(Dish other)
        {
            if (other == null) return 1;

            return this.Price.CompareTo(other.Price);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
