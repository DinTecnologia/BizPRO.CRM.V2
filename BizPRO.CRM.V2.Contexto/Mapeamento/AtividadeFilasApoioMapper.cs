using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AtividadeFilasApoioMapper : ClassMapper<AtividadeFilasApoio>
    {

        public AtividadeFilasApoioMapper()
        {
            Map(m => m.NomeFila).Column("nomeFila");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.TipoAtividade).Column("tipoAtividade");
            Map(m => m.NomeUsuario).Column("nomeUsuario");
            Map(m => m.NomeOcorrencia).Column("nomeOcorrencia");
            Map(m => m.AtividadesTiposId).Column("atividadesTiposID");
            Map(m => m.AtividadeId).Column("atividadeID");
        }
    }
}