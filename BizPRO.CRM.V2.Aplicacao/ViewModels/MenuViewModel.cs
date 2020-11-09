using System;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class MenuViewModel
    {
        public long Id { get; set; }
        public long? MenuPai { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
        public String Action { get; set; }
        public String Controller { get; set; }        
        public string Parametro { get; set; }
        public string TipoAbertura { get; set; }
        public string Largura { get; set; }
        public string Altura { get; set; }
        public string Tipo { get; set; }
        public int Ordem { get; set; }
        public string Sobrescreve { get; set; }

        public MenuViewModel()
        {

        }
        public MenuViewModel(Menu menu, Fila fila)
        {
            if (menu == null) return;

            Ordem = menu.ordem;
            Icone = menu.icone;
            Id = menu.id;
            MenuPai = menu.menuPai;
            Tipo = menu.tipo;


            if (!string.IsNullOrEmpty(menu.tipoAbertura))
            {
                var contador = 1;
                foreach (var item in menu.tipoAbertura.Split('|'))
                {
                    switch (contador)
                    {
                        case 1: TipoAbertura = item.ToUpper(); break;
                        case 2: Largura = item; break;
                        case 3: Altura = item; break;
                        case 4: Sobrescreve = item; break;
                    }
                    contador++;
                }
            }

            switch (menu.tipo.ToUpper())
            {
                case "GRP":
                    Nome = menu.nome;
                    break;

                case "FUN":
                    Nome = menu.Funcionalidade.Nome;
                    Action = menu.Funcionalidade.ActionName;
                    Controller = menu.Funcionalidade.ControllerName;
                    Parametro = menu.Funcionalidade.PatternParametros ?? null;
                    break;

                case "LFL":
                    Nome = fila != null ? fila.Nome : "";
                    Action = menu.Funcionalidade.ActionName;
                    Controller = menu.Funcionalidade.ControllerName;
                    Parametro = fila != null ? fila.Id.ToString() : "";
                    break;
            }
        }
        public MenuViewModel(Menu menu)
        {
            if (menu == null) return;
            Ordem = menu.ordem;
            Icone = menu.icone;
            Id = menu.id;
            MenuPai = menu.menuPai;
            Tipo = menu.tipo;
            Nome = menu.nome;
        }
    }
}
