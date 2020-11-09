using System;
using System.Data;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using System.Data.SqlClient;

namespace BizPRO.CRM.V2.Repositorio.ADO
{
    public class RelatorioRepositorioAdo : IRelatorioRepositorioAdo
    {
        private readonly string _con;

        public RelatorioRepositorioAdo()
        {
            _con = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public DataSet ObterDadosRelatorioFluxoDeAtendimento(DateTime? dataInicio, DateTime? dataFim,
            int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido, string usuarioId)
        {
            var ds = new DataSet();

            try
            {
                using (var conexao = new SqlConnection(_con))
                {
                    var cmd = new SqlCommand("USP_REPORT_OBTER_ATENDIMENTOS_OCORRENCIA", conexao)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Atendimento_dataInicioPesquisa", dataInicio);
                    cmd.Parameters.AddWithValue("@Atendimento_dataFinalPesquisa", dataFim);
                    cmd.Parameters.AddWithValue("@Atendimento_canalID", canalId);
                    cmd.Parameters.AddWithValue("@Ocorrencia_ocorrenciasTiposEstrutura", ocorrenciaTipoEstrutura);
                    cmd.Parameters.AddWithValue("@Ocorrencia_statusEntidade", statusEntidadeId);
                    cmd.Parameters.AddWithValue("@Atendimento_sentido", sentido);
                    cmd.Parameters.AddWithValue("@Atendimento_Usuario", usuarioId);
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                return ds;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet ObterDadosRelatorioFluxoDeAtendimentoProdutivo(DateTime? dataInicio, DateTime? dataFim,
            int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido, string usuarioId)
        {
            var ds = new DataSet();

            try
            {
                using (var conexao = new SqlConnection(_con))
                {
                    var cmd = new SqlCommand("USP_REPORT_OBTER_ATENDIMENTOS_OCORRENCIA", conexao)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Atendimento_dataInicioPesquisa", dataInicio);
                    cmd.Parameters.AddWithValue("@Atendimento_dataFinalPesquisa", dataFim);
                    cmd.Parameters.AddWithValue("@Atendimento_canalID", canalId);
                    cmd.Parameters.AddWithValue("@Ocorrencia_ocorrenciasTiposEstrutura", ocorrenciaTipoEstrutura);
                    cmd.Parameters.AddWithValue("@Ocorrencia_statusEntidade", statusEntidadeId);
                    cmd.Parameters.AddWithValue("@Atendimento_sentido", sentido);
                    cmd.Parameters.AddWithValue("@Atendimento_Usuario", usuarioId);
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                return ds;
            }
            finally
            {
                ds = null;
            }
        }
    }
}
