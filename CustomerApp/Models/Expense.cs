using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CustomerApp.Models
{
    interface IXmldocs
    {

    }
    [Serializable]
    public class Expense : IXmldocs
    {
        [XmlElement("Cost_Centre")]
        public string Cost_Centre { get; set; }
        [XmlElement("Total")]
        public string Total { get; set; }
        [XmlElement("Payment_Method")]
        public string Payment_Method { get; set; }
    }
    [Serializable]
    public class Reservation : IXmldocs
    {
        [XmlElement("Vendor")]
        public string Vendor { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}