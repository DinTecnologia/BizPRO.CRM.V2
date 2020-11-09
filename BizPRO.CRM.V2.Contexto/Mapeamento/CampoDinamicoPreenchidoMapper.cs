using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class CampoDinamicoPreenchidoMapper : ClassMapper<CampoDinamicoPreenchido>
    {
        public CampoDinamicoPreenchidoMapper()
        {
            Table("CamposDinamicosPreenchidos");
            Map(m => m.ChaveEntidade).Column("chaveEntidade");
            Map(m => m.CamposDinamicosId).Column("camposDinamicosID");
            Map(m => m.CamposDinamicosOpcoesId).Column("camposDinamicosOpcoesID");
            Map(m => m.ValorPreenchido).Column("valorPreenchido");
            Map(m => m.EntidadesSecoesCamposDinamicosId).Column("entidadesSecoesCamposDinamicosID");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.AtualizadoEm).Column("AtualizadoEm");
            Map(m => m.AtualizadoPor).Column("AtualizadoPor");
            Map(m => m.Ativo).Column("Ativo");
        }
    }
}
