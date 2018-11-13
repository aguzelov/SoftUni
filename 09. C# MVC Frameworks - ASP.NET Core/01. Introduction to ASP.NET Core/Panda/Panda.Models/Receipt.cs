using System;

namespace Panda.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string UserId { get; set; }
        public virtual User Recipient { get; set; }

        public string PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}