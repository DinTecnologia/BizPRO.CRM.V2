using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class MidiaViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CriadoPorAspNetUserId { get; set; }
        public DateTime CriadoEm { get; set; }

        public MidiaViewModel(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
