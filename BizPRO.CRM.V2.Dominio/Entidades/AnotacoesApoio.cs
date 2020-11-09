using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AnotacoesApoio
    {
        public string Texto { get; set; }
        public DateTime CriadoEm { get; set; }
        public string Nome { get; set; }
        public bool AcompanhamentoOcorrencia { get; set; }
    }
}
