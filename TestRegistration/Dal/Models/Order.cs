using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal.Models
{
     public class Order
    {
        public Guid OrderId { get; set; }
        public double Sum { get; set; }

    }
}
