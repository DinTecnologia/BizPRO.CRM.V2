using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;


namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class FeriadoMapper : ClassMapper<Feriado>
    {
        public FeriadoMapper()
        {
            Table("feriados");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Ano).Column("ano");
            Map(m => m.Mes).Column("mes");
            Map(m => m.Dia).Column("dia");
            Map(m => m.Uf).Column("uf");
            Map(m => m.Descricao).Column("descricao");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserId");            
            Map(m => m.AtualizadoEm).Column("atualizadoEm");
            Map(m => m.AtualizadoPorUserId).Column("atualizadoPorUserId");
            Map(m => m.Ativo).Column("ativo");
        }
    }
}
