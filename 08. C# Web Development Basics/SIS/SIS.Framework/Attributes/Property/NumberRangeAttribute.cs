using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIS.Framework.Attributes.Property
{
    public class NumberRangeAttribute : ValidationAttribute
    {
        private readonly double minimumValue;

        private readonly double maximumValue;

        public NumberRangeAttribute(
            double minimumValue = double.MinValue,
            double maximumValue = double.MaxValue)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
        }

        public override bool IsValid(object value)
        {
            return this.minimumValue <= (double)value &&
                this.maximumValue >= (double)value;
        }
    }
}