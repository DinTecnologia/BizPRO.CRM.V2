using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Interfaces.Validacoes;
using Dapper;
using DomainValidation.Validation;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Enums;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtividadeServico : IAtividadeServico
    {
        private readonly IAtividadeRepositorio _repositorio;
        private readonly IAtividadeParteEnvolvidaServico _servicoAtividadeParteEnvolvida;
        private readonly IStatusAtividadeServico _servicoStatusAtividade;
        private readonly IAtividadeTipoServico _servicoAtividadeTipo;
        private readonly IAtividadeFilaServico _servicoAtividadeFila;
        private readonly IConfiguracaoServico _servicoConfiguracao;
        private readonly IOcorrenciaServico _servicoOcorrencia;
        private readonly IUsuarioServico _servicoUsuario;
        private readonly IAtendimentoAtividadeServico _atendimentoAtividadeServico;
        private readonly ICanalServico _canalServico;
        private readonly IAtividadeApoioServico _atividadeApoioServico;
        private readonly IAtividadeRepositorioDal _atividadeRepositorioDal;
        

        public AtividadeServico(IAtividadeRepositorio repositorio,
            IAtividadeParteEnvolvidaServico servicoAtividadeParteEnvolvida,
            IStatusAtividadeServico servicoStatusAtividade, IAtividadeTipoServico servicoAtividadeTipo,
            IAtividadeFilaServico servicoAtividadeFila, IConfiguracaoServico servicoConfiguracao,
            IOcorrenciaServico servicoOcorrencia, IUsuarioServico servicoUsuario,
            IAtendimentoAtividadeServico atendimentoAtividadeServico, ICanalServico canalServico,
            IAtividadeApoioServico atividadeApoioServico, IAtividadeRepositorioDal atividadeRepositorioDal)
        {
            _repositorio = repositorio;
            _servicoAtividadeParteEnvolvida = servicoAtividadeParteEnvolvida;
            _servicoStatusAtividade = servicoStatusAtividade;
            _servicoAtividadeTipo = servicoAtividadeTipo;
            _servicoAtividadeFila = servicoAtividadeFila;
            _servicoConfiguracao = servicoConfiguracao;
            _servicoOcorrencia = servicoOcorrencia;
            _servicoUsuario = servicoUsuario;
            _atendimentoAtividadeServico = atendimentoAtividadeServico;
            _canalServico = canalServico;
            _atividadeApoioServico = atividadeApoioServico;
            _atividadeRepositorioDal = atividadeRepositorioDal;
        }

        public IEnumerable<Atividade> ObterAtividadesPorOcorrenciaTipo(long ocorrenciaTipoId)
        {
            return _repositorio.ObterPorOcorrenciaTipoId(ocorrenciaTipoId);
        }

        public void AtualizarStatusLigacao(long ligacaoId, int statusAtividadeId)
        {
            _repositorio.AtualizarStatusAtividadePorLigacaoId(ligacaoId, statusAtividadeId);
        }

        public void AtualizarAtendimentoId(long atividadeId, long atendimentoId)
        {
            _repositorio.AtualizarAtendimentoId(atividadeId, atendimentoId);
        }

        public void AtualizarStatus(long atividadeId, int statusAtividadeId, string userId, int? midiaId)
        {
            var atividade = _repositorio.ObterPorId(atividadeId);
            var statusAtividade = _servicoStatusAtividade.ObterPorId(statusAtividadeId);

            if (atividade == null || statusAtividade == null) return;

            atividade.StatusAtividadeId = statusAtividadeId;

            if (midiaId.HasValue && midiaId > 0)
                atividade.MidiasId = midiaId;

            if (statusAtividade.FinalizaAtividade)
            {
                atividade.FinalizadoEm = DateTime.Now;
                atividade.FinalizadoPorUserId = userId;
            }

            _repositorio.Atualizar(atividade);

            if (atividade.AtividadeTipoId == 4)
            {
                var atividadeFilas = _servicoAtividadeFila.ObterPorAtividadeId(atividadeId);

                if (atividadeFilas == null)
                    return;

                foreach (var atividadeFila in atividadeFilas)
                {
                    if (!atividadeFila.SaiuDaFilaEm.HasValue)
                    {
                        _servicoAtividadeFila.AtualizaSaiuDaFilaEm(atividadeFila.Id);
                    }
                }
            }
        }

        public IEnumerable<Atividade> ObterAtividadesPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            int? quantidade)
        {
            if (pessoaFisicaId == null && pessoaJuridicaId == null)
                return null;

            return _repositorio.ObterPorCliente(pessoaFisicaId, pessoaJuridicaId, quantidade);
        }

        public void Atualizar(Atividade atividade, StatusAtividade statusAtividade, string finalizadoPorUserId,
            int midiaId)
        {
            if (statusAtividade.FinalizaAtividade)
            {
                atividade.FinalizadoEm = DateTime.Now;
                atividade.FinalizadoPorUserId = finalizadoPorUserId;
            }

            atividade.MidiasId = midiaId;
            atividade.StatusAtividadeId = statusAtividade.Id;
            _repositorio.Atualizar(atividade);
        }

        public ValidationResult Adicionar(Atividade entidade)
        {
            if (!entidade.ValidationResult.IsValid)
                return entidade.ValidationResult;

            var selfValidationEntity = entidade as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            var adicionou = _repositorio.Adicionar(entidade);

            if (adicionou == null)
                entidade.ValidationResult.Add(
                    new ValidationError(
                        "A Entidade que você está tentando gravar está nula, por favor tente novamente!" + entidade));

            if (entidade.AtividadeTipoId != null)
            {
                var atividadeTipo = _servicoAtividadeTipo.ObterPorId((int) entidade.AtividadeTipoId);

                if (atividadeTipo != null)
                    if (atividadeTipo.Nome.ToLower() == "ligação")
                    {
                        var atividadePartesEnvolvidas = new AtividadeParteEnvolvida(entidade.Id,
                            entidade.PessoasFisicasId, entidade.PessoasJuridicasId, entidade.PotenciaisClientesId,
                            entidade.CriadoPorUserId, TipoParteEnvolvida.Destinatario.Value, null, null);
                        _servicoAtividadeParteEnvolvida.Adicionar(atividadePartesEnvolvidas);
                    }
            }

            foreach (var envolvido in entidade.Envolvidos)
            {
                envolvido.SetarAtividadeId(entidade.Id);
                _servicoAtividadeParteEnvolvida.Adicionar(envolvido);
            }

            return entidade.ValidationResult;
        }

        public Atividade ObterPorId(long id)
        {
            return _repositorio.ObterPorId(id);
        }

        public Atividade ObterPorIdDal(long atividadeId)
        {
            return _atividadeRepositorioDal.ObterPorIdDal(atividadeId);
        }

        public ValidationResult Atualizar(Atividade entidade)
        {
            if (!entidade.ValidationResult.IsValid)
                return entidade.ValidationResult;

            var selfValidationEntity = entidade as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            var atualizar = _repositorio.Atualizar(entidade);
            if (!atualizar)
                entidade.ValidationResult.Add(
                    new ValidationError(
                        "A Entidade que você está tentando atualizar está nula, por favor tente novamente! Nome: " +
                        entidade));
            return entidade.ValidationResult;
        }

        public void AtualizarDadosAtividadeEAtividadeFila(string userId, long atividadeId)
        {
            var where = new DynamicParameters();
            where.Add("@UserID", userId);
            where.Add("@atividadeID", atividadeId);
            _repositorio.ExecutarProcedimento("usp_front_upd_AtividadesFilasAtividade", where);
        }

        public void AtualizarResponsavel(string userId, long atividadeId)
        {
            var where = new DynamicParameters();

            if (!string.IsNullOrEmpty(userId))
                where.Add("@UserID", userId);

            where.Add("@atividadeID", atividadeId);
            _repositorio.ExecutarProcedimento("usp_front_upd_AtividadesResponsavelPor", where);
        }

        public ValidationResult AdicionarSolicitacaoLigacaoCorretor(long ocorrenciaId, string criadoPorUserId,
            string descricao)
        {
            var retorno = new ValidationResult();
            var statusAtividade = _servicoStatusAtividade.ObterStatusAtividadePadraoParaLigacao();
            var valorEncontrado = statusAtividade != null;

            if (!valorEncontrado)
            {
                retorno.Add(
                    new ValidationError(
                        "Não foi possível cadastrar a solicitação de ligação: nenhum status atividade padrão para ligação retornado"));
                return retorno;
            }

            valorEncontrado = false;
            var atividadeTipo = _servicoAtividadeTipo.BuscarPorNome("Ligação");
            if (atividadeTipo != null)
                valorEncontrado = true;

            if (!valorEncontrado)
            {
                retorno.Add(
                    new ValidationError(
                        "Não foi possível cadastrar a solicitação de ligação: nenhuma atividade tipo para o nome Ligação foi retornado"));
                return retorno;
            }

            var ocorrencia = _servicoOcorrencia.ObterPorId(ocorrenciaId);

            var atividade = new Atividade()
            {
                CriadoPorUserId = criadoPorUserId,
                CriadoEm = DateTime.Now,
                StatusAtividadeId = statusAtividade.Id,
                AtividadeTipoId = atividadeTipo.Id,
                Titulo = "Ligação Ativa",
                Descricao = descricao,
                OcorrenciaId = ocorrenciaId,
                PessoasFisicasId = ocorrencia.PessoaFisicaId,
                PessoasJuridicasId = ocorrencia.PessoaJuridicaId
            };

            retorno = Adicionar(atividade);

            if (!retorno.IsValid) return retorno;

            var configuracao = new Configuracao();
            configuracao.SetarListaSolicitacaoLigacaoCorretor();
            var nomeFilaSolicitacaoCorretor = _servicoConfiguracao.ObterPor(configuracao);
            valorEncontrado = false;

            if (nomeFilaSolicitacaoCorretor != null)
                if (nomeFilaSolicitacaoCorretor.Any())
                    valorEncontrado = true;

            if (!valorEncontrado)
            {
                retorno.Add(
                    new ValidationError(
                        "Não foi possível cadastrar a solicitação de ligação: nenhuma lista para tratativa de solicitações Corretor cadastrada."));
                return retorno;
            }

            retorno = _servicoAtividadeFila.AdicionarAtividadeFila(nomeFilaSolicitacaoCorretor.FirstOrDefault().Valor,
                atividade.Id);

            return retorno;
        }

        public Atividade AdicionarAtividadeEmail(string userId, long? ocorrenciaId, long? contratoId,
            long? atendimentoId, string titulo, string descricao, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId, int? canalId, int? midiaId, string iniciadoPorUserId, long? atividadeDeOrigemId,
            IEnumerable<AtividadeParteEnvolvida> envolvidos, string responsavelPorUserId, bool enviarEmail,
            int? statusAtividadeId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                var usuarioAdm = _servicoUsuario.ObterPorEmail("sistemas@bizpro.com.br");
                userId = usuarioAdm != null ? usuarioAdm.Id : "f712efbb-4646-4870-8f37-a687cb2e8978";
            }

            var atividadeTipo = _servicoAtividadeTipo.BuscarPorNome("email");
            //var statusAtividadeId = 0;

            if (enviarEmail)
            {
                var statusAtividade = _servicoStatusAtividade.ObterStatusAtividade("Aguardando Envio", "email");
                if (statusAtividade != null)
                    statusAtividadeId = statusAtividade.FirstOrDefault().Id;
            }

            if (!statusAtividadeId.HasValue || statusAtividadeId == 0)
            {
                var statusAtividade = _servicoStatusAtividade.ObterStatusAtividadeEmail().FirstOrDefault();
                if (statusAtividade != null)
                    statusAtividadeId = statusAtividade.Id;
            }

            if (!canalId.HasValue)
            {
                var canal = _canalServico.ObterCanalEmail();
                if (canal.ValidationResult.IsValid)
                    canalId = canal.Id;
            }

            var atividade = new Atividade(userId, (int) statusAtividadeId, atividadeTipo.Id, titulo, pessoaFisicaId,
                pessoaJuridicaId, potencialClienteId, ocorrenciaId, descricao, atendimentoId, midiaId, envolvidos,
                responsavelPorUserId, atividadeDeOrigemId, null, canalId, iniciadoPorUserId);
            atividade.ValidationResult = Adicionar(atividade);

            return atividade;
        }

        public IEnumerable<Atividade> ObterNaoFinalizadasPorOcorrenciaId(long ocorrenciaId)
        {
            return _repositorio.ObterNaoFinalizadasPorOcorrenciaId(ocorrenciaId);
        }

        public Atividade ObterAtividadeCompletaPor(long atividadeId)
        {
            return _repositorio.ObterAtividadeCompletaPor(atividadeId);
        }

        public void AtualizarCliente(long atividadeId, long? pessoaFisicaId, long? pessoaJuridicaId, string userId,
            string tipoParteEnvolvida, bool inserirParteEnvolvida = true)
        {
            _repositorio.AtualizarCliente(atividadeId, pessoaFisicaId, pessoaJuridicaId, userId);
            var atividadeParteEnvolvida = new AtividadeParteEnvolvida(atividadeId, pessoaFisicaId, pessoaJuridicaId,
                null, userId, tipoParteEnvolvida, null, null);

            if (inserirParteEnvolvida)
                _servicoAtividadeParteEnvolvida.Adicionar(atividadeParteEnvolvida);
        }

        public Atividade NovaAtividadeLigacao(string criadoPorId, string reponsavelPorId, int? statusAtividade,
            long? atendimentoId, DateTime? previsaoDeExecucao, string titulo, string descricao, long? pessoaFisicaId,
            long? pessoaJuridicaId, string iniciadoPorUserId)
        {
            var atividade = new Atividade();

            if (string.IsNullOrEmpty(criadoPorId))
            {
                var usuarioAdm = _servicoUsuario.ObterPorEmail("sistemas@bizpro.com.br");
                if (usuarioAdm != null)
                    criadoPorId = usuarioAdm.Id;
                else
                {
                    atividade.ValidationResult.Add(
                        new ValidationError(
                            "Não foi informado o usuario (Criado Por) e também não possui usuario padrão cadastrado (sistemas@bizpro.com.br)"));
                    return atividade;
                }
            }

            /// Foi alterado esse trecho, pois o valor de atividadeTipo é Fixo, e estamos buscando performance nesse momento- 17/01/2019 Thiago H. Din
            //var atividadeTipo = _servicoAtividadeTipo.BuscarPorNome("Ligação");
            //if (atividadeTipo == null)
            //{
            //    atividade.ValidationResult.Add(new ValidationError("AtividadaTipo com nome (Ligação) não cadastrada"));
            //    return atividade;
            //}

            var atividadeTipoId = Convert.ToInt32(AtividadeTipoEnum.Ligacao);

            if (!statusAtividade.HasValue)
            {
                var statusAtividadePadraoLigacao = _servicoStatusAtividade.ObterStatusAtividadePadraoParaLigacao();

                if (statusAtividadePadraoLigacao == null)
                {
                    atividade.ValidationResult.Add(
                        new ValidationError("StatusAtividade Padrão para Ligação não cadastrada."));
                    return atividade;
                }

                statusAtividade = statusAtividadePadraoLigacao.Id;
            }

            //int? canalId = null;
            //var canal = _canalServico.ObterCanalTelefone();
            //if (canal.ValidationResult.IsValid)
            //    canalId = canal.Id;

            var canalId = Convert.ToInt32(CanalEnum.Telefone);

            atividade = new Atividade(criadoPorId, statusAtividade.Value, atividadeTipoId, "Ligação Receptiva",
                pessoaFisicaId, pessoaJuridicaId, null, null, null, atendimentoId, null, null, criadoPorId, null,
                previsaoDeExecucao, canalId, iniciadoPorUserId);

            _repositorio.Adicionar(atividade);

            if (atividade.Id <= 0 || !atividade.AtendimentoId.HasValue) return atividade;
            if (!(atividade.AtendimentoId > 0)) return atividade;

            var atendimentoAtividade = new AtendimentoAtividade(atividade.Id, (long) atividade.AtendimentoId);
            _atendimentoAtividadeServico.Adicionar(atendimentoAtividade);

            return atividade;
        }

        public ValidationResult AtualizarResponsavel(long atividadeId, string responsavelId, string atualizadoPorId)
        {
            var retorno = new ValidationResult();
            var atividade = _repositorio.ObterPorId(atividadeId);

            if (atividade == null)
            {
                retorno.Add(new ValidationError("Nenhuma Atividade retornada com o Id: " + atividadeId));
                return retorno;
            }

            atividade.ResponsavelPorUserId = responsavelId;

            if (!_repositorio.Atualizar(atividade))
                retorno.Add(new ValidationError("Problema ao atualizar a Atividade"));

            return retorno;
        }

        public Atividade AdicionarAtividadeTarefa(string userId, long? ocorrenciaId, long? contratoId,
            long? atendimentoId, string titulo, string descricao, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId, int? canalId, int? midiaId, string iniciadoPorUserId, long? atividadeDeOrigemId,
            string responsavelPorUserId, DateTime? previsaoExecucao)
        {
            if (string.IsNullOrEmpty(userId))
            {
                var usuarioAdm = _servicoUsuario.ObterPorEmail("sistemas@bizpro.com.br");
                userId = usuarioAdm != null ? usuarioAdm.Id : "f712efbb-4646-4870-8f37-a687cb2e8978";
            }

            var atividadeTipo = _servicoAtividadeTipo.BuscarPorNome("tarefa");
            var statusAtividadeId = 0;

            if (statusAtividadeId == 0)
            {
                var statusAtividade = _servicoStatusAtividade.ObterStatusAtividadePadraoTarefa();
                if (statusAtividade != null)
                    statusAtividadeId = statusAtividade.Id;
            }

            var atividade = new Atividade(userId, statusAtividadeId, atividadeTipo.Id, titulo, pessoaFisicaId,
                pessoaJuridicaId, potencialClienteId, ocorrenciaId, descricao, atendimentoId, midiaId, null,
                responsavelPorUserId, atividadeDeOrigemId, previsaoExecucao, null, iniciadoPorUserId);

            atividade.ValidationResult = Adicionar(atividade);
            return atividade;
        }

        public ValidationResult RedirecionarFila(string atividadesId, string usuarioId, int filaId)
        {
            return _repositorio.RedirecionarFila(atividadesId, usuarioId, filaId);
        }

        public IEnumerable<AtividadeApoio> ObterPor(int? atividadeTipoId, DateTime? criadoEm, string criadoPor,
            int? statusAtividadeId, long? ocorrenciaId, long? contratoId, long? atendimentoId,
            DateTime? previsaoExecucao, long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId,
            int canalId, int? midiaId, string responsavel, int? filaId, string protocolo, int? situacaoId,
            bool? atividadeEmFila, int departamentoId)
        {
            return _atividadeApoioServico.ObterPor(atividadeTipoId, criadoEm, criadoPor, statusAtividadeId, ocorrenciaId,
                contratoId, atendimentoId, previsaoExecucao, pessoaFisicaId, pessoaJuridicaId, potencialClienteId,
                canalId, midiaId, responsavel, filaId, protocolo, situacaoId, atividadeEmFila, departamentoId);
        }


        public Atividade AdicionarAtividadeChat(string usuarioId, long? atendimentoId,
            IEnumerable<AtividadeParteEnvolvida> envolvidos, int? statusAtividadeId)
        {
            var atividade = new Atividade();

            if (string.IsNullOrEmpty(usuarioId))
            {
                var usuarioAdm = _servicoUsuario.ObterPorEmail("sistemas@bizpro.com.br");
                if (usuarioAdm != null)
                    usuarioId = usuarioAdm.Id;
                else
                {
                    atividade.ValidationResult.Add(
                        new ValidationError(
                            "Não foi informado o usuario (Criado Por) e também não possui usuario padrão cadastrado (sistemas@bizpro.com.br)"));
                    return atividade;
                }
            }

            var atividadeTipo = _servicoAtividadeTipo.BuscarPorNome("Chat");
            if (atividadeTipo == null)
            {
                atividade.ValidationResult.Add(new ValidationError("AtividadaTipo com nome (Chat) não cadastrada"));
                return atividade;
            }

            if (!statusAtividadeId.HasValue)
            {
                var statusAtividadePadraoChat = _servicoStatusAtividade.ObterStatusAtividadePadraoParaChatPadrao();

                if (statusAtividadePadraoChat == null)
                {
                    atividade.ValidationResult.Add(
                        new ValidationError("StatusAtividade Padrão para Chat não cadastrada."));
                    return atividade;
                }

                statusAtividadeId = statusAtividadePadraoChat.Id;
            }

            int? canalId = null;
            var canal = _canalServico.ObterCanalChat();
            if (canal.ValidationResult.IsValid)
                canalId = canal.Id;

            atividade = new Atividade(usuarioId, statusAtividadeId.Value, atividadeTipo.Id, "Chat",
                null, null, null, null, null, atendimentoId, null, envolvidos, usuarioId, null,
                null, canalId, usuarioId);

            _repositorio.Adicionar(atividade);

            _servicoAtividadeFila.AdicionarAtividadeFila("chat",
                atividade.Id);

            if (envolvidos.Any())
            {
                foreach (var envolvido in atividade.Envolvidos)
                {
                    envolvido.SetarAtividadeId(atividade.Id);
                    _servicoAtividadeParteEnvolvida.Adicionar(envolvido);
                }
            }

            if (atividade.Id <= 0 || !atividade.AtendimentoId.HasValue) return atividade;
            if (!(atividade.AtendimentoId > 0)) return atividade;

            var atendimentoAtividade = new AtendimentoAtividade(atividade.Id, (long) atividade.AtendimentoId);
            _atendimentoAtividadeServico.Adicionar(atendimentoAtividade);

            return atividade;
        }

        
    }
}
