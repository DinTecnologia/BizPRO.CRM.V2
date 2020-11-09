using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;

namespace BizPRO.CRM.V2.Repositorio.ADO
{
    public class FilaRepositorioDal : IFilaRepositorioDal
    {
        private readonly string _conn;

        public FilaRepositorioDal()
        {
            _conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<Fila> ObterFilasPorUsuarioDal(string userId, bool? aceitaLigacao, bool? aceitaEmail,
            bool? aceitaTarefa, bool? aceitaChatSms, bool? aceitaChatWeb, bool? aceitaChatMessenger, bool? ativo)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_conn))
                {
                    List<Fila> lista = new List<Fila>();

                    SqlCommand cmd = new SqlCommand("usp_front_sel_FilaPermissaoPorUsuario", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@AceitaLigacoes", aceitaLigacao);
                    cmd.Parameters.AddWithValue("@AceitaEmails", aceitaEmail);
                    cmd.Parameters.AddWithValue("@AceitaTarefas", aceitaTarefa);
                    cmd.Parameters.AddWithValue("@AceitaChatSMS", aceitaChatSms);
                    cmd.Parameters.AddWithValue("@AceitaChatWeb", aceitaChatWeb);
                    cmd.Parameters.AddWithValue("@AceitaChatMessenger", aceitaChatMessenger);
                    cmd.Parameters.AddWithValue("@Ativo", true);

                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Fila fila = new Fila();
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
                            fila.AceitaChatMessenger = !string.IsNullOrEmpty(rdr["aceitaChatMessenger"].ToString()) ? Convert.ToBoolean(rdr["aceitaChatMessenger"]) : false;
                            fila.AlteradoEm = !string.IsNullOrEmpty(rdr["alteradoEm"].ToString()) ? (DateTime?)Convert.ToDateTime(rdr["alteradoEm"]) : null;
                            fila.AlteradoPorUserId = rdr["alteradoPorUserID"].ToString();
                            fila.ContaParaDisparoDeEmailConfiguracaoContasEmailsId = 
                                !string.IsNullOrEmpty(rdr["contaParaDisparoDeEmail_ConfiguracaoContasEmailsID"].ToString()) ? 
                                (int?)Convert.ToInt32(rdr["contaParaDisparoDeEmail_ConfiguracaoContasEmailsID"]) : null;

                            fila.TempoEmMinutosParaSlaDeFechamento = Convert.ToInt32(rdr["tempoEmMinutosParaSLADeFechamento"]);

                            fila.TempoEmMinutosParaSlaPrimeiroAtendimento = Convert.ToInt32(rdr["tempoEmMinutosParaSLAPrimeiroAtendimento"]);
                            fila.GerarProtocoloNaEntradaDeEmail =
                                !string.IsNullOrEmpty(rdr["gerarProtocoloNaEntradaDeEmail"].ToString()) ?
                                (bool?)Convert.ToBoolean(rdr["gerarProtocoloNaEntradaDeEmail"]) : null;

                            fila.EmailModeloEnvioProtocoloEmailsModeloId = 
                                !string.IsNullOrEmpty(rdr["emailModeloEnvioProtocolo_EmailsModeloID"].ToString()) ?
                                (int?)Convert.ToInt32(rdr["emailModeloEnvioProtocolo_EmailsModeloID"]) : null;

                            fila.DepartamentoId =
                                !string.IsNullOrEmpty(rdr["departamentoId"].ToString()) ? (int?)Convert.ToInt32(rdr["departamentoId"]) : null;

                            fila.TempoEmMinutosTma =
                               !string.IsNullOrEmpty(rdr["tempoEmMinutosTma"].ToString()) ? (int?)Convert.ToInt32(rdr["tempoEmMinutosTma"]) : null;

                            fila.TempoEmMinutosSemInteracao =
                                !string.IsNullOrEmpty(rdr["tempoEmMinutosSemInteracao"].ToString()) ? (int?)Convert.ToInt32(rdr["tempoEmMinutosSemInteracao"]) : null;

                            fila.TempoEmSegundosInatividadeContato =
                                !string.IsNullOrEmpty(rdr["tempoEmSegundosInatividadeContato"].ToString()) ? (int?)Convert.ToInt32(rdr["tempoEmSegundosInatividadeContato"]) : null;

                            fila.TempoEmSegundosAvisoInatividadeContato =
                                !string.IsNullOrEmpty(rdr["tempoEmSegundosAvisoInatividadeContato"].ToString()) ? (int?)Convert.ToInt32(rdr["tempoEmSegundosAvisoInatividadeContato"]) : null;

                            fila.CanalId =
                               !string.IsNullOrEmpty(rdr["CanalId"].ToString()) ? (int?)Convert.ToInt32(rdr["CanalId"]) : null;

                            lista.Add(fila);

                        }
                    }

                    return lista;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        public Fila ObterPorIdDal(int filaId)
        {
            Fila fila = new Fila();

            try
            {
                using (SqlConnection connection = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_front_sel_Filas_ObterPor", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (filaId > 0)
                        cmd.Parameters.AddWithValue("@id", filaId);

                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
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
                            fila.AceitaChatMessenger = !string.IsNullOrEmpty(rdr["aceitaChatMessenger"].ToString()) ? Convert.ToBoolean(rdr["aceitaChatMessenger"]) : false;
                            fila.AlteradoEm = !string.IsNullOrEmpty(rdr["alteradoEm"].ToString()) ? (DateTime?)Convert.ToDateTime(rdr["alteradoEm"]) : null;
                            fila.AlteradoPorUserId = rdr["alteradoPorUserID"].ToString();
                            fila.ContaParaDisparoDeEmailConfiguracaoContasEmailsId =
                                !string.IsNullOrEmpty(rdr["contaParaDisparoDeEmail_ConfiguracaoContasEmailsID"].ToString()) ?
                                (int?)Convert.ToInt32(rdr["contaParaDisparoDeEmail_ConfiguracaoContasEmailsID"]) : null;

                            fila.TempoEmMinutosParaSlaDeFechamento = Convert.ToInt32(rdr["tempoEmMinutosParaSLADeFechamento"]);

                            fila.TempoEmMinutosParaSlaPrimeiroAtendimento = Convert.ToInt32(rdr["tempoEmMinutosParaSLAPrimeiroAtendimento"]);
                            fila.GerarProtocoloNaEntradaDeEmail =
                                !string.IsNullOrEmpty(rdr["gerarProtocoloNaEntradaDeEmail"].ToString()) ?
                                (bool?)Convert.ToBoolean(rdr["gerarProtocoloNaEntradaDeEmail"]) : null;

                            fila.EmailModeloEnvioProtocoloEmailsModeloId =
                                !string.IsNullOrEmpty(rdr["emailModeloEnvioProtocolo_EmailsModeloID"].ToString()) ?
                                (int?)Convert.ToInt32(rdr["emailModeloEnvioProtocolo_EmailsModeloID"]) : null;

                            fila.DepartamentoId =
                                !string.IsNullOrEmpty(rdr["departamentoId"].ToString()) ? (int?)Convert.ToInt32(rdr["departamentoId"]) : null;

                            fila.TempoEmMinutosTma =
                               !string.IsNullOrEmpty(rdr["tempoEmMinutosTma"].ToString()) ? (int?)Convert.ToInt32(rdr["tempoEmMinutosTma"]) : null;

                            fila.TempoEmMinutosSemInteracao =
                                !string.IsNullOrEmpty(rdr["tempoEmMinutosSemInteracao"].ToString()) ? (int?)Convert.ToInt32(rdr["tempoEmMinutosSemInteracao"]) : null;

                            fila.TempoEmSegundosInatividadeContato =
                                !string.IsNullOrEmpty(rdr["tempoEmSegundosInatividadeContato"].ToString()) ? (int?)Convert.ToInt32(rdr["tempoEmSegundosInatividadeContato"]) : null;

                            fila.TempoEmSegundosAvisoInatividadeContato =
                                !string.IsNullOrEmpty(rdr["tempoEmSegundosAvisoInatividadeContato"].ToString()) ? (int?)Convert.ToInt32(rdr["tempoEmSegundosAvisoInatividadeContato"]) : null;

                            fila.CanalId =
                               !string.IsNullOrEmpty(rdr["CanalId"].ToString()) ? (int?)Convert.ToInt32(rdr["CanalId"]) : null; 
                        }
                    }

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
