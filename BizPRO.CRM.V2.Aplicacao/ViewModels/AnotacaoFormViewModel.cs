using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AnotacaoFormViewModel
    {
        [Key]
        public long? AnotacaoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Texto")]
        [Display(Name = "Texto")]
        public string Texto { get; set; }

        [ScaffoldColumn(false)]
        public long? OcorrenciaId { get; set; }

        [ScaffoldColumn(false)]
        public long? AtividadeId { get; set; }

        [ScaffoldColumn(false)]
        public long? PessoaFisicaId { get; set; }

        [ScaffoldColumn(false)]
        public long? PessoaJuridicaId { get; set; }

        [ScaffoldColumn(false)]
        public long? PotenciaisClienteId { get; set; }

        [ScaffoldColumn(false)]
        public string CriarPorUserId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        public long? AtendimentoId { get; set; }
        public SelectList AnotacaoTipos { get; set; }
        public long? AnotacaoTipoId { get; set; }

        [ScaffoldColumn(false)]
        public bool AcompanhamentoOcorrencia { get; set; }

        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public bool SolicitarLigacao { get; set; }

        public AnotacaoFormViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            CriadoEm = DateTime.Now;
        }

        public AnotacaoFormViewModel(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId, long? atendimentoId, SelectList anotacaoTipos)
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            OcorrenciaId = ocorrenciaId;
            AtividadeId = atividadeId;
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            PotenciaisClienteId = potencialClienteId;
            AnotacaoTipos = anotacaoTipos;
            AtendimentoId = atendimentoId;
        }
    }
}
