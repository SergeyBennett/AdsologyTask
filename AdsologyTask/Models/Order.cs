using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AdsologyTask.Models
{
    [Serializable, XmlRoot("order")]
    public partial class Order
    {
        public Order()
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
        public virtual HashSet<Articles> Articles { get; set; }
        public virtual HashSet<Payments> Payments { get; set; }
    }
}
