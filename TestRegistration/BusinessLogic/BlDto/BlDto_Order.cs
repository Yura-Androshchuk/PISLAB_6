using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BlDto
{
    public class BlDto_Order
    {
        public Guid OrderId { get; set; }
        public double Sum { get; set; }
    }
}
