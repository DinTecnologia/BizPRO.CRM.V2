using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DapperExtensions;
using Dapper;
using System.Linq;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class LigacaoServico : Servico<Ligacao>, ILigacaoServico
    {
        private readonly ILigacaoRepositorio _repositorio;
        private readonly IAtividadeServico _servicoAtividade;
        private readonly IAtendimentoServico _servicoAtendimento;
        private readonly IUsuarioServico _usuarioServico;
        private readonly ICanalServico _canalServico;
        private readonly IStatusAtividadeServico _atividadeServico;

        public LigacaoServico(ILigacaoRepositorio repositorio, IAtividadeServico servicoAtividade,
            IAtendimentoServico servicoAtendimento, IUsuarioServico usuarioServico, ICanalServico canalServico,
            IStatusAtividadeServico atividadeServico)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _servicoAtividade = servicoAtividade;
            _servicoAtendimento = servicoAtendimento;
            _usuarioServico = usuarioServico;
            _canalServico = canalServico;
            _atividadeServico = atividadeServico;
        }

        public Ligacao InserirAtividadeELigacao(Atividade entidade, string numeroOriginal, string sentido)
        {
            var retorno = new Ligacao();

            try
            {
                var parametros = new DynamicParameters();
                parametros.Add("@atividadeTipoID", entidade.AtividadeTipoId);
                parametros.Add("@criadoEm", entidade.CriadoEm);
                parametros.Add("@criadoPorUserID", entidade.CriadoPorUserId);
                parametros.Add("@responsavelPorUserID", entidade.ResponsavelPorUserId);
                parametros.Add("@statusAtividadeID", entidade.StatusAtividadeId);
                parametros.Add("@ocorrenciaID", entidade.OcorrenciaId);
                parametros.Add("@contratoID", entidade.ContratoId);
                parametros.Add("@atendimentoID", entidade.AtendimentoId);
                parametros.Add("@numeroOriginal", numeroOriginal);
                parametros.Add("@sentido", sentido);
                parametros.Add("@titulo", entidade.Titulo);
                var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_ins_atividadeELigacao", parametros);

                if (listaRetorno.Any())
                    retorno = listaRetorno.FirstOrDefault();
                else
                    retorno.ValidationResult.Add(new ValidationError("Registro Ligação não inserido."));
            }
            catch (Exception ex)
            {
                retorno.ValidationResult.Add(new ValidationError("Erro ao tentar registrar a Atividade e Ligação:" + ex));
            }

            return retorno;
        }

        public Ligacao InserirLigacao(Ligacao entidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@pessoaFisicaID", entidade.PessoaFisicaId);
            parametros.Add("@pessoaJuridicaID", entidade.PessoaJuridicaId);
            parametros.Add("@pessoaJuridicaID", entidade.PessoaJuridicaId);
            parametros.Add("@userID", entidade.UserId);
            parametros.Add("@numeroOriginal", entidade.NumeroOriginal);
            parametros.Add("@telefoneID", entidade.TelefoneId);
            parametros.Add("@criadoEm", entidade.CriadoEm);
            parametros.Add("@finalizadoEm", entidade.FinalizadoEm);
            parametros.Add("@sentido", entidade.Sentido);
            parametros.Add("@atividadeID", entidade.AtividadeId);
            parametros.Add("@PotenciaisClientesID", entidade.PotencialClientesId);

            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_ins_ligacao", parametros);
            return listaRetorno.FirstOrDefault();
        }

        public Ligacao BuscarPorAtividadeId(long atividadeId)
        {
            var pg = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            pg.Predicates.Add(Predicates.Field<Ligacao>(f => f.AtividadeId, Operator.Eq, atividadeId));
            var ligacao = _repositorio.ObterPor(pg).FirstOrDefault();
            return ligacao;
        }

        public Ligacao AdicionarLigacaoReceptiva(string criadoPorUserId, string numeroOriginal, long? telefoneId)
        {
            Ligacao ligacao;
            if (string.IsNullOrEmpty(criadoPorUserId))
            {
                var usuarioAdm = _usuarioServico.ObterPorEmail("sistemas@bizpro.com.br");
                if (usuarioAdm != null)
                    criadoPorUserId = usuarioAdm.Id;
                else
                {
                    ligacao = new Ligacao();
                    ligacao.ValidationResult.Add(
                        new ValidationError(
                            "Não foi informado o usuario (Criado Por) e também não possui usuario padrão cadastrado (sistemas@bizpro.com.br)"));
                    return ligacao;
                }
            }

            //var canal = _canalServico.ObterCanalTelefone();
            var canalTelefoneId = 1;
            var atendimento = _servicoAtendimento.AdicionarNovoAtendimento(canalTelefoneId, criadoPorUserId, null);

            if (!atendimento.ValidationResult.IsValid)
            {
                var retorno = new Ligacao {ValidationResult = atendimento.ValidationResult};
                return retorno;
            }

            var atividade = _servicoAtividade.NovaAtividadeLigacao(criadoPorUserId, null, null, atendimento.Id, null,
                null, null, null, null, criadoPorUserId);

            if (!atividade.ValidationResult.IsValid)
            {
                var retorno = new Ligacao {ValidationResult = atividade.ValidationResult};
                return retorno;
            }

            ligacao = new Ligacao(null, null, null, criadoPorUserId, "E", atividade.Id, null, numeroOriginal, atividade, null);
            _repositorio.Adicionar(ligacao);

            return BuscarLigacaoCompleta(ligacao.Id, null);
        }

        public Ligacao ObterLigacaoReceptivaUra(string numeroTelefone)
        {
            return _repositorio.ObterLigacaoReceptivaUra(numeroTelefone);
        }

        public Ligacao BuscarLigacaoCompleta(long? ligacaoId, long? atividadeId)
        {
            if (!ligacaoId.HasValue && !atividadeId.HasValue)
            {
                var ligacao = new Ligacao();
                ligacao.ValidationResult.Add(new ValidationError("É preciso informado ligacaoId ou atividadeId"));
                return ligacao;
            }
            return _repositorio.BuscarCompletoPorId(ligacaoId, atividadeId);
        }

        public void AtualizarLigacaoGeradorProtocoloUra(string userId, long ligacaoId, long atividadeId,
            long atendimentoId)
        {
            _repositorio.AtualizarLigacaoGeradorProtocoloUra(userId, ligacaoId, atividadeId, atendimentoId);
        }

        public Ligacao AdicionarLigacaoProtocoloUra(string numeroOriginal, string documento)
        {
            var criadoPorUserId = string.Empty;

            Ligacao ligacao;

            if (string.IsNullOrEmpty(criadoPorUserId))
            {
                var usuarioAdm = _usuarioServico.ObterPorEmail("sistemas@bizpro.com.br");
                if (usuarioAdm != null)
                    criadoPorUserId = usuarioAdm.Id;
                else
                {
                    ligacao = new Ligacao();
                    ligacao.ValidationResult.Add(
                        new ValidationError(
                            "Não foi informado o usuario (Criado Por) e também não possui usuario padrão cadastrado (sistemas@bizpro.com.br)"));
                    return ligacao;
                }
            }

            var atendimento = _servicoAtendimento.AdicionarNovoAtendimento(null, criadoPorUserId, null);

            if (!atendimento.ValidationResult.IsValid)
            {
                var retorno = new Ligacao {ValidationResult = atendimento.ValidationResult};
                return retorno;
            }

            var statusLigacao = _atividadeServico.ObterTodos().FirstOrDefault(x => x.Descricao == "Aberto Ura");

            var atividade = _servicoAtividade.NovaAtividadeLigacao(criadoPorUserId, null, statusLigacao != null
                ? (int?)statusLigacao.Id
                : null, atendimento.Id, null, null, null, null, null, criadoPorUserId);

            if (!atividade.ValidationResult.IsValid)
            {
                var retorno = new Ligacao {ValidationResult = atividade.ValidationResult};
                return retorno;
            }

            ligacao = new Ligacao(null, null, null, criadoPorUserId, "E", atividade.Id, null, numeroOriginal,
                atividade, documento);
            _repositorio.Adicionar(ligacao);

            return BuscarLigacaoCompleta(ligacao.Id, null);
        }

        public Ligacao ObterPor(long? id, long? atividadeId)
        {
            return _repositorio.BuscarCompletoPorId(id, atividadeId);
        }
    }
}
