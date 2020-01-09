using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgostonVendeghaz.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó megerősítése")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "Név")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Irányítószám")]
        [RegularExpression(@"^[1-9]\d{3}[.]?$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Város")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u00FFűőŰŐ .\-]{2,}$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Utca")]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u00FFűőŰŐ \-.]{2,}$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Házszám")]
        [StringLength(50)]
        [RegularExpression(@"^\d{1,4}[.\-/ ]?[0-9a-zA-Z\u00C0-\u00FFűőŰŐ \-.:/]*?$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        public string HouseNumber { get; set; }

        [Required]
        [Display(Name = "Telefonszám")]
        [RegularExpression(@"^\+?\d{2}[\-. ]?\d{1,2}[\-. ]?\d{3}[\-. ]?\d{3,4}$",
            ErrorMessage = "Helytelen formátum kérem próbálja újra!")]
        public string Phone { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
