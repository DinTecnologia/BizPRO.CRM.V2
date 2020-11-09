using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TelefonesTiposServico : Servico<TelefonesTipos>, ITelefonesTiposServico
    {
        private readonly ITelefonesTiposRepositorio _repositorio;
        public TelefonesTiposServico(ITelefonesTiposRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
