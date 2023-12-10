﻿using System;

namespace restaurant_logic.classes
{
    public class Dish : IDish, IComparable<Dish>, ICloneable
    {
        private string _name;
        private double _price;
        private DishType _type;

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

        public DishType Type { get; set; }

        public Dish(string name, double price, DishType type)
        {
            Name = name;
            Price = price;
            Type = type;
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
