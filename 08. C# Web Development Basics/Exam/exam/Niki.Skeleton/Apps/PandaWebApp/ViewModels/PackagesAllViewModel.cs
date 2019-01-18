using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class PackagesAllViewModel
    {
        public string Type { get; set; }

        public ICollection<PackagetAllDetailsViewModel> Packages { get; set; }
    }
}