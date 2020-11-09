using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class PessoaJuridicaContatoViewModel
    {
        public long Id { get; set; }
        public long PessoasFisicasId { get; set; }
        public bool Principal { get; set; }
        public int TiposContatoPessoaJuridicaId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public DateTime? RemovidoEm { get; set; }
        public string RemovidoPorUserId { get; set; }
        public long PessoasJuridicasId { get; set; }
        public PessoaFisicaFormViewModel PessoaFisicaFormViewModel { get; set; }
        public PessoaJuridicaFormViewModel PessoaJuridicaFormViewModel { get; set; }
        public PessoaJuridicaTiposContatoViewModel PessoaJuridicaTiposContatoViewModel { get; set; }

        public PessoaJuridicaContatoViewModel(long id, long pessoasFisicaId, long pessoasJuridicasId,
            PessoaFisicaFormViewModel pessoaFisicaFormViewModel,
            PessoaJuridicaTiposContatoViewModel pessoaJuridicaTiposContatoViewModel,
            PessoaJuridicaFormViewModel pessoaJuridicaFormViewModel)
        {
            Id = id;
            PessoasJuridicasId = pessoasJuridicasId;
            PessoasFisicasId = pessoasFisicaId;
            PessoaFisicaFormViewModel = pessoaFisicaFormViewModel;
            PessoaJuridicaTiposContatoViewModel = pessoaJuridicaTiposContatoViewModel;
            PessoaJuridicaFormViewModel = pessoaJuridicaFormViewModel;
        }

        public PessoaJuridicaContatoViewModel(long id, long pessoasFisicasId, bool principal,
            int tiposContatoPessoaJuridicaID, DateTime criadoEm, string criadoPorUserId, long pessoasJuridicasId)
        {
            PessoasFisicasId = pessoasFisicasId;
            PessoasJuridicasId = pessoasJuridicasId;
        }

        public PessoaJuridicaContatoViewModel()
        {

        }
    }
}
