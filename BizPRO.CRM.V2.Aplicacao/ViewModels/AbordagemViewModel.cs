using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AbordagemViewModel
    {
        public long? LigacaoId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? AtividadeId { get; set; }
        public long? AtendimentoId { get; set; }
        public long ClienteId { get; set; }
        public string TipoCliente { get; set; }


        public IEnumerable<Ocorrencia> OcorrenciaLista { get; set; }
        public IEnumerable<ContatoListaViewModel> ContatoLista { get; set; }
        public IEnumerable<ProtocoloListaViewModel> ProtocoloLista { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public AbordagemViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        public AbordagemViewModel(long? pessoaFisicaId, long? pessoaJuridicaId, long? atividadeId, long? ligacaoId,
            long? atendimentoId)
        {
            PessoaJuridicaId = pessoaJuridicaId;
            PessoaFisicaId = pessoaFisicaId;
            AtividadeId = atividadeId;
            Nome = "Não informado";
            Documento = "Não informado";
            Email = "Não informado";
            ClienteId = pessoaFisicaId ?? (pessoaJuridicaId ?? 0);
            TipoCliente = pessoaFisicaId != null ? "pf" : pessoaJuridicaId != null ? "pj" : "ni";
            LigacaoId = ligacaoId;
            AtendimentoId = atendimentoId;
        }
    }
}
