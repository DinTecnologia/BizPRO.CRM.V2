using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Data;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class LigacaoRepositorio : Repositorio<Ligacao>, ILigacaoRepositorio
    {
        public LigacaoRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public Ligacao BuscarCompletoPorId(long? ligacaoId, long? atividadeId)
        {
            var parametros = new DynamicParameters();

            if (ligacaoId.HasValue)
                parametros.Add("@ligacaoId", ligacaoId);

            if (atividadeId.HasValue)
                parametros.Add("@atividadeId", atividadeId);

            var retorno =
                Conn.Query<Ligacao, Atividade, Atendimento, PessoaFisica, PessoaJuridica, Ocorrencia, Fila, Ligacao>(
                    "usp_front_sel_Ligacao_Completo",
                    (ligacao, atividade, atendimento, pf, pj, oco, fila) =>
                    {
                        ligacao.Atividade = atividade;
                        ligacao.Atividade.Atendimento = atendimento;
                        ligacao.Atividade.PessoaFisica = pf;
                        ligacao.Atividade.PessoaJuridica = pj;
                        ligacao.Atividade.Ocorrencia = oco;
                        ligacao.Fila = fila;
                        return ligacao;
                    },
                    parametros,
                    splitOn: "Id,id,id,id,id,id,id",
                    commandType: CommandType.StoredProcedure);

            return retorno.FirstOrDefault();
        }

        public Ligacao ObterLigacaoReceptivaUra(string numeroTelefone)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@numeroTelefone", numeroTelefone);
            var listaRetorno = ObterPorProcedimento("usp_front_sel_LigacaoExistenteUraPorTelefone", parametros);
            return listaRetorno.Any() ? BuscarCompletoPorId(listaRetorno.FirstOrDefault().Id, null) : new Ligacao();
        }

        public void AtualizarLigacaoGeradorProtocoloUra(string userId, long ligacaoId, long atividadeId,
            long atendimentoId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ligacaoId", ligacaoId);
            parametros.Add("@atendimentoId", atendimentoId);
            parametros.Add("@atividadeId", atividadeId);
            parametros.Add("@userId", userId);
            ExecutarProcedimento("usp_front_upd_LigacaoGeradoraProtocoloURA", parametros);
        }
    }
}
