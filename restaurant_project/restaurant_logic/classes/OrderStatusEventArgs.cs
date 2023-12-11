using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_logic.classes
{
    public class OrderStatusEventArgs : EventArgs
    {
        public OrderStatus NewStatus { get; }

        public OrderStatusEventArgs(OrderStatus newStatus)
        {
            NewStatus = newStatus;
        }
    }
}
