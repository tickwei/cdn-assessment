using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cdn_assessment.Models
{
    public class User
    {
        public int Id { get; set; } // Primary Key

        //Add Validation with Validation Messages
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 100 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        // A list of skillsets the user possesses
        public List<string> Skillsets { get; set; } = new List<string>();

        // A list of hobbies the user enjoys
        public List<string> Hobbies { get; set; } = new List<string>();
    }
}





