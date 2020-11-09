using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ContratoMapper : ClassMapper<Contrato>
    {
        public ContratoMapper()
        {
            Table("Contratos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.NumeroContrato).Column("numeroContrato");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.AlteradoPorUserId).Column("alteradoPorUserID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.AlteradoEm).Column("alteradoEm");
            Map(m => m.ClientePessoaFisicaId).Column("clientePessoaFisicaID");
            Map(m => m.ClientePessoaJuridicaId).Column("clientePessoaJuridicaID");
            Map(m => m.DataInicio).Column("dataInicio");
            Map(m => m.DataTermino).Column("dataTermino");
            Map(m => m.ValorContrato).Column("valorContrato");
            Map(m => m.ValorDesconto).Column("valorDesconto");
            Map(m => m.TipoContrato).Column("tipoContrato");
            Map(m => m.ContratoPaiId).Column("contratoPaiID");
            Map(m => m.StatusEntidadeId).Column("statusEntidadeID");
            Map(m => m.Apelido).Column("apelido");
            Map(m => m.DataEncerramento).Column("DataEncerramento");
        }
    }
}
