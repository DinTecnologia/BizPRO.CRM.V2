using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class CategoriaDdlViewModel
    {
        public int Contador { get; set; }
        public SelectList Opcoes { get; set; }
        public string ValorSelecionado { get; set; }

        //public CategoriaDdlViewModel(int contador, SelectList opcoes, string valorSelecionado)
        //{
        //    Contador = contador;
        //    Opcoes = opcoes;
        //    ValorSelecionado = valorSelecionado;
        //}
    }
}
