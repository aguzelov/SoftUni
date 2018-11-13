using System;

namespace Panda.App.Models
{
    public class ReceiptIndexDetailViewModel
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }
        public string Recipient { get; set; }
    }
}