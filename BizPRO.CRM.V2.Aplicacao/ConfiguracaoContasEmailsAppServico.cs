using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ConfiguracaoContasEmailsAppServico : IConfiguracaoContasEmailsAppServico
    {
        private readonly IConfiguracaoContasEmailsServico _servicoContasEmail;

        public ConfiguracaoContasEmailsAppServico(IConfiguracaoContasEmailsServico servicoContasEmail)
        {
            _servicoContasEmail = servicoContasEmail;
        }

        public IEnumerable<ConfiguracoesContaEmailsViewModel> ObterTodos()
        {
            var filas = _servicoContasEmail.ObterTodos();
            return
                filas.Select(
                    item =>
                        new ConfiguracoesContaEmailsViewModel(item.Id, item.Descricao, item.ServidorPop,
                            item.ServidorSmtp, item.NecessarioSsl, item.Email, item.SenhaEmail, item.UsuarioEmail,
                            item.FilasId, item.ContaPadrao)).ToList();
        }


        public ConfiguracoesContaEmailsViewModel ObterPorId(int id)
        {
            var entidade = _servicoContasEmail.ObterPorId(id);

            var retorno = new ConfiguracoesContaEmailsViewModel
            {
                Assinatura = entidade.Assinatura
            };

            return retorno;
        }
    }
}