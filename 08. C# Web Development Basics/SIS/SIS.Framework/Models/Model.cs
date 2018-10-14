using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.Models
{
    public class Model
    {
        private bool? isValid;

        public bool? IsValid
        {
            get => this.isValid;
            set => this.isValid = this.isValid ?? value;
        }
    }
}