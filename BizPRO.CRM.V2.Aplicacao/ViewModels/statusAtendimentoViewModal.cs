using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class StatusAtendimentoViewModel
    {
        public IEnumerable<StatusAtividade> StatusAtividade { get; set; }
        public int StatusId { get; set; }
        public long AtividadeId { get; set; }
        public int? MidiaId { get; set; }
        public long? AtendimentoId { get; set; }

        public int Id { get; private set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool FinalizaAtendimento { get; set; }
        public bool GerarEntidade { get; set; }
        public string EntidadeNecessaria { get; set; }
        public string AtividadesValidas { get; set; }
        public bool StatusPadrao { get; set; }
        public bool FinalizaAtividade { get; set; }
    }
}
