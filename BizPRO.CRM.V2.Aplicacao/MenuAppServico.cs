using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using DapperExtensions;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class MenuAppServico : IMenuAppServico
    {
        private readonly IMenuServico _servicoMenu;
        private readonly IFuncionalidadeServico _servicoFuncionalidade;
        private readonly IAspNetRolesMenuServico _servicoAspNetMenu;

        public MenuAppServico(IMenuServico servicoMenu, IFuncionalidadeServico servicoFuncionalidade,
            IAspNetRolesMenuServico servicoAspNetMenu)
        {
            _servicoMenu = servicoMenu;
            _servicoFuncionalidade = servicoFuncionalidade;
            _servicoAspNetMenu = servicoAspNetMenu;
        }

        public IEnumerable<MenuViewModel> Carregar(string userId, string url)
        {
            var menus = _servicoMenu.ObterMenu(userId, url);
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

        public IEnumerable<MenuViewModel> CarregarAdministracao()
        {
            var viewModel = new List<MenuViewModel>();
            var menus = _servicoMenu.ObterTodos();

            if (menus == null) return viewModel;
            viewModel.AddRange(menus.Select(menu => new MenuViewModel(menu)));

            return viewModel;
        }

        public MenuAdminFormViewModel Create()
        {
            var opcoesMenuPai = _servicoMenu.ObterTodos().Where(w => w.menuPai == null).ToList();
            var opcoesFuncionalidade = _servicoFuncionalidade.ObterTodos().OrderBy(o => o.Nome).ToList();
            var menu = _servicoMenu.ObterTodos();
            var perfisVinculados = _servicoAspNetMenu.ObterTodos().ToList();
            var viewModel = new MenuAdminFormViewModel(menu.FirstOrDefault(), opcoesMenuPai, opcoesFuncionalidade,
                perfisVinculados);
            return viewModel;
        }

        public void EditarAdd(MenuAdminFormViewModel model)
        {
            var entity = _servicoMenu.ObterPorId(model.Id);
            if (entity != null)
            {
                entity.menuPai = model.MenuPaiId;
                entity.icone = model.Icone;
                entity.nome = model.Nome;
                entity.ordem = model.Ordem;
                entity.tipo = model.Tipo;
                entity.funcionalidadeID = model.FuncionalidadeId;
                entity.tipoAbertura = model.TipoAbertura;
                _servicoMenu.Atualizar(entity);

                var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
                @where.Predicates.Add(Predicates.Field<AspNetRolesMenu>(f => f.MenusId, Operator.Eq, entity.id));
                var aspNetRoles = _servicoAspNetMenu.ObterPor(where);

                if (aspNetRoles.Any())
                    foreach (var x in aspNetRoles)
                        _servicoAspNetMenu.Deletar(x);

                foreach (var x in model.PerfisVinculados)
                {
                    var aspnetMenu = new AspNetRolesMenu
                    {
                        AspNetRolesId = x,
                        MenusId = entity.id
                    };
                    _servicoAspNetMenu.Adicionar(aspnetMenu);
                }
            }
        }

        public void CreateAdd(MenuAdminFormViewModel model)
        {
            var menu = new Menu {menuPai = model.MenuPaiId};
            if (model.AplicacaoId != null) menu.aplicacaoId = (int) model.AplicacaoId;
            menu.icone = model.Icone;
            menu.nome = model.Nome;
            menu.ordem = model.Ordem;
            menu.tipo = model.Tipo;
            menu.funcionalidadeID = model.FuncionalidadeId;
            menu.tipoAbertura = model.TipoAbertura;
            _servicoMenu.Adicionar(menu);

            foreach (var x in model.PerfisVinculados)
            {
                var aspnetMenu = new AspNetRolesMenu
                {
                    AspNetRolesId = x,
                    MenusId = menu.id
                };
                _servicoAspNetMenu.Adicionar(aspnetMenu);
            }
        }

        public MenuAdminFormViewModel Editar(int id)
        {
            var opcoesMenuPai = _servicoMenu.ObterTodos().Where(w => w.menuPai == null).ToList();
            var opcoesFuncionalidade = _servicoFuncionalidade.ObterTodos().OrderBy(o => o.Nome).ToList();
            var menu = _servicoMenu.ObterPorId(id);
            var perfisVinculados = _servicoAspNetMenu.BuscarPorMenuId(menu.id).ToList();
            var viewModel = new MenuAdminFormViewModel(menu, opcoesMenuPai, opcoesFuncionalidade, perfisVinculados);
            return viewModel;
        }
    }
}
