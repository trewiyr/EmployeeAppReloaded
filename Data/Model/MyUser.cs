using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class MyUser: IdentityUser
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age {  get; set; }
        public char Gender {  get; set; }
        public string Address { get; set; } = default!;
        
      
    }
}
