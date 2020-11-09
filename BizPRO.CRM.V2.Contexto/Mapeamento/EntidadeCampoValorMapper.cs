using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class EntidadeCampoValorMapper : ClassMapper<EntidadeCampoValor>
    {
        public EntidadeCampoValorMapper()
        {
            Table("EntidadesCamposValores");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.EntidadeId).Column("entidadeID");
            Map(m => m.NomeCampo).Column("nomeCampo");
            Map(m => m.Valor).Column("valor");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.ValorPadrao).Column("valorPadrao");
        }
    }
}
