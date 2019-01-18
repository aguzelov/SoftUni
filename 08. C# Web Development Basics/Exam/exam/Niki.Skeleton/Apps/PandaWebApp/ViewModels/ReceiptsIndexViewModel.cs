using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class ReceiptsIndexViewModel
    {
        public ICollection<ReceiptIndexDetailViewModel> Receipts { get; set; }
    }
}