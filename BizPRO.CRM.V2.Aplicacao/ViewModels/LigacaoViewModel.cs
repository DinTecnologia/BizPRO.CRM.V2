using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class LigacaoViewModel
    {
        public long id { get;  set; }
        public long? pessoaFisicaID { get; set; }
        public long? pessoaJuridicaID { get; set; }
        public long? potencialClientesID { get; set; }
        public string userID { get; set; }
        public string numeroOriginal { get; set; }
        public long? telefoneID { get; set; }
        public DateTime criadoEm { get; set; }
        public DateTime? finalizadoEm { get; set; }
        public string sentido { get; set; }
        public long atividadeID { get;  set; }
        public ValidationResult ValidationResult { get;  set; }

        public LigacaoViewModel()
        {
            ValidationResult = new ValidationResult();
        }
        public LigacaoViewModel(long id)
        {
            this.id = id;
            ValidationResult = new ValidationResult();
        }

        public LigacaoViewModel(long id, long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClientesId,
            string userId, string sentido, long atividadeId, string numeroOriginal)
        {
            this.id = id;
            pessoaFisicaID = pessoaFisicaId;
            pessoaJuridicaID = pessoaJuridicaId;
            potencialClientesID = potencialClientesId;
            userID = userId;
            this.sentido = sentido;
            atividadeID = atividadeId;
            this.numeroOriginal = numeroOriginal;
            ValidationResult = new ValidationResult();
        }
    }
}
