using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ConfiguracaoContasEmailsServico : IConfiguracaoContasEmailsServico
    {
        private readonly IConfiguracaoContasEmailsRepositorio _repositorio;

        public ConfiguracaoContasEmailsServico(IConfiguracaoContasEmailsRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ConfiguracaoContasEmails ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<ConfiguracaoContasEmails> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public ConfiguracaoContasEmails ObterContaEmailPorAtividadeId(long atividadeId)
        {
            return _repositorio.ObterContaEmailPorAtividadeId(atividadeId);
        }

        public ConfiguracaoContasEmails ObterPorFilaId(int filaId)
        {
            return _repositorio.ObterPorFilaId(filaId);
        }

        public ConfiguracaoContasEmails ObterContaPadrao()
        {
            return _repositorio.ObterContaPadrao();
        }

        public IEnumerable<ConfiguracaoContasEmails> ObterPorUsuarioId(string usuarioId)
        {
            return _repositorio.ObterPorUsuarioId(usuarioId);
        }

        public IEnumerable<ConfiguracaoContasEmails> ObterRegistroEmailEntrada(string usuarioId)
        {
            return _repositorio.ObterRegistroEmailEntrada(usuarioId);
        }
    }
}
