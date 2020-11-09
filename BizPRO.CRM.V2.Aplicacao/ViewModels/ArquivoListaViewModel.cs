using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ArquivoListaViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Tamanho { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }

        public ArquivoListaViewModel(long id, string nome, string tamanho, DateTime criadoEm, string criadoPor)
        {
            Id = id;
            Nome = nome;
            Tamanho = tamanho;
            CriadoEm = criadoEm;
            CriadoPor = criadoPor;
        }
    }
}
