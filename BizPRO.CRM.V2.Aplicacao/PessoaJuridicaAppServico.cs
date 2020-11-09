using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Aplicacao.Adaptadores;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class PessoaJuridicaAppServico : IPessoaJuridicaAppServico
    {
        readonly IPessoaJuridicaServico _pessoaJuridicaServico;
        readonly ICidadeServico _cidadeServico;
        readonly ITelefoneServico _telefoneServico;
        readonly IViewDinamicaAppServico _viewDinamicaAppServico;
        readonly IEntidadeCampoValorServico _entidadeCampoValorServico;

        public PessoaJuridicaAppServico(IPessoaJuridicaServico pessoaJuridicaServico, ICidadeServico cidadeServico,
            ITelefoneServico telefoneServico, IViewDinamicaAppServico viewDinamicaAppServico,
            IEntidadeCampoValorServico entidadeCampoValorServico)
        {
            _pessoaJuridicaServico = pessoaJuridicaServico;
            _cidadeServico = cidadeServico;
            _telefoneServico = telefoneServico;
            _viewDinamicaAppServico = viewDinamicaAppServico;
            _entidadeCampoValorServico = entidadeCampoValorServico;
        }

        public PessoaJuridicaFormViewModel Carregar(bool atender)
        {
            var listaUf = _cidadeServico.ObterTodosEstados();
            var viewDinamicaModel = _viewDinamicaAppServico.Carregar("PESSOASJUR", "padrão", null, null, true);
            var listaCanalDeEnvio = _entidadeCampoValorServico.ObterPor("pessoasJuridicas", "canalEntidadesCamposValoresID", true, null);
            var listaTipo = _entidadeCampoValorServico.ObterPor("pessoasJuridicas", "tipoEntidadesCamposValoresID", true, null);
            return new PessoaJuridicaFormViewModel(listaUf, atender, viewDinamicaModel, listaCanalDeEnvio, listaTipo);
        }

        public PessoaJuridicaFormViewModel Salvar(PessoaJuridicaFormViewModel model, string usuarioId)
        {
            var pessoaJuridica = PessoaJuridicaAdaptador.ParaDominioModelo(model);
            var resultado = _pessoaJuridicaServico.Adicionar(pessoaJuridica);

            if (!resultado.ValidationResult.IsValid)
            {
                model.ValidationResult = resultado.ValidationResult;
                return model;
            }

            if (model.TelefoneLista != null)
                if (model.TelefoneLista.Any())
                {
                    var telefones = _telefoneServico.ObterTelefoneCliente(null, resultado.Id, null);

                    foreach (var item in model.TelefoneLista)
                    {
                        var tel = telefones.FirstOrDefault(c => c.Ddd == item.DDD && c.Numero == item.numero);
                        if (tel != null) continue;
                        var telefone = new Telefone(item.DDD, item.numero, model.CriadoPor, null, resultado.Id,
                            item.TelefonesTiposID, null);
                        _telefoneServico.Adicionar(telefone);
                    }
                }

            //model = PessoaJuridicaAdaptador.ParaAplicacaoViewModel(resultado);
            model.Id = pessoaJuridica.Id;

            if (model.ViewDinamica == null) return model;

            model.ViewDinamica.ChaveEntidadeId = pessoaJuridica.Id;
            _viewDinamicaAppServico.Atualizar(model.ViewDinamica,usuarioId);
            return model;
        }

        public IEnumerable<Cidade> ObterCidadesPorUf(string uf)
        {
            return _cidadeServico.ObterCidadesPorEstado(uf);
        }

        public PessoaJuridicaFormViewModel PessoaJuridicaPorId(long pessoaJuridicaId)
        {
            var cidadeModel = new CidadeViewModel();
            var telefone = new StringBuilder();
            long telmax;
            var entidade =
                _pessoaJuridicaServico.PesquisarPessoaJuridica("", "", "", pessoaJuridicaId, "").FirstOrDefault();

            if (entidade != null)
            {
                var listaUf = _cidadeServico.ObterTodosEstados();
                var listaCidade = _cidadeServico.ObterCidadesPorEstado(entidade.NomeEstado);
                var telefones = _telefoneServico.ObterTelefonePessoaJuridica(pessoaJuridicaId);
                var viewDinamicaModel = _viewDinamicaAppServico.Carregar("PESSOASJUR", "padrão", null, pessoaJuridicaId,
                    true);
                var listaCanalDeEnvio = _entidadeCampoValorServico.ObterPor("pessoasJuridicas",
                    "canalEntidadesCamposValoresID", true, null);
                var listaTipo = _entidadeCampoValorServico.ObterPor("pessoasJuridicas", "tipoEntidadesCamposValoresID",
                    true, null);

                if (telefones.Any())
                {
                    telmax = telefones.Max(c => c.Id);
                    var tel = telefones.FirstOrDefault(c => c.Id == telmax);
                    if (tel != null)
                    {
                        telefone.Append(tel.Ddd);
                        telefone.Append(tel.Numero);
                    }
                }

                if (entidade.CidadeId != null)
                {
                    var cidade = _cidadeServico.ObterPorId((long)entidade.CidadeId);
                    cidadeModel = new CidadeViewModel(cidade.Id, cidade.Nome, cidade.Uf);
                }

                return new PessoaJuridicaFormViewModel(entidade.Id, entidade.RazaoSocial, entidade.NomeFantasia,
                    entidade.InscricaoEstadual, entidade.Cnpj, entidade.DataDeConstituicao, listaUf, entidade.NomeEstado,
                    entidade.CidadeId, listaCidade, entidade.EmailPrincipal, entidade.Logradouro, entidade.Numero,
                    entidade.Bairro, entidade.CodigoPostal, entidade.Complemento, telefone.ToString(), viewDinamicaModel,
                    cidadeModel, entidade.CriadoEm, entidade.AlteradoEm, listaCanalDeEnvio, listaTipo,
                    entidade.AceitaComunicados, entidade.CanalEntidadesCamposValoresId,
                    entidade.TipoEntidadesCamposValoresId);
            }

            var validacaoRetorno = new ValidationResult();
            validacaoRetorno.Add(new ValidationError("Nenhum cliente encontrado com os parâmetros informados."));
            return new PessoaJuridicaFormViewModel { ValidationResult = validacaoRetorno };
        }

        public PessoaJuridicaFormViewModel Atualizar(PessoaJuridicaFormViewModel model, string userId)
        {
            model.AlteradoPorUserId = userId;
            var pessoaJuridica = PessoaJuridicaAdaptador.ParaDominioModelo(model);
            pessoaJuridica.AlteradoPorUserId = userId;

            var resultado = _pessoaJuridicaServico.Editar(pessoaJuridica);

            if (!resultado.ValidationResult.IsValid)
            {
                model.ValidationResult = resultado.ValidationResult;
                return model;
            }

            if (model.TelefoneLista == null) return model;

            if (model.TelefoneLista.Any())
            {
                var telefones = _telefoneServico.ObterTelefoneCliente(null, resultado.Id, null);

                foreach (var item in model.TelefoneLista)
                {
                    var tel = telefones.FirstOrDefault(c => c.Ddd == item.DDD && c.Numero == item.numero);
                    if (tel != null) continue;

                    var telefone = new Telefone(item.DDD, item.numero, userId, null, pessoaJuridica.Id,
                        item.TelefonesTiposID, null);
                    _telefoneServico.Adicionar(telefone);
                }
            }

            if (model.ViewDinamica == null) return model;

            model.ViewDinamica.ChaveEntidadeId = pessoaJuridica.Id;
            _viewDinamicaAppServico.Atualizar(model.ViewDinamica, userId);
            return model;
        }

        IEnumerable<PessoaJuridica> IPessoaJuridicaAppServico.PesquisarPessoaJuridica(string razaoSocial,
            string documento, string telefone, long? pessoaJuridicaId, string protocolo)
        {
            return _pessoaJuridicaServico.PesquisarPessoaJuridica(razaoSocial,
                documento.Replace(".", "").Replace("-", "").Replace("/", ""), telefone, pessoaJuridicaId, protocolo);
        }

        public SelectList ObterPor(long? tipoId, string letraBusca)
        {
            var lista = _pessoaJuridicaServico.ObterPor(tipoId, letraBusca);
            return new SelectList(lista, "id", "nomeFantasia");
        }
    }
}
