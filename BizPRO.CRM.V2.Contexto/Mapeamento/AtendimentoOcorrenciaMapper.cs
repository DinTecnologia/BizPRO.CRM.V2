using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AtendimentoOcorrenciaMapper : ClassMapper<AtendimentoOcorrencia>
    {
        public AtendimentoOcorrenciaMapper()
        {
            Table("AtendimentosOcorrencias");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.OcorrenciasId).Column("ocorrenciasID");
            Map(m => m.AtendimentosId).Column("atendimentosID");            
        }
    }
}
