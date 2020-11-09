using System;
using System.Collections.Generic;
using System.Text;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ContratosIntegracaoViewModel
    {
        public string Status { get; private set; }
        public string Vigencia { get; private set; }
        public string Apolice { get; private set; }
        public string Apelido { get; private set; }
        public string Produtos { get; private set; }

        public ContratosIntegracaoViewModel(string status, DateTime? dataVigenciaInicio, DateTime? dataVigenciaFim,
            string apolice, List<string> produtos)
        {
            Status = status;
            Apelido = "--";
            Apolice = apolice;

            var spVigencia = new StringBuilder();
            spVigencia.Append(dataVigenciaInicio.HasValue ? dataVigenciaInicio.Value.ToString("dd/MM/yyyy") : "--");
            spVigencia.Append(" até ");
            spVigencia.Append(dataVigenciaFim.HasValue ? dataVigenciaFim.Value.ToString("dd/MM/yyyy") : "--");
            Vigencia = spVigencia.ToString();

            var spProdutos = new StringBuilder();
            if (produtos != null)
                for (int i = 0; i < produtos.Count; i++)
                {
                    if (i > 0)
                        spProdutos.Append(" " + produtos[i]);
                    else
                        spProdutos.Append(produtos[i]);
                }

            Produtos = spProdutos.ToString();
        }
    }
}
