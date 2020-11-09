using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class PotenciaisClienteMapper : ClassMapper<PotenciaisCliente>
    {
       public PotenciaisClienteMapper()
       {
           Table("PotenciaisClientes");
           Map(m => m.id).Column("id").Key(KeyType.Identity);
           Map(m => m.nome).Column("nome");
           Map(m => m.alteradoEm).Column("alteradoEm");
           Map(m => m.alteradoPorAspNetUserID).Column("alteradoPorAspNetUserID");
           Map(m => m.bairro).Column("bairro");
           Map(m => m.cep).Column("cep");
           Map(m => m.CidadesID).Column("CidadesID");
           Map(m => m.contato).Column("contato");
           Map(m => m.contatoDocumento).Column("contatoDocumento");
           Map(m => m.contatoEmail).Column("contatoEmail");
           Map(m => m.criadoEm).Column("criadoEm");
           Map(m => m.criadoPorAspNetUserID).Column("criadoPorAspNetUserID");
           Map(m => m.documento).Column("documento");
           Map(m => m.email).Column("email");
           Map(m => m.logradouro).Column("logradouro");
           Map(m => m.numero).Column("numero");
           Map(m => m.responsavelDesde).Column("responsavelDesde");
           Map(m => m.responsavelPorAspNetUserID).Column("responsavelPorAspNetUserID");
           Map(m => m.tipo).Column("tipo");

       }
    }
}
