using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class PackagesViewModel
    {
        public ICollection<PackageViewModel> Pending { get; set; }

        public ICollection<PackageViewModel> Shipped { get; set; }

        public ICollection<PackageViewModel> Delivered { get; set; }
    }
}