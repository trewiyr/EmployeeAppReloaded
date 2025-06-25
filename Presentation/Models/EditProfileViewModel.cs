using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class EditProfileViewModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; } = default!;
        [Phone]
        public string ?PhoneNumber { get; set; } = default!;

    }
}
