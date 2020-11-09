using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class TelefoneMapper : ClassMapper<Telefone>
    {
        public TelefoneMapper()
        {
            Table("Telefones");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.ClientePessoaFisicaId).Column("clientePessoaFisicaID");
            Map(m => m.ClientePessoaJuridicaId).Column("clientePessoaJuridicaID");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.TipoTelefone).Column("tipoTelefone");
            Map(m => m.Ordem).Column("ordem");
            Map(m => m.Ddi).Column("ddi");
            Map(m => m.Ddd).Column("ddd");
            Map(m => m.Numero).Column("numero");
            Map(m => m.Principal).Column("principal");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.EhMovel).Column("ehMovel");
            Map(m => m.TelefonesTiposId).Column("TelefonesTiposID");
            Map(m => m.PotenciaisClientesId).Column("PotenciaisClientesID");
        }
    }
}
