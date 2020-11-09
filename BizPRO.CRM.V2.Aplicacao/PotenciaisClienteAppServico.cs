using BizPRO.CRM.V2.Aplicacao.Adaptadores;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class PotenciaisClienteAppServico : IPotenciaisClienteAppServico
    {
        private readonly ICidadeServico _cidadeServico;
        private readonly IPotenciaisClienteServico _potenciaisClienteServico;
        private readonly ITelefoneServico _servicoTelefone;
        private readonly IViewDinamicaAppServico _viewDinamicaAppServico;
        private readonly IPessoaFisicaAppServico _pessoaFisicaAppServico;
        private readonly IPessoaJuridicaAppServico _pessoaJuridicaAppServico;

        public PotenciaisClienteAppServico(ICidadeServico cidadeServico,
            IPotenciaisClienteServico potenciaisClienteServico, ITelefoneServico servicoTelefone,
            IViewDinamicaAppServico viewDinamicaAppServico,
            IPessoaFisicaAppServico pessoaFisicaAppServico, IPessoaJuridicaAppServico pessoaJuridicaAppServico)
        {
            _cidadeServico = cidadeServico;
            _potenciaisClienteServico = potenciaisClienteServico;
            _servicoTelefone = servicoTelefone;
            _viewDinamicaAppServico = viewDinamicaAppServico;
            _pessoaFisicaAppServico = pessoaFisicaAppServico;
            _pessoaJuridicaAppServico = pessoaJuridicaAppServico;
        }

        public PotenciaisClienteViewModel Carregar()
        {
            var model = new PotenciaisClienteViewModel();
            var cidadeViewModel = new List<CidadeViewModel>();

            foreach (var item in _cidadeServico.ObterTodosEstados())
            {
                cidadeViewModel.Add(new CidadeViewModel(item.Id, item.Nome, item.Uf));
            }

            model.ListaUF = cidadeViewModel;
            model.ViewDinamica = _viewDinamicaAppServico.Carregar("POTENCIACL", "padrão", null, null, true);
            return model;
        }

        public List<CidadeViewModel> ObterCidadesPorUf(string uf)
        {
            var model = new List<CidadeViewModel>();

            foreach (var item in _cidadeServico.ObterCidadesPorEstado(uf))
            {
                model.Add(new CidadeViewModel(item.Id, item.Nome, item.Uf));
            }

            return model;
        }

        public PotenciaisClienteViewModel Adicionar(PotenciaisClienteViewModel model, string usuarioId)
        {
            var entidade = PotenciaisClienteAdaptador.ParaDominioModelo(model);
            var resultado = _potenciaisClienteServico.AdicionarPotenciaisCliente(entidade);

            if (!resultado.ValidationResult.IsValid)
            {
                model.ValidationResult = resultado.ValidationResult;
                return model;
            }

            if (model.TelefoneLista != null)
                if (model.TelefoneLista.Any())
                {
                    var telefones = _servicoTelefone.ObterTelefoneCliente(null, null, resultado.id);

                    foreach (var item in model.TelefoneLista)
                    {
                        var tel = telefones.FirstOrDefault(c => c.Ddd == item.DDD && c.Numero == item.numero);
                        if (tel != null) continue;
                        var telefone = new Telefone(item.DDD, item.numero, model.criadoPorAspNetUserID, null, null,
                            item.TelefonesTiposID, resultado.id);
                        _servicoTelefone.Adicionar(telefone);
                    }
                }

            if (model.ViewDinamica != null)
            {
                model.ViewDinamica.ChaveEntidadeId = resultado.id;
                _viewDinamicaAppServico.Atualizar(model.ViewDinamica,usuarioId);
            }
            return model;
        }

        public IEnumerable<listarPotenciaisClienteViewModel> Pesquisar(string nome, string documento, string protocolo)
        {
            var model = new List<listarPotenciaisClienteViewModel>();
            var entidade = _potenciaisClienteServico.PesquisarPotenciaisCliente(nome, documento, protocolo);
            foreach (var item in entidade)
            {
                model.Add(new listarPotenciaisClienteViewModel(item.id, item.nome, item.documento, item.criadoEm,
                    item.tipo, item.email));
            }
            return model;
        }

        public PotenciaisClienteViewModel BuscarCliente(long id)
        {
            var _listaCidade = new List<CidadeViewModel>();
            var _listaEstado = new List<CidadeViewModel>();
            var _listaTelefone = new List<TelefoneListaViewModel>();
            string estado = null;
            var _cidade = new CidadeViewModel();
            var entidade = _potenciaisClienteServico.ObterPorId(id);
            if (entidade != null)
            {
                var listaUf = _cidadeServico.ObterTodosEstados();

                foreach (var item in listaUf)
                {
                    _listaEstado.Add(new CidadeViewModel(item.Id, item.Nome, item.Uf));
                }

                if (entidade.CidadesID != null)
                {
                    var cidade = _cidadeServico.ObterPorId((int) entidade.CidadesID);

                    _cidade = new CidadeViewModel(cidade.Id, cidade.Nome, cidade.Uf);
                    estado = cidade.Uf;
                    var listaCidade = _cidadeServico.ObterCidadesPorEstado(cidade.Uf);

                    foreach (var item in listaCidade)
                    {
                        _listaCidade.Add(new CidadeViewModel(item.Id, item.Nome, item.Uf));
                    }
                }


                var telefones = _servicoTelefone.ObterTelefoneCliente(null, null, (long) entidade.id);
                foreach (var item in telefones)
                {
                    _listaTelefone.Add(new TelefoneListaViewModel(item.Id, item.ClientePessoaFisicaId,
                        item.ClientePessoaJuridicaId, item.Ddd, item.Numero, item.TipoTelefone, item.TelefonesTiposId,
                        item.PotenciaisClientesId));
                }

                var viewDinamica = _viewDinamicaAppServico.Carregar("POTENCIACL", "padrão", null, id, true);


                return new PotenciaisClienteViewModel
                (
                    entidade.id
                    , entidade.nome
                    , entidade.documento
                    , entidade.contato
                    , entidade.contatoDocumento
                    , entidade.email
                    , entidade.logradouro
                    , entidade.numero
                    , entidade.bairro
                    , entidade.CidadesID
                    , entidade.criadoPorAspNetUserID
                    , entidade.tipo
                    , entidade.cep
                    , entidade.contatoEmail
                    , entidade.criadoEm
                    , entidade.alteradoEm
                    , _listaEstado
                    , _listaCidade
                    , _cidade
                    , _listaTelefone
                    , estado
                    , viewDinamica
                );
            }

            var validacaoRetorno = new ValidationResult();
            validacaoRetorno.Add(
                new ValidationError(
                    "Nenhum cliente encontrado com os parâmetros informados."));
            return new PotenciaisClienteViewModel() {ValidationResult = validacaoRetorno};
        }

        public PotenciaisClienteViewModel Editar(PotenciaisClienteViewModel model, string usuarioId)
        {
            var entidade = PotenciaisClienteAdaptador.ParaDominioModelo(model);
            var resultado = _potenciaisClienteServico.EditarPotenciaisCliente(entidade);

            if (!resultado.ValidationResult.IsValid)
            {
                model.ValidationResult = resultado.ValidationResult;
                return model;
            }

            if (model.TelefoneLista != null)
                if (model.TelefoneLista.Any())
                {
                    var telefones = _servicoTelefone.ObterTelefoneCliente(null, null, resultado.id);

                    foreach (var item in model.TelefoneLista)
                    {
                        var tel = telefones.FirstOrDefault(c => c.Ddd == item.DDD && c.Numero == item.numero);
                        if (tel == null)
                        {
                            var telefone = new Telefone(item.DDD, item.numero, model.alteradoPorAspNetUserID, null, null,
                                item.TelefonesTiposID, resultado.id);
                            _servicoTelefone.Adicionar(telefone);
                        }
                    }
                }

            if (model.ViewDinamica != null)
            {
                model.ViewDinamica.ChaveEntidadeId = resultado.id;
                _viewDinamicaAppServico.Atualizar(model.ViewDinamica,  usuarioId);
            }

            return model;
        }

        public PotenciaisClienteViewModel ConverterEmCliente(PotenciaisClienteViewModel model)
        {
            if (model.tipo == "PF")
            {
                var retorno = ConverterPf(model);

                if (!retorno.ValidationResult.IsValid)
                {
                    model.ValidationResult = retorno.ValidationResult;
                    return model;
                }
                model.convertidoEmClientePessoasFisicasID = retorno.Id;
                model.convertidoEmClientePorAspNetUserID = model.convertidoEmClientePorAspNetUserID;
                model.convertidoEmClienteEm = DateTime.Now;

                var entidade = PotenciaisClienteAdaptador.ParaDominioModelo(model);
                var resultado = _potenciaisClienteServico.AtualizarConverterCliente(entidade);

                return model;
            }

            if (model.tipo == "PJ")
            {
                var retorno = ConverterPj(model);

                if (!retorno.ValidationResult.IsValid)
                {
                    model.ValidationResult = retorno.ValidationResult;
                    return model;
                }
                model.convertidoEmClientePessoasJuridicasID = retorno.Id;
                model.convertidoEmClientePorAspNetUserID = model.convertidoEmClientePorAspNetUserID;
                model.convertidoEmClienteEm = DateTime.Now;

                var entidade = PotenciaisClienteAdaptador.ParaDominioModelo(model);
                var resultado = _potenciaisClienteServico.AtualizarConverterCliente(entidade);

                return model;
            }
            return model;

        }

        private PessoaFisicaFormViewModel ConverterPf(PotenciaisClienteViewModel model)
        {
            var modelView = new PessoaFisicaFormViewModel(model.nome, model.documento,
                model.convertidoEmClientePorAspNetUserID, model.logradouro, model.numero, model.bairro, model.CidadesID,
                model.cep, model.email, model.TelefoneLista);
            return _pessoaFisicaAppServico.Salvar(modelView, model.criadoPorAspNetUserID);
        }

        private PessoaJuridicaFormViewModel ConverterPj(PotenciaisClienteViewModel model)
        {
            var modelView = new PessoaJuridicaFormViewModel(model.nome, model.documento,
                model.convertidoEmClientePorAspNetUserID, model.logradouro, model.numero, model.bairro, model.CidadesID,
                model.cep, model.email, model.TelefoneLista);
            return _pessoaJuridicaAppServico.Salvar(modelView, model.criadoPorAspNetUserID);
        }

        public PotenciaisClienteViewModel ObterPorPotencialClienteId(long? id)
        {
            var modelView = _potenciaisClienteServico.ObterPorId((long) id);

            return new PotenciaisClienteViewModel(modelView.id, modelView.nome, modelView.documento, modelView.contato,
                modelView.contatoDocumento, modelView.email, modelView.logradouro, modelView.numero, modelView.bairro,
                modelView.CidadesID, modelView.criadoPorAspNetUserID, modelView.tipo, modelView.cep,
                modelView.contatoEmail, modelView.criadoEm, modelView.alteradoEm, null, null, null, null, "", null);
        }
    }
}