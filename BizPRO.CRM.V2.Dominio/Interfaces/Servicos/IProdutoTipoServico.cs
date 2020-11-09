using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IProdutoTipoServico : IServico<ProdutoTipo>
    {
        IEnumerable<ProdutoTipo> ObterProdutoTipoAtivo(long? idProdutoTipo);
    }
}
