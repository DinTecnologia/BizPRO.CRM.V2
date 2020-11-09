using System;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AnotacoesViewForm
    {
        public string NomeUsuarioCriador { get; set; }
        public string Texto { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool AcompanhamentoOcorrencia { get; set; }

        public AnotacoesViewForm(AnotacoesApoio anotacaoApoio)
        {
            NomeUsuarioCriador = anotacaoApoio.Nome;
            Texto = anotacaoApoio.Texto;
            CriadoEm = anotacaoApoio.CriadoEm;
            AcompanhamentoOcorrencia = anotacaoApoio.AcompanhamentoOcorrencia;
        }
    }
}
