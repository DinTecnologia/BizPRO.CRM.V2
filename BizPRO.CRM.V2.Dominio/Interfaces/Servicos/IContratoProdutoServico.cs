using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IContratoProdutoServico : IServico<ContratoProduto>
    {
        IEnumerable<ContratoProduto> ListarContratoProduto(long? contratoId, long? produtoId);
    }
}
