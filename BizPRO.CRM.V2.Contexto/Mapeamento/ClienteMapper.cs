using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ClienteMapper : ClassMapper<Cliente>
    {
        public ClienteMapper()
        {
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.TipoCliente).Column("tipoCliente");
            Map(m => m.Nome).Column("nome");
            Map(m => m.Documento).Column("documento");
            Map(m => m.DataNascimento).Column("dataNascimento");
        }
    }
}
