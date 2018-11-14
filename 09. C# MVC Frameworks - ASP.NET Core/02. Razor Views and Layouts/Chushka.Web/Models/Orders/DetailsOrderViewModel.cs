using System;

namespace Chushka.Web.Models.Orders
{
    public class DetailsOrderViewModel
    {
        public string Id { get; set; }

        public string Client { get; set; }

        public string Product { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}