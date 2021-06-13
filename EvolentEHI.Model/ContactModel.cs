using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EvolentEHI.Model
{
    /// <summary>
    /// Model class is used for binding and validation.
    /// </summary>
   public class ContactModel
    {
                
        public int ContactId { get; set; }

        [Display(Name = "First Name")]
        [Required (ErrorMessage ="First Name is mandatory")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is mandatory")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Valid phone number require")]
        public string PhoneNumber { get; set; }

        public bool Status { get; set; }
    }
}
