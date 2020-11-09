using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
   public  class CanalViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }

        public CanalViewModel(long id , string nome )
        {
            Id = id;
            Nome = nome; 
        }
    }
}
