using System.Collections.Generic;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Data;
using System.Linq;
using Dapper;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class OcorrenciaRepositorio : Repositorio<Ocorrencia>, IOcorrenciaRepositorio
    {
        public OcorrenciaRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasLocalPorUserId(string userId)
        {
            var where = new DynamicParameters();
            where.Add("@userID", userId);

            var retorno =
                Conn
                    .Query
                    <Ocorrencia, OcorrenciaTipo, StatusEntidade, Usuario, PessoaFisica, PessoaJuridica, Ocorrencia>(
                        "usp_front_sel_ObterOcorrenciasLocalPorUserID",
                        (ret, proTp, sts, user, pf, pj) =>
                        {
                            ret.OcorrenciaTipo = proTp;
                            ret.StatusEntidade = sts;
                            ret.PessoaFisica = pf;
                            ret.PessoaJuridica = pj;
                            ret.Usuario = user;
                            return ret;
                        },
                        where,
                        splitOn: "Id,nomeExibicao,nome,nome,nome,nomeFantasia",
                        commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasLocalPorObjetos(string userId, string protocolo, string cliente,
            long? ocorrenciaTipoId, string documento)
        {
            var where = new DynamicParameters();
            where.Add("@userID", userId);

            if (!string.IsNullOrEmpty(protocolo))
                where.Add("@protocolo", protocolo);


            if (!string.IsNullOrEmpty(cliente))
                where.Add("@cliente", cliente);

            if (ocorrenciaTipoId != null)
                where.Add("@ocorrenciaTipoID", ocorrenciaTipoId);

            if (!string.IsNullOrEmpty(documento))
                where.Add("@documento", documento);

            var retorno =
                Conn
                    .Query
                    <Ocorrencia, OcorrenciaTipo, StatusEntidade, Usuario, PessoaFisica, PessoaJuridica, Ocorrencia>(
                        "usp_front_sel_ObterOcorrenciasLocal",
                        (ret, proTp, sts, user, pf, pj) =>
                        {
                            ret.OcorrenciaTipo = proTp;
                            ret.StatusEntidade = sts;
                            ret.PessoaFisica = pf;
                            ret.PessoaJuridica = pj;
                            ret.Usuario = user;
                            return ret;
                        },
                        where,
                        splitOn: "Id,nomeExibicao,nome,nome,nome,nomeFantasia",
                        commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasPorProtocolo(string protocolo)
        {
            var where = new DynamicParameters();
            where.Add("@protocolo", protocolo);

            var retorno =
                Conn
                    .Query
                    <Ocorrencia, OcorrenciaTipo, StatusEntidade, Usuario, PessoaFisica, PessoaJuridica, Ocorrencia>(
                        "usp_front_sel_OcorrenciasPorProtocolo",
                        (ret, proTp, sts, user, pf, pj) =>
                        {
                            ret.OcorrenciaTipo = proTp;
                            ret.StatusEntidade = sts;
                            ret.PessoaFisica = pf;
                            ret.PessoaJuridica = pj;
                            ret.Usuario = user;
                            return ret;
                        },
                        where,
                        splitOn: "Id,nomeExibicao,nome,nome,nome,nomeFantasia",
                        commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasLojista(string userId, string protocolo, string documento)
        {
            var where = new DynamicParameters();

            if (!string.IsNullOrEmpty(protocolo))
                where.Add("@protocolo", protocolo);

            if (!string.IsNullOrEmpty(userId))
                where.Add("@userId", userId);

            if (!string.IsNullOrEmpty(documento))
                where.Add("@documento", documento);

            var retorno =
                Conn
                    .Query
                    <Ocorrencia, OcorrenciaTipo, StatusEntidade, Usuario, PessoaFisica, PessoaJuridica, Ocorrencia>(
                        "usp_front_sel_Ocorrencias_Lojista",
                        (ret, proTp, sts, user, pf, pj) =>
                        {
                            ret.OcorrenciaTipo = proTp;
                            ret.StatusEntidade = sts;
                            ret.PessoaFisica = pf;
                            ret.PessoaJuridica = pj;
                            ret.Usuario = user;
                            return ret;
                        },
                        where,
                        splitOn: "Id,nomeExibicao,nome,nome,nome,nomeFantasia",
                        commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Ocorrencia> BuscarOcorrenciasCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@pessoaFisicaId", pessoaFisicaId);
            parametros.Add("@pessoaJuridicaId", pessoaJuridicaId);
            parametros.Add("@potencialClienteId", potencialClienteId);

            //if (atendimentoId.HasValue)
            //    parametros.Add("@AtendimentoId", atendimentoId);

            var retorno =
                Conn.Query<Ocorrencia, OcorrenciaTipo, StatusEntidade, Usuario, Ocorrencia>(
                    "usp_front_sel_ocorrenciasCliente",
                    (ret, proTp, sts, user) =>
                    {
                        ret.OcorrenciaTipo = proTp;
                        ret.StatusEntidade = sts;
                        ret.Usuario = user;
                        return ret;
                    },
                    parametros,
                    splitOn: "Id,nome,nome,nome",
                    commandType: CommandType.StoredProcedure);

            return retorno;
        }


        public IEnumerable<Ocorrencia> ObterOcorrenciasOriginal(string cliente, string protocolo, long? pessoaJuridicaId,
            long? pessoaFisicaId, long? ocorrenciaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@pessoaFisicaId", pessoaFisicaId);
            parametros.Add("@pessoaJuridicaId", pessoaJuridicaId);
            parametros.Add("@ocorrenciaId", ocorrenciaId);

            if (!string.IsNullOrEmpty(cliente))
                parametros.Add("@cliente", cliente);
            if (!string.IsNullOrEmpty(protocolo))
                parametros.Add("@protocolo", protocolo);

            var retorno =
                Conn
                    .Query
                    <Ocorrencia, Atendimento, OcorrenciaTipo, StatusEntidade, PessoaJuridica, PessoaFisica, Ocorrencia>(
                        "usp_front_Ocorrencias_BuscaOcorrenciaOriginal",
                        (ret, atendimento, ocorrenciaTipo, statusEntidade, pj, pf) =>
                        {
                            ret.Atendimento = atendimento;
                            ret.OcorrenciaTipo = ocorrenciaTipo;
                            ret.StatusEntidade = statusEntidade;
                            ret.PessoaFisica = pf;
                            ret.PessoaJuridica = pj;
                            return ret;
                        },
                        parametros,
                        splitOn: "id,id,id,id,id,id",
                        commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public bool OcorrenciaFinalizada(long ocorrenciaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ocorrenciaId", ocorrenciaId);
            var ocorrencia = ObterPorProcedimento("usp_front_sel_ValidarOcorrenciaFinalizada", parametros)
                .FirstOrDefault();
            return
                ocorrencia != null && ocorrencia
                    .Finalizada;
        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasCorrecao()
        {
            var where = new DynamicParameters();

            var retorno =
                Conn
                    .Query
                    <Ocorrencia, OcorrenciaTipo, Ocorrencia>(
                        "usp_front_sel_OcorrenciasCorrecao",
                        (oco, oT) =>
                        {
                            oco.OcorrenciaTipo = oT;
                            return oco;
                        },
                        where,
                        splitOn: "Id,id",
                        commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public ValidationResult AtualizarMotivoOcorrencia(long ocorrenciaId, long ocorrenciaTipoId, string usuarioId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@OcorrenciadId", ocorrenciaId);
            parametros.Add("@OcorrenciaTipoId", ocorrenciaTipoId);
            parametros.Add("@UsuarioId", usuarioId);

            ExecutarProcedimento("usp_front_AtualizarMotivoOcorrencia", parametros);

            return new ValidationResult();
        }

        public ValidationResult AtualizarContratoOcorrencia(long ocorrenciaId, long contratoId, string usuarioId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@OcorrenciadId", ocorrenciaId);
            parametros.Add("@contratoId", contratoId);
            parametros.Add("@UsuarioId", usuarioId);

            ExecutarProcedimento("usp_front_AtualizarContratoOcorrencia", parametros);

            return new ValidationResult();
        }
    }
}
