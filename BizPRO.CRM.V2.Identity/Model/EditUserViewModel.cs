using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace BizPRO.CRM.V2.Identity.Model
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string UserID { get; set; }

        [Display(Name = "Departamento")] public int? DepartamentoId { get; set; }

        [Display(Name = "Equipe")] public int? EquipeId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo UserName")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string UserName { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
        public long Terminal { get; set; }
        public long Agente { get; set; }
        public List<terminal> TerminaisUsuario { get; set; }
        public string[] selectedRoles { get; set; }
        public IEnumerable<Fila> FilaChat { get; set; }
        public IEnumerable<Fila> FilaMessenger { get; set; }

        public EditUserViewModel(string id, List<terminal> TerminaisUsuario, IEnumerable<Fila> filasChat,
            IEnumerable<Fila> filasMessenger)
        {
            this.TerminaisUsuario = TerminaisUsuario;
            Id = id;
            FilaChat = filasChat;
            FilaMessenger = filasMessenger;
        }

        public EditUserViewModel()
        {

        }
    }
}