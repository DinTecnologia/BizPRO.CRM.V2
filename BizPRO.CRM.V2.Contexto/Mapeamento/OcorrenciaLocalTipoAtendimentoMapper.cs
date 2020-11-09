using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class OcorrenciaLocalTipoAtendimentoMapper : ClassMapper<OcorrenciaLocalTipoAtendimento>
    {
        public OcorrenciaLocalTipoAtendimentoMapper()
        {
            Table("OcorrenciasLocaisTipoAtendimento");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.OcorrenciasId).Column("ocorrenciasID");
            Map(m => m.LocaisId).Column("locaisID");
            Map(m => m.LocaisTiposAtendimentoId).Column("locaisTiposAtendimentoID");
            Map(m => m.Logradouro).Column("logradouro");
            Map(m => m.Numero).Column("numero");
            Map(m => m.Cep).Column("cep");
            Map(m => m.Bairro).Column("bairro");
            Map(m => m.CidadesId).Column("cidadesID");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.AlteradoPorUserId).Column("alteradoPorUserID");
            Map(m => m.AlteradoEm).Column("alteradoEm");
            Map(m => m.Complemento).Column("complemento");
        }
    }
}
