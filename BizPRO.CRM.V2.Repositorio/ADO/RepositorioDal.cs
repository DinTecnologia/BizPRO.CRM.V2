using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Repositorio.ADO
{
    public class RepositorioDal : IRepositorioDal
    {
        private readonly string _conn;

        public RepositorioDal()
        {
            _conn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public Fila GetFila(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_conn))
                {
                    Fila fila = new Fila();

                    SqlCommand cmd = new SqlCommand("usp_front_sel_Filas_ObterPor", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (id > 0)
                        cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        fila.Id = Convert.ToInt32(rdr["id"]);
                        fila.Nome = rdr["nome"].ToString();
                        fila.Ativo = Convert.ToBoolean(rdr["ativo"]);
                        fila.CriadoEm = Convert.ToDateTime(rdr["criadoEm"]);
                        fila.CriadoPorUserId = rdr["criadoPorUserID"].ToString();
                        fila.AceitaLigacoes = Convert.ToBoolean(rdr["aceitaLigacoes"]);
                        fila.AceitaEmails = Convert.ToBoolean(rdr["aceitaEmails"]);
                        fila.AceitaTarefas = Convert.ToBoolean(rdr["aceitaTarefas"]);
                        fila.AceitaChatSms = Convert.ToBoolean(rdr["aceitaChatSMS"]);
                        fila.AceitaChatWeb = Convert.ToBoolean(rdr["aceitaChatWeb"]);
                        fila.AceitaChatMessenger = Convert.ToBoolean(rdr["aceitaChatMessenger"]);
                        fila.AlteradoEm = Convert.ToDateTime(rdr["alteradoEm"]);
                        fila.AlteradoPorUserId = rdr["alteradorPorUserID"].ToString();
                    }
                    connection.Close();
                    return fila;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}