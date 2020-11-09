using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AtendimentoMapper : ClassMapper<Atendimento>
    {
        public AtendimentoMapper()
        {
            Table("Atendimentos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Protocolo).Column("protocolo");
            Map(m => m.CanalOrigemId).Column("canalOrigemID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserId");
            Map(m => m.MidiasId).Column("MidiasID");
            Map(m => m.ClienteSomenteContato).Column("clienteSomenteContato");
            Map(m => m.TipoClienteContatoEntidadesCamposValoresId).Column("tipoClienteContatoEntidadesCamposValoresID");
        }
    }
}
