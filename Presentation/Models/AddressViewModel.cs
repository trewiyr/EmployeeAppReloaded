using Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "StreetNo")]
        public int StreetNo { get; set; }
        [Required]
        public string? City { get; set; } 
        public string? StreetName { get; set; }
        //public State? State { get; set; }
    }
}
