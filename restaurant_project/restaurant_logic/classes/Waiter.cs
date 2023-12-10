using System;

namespace restaurant_logic.classes
{
    public class Waiter : Staff
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
            Console.WriteLine($"{Name} is taking orders and serving customers.");
        }

        public override void AttendMeeting()
        {
            Console.WriteLine($"{Name} is attending a staff meeting.");
        }

        public override void DisplayInfo(Staff staffMember)
        {
            if (staffMember is Waiter waiter)
            {
                Console.WriteLine($"Waiter's name: {waiter.Name}");
            }
            else
            {
                Console.WriteLine("This staff member is not a waiter.");
                base.DisplayInfo(staffMember);
            }
        }
    }
}
