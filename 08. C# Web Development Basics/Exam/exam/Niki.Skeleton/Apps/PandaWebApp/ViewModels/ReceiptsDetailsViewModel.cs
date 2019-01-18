using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class ReceiptsDetailsViewModel
    {
        public int Id { get; set; }

        public string IssuedOn { get; set; }

        public string Address { get; set; }

        public float Weight { get; set; }

        public string Description { get; set; }

        public string Recipient { get; set; }

        public decimal Total { get; set; }
    }
}

//<!--RECIPIENT-->
//<!--PACKAGE WEIGHT-->
//<!--PACKAGE DESCRIPTION-->
//<!--DELIVERY ADDRESS-->