using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EmailModeloServico : Servico<EmailModelo>, IEmailModeloServico
    {
        private readonly IEmailModeloRepositorio _repositorio;

        public EmailModeloServico(IEmailModeloRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<EmailModelo> ObterPor(EmailModelo entidade)
        {
            return _repositorio.ObterPor(entidade);
        }

        public EmailModelo ObterUltimoModeloPor(EmailModelo entidade)
        {
            return _repositorio.ObterPor(entidade).OrderByDescending(o => o.Id).FirstOrDefault();
        }

        public EmailModelo ObterModeloNovaOcorrenciaLinkExterno()
        {
            var emailModelo = new EmailModelo();
            emailModelo.SetarNovaOcorrenciaLinkExterno();
            return ObterUltimoModeloPor(emailModelo);
        }
    }
}
