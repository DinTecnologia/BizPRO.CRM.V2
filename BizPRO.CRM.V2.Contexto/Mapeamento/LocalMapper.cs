using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class LocalMapper : ClassMapper<Local>
    {
        public LocalMapper()
        {
            Table("Locais");
            Map(m => m.id).Column("id").Key(KeyType.Identity);
            Map(m => m.nome).Column("nome");
            Map(m => m.nomeContato).Column("nomeContato");
            Map(m => m.locaisTiposID).Column("locaisTiposID");
            Map(m => m.criadoPorUserID).Column("criadoPorUserID");
            Map(m => m.criadoEm).Column("criadoEm");
            Map(m => m.alteradoPorUserID).Column("alteradoPorUserID");
            Map(m => m.alteradoEm).Column("alteradoEm");
            Map(m => m.logradouro).Column("logradouro");
            Map(m => m.numero).Column("numero");
            Map(m => m.cep).Column("cep");
            Map(m => m.bairro).Column("bairro");
            Map(m => m.cidadesID).Column("cidadesID");
            Map(m => m.latitude).Column("latitude");
            Map(m => m.longitude).Column("longitude");
            Map(m => m.telefone01).Column("telefone01");
            Map(m => m.telefone02).Column("telefone02");
            Map(m => m.telefone03).Column("telefone03");
            Map(m => m.email01).Column("email01");
            Map(m => m.email02).Column("email02");
            Map(m => m.webSite).Column("webSite");
            //Map(m => m.Detalhe).Column("Detalhe");
        }
    }
}
