using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class LigacaoAppServico : ILigacaoAppServico
    {
        private readonly ILigacaoServico _servicoLigacao;
        private readonly IMidiaServico _servicoMidia;
        private readonly IStatusAtividadeServico _statusAtividadeServico;
        private readonly ITelefoneServico _servicoTelefone;
        private readonly IAtendimentoServico _servicoAtendimento;

        public LigacaoAppServico(ILigacaoServico servicoLigacao, IMidiaServico servicoMidia,
            IStatusAtividadeServico statusAtividadeServico, ITelefoneServico servicoTelefone, IAtendimentoServico servicoAtendimento)
        {
            _servicoLigacao = servicoLigacao;
            _servicoMidia = servicoMidia;
            _statusAtividadeServico = statusAtividadeServico;
            _servicoTelefone = servicoTelefone;
            _servicoAtendimento = servicoAtendimento;
        }

        public _LigacaoViewModel NovaLigacao(string tipo, string usuarioId, string informacaoUra,
            string numeroTelefone, string codLigacao, string terminal)
        {
            //Ligacao ligacao;

            //if (!string.IsNullOrEmpty(numeroTelefone))
            //{
            //    ligacao = _servicoLigacao.ObterLigacaoReceptivaUra(numeroTelefone);

            //    if (ligacao.Id > 0)
            //    {
            //        if (ligacao.Atividade != null)
            //            if (ligacao.Atividade.Id > 0)
            //            {
            //                if (ligacao.Atividade.Atendimento != null)
            //                    if (ligacao.Atividade.Atendimento.Id > 0)
            //                    {
            //                        _servicoLigacao.AtualizarLigacaoGeradorProtocoloUra(usuarioId, ligacao.Id,
            //                            ligacao.Atividade.Id, ligacao.Atividade.Atendimento.Id);
            //                    }
            //            }
            //    }
            //}



            //if (ligacao.Id == 0)
            //    ligacao = _servicoLigacao.AdicionarLigacaoReceptiva(usuarioId, numeroTelefone, null);


            return null;

        }

        public _LigacaoViewModel Carregar(long? id, long? atividadiId)
        {
            var ligacao = _servicoLigacao.ObterPor(id, atividadiId);

            if (ligacao == null)
            {
                var retorno = new _LigacaoViewModel();
                retorno.ValidationResult.Add(
                    new ValidationError("Nenhuma Ligação Encontrada com os parametros fornecidos"));
                return retorno;
            }

            if (ligacao.Atividade.Atendimento == null)
            {
                var atendimento = _servicoAtendimento.AdicionarNovoAtendimento(1, "f712efbb-4646-4870-8f37-a687cb2e8978",
                    ligacao.Atividade.MidiasId);

                if (atendimento != null)
                {
                    ligacao.Atividade.Atendimento = atendimento;
                }
            }

            if (ligacao.TelefoneId.HasValue)
            {
                ligacao.Telefone = _servicoTelefone.ObterPorId(ligacao.TelefoneId.Value);
            }

            if (ligacao.Atividade.StatusAtividadeId > 0)
            {
                ligacao.Atividade.StatusAtividade =
                    _statusAtividadeServico.ObterPorId(ligacao.Atividade.StatusAtividadeId);
            }

            var midias = _servicoMidia.ObterTodos();
            var statusAtividades = ligacao.Receptiva == null
                ? _statusAtividadeServico.ObterTodos()
                : (ligacao.Receptiva.Value
                    ? _statusAtividadeServico.ObterStatusAtividadeLigacaoReceptiva()
                    : _statusAtividadeServico.ObterStatusAtividadeLigacaoAtiva());

            return new _LigacaoViewModel(ligacao, midias, statusAtividades);
        }
    }
}
