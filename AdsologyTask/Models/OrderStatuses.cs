using System;
using System.Collections.Generic;

namespace AdsologyTask.Models
{
    public partial class OrderStatuses
    {
        public OrderStatuses()
        {
            Orders = new HashSet<Order>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual HashSet<Order> Orders { get; set; }
    }
}
