using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class StatusAtividadeMapper : ClassMapper<StatusAtividade>
    {
        public StatusAtividadeMapper()
        {
            Table("StatusAtividade");
            Map(p => p.Id).Column("id").Key(KeyType.Identity);
            Map(p => p.Descricao).Column("descricao");
            Map(p => p.Ativo).Column("ativo");
            Map(p => p.FinalizaAtendimento).Column("finalizaAtendimento");
            Map(p => p.GerarEntidade).Column("gerarEntidade");
            Map(p => p.EntidadeNecessaria).Column("entidadeNecessaria");
            Map(p => p.AtividadesValidas).Column("atividadesValidas");
            Map(p => p.StatusPadrao).Column("statusPadrao");
            Map(p => p.FinalizaAtividade).Column("finalizaAtividade");
            Map(p => p.TipoAgendamento).Column("tipoAgendamento");
            Map(p => p.SentidosValidos).Column("sentidosValidos");
            Map(p => p.StatusDeSistema).Column("statusDeSistema");
            Map(p => p.EntidadeNaoNecessaria).Column("entidadeNaoNecessaria");
            Map(p => p.StatusAtividadeIdRequerida).Column("StatusAtividadeIdRequerida");
            Map(p => p.TempoMaximoAtividadeEmMinutos).Column("TempoMaximoAtividadeEmMinutos");
        }
    }
}
