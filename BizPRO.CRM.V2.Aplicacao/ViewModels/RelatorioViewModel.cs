using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class RelatorioViewModel
    {
        public string dataInicio { get; set; }
        public string dataFim { get; set; }
        public string Responsavel { get; set; }
        public int? StatusID { get; set; }
        public string DsStatus { get; set; }
        public int? UsuarioID { get; set; }
        public string DsUsuario { get; set; }
        public int? OcorrenciaTipoID { get; set; }
        public string DsOcorrenciaTipo { get; set; }
        public int? CanalID { get; set; }
        public string DsCanal { get; set; }
        public int? MidiaID { get; set; }
        public string DsMidia { get; set; }
        public string DsSentido { get; set; }
        public int? ClienteID { get; set; }
        public string DsCliente { get; set; }
        public string ClienteTipo { get; set; }
        public IEnumerable<StatusEntidade> Status { get; set; }
        public IEnumerable<Relatorio> HistoricoCronologia { get; set; }
        public IEnumerable<Relatorio> RelatorioAtendimento { get; set; }
        public IEnumerable<Usuario> ListaUsuarios { get; set; }
        public statusEntidadeViewModal StatusEntidade { get; set; }
        public IEnumerable<OcorrenciaTipoViewModel> ListarOcorrenciaTipo { get; set; }
        public IEnumerable<CanalViewModel> ListarCanais { get; set; }
        public IEnumerable<MidiaViewModel> ListarMidias { get; set; }

    }
}
