using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class TelefonesAppService : ITelefoneAppServico
    {
        private readonly ITelefoneServico _ITelefoneServico;
        private readonly ITelefonesTiposServico _ITelefonesTiposServico;

        public TelefonesAppService(ITelefoneServico telefoneServico, ITelefonesTiposServico telefonesTiposServico)
        {
            _ITelefoneServico = telefoneServico;
            _ITelefonesTiposServico = telefonesTiposServico;
        }

        public IEnumerable<TelefoneListaViewModel> CarregarTelefones(long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potenciaisClinteId)
        {
            var view = new List<TelefoneListaViewModel>();

            if (pessoaFisicaId == null && pessoaJuridicaId == null && potenciaisClinteId == null)
                return view;

            var telefones = _ITelefoneServico.ObterTelefoneCliente(pessoaFisicaId, pessoaJuridicaId, potenciaisClinteId);
            var tipos = _ITelefonesTiposServico.ObterTodos();
            var telefoneTipo = from t1 in telefones
                join t2 in tipos on t1.TelefonesTiposId equals t2.Id
                select
                new
                {
                    id = t1.Id,
                    ddd = t1.Ddd,
                    numero = t1.Numero,
                    tipo = t2.Nome,
                    clientePessoaFisicaID = t1.ClientePessoaFisicaId,
                    clientePessoaJuridicaID = t1.ClientePessoaJuridicaId,
                    TelefonesTiposID = t1.TelefonesTiposId,
                    PotenciaisClientesID = t1.PotenciaisClientesId
                };

            view.AddRange(
                telefoneTipo.Select(
                    telefone =>
                        new TelefoneListaViewModel(telefone.id, telefone.clientePessoaFisicaID,
                            telefone.clientePessoaJuridicaID, telefone.ddd, telefone.numero, telefone.tipo,
                            telefone.TelefonesTiposID, telefone.PotenciaisClientesID)));

            return view;
        }

        public TelefoneListaViewModel AtualizarTelefone(long id, bool ativo)
        {
            var view = new TelefoneListaViewModel();

            var telefone = _ITelefoneServico.AtualizarTelefone(id, ativo);

            view.ID = telefone.Id;
            view.DDD = telefone.Ddd;
            view.numero = telefone.Numero;
            view.PessoaFisicaID = telefone.ClientePessoaFisicaId;
            view.PessoaJuridicaID = telefone.ClientePessoaJuridicaId;
            view.ativo = telefone.Ativo;


            return view;
        }

        public TelefoneViewModel SalvarTelefone(TelefoneViewModel view, string userId)
        {
            var telefones = _ITelefoneServico.ObterTelefoneCliente(view.PessoaFisicaID, view.PessoaJuridicaID,
                view.PotenciaisClientesID);
            if (telefones.Any(c => c.Ddd == view.DDD && c.Numero == view.numero))
            {
                var validacaoRetorno = new ValidationResult();
                validacaoRetorno.Add(
                    new ValidationError("Telefone informado ja existe para esse cliente."));
                return new TelefoneViewModel {ValidationResult = validacaoRetorno};
            }
            var telefone =
                _ITelefoneServico.SalvarTelefone(new Telefone(view.DDD, view.numero, userId, view.PessoaFisicaID,
                    view.PessoaJuridicaID, view.TelefonesTiposID, view.PotenciaisClientesID));

            return new TelefoneViewModel(telefone.Id, telefone.ClientePessoaFisicaId, telefone.ClientePessoaJuridicaId,
                telefone.Ddd, telefone.Numero, "", telefone.TelefonesTiposId, telefone.PotenciaisClientesId);
        }
    }
}
