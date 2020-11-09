using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AcoesTokensValidadeViewModel
    {
        public long id { get; set; }
        public string acao { get; set; }
        public string token { get; set; }
        public DateTime criadoEm { get; set; }
        public DateTime? utilizadoEm { get; set; }
        public int validadePrevistaEmHoras { get; set; }
        public string valoresDaAcao { get; set; }

        public AcoesTokensValidadeViewModel(long id, string acao, string token, DateTime criadoEm, DateTime? utilizadoEm,
            int validadePrevistaEmHoras, string valoresDaAcao)
        {
            this.id = id;
            this.acao = acao;
            this.token = token;
            this.criadoEm = criadoEm;
            this.utilizadoEm = utilizadoEm;
            this.validadePrevistaEmHoras = validadePrevistaEmHoras;
            this.valoresDaAcao = valoresDaAcao;
        }

        public AcoesTokensValidadeViewModel()
        {

        }
    }
}
