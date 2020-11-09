using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class TarefaMapper : ClassMapper<Tarefa>
    {
        public TarefaMapper()
        {
            Table("tarefas");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.ResponsavelPorUserId).Column("responsavelPorUserID");
            Map(m => m.Descricao).Column("descricao");
            Map(m => m.AtividadeId).Column("atividadeID");
        }
    }
}
