using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class OcorrenciaMapper : ClassMapper<Ocorrencia>
    {
        public OcorrenciaMapper()
        {
            Table("Ocorrencias");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.OcorrenciasTiposId).Column("ocorrenciasTiposID");
            Map(m => m.DecritivoDeAbertura).Column("decritivoDeAbertura");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.PessoaFisicaId).Column("pessoaFisicaID");
            Map(m => m.PessoaJuridicaId).Column("pessoaJuridicaID");
            Map(m => m.PotenciaisClientesId).Column("potenciaisClientesID");
            Map(m => m.ContratoId).Column("contratoID");
            Map(m => m.FinalizadoEm).Column("finalizadoEm");
            Map(m => m.FinalizadoPorUserId).Column("finalizadoPorUserID");
            Map(m => m.StatusEntidadesId).Column("statusEntidadesID");
            Map(m => m.AtualizadoEm).Column("atualizadoEm");
            Map(m => m.AtualizadoPorAspNetUserId).Column("atualizadoPorAspNetUserID");
            Map(m => m.ResponsavelPorAspNetUserId).Column("responsavelPorAspNetUserID");
            Map(m => m.ResponsavelAtribuidoEm).Column("responsavelAtribuidoEm");
            Map(m => m.CampoChave1).Column("campoChave1");
            Map(m => m.PrevisaoInicial).Column("PrevisaoInicial");
            Map(m => m.PrevisaoNova).Column("PrevisaoNova");            
        }
    }
}
