using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AlterarMotivoViewModel
    {
        public long OcorrenciaId { get; set; }
        public string NomeMotivoAtual { get; set; }
        public IEnumerable<OcorrenciaTipo> ListaOcorrenciaTipo { get; set; }
        public long? OcorrenciaTipoId { get; set; }
        public long OcorrenciaTipoNovoId { get; set; }
    }

    public class AlterarContratoViewModel
    {
        public long OcorrenciaId { get; set; }
        public string NomeContratoAtual { get; set; }
        public IEnumerable<Contrato> ListaContrato { get; set; }
        public long? ContratoId { get; set; }
        public long ContratoNovoId { get; set; }
    }
}
