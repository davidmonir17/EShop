using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics.Models
{
    public class BasketCheackoutModel
    {
        public String UserName { get; set; }
        public decimal TotalPrice { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }

        //address
        public String AddressLine { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }

        //payment
        public String CardNumber { get; set; }
        public String CardName { get; set; }
        public String Expiration { get; set; }
        public String Cvv { get; set; }
        public String PaymentMethod { get; set; }
    }
}
