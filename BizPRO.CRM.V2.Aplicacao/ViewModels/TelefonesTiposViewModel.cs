using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class TelefonesTiposViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public IEnumerable<TelefonesTipos> ListaTelefonesTipos { get; set; }

        public TelefonesTiposViewModel()
        {

        }

        public TelefonesTiposViewModel( int id , string nome)
        {
            this.id = id;
            this.nome = nome;
        }

    }
}
