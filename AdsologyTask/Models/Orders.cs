using System;
using System.Collections.Generic;

namespace AdsologyTask.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Articles = new HashSet<Articles>();
            Payments = new HashSet<Payments>();
        }

        public long OxId { get; set; }
        public DateTime OrderDatetime { get; set; }
        public byte? OrderStatus { get; set; }
        public int? InvoiceNumber { get; set; }

        public virtual OrderStatuses OrderStatusNavigation { get; set; }
        public virtual BillingAddresses BillingAddresses { get; set; }
        public virtual ICollection<Articles> Articles { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
