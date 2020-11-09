using System;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Web.Mvc;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Enums;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ReceptivoAppServico : AppServicoDapper, IReceptivoAppServico
    {
        private readonly IStatusAtividadeServico _servicoStatusAtividade;
        private readonly IAtividadeServico _servicoAtividade;
        private readonly ILigacaoServico _servicoLigacao;
        private readonly IAtendimentoServico _servicoAtendimento;
        private readonly IPessoaFisicaServico _servicoPessoaFisica;
        private readonly IPessoaJuridicaServico _servicoPessoaJuridica;
        private readonly IMidiaServico _servicoMidia;
        private readonly IAtividadeParteEnvolvidaServico _servicoAtividadeParteEnvolvida;
        private readonly ICanalServico _canalServico;

        public ReceptivoAppServico(IStatusAtividadeServico servicoStatusAtividade, IAtividadeServico servicoAtividade,
            ILigacaoServico servicoLigacao, IAtendimentoServico servicoAtendimento, IClienteServico servicoCliente,
            IPessoaFisicaServico servicoPessoaFisica, IPessoaJuridicaServico servicoPessoaJuridica,
            IMidiaServico servicoMidia, IAtividadeParteEnvolvidaServico servicoAtividadeParteEnvolvida,
            ICanalServico canalServico)
        {
            _servicoAtividade = servicoAtividade;
            _servicoStatusAtividade = servicoStatusAtividade;
            _servicoLigacao = servicoLigacao;
            _servicoAtendimento = servicoAtendimento;
            _servicoPessoaFisica = servicoPessoaFisica;
            _servicoPessoaJuridica = servicoPessoaJuridica;
            _servicoMidia = servicoMidia;
            _servicoAtividadeParteEnvolvida = servicoAtividadeParteEnvolvida;
            _canalServico = canalServico;
        }

        public ValidationResult AtualizarStatusAtividade(long ligacaoId, int statusAtividadeId, long atendimentoId,
            long atividadeId,
            string userId, int midiaId)
        {
            var retorno = new ValidationResult();
            var statusAtividade = _servicoStatusAtividade.ObterPorId(statusAtividadeId);

            if (!string.IsNullOrEmpty(statusAtividade.EntidadeNecessaria))
            {
                var podeAtualizar = _servicoStatusAtividade.VerificarEntidadeRequeridaAtendimento(atendimentoId,
                    statusAtividadeId);

                if (!podeAtualizar)
                {
                    retorno.Add(
                        new ValidationError(
                            string.Format(
                                "Não é possível alterar o status desse atendimento, pois ainda não houve criação e/ou interação de uma: {0}",
                                statusAtividade.EntidadeNecessaria)));
                    return retorno;
                }
            }

            if (!string.IsNullOrEmpty(statusAtividade.EntidadeNaoNecessaria))
            {
                var podeAtualizar = _servicoStatusAtividade.VerificarEntidadeNaoRequeridaAtendimento(atendimentoId,
                    statusAtividadeId);

                if (!podeAtualizar)
                {
                    retorno.Add(
                        new ValidationError(
                            string.Format(
                                "Não é possível alterar o status desse atendimento, pois houve criação e/ou interação de uma: {0}",
                                statusAtividade.EntidadeNaoNecessaria)));
                    return retorno;
                }
            }


            var ligacao = _servicoLigacao.ObterPorId(ligacaoId);

            if (ligacao == null)
            {
                retorno.Add(
                    new ValidationError(
                        string.Format(
                            "Não foi possível alterar o status desse atendimento, nenhuma Ligação retornada com o Id: {0}",
                            ligacaoId)));
                return retorno;
            }

            atividadeId = ligacao.AtividadeId;
            var atividade = _servicoAtividade.ObterPorId(atividadeId);

            if (atividade == null)
            {
                retorno.Add(
                    new ValidationError(
                        string.Format(
                            "Não foi possível alterar o status desse atendimento, nenhuma Atividade retornada com o Id: {0}",
                            atividadeId)));
                return retorno;
            }

            _servicoAtividade.Atualizar(atividade, statusAtividade, userId, midiaId);
            var atendimento = _servicoAtendimento.ObterPorId(atendimentoId);

            if (atendimento != null)
            {
                if (statusAtividade.FinalizaAtendimento)
                {
                    atendimento.FinalizadoEm = DateTime.Now;
                    atendimento.FinalizadoPorUserId = userId;
                }
                atendimento.MidiasId = midiaId;
                _servicoAtendimento.Atualizar(atendimento);
            }

            ligacao.FinalizadoEm = DateTime.Now;
            _servicoLigacao.Atualizar(ligacao);

            return retorno;
        }

        public ReceptivoViewModel NovaLigacaoReceptiva(string userId, string informacaoUra, string numeroTelefone,
            string codLigacao, string terminal)
        {
            var statusUra = false;
            var ligacao = new Ligacao();

            if (!string.IsNullOrEmpty(numeroTelefone))
            {
                ligacao = _servicoLigacao.ObterLigacaoReceptivaUra(numeroTelefone);
                statusUra = true;

                if (ligacao.Id > 0)
                {
                    if (ligacao.Atividade != null)
                        if (ligacao.Atividade.Id > 0)
                        {
                            if (ligacao.Atividade.Atendimento != null)
                                if (ligacao.Atividade.Atendimento.Id > 0)
                                {
                                    _servicoLigacao.AtualizarLigacaoGeradorProtocoloUra(userId, ligacao.Id,
                                        ligacao.Atividade.Id, ligacao.Atividade.Atendimento.Id);
                                }
                        }
                }
            }

            if (ligacao.Id == 0)
                ligacao = _servicoLigacao.AdicionarLigacaoReceptiva(userId, numeroTelefone, null);

            

            if (ligacao.ValidationResult.IsValid)
            {
                if (!string.IsNullOrEmpty(ligacao.Documento))
                    informacaoUra = ligacao.Documento;

                var canalTelefoneId = Convert.ToInt32(CanalEnum.Telefone);
                var listaMidias = new SelectList(_servicoMidia.ObterPor(null, canalTelefoneId), "id", "nome");
                var listaStatusAtividade =
                    new SelectList(_servicoStatusAtividade.ObterStatusAtividadeLigacaoReceptiva(), "id", "descricao");
                if (ligacao.Atividade == null || ligacao.Atividade.AtendimentoId == null) return null;

                if (ligacao.Atividade.Atendimento != null)
                    return new ReceptivoViewModel((long)ligacao.Atividade.AtendimentoId, ligacao.Id,
                        ligacao.AtividadeId, informacaoUra, numeroTelefone, ligacao.Atividade.Atendimento.Protocolo,
                        null, null, null, null, null, listaMidias, listaStatusAtividade, null, statusUra, false, null);
            }
            else
            {
                var retorno = new ReceptivoViewModel { ValidationResult = ligacao.ValidationResult };
                return retorno;
            }
            return null;
        }

        public ReceptivoViewModel Carregar(long atividadeId, bool novoClienteTratativa)
        {
            var model = new ReceptivoViewModel();
            var ligacao = _servicoLigacao.BuscarLigacaoCompleta(null, atividadeId);
            long? tratativaPessoaJuriciaId = null;
            long? tratativaPessoaFisicaId = null;
            var nomeClienteContato = string.Empty;

            if (ligacao == null)
            {
                model.ValidationResult.Add(
                    new ValidationError("Nenhuma Atividade retornada com o Id informado: " + atividadeId));
                return model;
            }

            if (!ligacao.ValidationResult.IsValid)
            {
                foreach (var erro in ligacao.ValidationResult.Erros)
                {
                    model.ValidationResult.Add(erro);
                }
                return model;
            }

            if (!novoClienteTratativa)
            {
                var clienteTratativa = _servicoAtividadeParteEnvolvida.BuscarUltimoClienteTratativa(atividadeId);
                if (clienteTratativa != null)
                {
                    tratativaPessoaFisicaId = clienteTratativa.PessoasFisicasId;
                    tratativaPessoaJuriciaId = clienteTratativa.PessoasJuridicasId;
                }
            }

            var statuAtividade = _servicoStatusAtividade.ObterPorId(ligacao.Atividade.StatusAtividadeId);

            var clienteContato = _servicoAtividadeParteEnvolvida.BuscarClienteContato(atividadeId);
            if (clienteContato != null)
            {
                if (clienteContato.PessoasFisicasId.HasValue)
                {
                    var pessoaFisica = _servicoPessoaFisica.ObterPorId((long)clienteContato.PessoasFisicasId);
                    if (pessoaFisica != null)
                        nomeClienteContato = pessoaFisica.Nome;
                }
                else if (clienteContato.PessoasJuridicasId.HasValue)
                {
                    var pessoaJuridica = _servicoPessoaJuridica.ObterPorId((long)clienteContato.PessoasJuridicasId);
                    if (pessoaJuridica != null)
                        nomeClienteContato = pessoaJuridica.RazaoSocial;
                }
            }

            var canal = _canalServico.ObterCanalTelefone();
            var listaMidias = new SelectList(_servicoMidia.ObterPor(null, canal.Id), "id", "nome");
            var listaStatusAtividade = new SelectList(_servicoStatusAtividade.ObterStatusAtividadeLigacaoReceptiva(),
                "id", "descricao");
            return new ReceptivoViewModel((long)ligacao.Atividade.AtendimentoId, ligacao.Id, ligacao.AtividadeId, ligacao.Documento,
                ligacao.NumeroOriginal, ligacao.Atividade.Atendimento.Protocolo, ligacao.Atividade.MidiasId,
                ligacao.Atividade.PessoasFisicasId, ligacao.Atividade.PessoasJuridicasId, tratativaPessoaFisicaId,
                tratativaPessoaJuriciaId, listaMidias, listaStatusAtividade, nomeClienteContato, false,
                statuAtividade.FinalizaAtividade, statuAtividade.Descricao);
        }

        public SelectList ObterTiposClienteContato()
        {
            var valores = _servicoAtendimento.ObterTiposClienteContato();
            return new SelectList(valores, "id", "valor");
        }

        public ReceptivoViewModel GerarProtocolo(string numeroTelefone, string documento)
        {
            var ligacao = _servicoLigacao.AdicionarLigacaoProtocoloUra(numeroTelefone, documento);
            return new ReceptivoViewModel(ligacao.Atividade.Atendimento.Protocolo, ligacao.ValidationResult);
        }
    }
}
