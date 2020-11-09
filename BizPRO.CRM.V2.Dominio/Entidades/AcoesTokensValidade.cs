using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AcoesTokensValidade
    {

        public long Id { get; set; }
        public string Acao { get; set; }
        public string Token { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? UtilizadoEm { get; set; }
        public int ValidadePrevistaEmHoras { get; set; }
        public string ValoresDaAcao { get; set; }

        public AcoesTokensValidade(string valoresDaAcao)
        {
            Acao = "RESETSENHA";
            Token = Guid.NewGuid().ToString();
            CriadoEm = DateTime.Now;
            ValoresDaAcao = valoresDaAcao;
            ValidadePrevistaEmHoras = 24;
        }

        public AcoesTokensValidade()
        {

        }

        public AcoesTokensValidade(long id, string acao, string token, DateTime criadoEm, DateTime? utilizadoEm,
            int validadePrevistaEmHoras, string valoresDaAcao)
        {
            Id = id;
            Acao = acao;
            Token = token;
            CriadoEm = criadoEm;
            UtilizadoEm = utilizadoEm;
            ValidadePrevistaEmHoras = validadePrevistaEmHoras;
            ValoresDaAcao = valoresDaAcao;
        }
    }
}
