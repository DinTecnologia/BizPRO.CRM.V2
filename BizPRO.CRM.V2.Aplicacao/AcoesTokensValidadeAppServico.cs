using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AcoesTokensValidadeAppServico : IAcoesTokensValidadeAppServico
    {
        private readonly IAcoesTokensValidadeServico _acoesTokensValidadeServico;

        public AcoesTokensValidadeAppServico(IAcoesTokensValidadeServico acoesTokensValidadeServico)
        {
            _acoesTokensValidadeServico = acoesTokensValidadeServico;
        }

        public AcoesTokensValidadeViewModel Adicionar(string userName)
        {
            var retorno = _acoesTokensValidadeServico.AdicionarToken(new AcoesTokensValidade(userName));
            return new AcoesTokensValidadeViewModel(retorno.Id, retorno.Acao, retorno.Token, retorno.CriadoEm, retorno.UtilizadoEm, retorno.ValidadePrevistaEmHoras, retorno.ValoresDaAcao);
        }

        public AcoesTokensValidadeViewModel Carregar(string token)
        {
            var retorno = _acoesTokensValidadeServico.CarregarPorToken(token);
            if (retorno == null)
                return null;

            if (retorno.UtilizadoEm != null || retorno.CriadoEm.AddHours(retorno.ValidadePrevistaEmHoras) < DateTime.Now)
                return null;

            return new AcoesTokensValidadeViewModel(retorno.Id, retorno.Acao, retorno.Token, retorno.CriadoEm,
                retorno.UtilizadoEm, retorno.ValidadePrevistaEmHoras, retorno.ValoresDaAcao);
        }

        public AcoesTokensValidadeViewModel AtualizarToken(string token)
        {
            var retorno = _acoesTokensValidadeServico.AtualizarToken(token);
            return retorno == null
                ? null
                : new AcoesTokensValidadeViewModel(retorno.Id, retorno.Acao, retorno.Token, retorno.CriadoEm,
                    retorno.UtilizadoEm, retorno.ValidadePrevistaEmHoras, retorno.ValoresDaAcao);
        }
    }
}
