namespace Chushka.App.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                return this.Description.Length > 50 ?
                    this.Description.Substring(0, 50) + "..." :
                    this.Description;
            }
        }
    }
}