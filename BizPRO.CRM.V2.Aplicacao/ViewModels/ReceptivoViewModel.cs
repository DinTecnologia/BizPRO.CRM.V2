using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ReceptivoViewModel
    {
        public long AtendimentoId { get; set; }
        public long LigacaoId { get; set; }
        public long AtividadeId { get; set; }
        public string InformacaoUra { get; set; }
        public string NumeroTelefone { get; set; }
        public string Protocolo { get; set; }
        public long? MidiaId { get; set; }
        public long? ContatoPessoaFisicaId { get; set; }
        public long? ContatoPessoaJuridicaId { get; set; }
        public long? TratativaPessoaFisicaId { get; set; }
        public long? TratativaPessoaJuridicaId { get; set; }
        public string NomeClienteContato { get; set; }
        public bool AtendimentoGeradoPelaUra { get; set; }
        public bool AtendimentoFinalizado { get; set; }
        public string StatusAtividade { get; set; }

        public SelectList ListaMidias { get; set; }
        public SelectList ListaStatusAtividade { get; set; }
        public ClientePerfilViewModel ClienteTratativa { get; set; }
        public ClientePerfilViewModel ClienteContato { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public ReceptivoViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        public ReceptivoViewModel(long atendimentoId, long ligacaoId, long atividadeId, string informacaoUra,
            string numeroTelefone, string protocolo, long? midiaId, long? contatoPessoaFisicaId,
            long? contatoPessoaJuridicaId, long? tratativaPessoaFisicaId, long? tratativaPessoaJuridicaId,
            SelectList listaMidias, SelectList listaStatusAtividade, string nomeClienteContato,
            bool atendimentoGeradoPelaUra, bool atendimentoFinalizado, string statusAtividade)
        {
            AtendimentoId = atendimentoId;
            LigacaoId = ligacaoId;
            AtividadeId = atividadeId;
            NumeroTelefone = string.IsNullOrEmpty(numeroTelefone) ? "Não Identificado" : numeroTelefone;
            InformacaoUra = string.IsNullOrEmpty(informacaoUra) ? "Sem Informação" : informacaoUra;
            Protocolo = protocolo;
            MidiaId = midiaId;
            ContatoPessoaFisicaId = contatoPessoaFisicaId;
            ContatoPessoaJuridicaId = contatoPessoaJuridicaId;
            TratativaPessoaFisicaId = tratativaPessoaFisicaId;
            TratativaPessoaJuridicaId = tratativaPessoaJuridicaId;
            ListaMidias = listaMidias;
            ListaStatusAtividade = listaStatusAtividade;
            NomeClienteContato = string.IsNullOrEmpty(nomeClienteContato)
                ? "Não Identificado"
                : nomeClienteContato.ToUpper();
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            AtendimentoGeradoPelaUra = atendimentoGeradoPelaUra;
            AtendimentoFinalizado = atendimentoFinalizado;
            StatusAtividade = statusAtividade;
        }

        public bool ClienteContatoDiferente()
        {
            return ContatoPessoaFisicaId.HasValue
                ? ContatoPessoaFisicaId != TratativaPessoaFisicaId
                : ContatoPessoaJuridicaId != TratativaPessoaJuridicaId;
        }
        public ReceptivoViewModel(string procotolo, DomainValidation.Validation.ValidationResult validationResult)
        {
            Protocolo = procotolo;
            ValidationResult = validationResult;
        }
    }
}
