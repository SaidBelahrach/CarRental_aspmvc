using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projet_ASP.Models
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
        [EmailAddress]
        [Required(ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser),
                  ErrorMessageResourceName = "EmailReq")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Models.ApplicationUser))]

        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser), ErrorMessageResourceName = "PasswordReq"/*, ErrorMessage = "The {0} must be at least {2} characters long."*/, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Models.ApplicationUser))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Models.ApplicationUser))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser),
                  ErrorMessageResourceName = "ConfirmPasswordReq")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser),
                  ErrorMessageResourceName = "nomCompletReq")]
        [Display(Name = "nomComplet", ResourceType = typeof(Resources.Models.ApplicationUser))]
        public string nomComplet { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser),
                 ErrorMessageResourceName = "adresseReq")]
        [Display(Name = "adresse", ResourceType = typeof(Resources.Models.ApplicationUser))]
        public string adresse { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser),
                  ErrorMessageResourceName = "profileTypeReq")]
        [Display(Name = "profileType", ResourceType = typeof(Resources.Models.ApplicationUser))]
        public string profileType { get; set; }


        [Phone]
        [Required(ErrorMessageResourceType = typeof(Resources.Models.ApplicationUser),
                  ErrorMessageResourceName = "telReq")]
        [Display(Name = "tel", ResourceType = typeof(Resources.Models.ApplicationUser))]

        public string tel { get; set; }
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
