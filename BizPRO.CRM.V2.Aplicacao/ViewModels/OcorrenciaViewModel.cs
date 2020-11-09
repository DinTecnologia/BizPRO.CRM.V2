using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class OcorrenciaViewModel
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public string Cliente { get; set; }
        public long? OcorrenciaTipoId { get; set; }
        public string StatusIds { get; set; }
        public bool? SlaAtrasado { get; set; }
        public string ResponsavelId { get; set; }
        public string CriadoPorId { get; set; }
        public SelectList ListaOcorrenciaTipo { get; set; }
        public SelectList ListaStatus { get; set; }
        public SelectList ListaUsuarios { get; set; }
        public SelectList ListaDepartamento { get; set; }
        public int? DepartamentoId { get; set; }

        //[Key]
        //public Guid Id { get; set; }

        //[MaxLength(4000, ErrorMessage = "Máximo 4000 caracteres")]
        //[MinLength(10, ErrorMessage = "Mínimo 10 caracteres")]
        //[Required(ErrorMessage = "Preencha o campo Descritivo")]
        //[Display(Name = "Descritivo")]
        //public string decritivoDeAbertura { get; set; }

        //public IEnumerable<Contrato> ListaContrato { get; set; }
        //public IEnumerable<OcorrenciaTipo> ListaOcorrenciaTipo { get; set; }

        public OcorrenciaViewModel()
        {

        }

        public OcorrenciaViewModel(SelectList listaOcorrenciaTipo, SelectList listaUsuarios, SelectList listaDepartamento)
        {
            DataInicio = DateTime.Now;
            DataFinal = DateTime.Now;
            ListaOcorrenciaTipo = listaOcorrenciaTipo;
            ListaUsuarios = listaUsuarios;
            ListaDepartamento = listaDepartamento;
        }
    }
}
