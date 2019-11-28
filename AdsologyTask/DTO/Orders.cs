using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using AdsologyTask.Models;

namespace AdsologyTask.DTO
{
    [Serializable, XmlRoot("orders")]
    public class Orders
    {
        [XmlArray("orders")]
        [XmlArrayItem("order")]
        public List<Order> OrderList { get; set; }
    }
}
