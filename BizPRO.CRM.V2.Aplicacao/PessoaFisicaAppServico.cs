using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Aplicacao.Adaptadores;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class PessoaFisicaAppServico : IPessoaFisicaAppServico
    {
        readonly IPessoaFisicaServico _pessoaFisicaServico;
        readonly ICidadeServico _servicoCidade;
        readonly ITelefoneServico _servicoTelefone;
        readonly IViewDinamicaAppServico _viewDinamicaAppServico;
        readonly IEntidadeCampoValorServico _servicoEntidadeCampoValor;
        private readonly IIntegracaoControleServico _integracaoControleServico;

        public PessoaFisicaAppServico(IPessoaFisicaServico servicoPessoaFisisca, ICidadeServico servicoCidade,
            ITelefoneServico servicoTelefone, IViewDinamicaAppServico viewDinamicaAppServico,
            IEntidadeCampoValorServico servicoEntidadeCampoValor, IIntegracaoControleServico integracaoControleServico)
        {
            _pessoaFisicaServico = servicoPessoaFisisca;
            _servicoCidade = servicoCidade;
            _servicoTelefone = servicoTelefone;
            _viewDinamicaAppServico = viewDinamicaAppServico;
            _servicoEntidadeCampoValor = servicoEntidadeCampoValor;
            _integracaoControleServico = integracaoControleServico;
        }

        public PessoaFisicaFormViewModel Carregar(bool atender)
        {
            var listaUf = _servicoCidade.ObterTodosEstados();
            var viewDinamicaModel = _viewDinamicaAppServico.Carregar("PESSOASFIS", "padrão", null, null, true);
            var listaCanalDeEnvio = _servicoEntidadeCampoValor.ObterPor("pessoasFisicas",
                "canalEntidadesCamposValoresID", true, null);
            var listaTipo = _servicoEntidadeCampoValor.ObterPor("pessoasFisicas", "tipoEntidadesCamposValoresID", true,
                null);
            return new PessoaFisicaFormViewModel(listaUf, atender, viewDinamicaModel, listaCanalDeEnvio, listaTipo);
        }

        public PessoaFisicaFormViewModel Salvar(PessoaFisicaFormViewModel model, string usuarioId)
        {
            var pessoaFisica = PessoaFisicaAdaptador.ParaDominioModelo(model);
            var resultado = _pessoaFisicaServico.Adicionar(pessoaFisica);

            if (!resultado.ValidationResult.IsValid)
            {
                model.ValidationResult = resultado.ValidationResult;
                return model;
            }

            if (model.IdentificadorIntegracao.HasValue)
            {
                _integracaoControleServico.AtualizarIntegracaoControle(new IntegracaoControle()
                {
                    IdentificadorIntegracao = model.IdentificadorIntegracao.Value,
                    PessoaFisicaId = resultado.Id,
                    CriadoPor = model.CriadoPor
                });
            }

            if (model.TelefoneLista != null)
                if (model.TelefoneLista.Any())
                {
                    var telefones = _servicoTelefone.ObterTelefoneCliente(resultado.Id, null, null);

                    foreach (var item in model.TelefoneLista)
                    {
                        var tel = telefones.FirstOrDefault(c => c.Ddd == item.DDD && c.Numero == item.numero);
                        if (tel == null)
                        {
                            var telefone = new Telefone(item.DDD, item.numero, model.CriadoPor, resultado.Id, null,
                                item.TelefonesTiposID, null);
                            _servicoTelefone.Adicionar(telefone);

                            if (model.IdentificadorIntegracao.HasValue)
                            {
                                _integracaoControleServico.AtualizarIntegracaoControle(new IntegracaoControle()
                                {
                                    IdentificadorIntegracao = model.IdentificadorIntegracao.Value,
                                    TelefoneId = telefone.Id,
                                    CriadoPor = model.CriadoPor
                                });
                            }
                        }
                    }
                }

            if (model.ViewDinamica == null) return PessoaFisicaAdaptador.ParaAplicacaoViewModel(resultado);

            model.ViewDinamica.ChaveEntidadeId = resultado.Id;
            _viewDinamicaAppServico.Atualizar(model.ViewDinamica,usuarioId);

            return PessoaFisicaAdaptador.ParaAplicacaoViewModel(resultado);
        }

        public IEnumerable<PessoaFisica> PesquisarPessoaFisica(string nome, string documento, string telefone,
            long? pessoaFisicaId, string protocolo)
        {
            if (string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(documento) && string.IsNullOrEmpty(telefone) &&
                !pessoaFisicaId.HasValue && string.IsNullOrEmpty(protocolo))
            {
                return new List<PessoaFisica>();
            }

            return _pessoaFisicaServico.PesquisarPessoaFisica(nome, documento.Replace(".", "").Replace("-", ""),
                telefone, pessoaFisicaId, protocolo);
        }

        public PessoaFisicaFormViewModel PessoaFisicaPorId(long pessoaFisicaId)
        {
            var cidadeModel = new CidadeViewModel();
            var telefone = new StringBuilder();
            long telmax;
            var entidade = _pessoaFisicaServico.PesquisarPessoaFisica("", "", "", pessoaFisicaId, "").FirstOrDefault();

            if (entidade != null)
            {
                var listaUf = _servicoCidade.ObterTodosEstados();
                var listaCidade = _servicoCidade.ObterCidadesPorEstado(entidade.NomeEstado);
                var telefones = _servicoTelefone.ObterTelefonePessoaFisica(pessoaFisicaId);
                var viewDinamicaModel = _viewDinamicaAppServico.Carregar("PESSOASFIS", "padrão", null,
                    pessoaFisicaId, true);
                var listaCanalDeEnvio = _servicoEntidadeCampoValor.ObterPor("pessoasFisicas",
                    "canalEntidadesCamposValoresID", true, null);
                var listaTipo = _servicoEntidadeCampoValor.ObterPor("pessoasFisicas", "tipoEntidadesCamposValoresID",
                    true, null);

                if (telefones.Any())
                {
                    telmax = telefones.Max(c => c.Id);
                    var tel = telefones.FirstOrDefault(c => c.Id == telmax);
                    telefone.Append(tel.Ddd);
                    telefone.Append(tel.Numero);
                }

                if (entidade.CidadeId != null)
                {
                    var cidade = _servicoCidade.ObterPorId((long) entidade.CidadeId);
                    cidadeModel = new CidadeViewModel(cidade.Id, cidade.Nome, cidade.Uf);
                }

                return new PessoaFisicaFormViewModel(entidade.Id, entidade.Nome, entidade.Sobrenome, entidade.Cpf,
                    entidade.CpfProprio, entidade.DataNascimento, listaUf, entidade.NomeEstado, entidade.CidadeId,
                    listaCidade, entidade.Email, entidade.Logradouro, entidade.Numero, entidade.Bairro,
                    entidade.CodigoPostal, entidade.Complemento, telefone.ToString(), viewDinamicaModel, cidadeModel,
                    entidade.CriadoEm, entidade.AlteradoEm, listaCanalDeEnvio, listaTipo, entidade.AceitaComunicados,
                    entidade.CanalEntidadesCamposValoresId, entidade.TipoEntidadesCamposValoresId);
            }

            var validacaoRetorno = new ValidationResult();
            validacaoRetorno.Add(
                new ValidationError(
                    "Nenhum cliente encontrado com os parâmetros informados."));
            return new PessoaFisicaFormViewModel() {ValidationResult = validacaoRetorno};
        }

        public PessoaFisicaFormViewModel Atualizar(PessoaFisicaFormViewModel model, string userId)
        {
            model.AlteradoPorUserId = userId;
            var pessoaFisica = PessoaFisicaAdaptador.ParaDominioModelo(model);
            pessoaFisica.AlteradoPorUserId = userId;

            var resultado = _pessoaFisicaServico.Editar(pessoaFisica);

            if (!resultado.ValidationResult.IsValid)
            {
                model.ValidationResult = resultado.ValidationResult;
                return model;
            }


            //Atualizando Integração Controle
            if (model.IdentificadorIntegracao.HasValue)
            {
                _integracaoControleServico.AtualizarIntegracaoControle(new IntegracaoControle()
                {
                    IdentificadorIntegracao = model.IdentificadorIntegracao.Value,
                    PessoaFisicaId = resultado.Id,
                    CriadoPor = model.CriadoPor
                });
            }


            if (model.TelefoneLista != null)
                if (model.TelefoneLista.Any())
                {
                    var telefones = _servicoTelefone.ObterTelefoneCliente(resultado.Id, null, null);

                    foreach (var item in model.TelefoneLista)
                    {
                        var tel = telefones.FirstOrDefault(c => c.Ddd == item.DDD && c.Numero == item.numero);
                        if (tel == null)
                        {
                            var telefone = new Telefone(item.DDD, item.numero, userId, resultado.Id, null,
                                item.TelefonesTiposID, null);
                            var retorno = _servicoTelefone.Adicionar(telefone);

                            if (retorno.IsValid)
                            {
                                //Atualizando Integração Controle
                                if (model.IdentificadorIntegracao.HasValue)
                                {
                                    _integracaoControleServico.AtualizarIntegracaoControle(new IntegracaoControle()
                                    {
                                        IdentificadorIntegracao = model.IdentificadorIntegracao.Value,
                                        TelefoneId = telefone.Id,
                                        CriadoPor = model.CriadoPor
                                    });
                                }   
                            }
                        }
                    }
                }

            if (model.ViewDinamica != null)
            {
                model.ViewDinamica.ChaveEntidadeId = pessoaFisica.Id;
                _viewDinamicaAppServico.Atualizar(model.ViewDinamica, userId);
            }
            return model;
        }

        //public long AdicionarClienteIntegracao(PessoaFisica model)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
