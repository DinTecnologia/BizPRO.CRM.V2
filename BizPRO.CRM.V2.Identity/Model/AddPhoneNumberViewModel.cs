using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Identity.Model
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}