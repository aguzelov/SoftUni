using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class PackagetAllDetailsViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public float Weight { get; set; }

        public string EstimatedDeliveryDate { get; set; }

        public string Address { get; set; }

        public string Recipient { get; set; }
    }
}