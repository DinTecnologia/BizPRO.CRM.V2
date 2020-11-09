using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AbasClienteViewModel
    {
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? AtendimentoId { get; set; }
        public bool EdicaoCliente { get; set; }
        public bool AbrirOcorrenciaIframe { get; set; }
        public bool AbaIntegracao { get; set; }
        public DateTime? DataUltimaAtualizacaoIntegracao { get; set; }
    }
}
