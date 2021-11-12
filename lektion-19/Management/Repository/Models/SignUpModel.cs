using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class SignUpModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "{0} must be provided")]
        [StringLength(255, ErrorMessage = "{0} must be at least {2} characters long", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "{0} must be provided")]
        [StringLength(255, ErrorMessage = "{0} must be at least {2} characters long", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [EmailAddress]
        [Required(ErrorMessage = "{0} must be provided")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "{0} must be a valid address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} must be provided")]   
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "{0} must be at least 8 characters long, contain one number and a mixture of uppercase and lowercase letters and at least one special character (!*@#$%^&+=)")]
        public string Password { get; set; }
    }
}
