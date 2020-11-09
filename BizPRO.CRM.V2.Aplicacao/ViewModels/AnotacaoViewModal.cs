using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AnotacaoViewModal
    {
        public Anotacao Anotacoes { get; set; }
        public IEnumerable<AnotacoesApoio> AnotacoesApoio { get; set; }
    }
}
