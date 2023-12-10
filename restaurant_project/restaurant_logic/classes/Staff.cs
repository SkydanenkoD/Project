using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_logic.classes
{
    public abstract class Staff
    {
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }

        public abstract void PerformDuties();
        public abstract void AttendMeeting();
        public virtual void DisplayInfo(Staff staffMember)
        {
            Console.WriteLine("Displaying general staff information.");
        }
    }
}
