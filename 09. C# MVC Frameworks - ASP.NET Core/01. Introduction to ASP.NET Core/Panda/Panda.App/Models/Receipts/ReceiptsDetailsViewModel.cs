using System;

namespace Panda.App.Models
{
    public class ReceiptsDetailsViewModel
    {
        public string Id { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public DateTime IssuedOn { get; set; }

        public string Recipient { get; set; }

        public float Weight { get; set; }

        public decimal Total { get; set; }
    }
}