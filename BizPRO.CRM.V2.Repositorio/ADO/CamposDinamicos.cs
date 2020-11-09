using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BizPRO.CRM.V2.Repositorio.ADO
{
    public class CamposDinamicos : IDisposable, ICamposDinamicosRepositorio
    {
        private readonly string _con;

        public CamposDinamicos()
        {
            _con = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public DataSet ProcessoTabelaDinamica(string campos, string userId, DateTime? inicio, DateTime? fim,
            string status, string cliente, long? ocorrenciaTipoId)
        {

            var ds = new DataSet();

            try
            {

                var conexao = new SqlConnection(_con);
                var cmd = new SqlCommand("usp_front_sel_montaTabela", conexao)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@campos", campos);

                if (!userId.Equals(""))
                    cmd.Parameters.AddWithValue("@UserID", userId);

                if (!status.Equals(""))
                    cmd.Parameters.AddWithValue("@status", status);

                if (!cliente.Equals(""))
                    cmd.Parameters.AddWithValue("@cliente", cliente);

                if (ocorrenciaTipoId != null)
                    cmd.Parameters.AddWithValue("@ocorrenciaTipoID", ocorrenciaTipoId);

                cmd.Parameters.AddWithValue("@inicio", inicio);

                cmd.Parameters.AddWithValue("@fim", @fim);


                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
            finally
            {
                ds = null;
            }

        }

        public void Dispose()
        {

        }

        public DataSet ObterOcorrenciasExportar(string campos, string usuarioId, DateTime? dataInicio, DateTime? dataFim,
            string stautsIds, string cliente, long? ocorrenciaTipoId, string camposDinamicosOcorrenciaId,
            string camposDinamicosContratoId)
        {
            var ds = new DataSet();

            try
            {
                var conexao = new SqlConnection(_con);
                var cmd = new SqlCommand("usp_front_sel_ExportarOcorrencias", conexao)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@campos", campos);

                if (!string.IsNullOrEmpty(usuarioId))
                    cmd.Parameters.AddWithValue("@UserID", usuarioId);

                if (!string.IsNullOrEmpty(stautsIds))
                    cmd.Parameters.AddWithValue("@status", stautsIds);

                if (!string.IsNullOrEmpty(cliente))
                    cmd.Parameters.AddWithValue("@cliente", cliente);

                if (ocorrenciaTipoId.HasValue)
                    cmd.Parameters.AddWithValue("@ocorrenciaTipoID", ocorrenciaTipoId);

                cmd.Parameters.AddWithValue("@inicio", dataInicio ?? DateTime.Now);
                cmd.Parameters.AddWithValue("@fim", dataFim ?? DateTime.Now);


                if (!string.IsNullOrEmpty(camposDinamicosOcorrenciaId))
                    cmd.Parameters.AddWithValue("@campoDinamicoIds", camposDinamicosOcorrenciaId);

                if (!string.IsNullOrEmpty(camposDinamicosContratoId))
                    cmd.Parameters.AddWithValue("@campoDinamicoContratoIds", camposDinamicosContratoId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
            finally
            {
                ds = null;
            }
        }
    }
}
