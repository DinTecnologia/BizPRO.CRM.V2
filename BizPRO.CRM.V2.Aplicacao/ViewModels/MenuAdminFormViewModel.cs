using System;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class MenuAdminFormViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? MenuPaiId { get; set; }
        public string Tipo { get; set; }
        public int? FuncionalidadeId { get; set; }
        public string TipoAbertura { get; set; }
        public int Ordem { get; set; }
        public string Icone { get; set; }
        public int? AplicacaoId { get; set; }
        public SelectList OpcoesMenuPai { get; set; }
        public SelectList OpcoesFuncionalidade { get; set; }
        public SelectList OpcoesTipo { get; set; }
        public SelectList OpcoesTipoAbertura { get; set; }
        public SelectList OpcoesOrdem { get; set; }
        public IEnumerable<SelectListItem> OpcoesPerfil { get; set; }
        public List<string> PerfisVinculados { get; set; }

        public MenuAdminFormViewModel()
        {
        }

        public MenuAdminFormViewModel(Menu entidade, List<Menu> listaMenuPai, List<Funcionalidade> listaFuncionalidade,
            List<AspNetRolesMenu> listaPerfilVinculados)
        {
            Id = entidade.id;
            Nome = entidade.nome;
            MenuPaiId = entidade.menuPai;
            Tipo = entidade.tipo;
            FuncionalidadeId = entidade.funcionalidadeID;
            TipoAbertura = entidade.tipoAbertura;
            Ordem = entidade.ordem;
            Icone = entidade.icone;
            AplicacaoId = entidade.aplicacaoId;
            OpcoesMenuPai = new SelectList(listaMenuPai, "id", "nome");
            OpcoesFuncionalidade = new SelectList(listaFuncionalidade, "id", "nome");
            PerfisVinculados = new List<string>();

            if (listaPerfilVinculados != null)
                foreach (var item in listaPerfilVinculados)
                {
                    PerfisVinculados.Add(item.AspNetRolesId);
                }

            var listaOpcoesTipo = new Dictionary<string, string>
            {
                {"Funcionalidade", "FUN"},
                {"Grupo", "GRP"},
                {"Listagem", "LFL"}
            };
            OpcoesTipo = new SelectList(listaOpcoesTipo);

            var listaOpcoesTipoAbertura = new Dictionary<string, string>
            {
                {"Página", "PAG"},
                {"PopUp", "POP"}
            };
            OpcoesTipoAbertura = new SelectList(listaOpcoesTipoAbertura);

            var listaOpcoesOrdem = new Dictionary<int, string>();
            for (var x = 1; x <= 100; x++)
                listaOpcoesOrdem.Add(x, Convert.ToString(x));
            OpcoesOrdem = new SelectList(listaOpcoesOrdem);
        }
    }
}

