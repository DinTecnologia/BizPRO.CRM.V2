using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AlterarResponsavelViewModel
    {
        public long? OcorrenciaId { get; set; }
        public long? AtividadeId { get; set; }
        public string ResponsavelAtualId { get; set; }
        public string ResponsavalNovoId { get; set; }
        public string NomeReponsavel { get; set; }
        public SelectList ListaResponsaveis { get; set; }
        public string AtualizadoPorUserId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public AlterarResponsavelViewModel()
        {

        }

        public AlterarResponsavelViewModel(long? ocorrenciaId, long? atividadeId, string responsavelAtualId,
            string nomeResponsavel, SelectList responsaveis)
        {
            OcorrenciaId = ocorrenciaId;
            AtividadeId = atividadeId;
            ResponsavelAtualId = responsavelAtualId;
            NomeReponsavel = nomeResponsavel;
            ListaResponsaveis = responsaveis;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
