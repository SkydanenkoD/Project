using System;

namespace restaurant_logic.classes
{
    public class Chef : Staff
    {
        private string _name;
        private int _age;

        public override string Name
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

        public override int Age
        {
            get => _age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be a positive number.");
                }
                _age = value;
            }
        }

        public override void PerformDuties()
        {
            Console.WriteLine($"{Name} is preparing delicious meals in the kitchen.");
        }

        public override void AttendMeeting()
        {
            Console.WriteLine($"{Name} is attending a staff meeting.");
        }

        public override void DisplayInfo(Staff staffMember)
        {
            if (staffMember is Chef chef)
            {
                Console.WriteLine($"Chef's name: {chef.Name}");
            }
            else
            {
                Console.WriteLine("This staff member is not a chef.");
                base.DisplayInfo(staffMember);
            }
        }
    }
}
