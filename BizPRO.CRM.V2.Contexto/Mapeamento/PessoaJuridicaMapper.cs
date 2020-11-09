using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class PessoaJuridicaMapper : ClassMapper<PessoaJuridica>
    {
        public PessoaJuridicaMapper()
        {
            Table("PessoasJuridica");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.RazaoSocial).Column("razaoSocial");
            Map(m => m.NomeFantasia).Column("nomeFantasia");
            Map(m => m.Cnpj).Column("cnpj");
            Map(m => m.InscricaoEstadual).Column("inscricaoEstadual");
            Map(m => m.DataDeConstituicao).Column("dataDeConstituicao");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.EmailPrincipal).Column("emailPrincipal");
            Map(m => m.CodigoPostal).Column("codigoPostal");
            Map(m => m.Logradouro).Column("logradouro");
            Map(m => m.Numero).Column("numero");
            Map(m => m.Bairro).Column("bairro");
            Map(m => m.CidadeId).Column("cidadesID");
            Map(m => m.AlteradoEm).Column("alteradoEm");
            Map(m => m.AlteradoPorUserId).Column("alteradoPorUserID");
            Map(m => m.Complemento).Column("complemento");
            Map(m => m.AtendimentoId).Column("atendimentosID");
            Map(m => m.AceitaComunicados).Column("aceitaComunicados");
            Map(m => m.CanalEntidadesCamposValoresId).Column("canalEntidadesCamposValoresID");
            Map(m => m.TipoEntidadesCamposValoresId).Column("tipoEntidadesCamposValoresID");
        }
    }
}
