using System.Collections.Generic;

namespace FDMC.App.Models
{
    public class CatsViewModel
    {
        public ICollection<CatViewModel> Cats { get; set; }
    }
}