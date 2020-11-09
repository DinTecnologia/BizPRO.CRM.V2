using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class MenuServico : Servico<Menu>, IMenuServico
    {
        private readonly IMenuRepositorio _repositorio;
        private readonly IFilaServico _servicoFilas;
        private readonly IFuncionalidadeServico _servicoFuncionalidade;

        public MenuServico(IMenuRepositorio repositorio, IFilaServico servicoFilas,
            IFuncionalidadeServico servicoFuncionalidade)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _servicoFilas = servicoFilas;
            _servicoFuncionalidade = servicoFuncionalidade;
        }

        public IEnumerable<Menu> ObterMenu(string userId, string url)
        {
            var menus = _repositorio.ObterMenu(userId, url);
            if (menus != null)
            {
                foreach (var menu in menus)
                {
                    if (menu.funcionalidadeID != null)
                    {
                        menu.Funcionalidade = _servicoFuncionalidade.ObterPorId((int) menu.funcionalidadeID);
                    }

                    if (menu.tipo != null)
                        if (menu.tipo.ToUpper() == "LFL")
                        {
                            menu.Filas = _servicoFilas.ObterFilasMenu(userId);
                        }
                }
            }
            return menus;
        }
    }
}
