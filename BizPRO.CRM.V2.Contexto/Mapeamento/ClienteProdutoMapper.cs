using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ClienteProdutoMapper : ClassMapper<ClienteProduto>
    {
        public ClienteProdutoMapper()
        {
            Table("ClienteProdutos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.ClienteId).Column("clienteId");
            Map(m => m.ProdutoId).Column("produtoId");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
        }
    }
}
