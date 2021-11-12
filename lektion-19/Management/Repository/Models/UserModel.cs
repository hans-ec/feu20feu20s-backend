using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class UserModel
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }

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

    }
}
