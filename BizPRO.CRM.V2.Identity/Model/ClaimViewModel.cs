using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Identity.Model
{
    public class ClaimViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nome da Claim")]
        public string Type { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Valor da Claim")]
        public string Value { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "ID da Claim")]
        public string ID { get; set; }
    }
}

