using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public int UserId { get; set; }
        public virtual User Recipient { get; set; }

        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}

//•	Has an Id – a GUID String or an Integer.
//•	Has a Fee – a decimal number.
//•	Has an Issued On – a DateTime object.
//•	Has a Recipient – a User object.
//•	Has a Package – a Package object.