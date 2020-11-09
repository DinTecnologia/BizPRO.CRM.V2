using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class LogAcessoServico : Servico<LogAcesso>, ILogAcessoServico
    {
        private readonly ILogAcessoRepositorio _repositorio;
        public LogAcessoServico(ILogAcessoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
