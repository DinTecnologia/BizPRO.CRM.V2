using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class StatusAtividadeListaViewModel
    {
        public int id { get; set; }
        public string descricao { get; set; }

        public void Popular(StatusAtividade statusAtividade)
        {
            this.id = statusAtividade.Id;
            this.descricao = statusAtividade.Descricao;
        }
    }
}
