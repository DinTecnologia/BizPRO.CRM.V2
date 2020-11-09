using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IProdutoTipoAppServico
    {   
        IEnumerable<ProdutoTipo> ObterProdutoTipoAtivo(int? idProdutoTipo);
    }
}
