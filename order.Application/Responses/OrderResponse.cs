using System;
using System.Collections.Generic;
using System.Text;

namespace order.Application.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String TotalPrice { get; set; }

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
