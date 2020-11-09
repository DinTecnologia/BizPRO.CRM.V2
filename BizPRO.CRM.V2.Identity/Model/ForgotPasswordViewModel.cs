using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Identity.Model
{
    public class ForgotPasswordViewModel
    {
    
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
