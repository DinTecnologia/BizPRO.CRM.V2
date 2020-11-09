using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;


namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class FeriadoServico : IFeriadoServico
    {
        private readonly IFeriadoRepositorio _repositorio;

        public FeriadoServico(IFeriadoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public System.Collections.Generic.IEnumerable<Entidades.Feriado> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }
    }
}
