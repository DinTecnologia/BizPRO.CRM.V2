using DomainValidation.Validation;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class EmailFormViewModel
    {
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? AtendimentoId { get; set; }
        public int? FilaId { get; set; }
        public long? OcorrenciaId { get; set; }
        public bool RetornarPartial { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public string UsuarioId { get; set; }

        public long? EmailId { get; set; }
        public long? AtividadePaiId { get; set; }
        public long? EmailPaiId { get; set; }
        public long AtividadeId { get; set; }
        public int? ConfiguracaoContaEmailId { get; set; }
        public string Assunto { get; set; }
        public string EmailIdProvisorio { get; set; }
        public string Sentido { get; set; }
        public SelectList ConfiguracaoContasEmail { get; set; }
        public int? StatusId { get; set; }

        // Propiedade do Form
        public string Remetente { get; set; }
        public string Para { get; set; }
        public string Copia { get; set; }
        public string CopiaOculta { get; set; }
        public List<EmailAnexosViewModel> Anexos { get; set; }

        [AllowHtml]
        public string Html { get; set; }

        public EmailFormViewModel()
        {
            ValidationResult = new ValidationResult();
            RetornarPartial = false;
            Anexos = new List<EmailAnexosViewModel>();
        }
    }
}
