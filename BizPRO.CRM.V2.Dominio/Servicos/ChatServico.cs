using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ChatServico : Servico<Chat>, IChatServico
    {
        private readonly IChatRepositorio _repositorio;
        private readonly IChatSolicitacaoServico _chatSolicitacao;
        private readonly IUsuarioServico _usuarioServico;
        private readonly ICanalServico _canalServico;
        private readonly IAtendimentoServico _servicoAtendimento;
        private readonly IAtividadeServico _servicoAtividade;
        private readonly IConfiguracaoServico _configuracaoServico;

        public ChatServico(IChatRepositorio repositorio, IChatSolicitacaoServico chatSolicitacao,
            IUsuarioServico usuarioServico, ICanalServico canalServico, IAtendimentoServico servicoAtendimento,
            IAtividadeServico servicoAtividade, IConfiguracaoServico configuracaoServico)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _chatSolicitacao = chatSolicitacao;
            _usuarioServico = usuarioServico;
            _canalServico = canalServico;
            _servicoAtendimento = servicoAtendimento;
            _servicoAtividade = servicoAtividade;
            _configuracaoServico = configuracaoServico;
        }

        public ChatSolicitacao RegistrarSolicitacao(string campanhaId, int? filaId, string conexaoClienteId, string nome,
            string documento)
        {
            var chatSolicitacao = new ChatSolicitacao
            {
                CampanhaId = campanhaId,
                FilaId = filaId,
                ConexaoClienteId = conexaoClienteId,
                Nome = nome,
                Documento = documento
            };

            var resultado = _chatSolicitacao.Adicionar(chatSolicitacao);
            chatSolicitacao.ValidationResult = resultado;
            return chatSolicitacao;
        }

        public Chat Novo(string usuarioId, long solicitacaoId, string conexaoClienteId, string nomeCliente, string conexaoAgenteId)
        {
            Chat chat;

            if (string.IsNullOrEmpty(usuarioId))
            {
                var usuarioAdm = _usuarioServico.ObterPorEmail("sistemas@bizpro.com.br");
                if (usuarioAdm != null)
                    usuarioId = usuarioAdm.Id;
                else
                {
                    chat = new Chat();
                    chat.ValidationResult.Add(
                        new ValidationError(
                            "Não foi informado o usuario (Criado Por) e também não possui usuario padrão cadastrado (sistemas@bizpro.com.br)"));
                    return chat;
                }
            }


            var canal = _canalServico.ObterCanalChat();
            var atendimento = _servicoAtendimento.AdicionarNovoAtendimento(canal != null ? canal.Id : (int?) null,
                usuarioId, null);

            if (!atendimento.ValidationResult.IsValid)
            {
                var retorno = new Chat() {ValidationResult = atendimento.ValidationResult};
                return retorno;
            }

            var envolvidos = new List<AtividadeParteEnvolvida> {new AtividadeParteEnvolvida(null, nomeCliente, "R")};
            var atividade = _servicoAtividade.AdicionarAtividadeChat(usuarioId, atendimento.Id, envolvidos, null);
           
            if (!atividade.ValidationResult.IsValid)
            {
                var retorno = new Chat {ValidationResult = atividade.ValidationResult};
                return retorno;
            }

            chat = new Chat
            {
                Tipo = "PAD",
                AtividadeId = atividade.Id,
                ConexaoClienteId = conexaoClienteId,
                ChatSolicitacaoId = solicitacaoId,
                ConexaoOperadorId = conexaoAgenteId
            };

            _repositorio.Adicionar(chat);
            atividade.Atendimento = atendimento;
            chat.Atividade = atividade;
            return chat;
        }

        public int ObterQuantidadeConversaPorOperador(string usuarioId)
        {
            var totalConfigurado = _configuracaoServico.ObterQuantidadeConversaPadrao();
            int retorno;
            int.TryParse(totalConfigurado.Valor, out retorno);

            if (retorno == 0)
                retorno = 1;

            // Quando colocar as regras por operador também, deveremos buscar aqui!

            return retorno;
        }

        public bool Online(int? filaId)
        {
            var retorno = _repositorio.Online(filaId);
            return retorno;
        }

        public Chat ObterPorAtividadeId(long atividadeId)
        {
            return _repositorio.ObterPorAtividadeId(atividadeId);
        }
    }
}
