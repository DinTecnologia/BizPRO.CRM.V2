using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BizPRO.CRM.V2.Repositorio.ADO
{
    public class AtividadeFilaApoioRepositorioDal : IAtividadeFilaApoioRepositorioDal
    {
        private readonly string _conn;

        public AtividadeFilaApoioRepositorioDal()
        {
            _conn = _conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public long ObterTotalAtividadesFilaDal(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento,
            string nomeCliente, string emailCliente, string assuntoAtividade)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_conn))
                {
                    var cmd = new SqlCommand("usp_front_sel_TotalAtividadeFila", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    if (!string.IsNullOrEmpty(criadoPorId))
                        cmd.Parameters.AddWithValue("@criadoPorID", criadoPorId);

                    if (!string.IsNullOrEmpty(responsavelPorId))
                        cmd.Parameters.AddWithValue("@responsavelPorID", responsavelPorId);

                    if (dataInicio != DateTime.MinValue && dataInicio.HasValue)
                        cmd.Parameters.AddWithValue("@dataInicio", dataInicio);

                    if (dataFim != DateTime.MinValue && dataFim.HasValue)
                        cmd.Parameters.AddWithValue("@dataFim", dataFim);

                    if (!string.IsNullOrEmpty(status))
                        cmd.Parameters.AddWithValue("@status", status);

                    if (filaId.HasValue)
                        cmd.Parameters.AddWithValue("@filaID", filaId);

                    if (atrasadoAtendimento != null)
                        cmd.Parameters.AddWithValue("@atrasadoAtendimento", atrasadoAtendimento);

                    if (atrasadoAtribuicao != null)
                        cmd.Parameters.AddWithValue("@atrasadoAtribuicao", atrasadoAtribuicao);

                    cmd.Parameters.AddWithValue("@finalizado", finalizado);


                    if (!string.IsNullOrEmpty(nomeCliente))
                        cmd.Parameters.AddWithValue("@nomeCliente", nomeCliente);

                    if (!string.IsNullOrEmpty(emailCliente))
                        cmd.Parameters.AddWithValue("@emailCliente", emailCliente);

                    if (!string.IsNullOrEmpty(assuntoAtividade))
                        cmd.Parameters.AddWithValue("@assuntoAtividade", assuntoAtividade);


                    connection.Open();
                    long qtdRegistros = Convert.ToInt64(cmd.ExecuteScalar());

                    connection.Close();
                    return qtdRegistros;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}