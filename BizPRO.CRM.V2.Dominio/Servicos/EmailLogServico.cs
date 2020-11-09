using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EmailLogServico : Servico<EmailLog>, IEmailLogServico
    {
        private readonly IEmailLogRepositorio _repositorio;

        public EmailLogServico(IEmailLogRepositorio repositorio)
            : base(repositorio)
        {
            this._repositorio = repositorio;
        }
    }
}
