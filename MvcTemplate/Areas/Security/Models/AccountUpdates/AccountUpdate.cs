using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcTemplate.Areas.Security.Models.AccountUpdates
{
    public class AccountUpdate
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [ValidatePasswordLength]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}