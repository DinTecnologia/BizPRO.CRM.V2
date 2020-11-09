using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class EntidadeSecaoCampoDinamicoMapper : ClassMapper<EntidadeSecaoCampoDinamico>
    {
        public EntidadeSecaoCampoDinamicoMapper()
        {
            Table("EntidadesSecoesCamposDinamicos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.CamposDinamicosId).Column("camposDinamicosID");
            Map(m => m.EntidadesSecoesId).Column("entidadesSecoesID");
            Map(m => m.Ativo).Column("Ativo");
            Map(m => m.Ordem).Column("Ordem");
        }
    }
}
