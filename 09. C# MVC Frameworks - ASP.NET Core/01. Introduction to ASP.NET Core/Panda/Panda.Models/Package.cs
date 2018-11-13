using System;
using System.Collections.Generic;

namespace Panda.Models
{
    public class Package
    {
        public Package()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Receipts = new HashSet<Receipt>();
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public float Weight { get; set; }

        public string ShippingAddress { get; set; }

        public PackageStatus Status { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public string UserId { get; set; }
        public virtual User Recipient { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}