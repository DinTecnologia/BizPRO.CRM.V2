using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class TarefaViewModel
    {
        public long? TarefaId { get; set; }
        public Anotacao Anotacoes { get; set; }
        public IEnumerable<AnotacoesApoio> AnotacoesApoio { get; set; }
        public IEnumerable<StatusAtividade> StatusAtividade { get; set; }
        public long statusId { get; set; }
        public TarefaAtividadeOcorrencia TarefaAtividadeOcorrencia { get; set; }
        //public Apoio Apoio { get; set; }
        public AnotacaoViewModal AnotacaoViewModal { get; set; }
        public bool PodeEditar { get; set; }
        public long? AtividadeId { get; set; }

        public TarefaViewModel()
        {
            AnotacaoViewModal = new AnotacaoViewModal();
            PodeEditar = true;
        }
    }
}
