using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models {

    public class GuestViewModel
    {
        [Required]
        [Display(Name = "�����")]
        public string GuestAcct { get; set; }

        [Required]
        [Display(Name = "������")]
        public string GuestPassword { get; set; }

    }

    public class ExternalLoginConfirmationViewModel {
        [Required]
        [Display(Name = "�����")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class VerifyCodeViewModel {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "���")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "��������� ���� �������?")]
        public bool RememberBrowser { get; set; }
    }

    public class ForgotViewModel {
        [Required]
        [Display(Name = "�����")]
        public string Email { get; set; }
    }

    public class LoginViewModel {
        [Required]
        [Display(Name = "�����")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }

        [Display(Name = "��������� ������?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "�����")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} ������ ������ �������� ������� �� {2} ��������.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "���������� ������")]
        [Compare("Password", ErrorMessage = "������ �� ���������.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "�����")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} ������ ������ �������� ������� �� {2} ��������.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "��������� ������")]
        [Compare("Password", ErrorMessage = "������ �� ���������.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "�����")]
        public string Email { get; set; }
    }
}