using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9\s]*( str.)$")]
        public string Address { get; set; }

        public int PrisonerId { get; set; }

        [Required]
        public Prisoner Prisoner { get; set; }
    }
}

/*
Id – integer, Primary Key
Description– text (required)
Sender – text (required)
Address – text, consisting only of letters, spaces and numbers, which ends with “ str.” (required) (Example: “62 Muir Hill str.“)
PrisonerId - integer, foreign key
Prisoner – the mail's Prisoner (required)
*/