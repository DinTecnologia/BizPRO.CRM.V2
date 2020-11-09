using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BizPRO.CRM.V2.Repositorio.ADO
{
    public class UsuarioRepositorioDal : IUsuarioRepositorioDal
    {
        private readonly string _conn;

        public UsuarioRepositorioDal()
        {
            _conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public Usuario ObterPorUserId(string userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_conn))
                {

                    Usuario user = new Usuario();
                    SqlCommand cmd = new SqlCommand("usp_front_sel_Usuarios", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    if (string.IsNullOrEmpty(userId))
                        cmd.Parameters.AddWithValue("@id", userId);

                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            user.DepartamentoId = !string.IsNullOrEmpty(rdr["departamentoId"].ToString()) ? (int?)Convert.ToInt32(rdr["departamentoId"]) : null;
                            user.EnderecoEmail = rdr["Email"].ToString();
                            user.TrocarSenha = Convert.ToBoolean(rdr["trocarSenha"]);

                            //TokenAcessoRapido tokenUser = new TokenAcessoRapido();
                            //tokenUser.Id = rdr["TokensAcessoRapido_Id"].ToString();
                            //user.Token
                            user.TrocarSenhaEmXDias = Convert.ToInt32(rdr["trocarSenhaEmXDias"]);
                            user.UltimaTrocaDeSenha = !string.IsNullOrEmpty(rdr["ultimaTrocaDeSenha"].ToString()) ? (DateTime?)Convert.ToDateTime(rdr["ultimaTrocaDeSenha"]) : null;
                            //user.ValidationResult

                        }
                    }

                    connection.Close();
                    return user;
                }
            }
            catch (Exception)
            {
                throw;
            }


        }


        public bool VerificaTrocaSenha(string userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_conn))
                {

                    Usuario user = new Usuario();
                    SqlCommand cmd = new SqlCommand("usp_front_sel_verificaTrocaSenha", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    if (string.IsNullOrEmpty(userId))
                        cmd.Parameters.AddWithValue("@userId", userId);

                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    return rdr.HasRows;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
