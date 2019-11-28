using System;
using System.Collections.Generic;

namespace AdsologyTask.Models
{
    public partial class BillingAddresses
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public short HomeNumber { get; set; }
        public int Zip { get; set; }
        public long OrderOxId { get; set; }

        public virtual Order OrderOx { get; set; }
    }
}
