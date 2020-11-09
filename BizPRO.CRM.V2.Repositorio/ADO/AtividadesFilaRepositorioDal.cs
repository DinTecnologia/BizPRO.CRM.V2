using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Camadas.Aplicacao.Interfaces;

namespace BizPRO.CRM.V2.Repositorio.ADO
{
    public class AtividadesFilaRepositorioDal : IAtividadesFilaRepositorioDal
    {
        private readonly string _conn;

        public AtividadesFilaRepositorioDal()
        {
            _conn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente,
            string assuntoAtividade)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_conn))
                {
                    List<AtividadeFilasApoio> Lista = new List<AtividadeFilasApoio>();

                    SqlCommand cmd = new SqlCommand("usp_front_sel_AtividadeFila", connection)
                    {
                        CommandType = CommandType.StoredProcedure
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
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AtividadeFilasApoio _obj = new AtividadeFilasApoio();
                            _obj.AtividadeId = long.Parse(dr["atividadeID"].ToString());
                            _obj.TipoAtividade = dr["tipoAtividade"].ToString();
                            _obj.Titulo = dr["titulo"].ToString();
                            _obj.CriadoEm = dr["criadoEm"] == null ? _obj.CriadoEm : Convert.ToDateTime(dr["criadoEm"]);
                            _obj.PrevisaoDeExecucao = dr["criadoEm"] == null ? _obj.PrevisaoDeExecucao : Convert.ToDateTime(dr["criadoEm"]);
                            _obj.Referente = dr["referente"].ToString();
                            _obj.NomeCliente = dr["nomeCliente"].ToString();
                            _obj.TempoAtribuicao = dr["tempoAtribuicao"].ToString();
                            _obj.AtrasadoAtribuicao = Convert.ToBoolean(dr["atrasadoAtribuicao"]);
                            _obj.PossuiSlaAtribuicao = Convert.ToBoolean(dr["possuiSlaAtribuicao"]);
                            _obj.AtrasadoFechamento = Convert.ToBoolean(dr["atrasadoFechamento"]);
                            _obj.PossuiSlaFechamento = Convert.ToBoolean(dr["possuiSlaFechamento"]);
                            _obj.NomeExibicao = dr["nomeExibicao"].ToString();
                            _obj.NomeFila = dr["nomeFila"].ToString();
                            _obj.AtividadeFinalizada = Convert.ToBoolean(dr["atividadeFinalizada"]);
                            _obj.FinalizadoEm = dr["finalizadoEm"].ToString() != "" ? (DateTime?)Convert.ToDateTime(dr["finalizadoEm"]): null;
                            //if(dr["finalizadoEm"] != DBNull) {
                            //    _obj.FinalizadoEm = (DateTime?)Convert.ToDateTime(dr["finalizadoEm"].ToString());
                            //}else{
                            //    _obj.FinalizadoEm = null;
                            //}
                            _obj.Descricao = dr["descricao"].ToString();
                            _obj.ResponsavelUserId = dr["responsavelUserId"].ToString() != "" ? dr["responsavelUserId"].ToString() : null;

                            Lista.Add(_obj);
                        }
                    }
                    connection.Close();
                    return Lista;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
