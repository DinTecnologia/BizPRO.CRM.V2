using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AtividadeMapper : ClassMapper<Atividade>
    {
        public AtividadeMapper()
        {
            Table("Atividades");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.AtividadeTipoId).Column("atividadeTipoID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.ResponsavelPorUserId).Column("responsavelPorUserID");
            Map(m => m.StatusAtividadeId).Column("statusAtividadeID");
            Map(m => m.OcorrenciaId).Column("ocorrenciaID");
            Map(m => m.ContratoId).Column("contratoID");
            Map(m => m.AtendimentoId).Column("atendimentoID");
            Map(m => m.PrevisaoDeExecucao).Column("previsaoDeExecucao");
            Map(m => m.FinalizadoEm).Column("finalizadoEm");
            Map(m => m.FinalizadoPorUserId).Column("finalizadoPorUserID");
            Map(m => m.Titulo).Column("titulo");
            Map(m => m.Descricao).Column("descricao");
            Map(m => m.PessoasFisicasId).Column("pessoasFisicasID");
            Map(m => m.PessoasJuridicasId).Column("pessoasJuridicasID");
            Map(m => m.PotenciaisClientesId).Column("potenciaisClientesID");
            Map(m => m.CanaisId).Column("CanaisId");
            Map(m => m.MidiasId).Column("MidiasID");
            Map(m => m.IniciadoEm).Column("iniciadoEm");
            Map(m => m.IniciadoPorUserId).Column("iniciadoPorUserID");
            Map(m => m.AtividadeDeOrigemId).Column("AtividadeDeOrigemId");
            Map(m => m.UsuarioId).Column("UsuarioId");
            Map(m => m.ClienteFinalizouContatoEm).Column("ClienteFinalizouContatoEm");
            Map(m => m.AgenteFinalizouContatoEm).Column("AgenteFinalizouContatoEm");
        }
    }
}