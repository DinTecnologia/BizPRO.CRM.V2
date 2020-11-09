using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;

namespace BizPRO.CRM.V2.Repositorio.ADO
{
    public class AtividadeRepositorioDal : IAtividadeRepositorioDal
    {
        private readonly string _conn;


        public AtividadeRepositorioDal()
        {
            _conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }


        public Atividade ObterPorIdDal(long idAtividade)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand("usp_front_sel_atividade", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (idAtividade > 0)
                        cmd.Parameters.AddWithValue("@atividadeID", idAtividade);
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            //Ativivdade
                            Atividade objRetorno = new Atividade
                                (
                                Convert.ToInt32(rdr["Id"]),
                                Convert.ToInt32(rdr["atividadeTipoID"]),
                                !string.IsNullOrEmpty(rdr["previsaoDeExecucao"].ToString()) ? (DateTime?)Convert.ToDateTime(rdr["atendimentoID"]) : null,
                                rdr["titulo"].ToString(),
                                rdr["descricao"].ToString()
                                );

                            objRetorno.AtividadeTipoId = (int?)Convert.ToInt32(rdr["atividadeTipoID"]);
                            objRetorno.CriadoEm = Convert.ToDateTime(rdr["criadoEm"]);
                            objRetorno.CriadoPorUserId = rdr["criadoPorUserID"].ToString();
                            objRetorno.ResponsavelPorUserId = rdr["responsavelPorUserID"].ToString();
                            objRetorno.StatusAtividadeId = Convert.ToInt32(rdr["statusAtividadeID"]);
                            objRetorno.OcorrenciaId = !string.IsNullOrEmpty(rdr["ocorrenciaID"].ToString()) ?
                                (long?)Convert.ToInt64(rdr["ocorrenciaID"]) : null;
                            objRetorno.ContratoId = !string.IsNullOrEmpty(rdr["contratoID"].ToString()) ?
                                (long?)Convert.ToInt64(rdr["contratoID"]) : null;
                            objRetorno.AtendimentoId = !string.IsNullOrEmpty(rdr["atendimentoID"].ToString()) ?
                                (long?)Convert.ToInt64(rdr["atendimentoID"]) : null;
                            objRetorno.PrevisaoDeExecucao = !string.IsNullOrEmpty(rdr["previsaoDeExecucao"].ToString()) ?
                                (DateTime?)Convert.ToDateTime(rdr["atendimentoID"]) : null;
                            objRetorno.FinalizadoEm = !string.IsNullOrEmpty(rdr["finalizadoEm"].ToString()) ?
                                (DateTime?)Convert.ToDateTime(rdr["finalizadoEm"]) : null;
                            objRetorno.FinalizadoPorUserId = !string.IsNullOrEmpty(rdr["finalizadoPorUserID"].ToString()) ?
                                rdr["finalizadoPorUserID"].ToString() : null;
                            objRetorno.Titulo = rdr["titulo"].ToString();
                            objRetorno.Descricao = rdr["descricao"].ToString();
                            objRetorno.PessoasFisicasId = !string.IsNullOrEmpty(rdr["PessoasFisicasID"].ToString()) ?
                                (long?)Convert.ToInt64(rdr["PessoasFisicasID"]) : null;
                            objRetorno.PessoasJuridicasId = !string.IsNullOrEmpty(rdr["PessoasJuridicasID"].ToString()) ?
                                (long?)Convert.ToInt64(rdr["PessoasJuridicasID"]) : null;
                            objRetorno.PotenciaisClientesId = !string.IsNullOrEmpty(rdr["PotenciaisClientesID"].ToString()) ?
                                (long?)Convert.ToInt64(rdr["PotenciaisClientesID"]) : null;
                            objRetorno.CanaisId = !string.IsNullOrEmpty(rdr["CanaisId"].ToString()) ?
                                (int?)Convert.ToInt32(rdr["CanaisId"]) : null;
                            objRetorno.MidiasId = !string.IsNullOrEmpty(rdr["MidiasID"].ToString()) ?
                                (int?)Convert.ToInt32(rdr["MidiasID"]) : null;
                            objRetorno.AtividadeDeOrigemId = !string.IsNullOrEmpty(rdr["AtividadeDeOrigemID"].ToString()) ?
                                (long?)Convert.ToInt64(rdr["AtividadeDeOrigemID"]) : null;
                            objRetorno.UsuarioId = !string.IsNullOrEmpty(rdr["UsuarioId"].ToString()) ?
                                rdr["UsuarioId"].ToString() : null;
                            objRetorno.ClienteFinalizouContatoEm = !string.IsNullOrEmpty(rdr["ClienteFinalizouContatoEm"].ToString()) ?
                                (DateTime?)Convert.ToDateTime(rdr["ClienteFinalizouContatoEm"]) : null;
                            objRetorno.AgenteFinalizouContatoEm = !string.IsNullOrEmpty(rdr["AgenteFinalizouContatoEm"].ToString()) ?
                                (DateTime?)Convert.ToDateTime(rdr["AgenteFinalizouContatoEm"]) : null;


                            //Status Atividade
                            //objRetorno.StatusAtividade.Id = Convert.ToInt32(rdr["id"]);
                            //objRetorno.StatusAtividade.Descricao = rdr["descricao"].ToString();
                            //objRetorno.StatusAtividade.Ativo = Convert.ToBoolean(rdr["ativo"]);
                            //objRetorno.StatusAtividade.FinalizaAtendimento = Convert.ToBoolean(rdr["finalizaAtendimento"]);
                            //objRetorno.StatusAtividade.GerarEntidade = Convert.ToBoolean(rdr["gerarEntidade"]);
                            //objRetorno.StatusAtividade.EntidadeNecessaria = rdr["entidadeNecessaria"].ToString();
                            //objRetorno.StatusAtividade.AtividadesValidas = rdr["atividadesValidas"].ToString();
                            //objRetorno.StatusAtividade.StatusPadrao = Convert.ToBoolean(rdr["statusPadrao"]);
                            //objRetorno.StatusAtividade.FinalizaAtividade = Convert.ToBoolean(rdr["finalizaAtividade"]);
                            //objRetorno.StatusAtividade.TipoAgendamento = Convert.ToInt32(rdr["tipoAgendamento"]);
                            //objRetorno.StatusAtividade.SentidosValidos = rdr["sentidosValidos"].ToString();
                            //objRetorno.StatusAtividade.StatusDeSistema = Convert.ToBoolean(rdr["statusDeSistema"]);
                            //objRetorno.StatusAtividade.EntidadeNaoNecessaria = rdr["entidadeNaoNecessaria"].ToString();
                            //objRetorno.StatusAtividade.StatusAtividadeIdRequerida = !string.IsNullOrEmpty(rdr["StatusAtividadeIdRequerida"].ToString()) ?
                            //    (int?)Convert.ToInt32(rdr["StatusAtividadeIdRequerida"]) : null;
                            //objRetorno.StatusAtividade.TempoMaximoAtividadeEmMinutos = !string.IsNullOrEmpty(rdr["TempoMaximoAtividadeEmMinutos"].ToString()) ?
                            //    (int?)Convert.ToInt32(rdr["TempoMaximoAtividadeEmMinutos"]) : null;

                            //Ocorrencia






                            connection.Close();
                            return objRetorno;


                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return new Atividade();

        }



    }
}
