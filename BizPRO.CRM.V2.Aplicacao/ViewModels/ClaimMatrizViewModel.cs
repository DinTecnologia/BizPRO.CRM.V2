using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ClaimMatrizViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public AspNetMatriz Matriz { get; set; }
    }
}
