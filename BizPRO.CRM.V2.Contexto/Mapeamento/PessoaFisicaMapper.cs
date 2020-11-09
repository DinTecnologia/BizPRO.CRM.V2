using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class PessoaFisicaMapper : ClassMapper<PessoaFisica>
    {
        public PessoaFisicaMapper()
        {
            Table("PessoasFisica");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.Sobrenome).Column("sobrenome");
            Map(m => m.Cpf).Column("cpf");
            Map(m => m.CpfProprio).Column("cpfProprio");
            Map(m => m.DataNascimento).Column("dataNascimento");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.CodigoPostal).Column("codigoPostal");
            Map(m => m.Logradouro).Column("logradouro");
            Map(m => m.Numero).Column("numero");
            Map(m => m.Bairro).Column("bairro");
            Map(m => m.CidadeId).Column("cidadesID");
            Map(m => m.AlteradoEm).Column("alteradoEm");
            Map(m => m.AlteradoPorUserId).Column("alteradoPorUserID");
            Map(m => m.Complemento).Column("complemento");
            Map(m => m.Email).Column("email");
            Map(m => m.AtendimentoId).Column("atendimentosID");
            Map(m => m.AceitaComunicados).Column("aceitaComunicados");
            Map(m => m.CanalEntidadesCamposValoresId).Column("canalEntidadesCamposValoresID");
            Map(m => m.TipoEntidadesCamposValoresId).Column("tipoEntidadesCamposValoresID");
        }
    }
}
