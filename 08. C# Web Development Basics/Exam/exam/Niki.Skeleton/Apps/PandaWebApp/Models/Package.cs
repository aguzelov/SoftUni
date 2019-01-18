using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.Models
{
    public class Package
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public float Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public int UserId { get; set; }
        public virtual User Recipient { get; set; }
    }
}

//•	Has an Id – a GUID String or an Integer.
//•	Has a Description – a string.
//•	Has a Weight – a floating-point number.
//•	Has a Shipping Address – a string.
//•	Has a Status – can be one of the following values (“Pending”, “Shipped”, “Delivered”, “//Acquired”)
//•	Has an Estimated Delivery Date – A DateTime object.
//•	Has a Recipient – a User object.