using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class BaseAppServico : IBaseAppServico
    {
        private readonly IMenuServico _menuServico;
        private readonly IConfiguracaoServico _configuracaoServico;
        private readonly IEntidadeServico _entidadeServico;

        public BaseAppServico(IMenuServico menuServico, IConfiguracaoServico configuracaoServico,IEntidadeServico entidadeServico)
        {
            _menuServico = menuServico;
            _configuracaoServico = configuracaoServico;
            _entidadeServico = entidadeServico;
        }

        public IEnumerable<MenuViewModel> ObterMenu(string usuarioId, string url)
        {
            var menus = _menuServico.ObterMenu(usuarioId, url);
            var retorno = new List<MenuViewModel>();

            if (menus == null) return retorno;

            foreach (var menu in menus)
            {
                if (menu.tipo.ToUpper() == "LFL")
                {
                    if (menu.Filas == null) continue;
                    retorno.AddRange(menu.Filas.Select(fila => new MenuViewModel(menu, fila)));
                }
                else
                    retorno.Add(new MenuViewModel(menu, null));
            }
            return retorno;
        }

        public string ObterTitle()
        {
            return _configuracaoServico.ObterTitle();
        }

        public string ObterTitleMenu()
        {
            return _configuracaoServico.ObterTitleMenu();
        }

        public string ObterScript(string nomeLogico)
        {
            return string.IsNullOrEmpty(nomeLogico) ? null : _entidadeServico.ObterScriptEntidade(nomeLogico);
        }
    }
}
