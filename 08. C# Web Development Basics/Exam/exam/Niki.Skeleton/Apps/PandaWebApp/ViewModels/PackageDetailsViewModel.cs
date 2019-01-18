using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class PackageDetailsViewModel
    {
        public string Address { get; set; }

        public string Status { get; set; }

        public string EstimatedDeliveryDate { get; set; }

        public float Weight { get; set; }

        public string Recipient { get; set; }

        public string Description { get; set; }
    }
}