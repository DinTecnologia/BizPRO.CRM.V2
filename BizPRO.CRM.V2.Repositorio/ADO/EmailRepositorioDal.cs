
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
    public class EmailRepositorioDal : IEmailRepositorioDal
    {
        private readonly string _conn;
        public EmailRepositorioDal()
        {
            _conn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public int PossuiNovosEmails(string userId)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(_conn))
                {

                    SqlCommand cmd = new SqlCommand("usp_front_sel_VerificarNovoEmail", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    if (!string.IsNullOrEmpty(userId))
                        cmd.Parameters.AddWithValue("@userID", userId);

                    SqlDataAdapter data = new SqlDataAdapter(cmd);
                    return data.Fill(ds);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
