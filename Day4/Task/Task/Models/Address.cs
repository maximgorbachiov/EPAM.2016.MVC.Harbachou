using System.ComponentModel;

namespace Task.Models
{
    public class Address
    {
        [DisplayName("Address 1")]
        public string Line1 { get; set; }

        [DisplayName("Address 2")]
        public string Line2 { get; set; }

        public string City { get; set; }

        [DisplayName("Postal code")]
        public string PostalCode { get; set; }

        public string Country { get; set; }

        [DisplayName("Address summary")]
        public string AddressSummary { get; set; }
    }
}