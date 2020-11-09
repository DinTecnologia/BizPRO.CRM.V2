using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ArquivoFormViewModel
    {
        public long Id { get; set; }
        public string Caminho { get; set; }
        public string Nome { get; set; }
        public long Tamanho { get; set; }
        public string Extensao { get; set; }
        public long ChaveEntidadeId { get; set; }
        public long EntidadeId { get; set; }
        public long? OcorrenciaId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public string ContentType { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public ArquivoFormViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        public ArquivoFormViewModel(string nome, string caminho, long tamanho, string extensao, long chaveEntidadeId,
            long entidadeId, string contentType)
        {
            ValidationResult = new ValidationResult();
            Nome = nome;
            Caminho = caminho;
            Tamanho = tamanho;
            Extensao = extensao;
            ChaveEntidadeId = chaveEntidadeId;
            EntidadeId = entidadeId;
            ContentType = contentType;
        }
    }
}
