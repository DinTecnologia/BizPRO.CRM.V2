using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class TimelineApoioMapper : ClassMapper<TimelineApoio>
    {
        public TimelineApoioMapper()
        {   
            Map(m => m.plaTipo).Column("plaTipo");
            Map(m => m.plaTipoID).Column("plaTipoID");
            Map(m => m.plaAtendimentoID).Column("plaAtendimentoID");
            Map(m => m.plaNomeTipo).Column("plaNomeTipo");
            Map(m => m.plaData).Column("plaData");
            Map(m => m.plaStatus).Column("plaStatus");
            Map(m => m.plaDataTermino).Column("plaDataTermino");
            Map(m => m.plaCriadoPor).Column("plaCriadoPor");
            Map(m => m.plaResponsavel).Column("plaResponsavel");
            Map(m => m.plaTitulo).Column("plaTitulo");
            Map(m => m.pladescricao).Column("pladescricao");
            Map(m => m.plasentido).Column("plasentido");
        }
    }
}
