using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ServicoMapper : ClassMapper<Servico>
    {
        public ServicoMapper()
        {
            Table("Servicos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.AlteradoPorUserId).Column("alteradoPorUserID");
            Map(m => m.AlteradoEm).Column("alteradoEm");
        }
    }
}
