using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EmailRemetenteRegraServico : Servico<EmailRemetenteRegra>, IEmailRemetenteRegraServico
    {
        private readonly IEmailRemetenteRegraRepositorio _repositorio;

        public EmailRemetenteRegraServico(IEmailRemetenteRegraRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }        

        public IEnumerable<EmailRemetenteRegra> ObterPorFilaId(int? filaId)
        {
            return _repositorio.ObterRemetentesRegras(filaId);
        }
    }
}
