using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Linq;
using BizPRO.CRM.V2.Core.ValueObjects;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class StatusAtividadeServico : Servico<StatusAtividade>, IStatusAtividadeServico
    {
        private readonly IStatusAtividadeRepositorio _repositorio;

        public StatusAtividadeServico(IStatusAtividadeRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public StatusAtividade ObterStatusAtividadePadraoParaLigacao()
        {
            var statusAtividades = _repositorio.ObterStatusAtividades(null, "ligacao", true, null, null, true);
            return statusAtividades.Any() ? statusAtividades.FirstOrDefault() : null;
        }

        public StatusAtividade ObterStatusAtividadePadraoParaChatPadrao()
        {
            var statusAtividades = _repositorio.ObterStatusAtividades(null, "chatPadrao", true, null, null, true, null,
                true);
            return statusAtividades.Any() ? statusAtividades.FirstOrDefault() : null;
        }

        public StatusAtividade ObterStatusAtividadePadraoTarefa()
        {
            var statusAtividades = _repositorio.ObterStatusAtividades(null, "tarefa", true, null, null, true);
            return statusAtividades.Any() ? statusAtividades.FirstOrDefault() : null;
        }

        public StatusAtividade ObterStatusAtividadePadraoFinalizaParaEmail()
        {
            return ObterStatusAtividadeEmail().FirstOrDefault(w => w.StatusPadrao && w.FinalizaAtividade);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividadeLigacaoReceptiva()
        {
            return _repositorio.ObterStatusAtividades(null, "ligacao", null, true, null, true, "e",
                false);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividadeTarefa()
        {
            return _repositorio.ObterStatusAtividades(null, "tarefa", null, null, null, true);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividadeEmail()
        {
            return _repositorio.ObterStatusAtividades(null, "email", null, null, null, true);
        }

        public IEnumerable<StatusAtividade> ObterTodos()
        {
            return _repositorio.ObterTodos().OrderBy(c => c.Descricao);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividadeLigacaoAtiva()
        {
            return _repositorio.ObterPorProcedimento("usp_front_sel_statusAtividadesLigacaoAtiva", null);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividadeChat()
        {
            return _repositorio.ObterStatusAtividades(null, "chatPadrao", false, null, null, true);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividadeMessenger()
        {
            return _repositorio.ObterStatusAtividades(null, "messenger", false, null, null, true);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividade(string descricao, string atividadesValidas)
        {
            return _repositorio.ObterStatusAtividades(descricao, atividadesValidas, null, null, null, true);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividadeEmailRecebido()
        {
            return _repositorio.ObterStatusAtividades(null, "email", null, true, true, true, "e");
        }

        public bool VerificarEntidadeRequeridaAtendimento(long atendimentoId, long statusAtividadeId)
        {
            return _repositorio.VerificarEntidadeRequeridaAtendimento(atendimentoId, statusAtividadeId);
        }

        public bool VerificarEntidadeNaoRequeridaAtendimento(long atendimentoId, long statusAtividadeId)
        {
            return _repositorio.VerificarEntidadeNaoRequeridaAtendimento(atendimentoId, statusAtividadeId);
        }

        public IEnumerable<StatusAtividade> ObterPor(int canal, string sentido, bool? padrao)
        {
            var entidadeValida = "";

            switch (canal)
            {
                case (int) CanalValueObjects.Telefone:
                    entidadeValida = "ligacao";
                    break;
                case (int) CanalValueObjects.Email:
                    entidadeValida = "email";
                    break;
                case (int) CanalValueObjects.Chat:
                    entidadeValida = "chatPadrao";
                    break;
            }

            if (!string.IsNullOrEmpty(sentido))
                sentido = sentido.ToLower();

            return _repositorio.ObterStatusAtividades(null, entidadeValida, padrao, null, null, true, sentido);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividadeEmailEnviado()
        {
            return _repositorio.ObterStatusAtividades(null, "email", null, true, true, true, "s");
        }


        public bool VerificarTempoAtividade(long atividadeId, long statusAtividadeId)
        {
            return _repositorio.VerificarTempoAtividade(atividadeId, statusAtividadeId);
        }

        public bool VerificarStatusAtividadeRequerida(long atividadeId, long statusAtividadeId)
        {
            return _repositorio.VerificarStatusAtividadeRequerida(atividadeId, statusAtividadeId);
        }
    }
}