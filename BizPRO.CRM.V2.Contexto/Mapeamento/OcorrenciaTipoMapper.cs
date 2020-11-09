using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class OcorrenciaTipoMapper : ClassMapper<OcorrenciaTipo>
    {
        public OcorrenciaTipoMapper()
        {
            Table("OcorrenciasTipos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.OcorrenciasTiposPaiId).Column("ocorrenciasTiposPaiID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.NomeExibicao).Column("nomeExibicao");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.EstruturaDeIDs).Column("estruturaDeIDs");
            Map(m => m.VincularLocal).Column("vincularLocal");
            Map(m => m.TempoPrevistoAtendimento).Column("tempoPrevistoAtendimento");
            Map(m => m.TempoPrevistoCorrido).Column("TempoPrevistoCorrido");
            Map(m => m.TextoDescricaoPadrao).Column("TextoDescricaoPadrao");
            Map(m => m.EhUltimoNivel).Column("ehUltimoNivel");
        }
    }
}