using System.Linq;
using System.Xml.Serialization;

namespace CarDealer.DataProcessor.Models.Export
{
    [XmlType("customer")]
    public class TotalSalesByCustomerExportDto
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }

        [XmlAttribute("bought-cars")]
        public int CatsCount { get; set; }

        [XmlAttribute("spent-money")]
        public string MoneySpent
        {
            get
            {
                return this.PriceAndDiscounts.Sum(c => c.TotalPrice - (c.TotalPrice * (decimal)c.Discount)).ToString("F2");
            }
            set { this.MoneySpent = value; }
        }

        [XmlIgnore]
        public CarPriceAndDiscountExportDto[] PriceAndDiscounts { get; set; }
    }
}