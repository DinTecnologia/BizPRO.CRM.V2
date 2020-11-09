namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ClienteAtendimentoViewModel
    {
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? AtendimentoId { get; set; }
        public long? AtividadeId { get; set; }

        public ClienteAtendimentoViewModel(long? pessoaFisicaId, long? pessoaJuridicaId, long? atendimentoId, long? atividadeId)
        {
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            AtendimentoId = atendimentoId;
            AtividadeId = atividadeId;
        }
    }
}
