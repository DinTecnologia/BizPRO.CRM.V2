using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Enums;

namespace BizPRO.CRM.V2.Aplicacao
{
    //public class IntegracaoAppServico : IIntegracaoAppServico
    //{
    //    private readonly IIntegracaoControleServico _integracaoControleServico;
    //    private readonly IPessoaJuridicaAppServico _pessoaJuridicaAppServico;
    //    private readonly IPessoaFisicaAppServico _pessoaFisicaAppServico;
    //    private readonly IConfiguracaoAppServico _configuracaoAppServico;
    //    private readonly ICidadeServico _cidadeServico;
    //    private readonly ICidadeServico _servicoCidade;
    //    readonly IEntidadeCampoValorServico _servicoEntidadeCampoValor;
    //    private readonly IPessoaFisicaServico _pessoaFisicaServico;

    //    public IntegracaoAppServico(IIntegracaoControleServico integracaoControleServico,
    //        IPessoaJuridicaAppServico pessoaJuridicaAppServico, IPessoaFisicaAppServico pessoaFisicaAppServico,
    //        IConfiguracaoAppServico configuracaoAppServico, ICidadeServico cidadeServico, ICidadeServico servicoCidade,
    //        IEntidadeCampoValorServico servicoEntidadeCampoValor, IPessoaFisicaServico pessoaFisicaServico)
    //    {
    //        _integracaoControleServico = integracaoControleServico;
    //        _pessoaJuridicaAppServico = pessoaJuridicaAppServico;
    //        _pessoaFisicaAppServico = pessoaFisicaAppServico;
    //        _configuracaoAppServico = configuracaoAppServico;
    //        _cidadeServico = cidadeServico;
    //        _servicoCidade = servicoCidade;
    //        _servicoEntidadeCampoValor = servicoEntidadeCampoValor;
    //        _pessoaFisicaServico = pessoaFisicaServico;
    //    }

    //    public ClienteIntegracaoBusca ObterClientesIntegracaoPor(string nome, string telefone, string documento,
    //        long? identificador, string criadoPor)
    //    {
    //        var clientesIntegracao = new ClienteIntegracaoBusca();
    //        var servico = new Integracao(criadoPor);

    //        if (!string.IsNullOrEmpty(nome))
    //        {
    //            var retornoClientesPorNome = servico.ObterClienteIntegracaoPorNome(null, nome);
    //            clientesIntegracao.PessoasFisicas.AddRange(retornoClientesPorNome.PessoasFisicas);
    //            clientesIntegracao.PessoasJuridicas.AddRange(retornoClientesPorNome.PessoasJuridicas);
    //        }

    //        if (!string.IsNullOrEmpty(telefone))
    //        {
    //            var retornoClientesPorTelefone = servico.ObterClienteIntegracaoPorTelefone(null, telefone);
    //            clientesIntegracao.PessoasFisicas.AddRange(retornoClientesPorTelefone.PessoasFisicas);
    //            clientesIntegracao.PessoasJuridicas.AddRange(retornoClientesPorTelefone.PessoasJuridicas);
    //        }

    //        if (!string.IsNullOrEmpty(documento))
    //        {
    //            try
    //            {
    //                documento = Regex.Replace(documento, @"[^0-9]+", "");
    //                //numero = string.Join("", Regex.Split(documento, @"[^\d]"));
    //            }
    //            catch (Exception e)
    //            {

    //            }

    //            var retornoClientesPorIdentificador = servico.ObterClienteIntegracaoPorIdentificador(null, documento);
    //            clientesIntegracao.PessoasFisicas.AddRange(retornoClientesPorIdentificador.PessoasFisicas);
    //            clientesIntegracao.PessoasJuridicas.AddRange(retornoClientesPorIdentificador.PessoasJuridicas);
    //        }

    //        var clientesJaIntegrados = _integracaoControleServico.ObterClientesJaIntegrados(null);
    //        var listaLimpa = new ClienteIntegracaoBusca();
    //        var adicionarCliente = false;


    //        //PF
    //        foreach (var pfIntegracao in clientesIntegracao.PessoasFisicas)
    //        {
    //            foreach (var clienteJaIntegrado in clientesJaIntegrados.Where(x => x.PessoaFisicaId != null))
    //            {
    //                adicionarCliente = true;

    //                if (pfIntegracao.IdentificadorIntegracao.Value == clienteJaIntegrado.IdentificadorIntegracao)
    //                    adicionarCliente = false;

    //                if (adicionarCliente)
    //                    listaLimpa.PessoasFisicas.Add(pfIntegracao);
    //            }
    //        }


    //        //PJ
    //        foreach (var pjIntegracao in clientesIntegracao.PessoasJuridicas)
    //        {
    //            foreach (var clienteJaIntegrado in clientesJaIntegrados.Where(x => x.PessoaJuridicaId != null))
    //            {
    //                adicionarCliente = true;

    //                if (pjIntegracao.IdentificadorIntegracao.Value == clienteJaIntegrado.IdentificadorIntegracao)
    //                    adicionarCliente = false;

    //                if (adicionarCliente)
    //                    listaLimpa.PessoasJuridicas.Add(pjIntegracao);
    //            }
    //        }

    //        return clientesIntegracao;
    //    }

    //    public long ClienteIntegracaoSelecionado(string documento, long identificadorIntegracao, string criadoPor)
    //    {
    //        var servico = new Integracao(criadoPor);
    //        var importarClienteIntegracao = true;
    //        var retornoClientePorIdentificadorIntegracao = servico.ObterClienteIntegracaoPorIdentificador(null,
    //            documento);

    //        if (retornoClientePorIdentificadorIntegracao != null)
    //        {
    //            var enderecoClienteIntegracao = servico.ObterClienteEnderecoIntegracaoPorIdentificador(null,
    //                identificadorIntegracao);

    //            var emailsClienteIntegracao = servico.ObterClienteEmailsPorIdentificador(null,
    //                identificadorIntegracao);

    //            if (retornoClientePorIdentificadorIntegracao.PessoasFisicas != null)
    //            {
    //                var clienteIntegracao = retornoClientePorIdentificadorIntegracao.PessoasFisicas.FirstOrDefault();

    //                //Adicionar PessoaFisica
    //            }
    //        }


    //        if (importarClienteIntegracao)
    //        {
    //            //Aqui precisa fazer toda a importação do cliente
    //        }

    //        return 0;
    //    }

    //    public ClienteIntegracaoViewModel AdicionarClienteIntegracao(string documento, long identificadorIntegracao,
    //        string criadoPor)
    //    {
    //        var retorno = new ClienteIntegracaoViewModel();
    //        var servico = new Integracao(criadoPor);
    //        var retornoClientePorIdentificadorIntegracao = servico.ObterClienteIntegracaoPorIdentificador(null,
    //            documento);

    //        if (retornoClientePorIdentificadorIntegracao == null)
    //        {
    //            retorno.ValidationResult.Add(
    //                new ValidationError("Não foi possível retornar os dados do cliente pela integração"));
    //            return retorno;
    //        }

    //        var enderecoClienteIntegracao = servico.ObterClienteEnderecoIntegracaoPorIdentificador(null,
    //            identificadorIntegracao);

    //        var emailsClienteIntegracao = servico.ObterClienteEmailsPorIdentificador(null,
    //            identificadorIntegracao);

    //        var contratosClienteIntegracao =
    //            servico.ObterClienteContratosPorIdentificador(null, identificadorIntegracao);
    //        var telefonesClienteIntegracao =
    //            servico.ObterClienteTelefonesPorIdentificador(null, identificadorIntegracao);
    //        var telefonesCliente = new List<TelefoneListaViewModel>();

    //        if (telefonesClienteIntegracao.Any())
    //        {
    //            telefonesCliente.AddRange(from telefoneClienteIntegracao in telefonesClienteIntegracao
    //                where telefoneClienteIntegracao.Numero > 0
    //                select new TelefoneListaViewModel
    //                {
    //                    numero = telefoneClienteIntegracao.Numero,
    //                    DDD = telefoneClienteIntegracao.Ddd,
    //                    ativo = true,
    //                    TelefonesTiposID = Convert.ToInt32(TelefoneTipoEnum.Comercial)
    //                });
    //        }

    //        if (retornoClientePorIdentificadorIntegracao.PessoasFisicas.Any())
    //        {
    //            var pessoaFisicaIntegracao = retornoClientePorIdentificadorIntegracao.PessoasFisicas.FirstOrDefault();

    //            var pfModelView = new PessoaFisicaFormViewModel
    //            {
    //                CriadoPor = criadoPor,
    //                Nome = pessoaFisicaIntegracao.Nome,
    //                Sobrenome = pessoaFisicaIntegracao.Sobrenome,
    //                Cpf = pessoaFisicaIntegracao.Cpf,
    //                CpfProprio = true,
    //                DataNascimento = pessoaFisicaIntegracao.DataNascimento,
    //                IdentificadorIntegracao = pessoaFisicaIntegracao.IdentificadorIntegracao
    //            };

    //            if (emailsClienteIntegracao.Any())
    //            {
    //                pfModelView.Email = emailsClienteIntegracao.FirstOrDefault();
    //            }

    //            if (enderecoClienteIntegracao != null)
    //            {
    //                int? cidadeId = null;
    //                var cidade = _cidadeServico.ObterCidadesSemAcento(enderecoClienteIntegracao.Cidade);

    //                if (cidade.Any())
    //                    cidadeId = cidade.FirstOrDefault().Id;

    //                pfModelView.Logradouro = enderecoClienteIntegracao.Logradouro;
    //                pfModelView.Numero = enderecoClienteIntegracao.Numero;
    //                pfModelView.Bairro = enderecoClienteIntegracao.Bairro;
    //                pfModelView.Complemento = enderecoClienteIntegracao.Complemento;
    //                pfModelView.CodigoPostal = enderecoClienteIntegracao.Cep;
    //                pfModelView.CidadesId = cidadeId;
    //            }

    //            pfModelView.TelefoneLista = telefonesCliente;

    //            var retornoPessoaFisicaApp = _pessoaFisicaAppServico.Salvar(pfModelView, criadoPor);
    //            if (retornoPessoaFisicaApp.ValidationResult.IsValid)
    //            {
    //                retorno.PessoaFisicaId = retornoPessoaFisicaApp.Id;


    //                if (contratosClienteIntegracao.Any())
    //                {
    //                    foreach (var contratoIntegracao in contratosClienteIntegracao)
    //                    {
    //                        var produtosContratoIntegracao = servico.ObterProdutosContratoPorContratoIntegracaoId(null,
    //                            contratoIntegracao.ContratoIntegracaoId);

    //                        var produtoContratoIntegracao = new ProdutoContratoIntegracao();

    //                        if (produtosContratoIntegracao.Any())
    //                            produtoContratoIntegracao = produtosContratoIntegracao.FirstOrDefault();

    //                        try
    //                        {
    //                            var servicoIntegracaoDao = new Dao();

    //                            servicoIntegracaoDao.AdicionarDadosDeContratoProduto(retorno.PessoaFisicaId, null,
    //                                criadoPor, contratoIntegracao.TipoProduto, produtoContratoIntegracao.Codigo,
    //                                produtoContratoIntegracao.DescricaoItem, contratoIntegracao.Certificado,
    //                                contratoIntegracao.InicioVigencia, contratoIntegracao.FimVigencia,
    //                                contratoIntegracao.Premio, contratoIntegracao.Lmi, contratoIntegracao.DataAdesao,
    //                                contratoIntegracao.ContratoIntegracaoId, produtoContratoIntegracao.PequenoPorte,
    //                                produtoContratoIntegracao.Marca, contratoIntegracao.Status,
    //                                produtoContratoIntegracao.Nome, produtoContratoIntegracao.Segmento,
    //                                produtoContratoIntegracao.Cobertura, produtoContratoIntegracao.PlanoAxa);
    //                        }
    //                        catch (Exception ex)
    //                        {

    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                retorno.ValidationResult = retornoPessoaFisicaApp.ValidationResult;
    //            }

    //            return retorno;
    //        }

    //        if (retornoClientePorIdentificadorIntegracao.PessoasJuridicas.Any())
    //        {
    //            var pessoaJuridicaIntegracao =
    //                retornoClientePorIdentificadorIntegracao.PessoasJuridicas.FirstOrDefault();

    //            var pjModelView = new PessoaJuridicaFormViewModel
    //            {
    //                CriadoPor = criadoPor,
    //                RazaoSocial = pessoaJuridicaIntegracao.RazaoSocial,
    //                NomeFantasia = pessoaJuridicaIntegracao.NomeFantasia,
    //                Cnpj = pessoaJuridicaIntegracao.Cnpj,
    //                TelefoneLista = telefonesCliente,
    //                IdentificadorIntegracao = pessoaJuridicaIntegracao.IdentificadorIntegracao
    //            };

    //            if (enderecoClienteIntegracao != null)
    //            {
    //                int? cidadeId = null;
    //                var cidade = _cidadeServico.ObterCidadesSemAcento(enderecoClienteIntegracao.Cidade);

    //                if (cidade.Any())
    //                    cidadeId = cidade.FirstOrDefault().Id;

    //                pjModelView.Logradouro = enderecoClienteIntegracao.Logradouro;
    //                pjModelView.Numero = enderecoClienteIntegracao.Numero;
    //                pjModelView.Bairro = enderecoClienteIntegracao.Bairro;
    //                pjModelView.Complemento = enderecoClienteIntegracao.Complemento;
    //                pjModelView.CodigoPostal = enderecoClienteIntegracao.Cep;
    //                pjModelView.CidadesId = cidadeId;
    //            }

    //            if (emailsClienteIntegracao.Any())
    //            {
    //                pjModelView.EmailPrincipal = emailsClienteIntegracao.FirstOrDefault();
    //            }

    //            var retornoPessoaJuridicaApp = _pessoaJuridicaAppServico.Salvar(pjModelView, criadoPor);
    //            if (retornoPessoaJuridicaApp.ValidationResult.IsValid)
    //            {
    //                retorno.PessoaJuridicaId = retornoPessoaJuridicaApp.Id;
    //            }
    //            else
    //            {
    //                retorno.ValidationResult = retornoPessoaJuridicaApp.ValidationResult;
    //            }

    //            return retorno;
    //        }

    //        retorno.ValidationResult.Add(
    //            new ValidationError(
    //                "Não foi possível continuar a ação, o serviço de integração não retornou nenhum cliente"));

    //        return retorno;
    //    }

    //    public bool ConsultarIntegracao()
    //    {
    //        var retorno = false;
    //        var configuracaoIntegracao = _configuracaoAppServico.ObterPorSigla("INAXA");

    //        if (configuracaoIntegracao != null)
    //            if (configuracaoIntegracao.Valor == "True")
    //                retorno = true;

    //        return retorno;
    //    }

    //    public PessoaFisicaFormViewModel CarregarAbaClienteIntegracaoPf(string documento, long clienteId,
    //        string criadoPor)
    //    {
    //        var retorno = new PessoaFisicaFormViewModel();

    //        if (string.IsNullOrEmpty(documento))
    //        {
    //            var pf = _pessoaFisicaServico.ObterPorId(clienteId);
    //            documento = pf.Cpf;
    //        }

    //        var servico = new Integracao(criadoPor);
    //        var retornoClientePorIdentificadorIntegracao = servico.ObterClienteIntegracaoPorIdentificador(null,
    //            documento);

    //        if (retornoClientePorIdentificadorIntegracao == null)
    //        {
    //            retorno.ValidationResult.Add(
    //                new ValidationError("Não foi possível retornar os dados do cliente pela integração"));
    //            return retorno;
    //        }

    //        if (!retornoClientePorIdentificadorIntegracao.PessoasFisicas.Any())
    //        {
    //            retorno.ValidationResult.Add(
    //                new ValidationError("Não foi possível retornar os dados do cliente pela integração"));
    //            return retorno;
    //        }

    //        var pfclienteIntegracao = retornoClientePorIdentificadorIntegracao.PessoasFisicas.FirstOrDefault();

    //        var enderecoClienteIntegracao = servico.ObterClienteEnderecoIntegracaoPorIdentificador(null,
    //            pfclienteIntegracao.IdentificadorIntegracao.Value);


    //        CidadeViewModel cidadeModel = null;

    //        if (enderecoClienteIntegracao != null)
    //        {
    //            int? cidadeId = null;
    //            var cidades = _cidadeServico.ObterCidadesSemAcento(enderecoClienteIntegracao.Cidade);

    //            if (cidades.Any())
    //            {
    //                var cidade = cidades.FirstOrDefault();
    //                cidadeId = cidade.Id;
    //                pfclienteIntegracao.NomeEstado = cidade.Uf;

    //                cidadeModel = new CidadeViewModel(cidade.Id, cidade.Nome, cidade.Uf);
    //            }

    //            pfclienteIntegracao.Logradouro = enderecoClienteIntegracao.Logradouro;
    //            pfclienteIntegracao.Numero = enderecoClienteIntegracao.Numero;
    //            pfclienteIntegracao.Bairro = enderecoClienteIntegracao.Bairro;
    //            pfclienteIntegracao.Complemento = enderecoClienteIntegracao.Complemento;
    //            pfclienteIntegracao.CodigoPostal = enderecoClienteIntegracao.Cep;
    //            pfclienteIntegracao.CidadeId = cidadeId;
    //        }

    //        var emailsClienteIntegracao = servico.ObterClienteEmailsPorIdentificador(null,
    //            pfclienteIntegracao.IdentificadorIntegracao.Value);

    //        if (emailsClienteIntegracao.Any())
    //        {
    //            pfclienteIntegracao.Email = emailsClienteIntegracao.FirstOrDefault();
    //        }

    //        retorno = EntidadeParaViewModelPf(pfclienteIntegracao, cidadeModel);

    //        /// Por enquanto não vou carregar telefone do cliente PF
    //        var telefonesClienteIntegracao = servico.ObterClienteTelefonesPorIdentificador(null,
    //            pfclienteIntegracao.IdentificadorIntegracao.Value);

    //        if (telefonesClienteIntegracao.Any())
    //        {
    //            if (retorno.ListaTelefone == null)
    //                retorno.ListaTelefone = new List<TelefoneListaViewModel>();

    //            foreach (var telefone in telefonesClienteIntegracao)
    //            {
    //                ((List<TelefoneListaViewModel>) retorno.ListaTelefone).Add(
    //                    new TelefoneListaViewModel(telefone.Ddi,
    //                        telefone.Ddd, telefone.Numero));
    //            }
    //        }
    //        else
    //        {
    //            retorno.ListaTelefone = new List<TelefoneListaViewModel>();
    //        }

    //        var contratosClienteIntegracao = servico.ObterClienteContratosPorIdentificador(null,
    //            pfclienteIntegracao.IdentificadorIntegracao.Value);

    //        if (contratosClienteIntegracao != null && contratosClienteIntegracao.Any())
    //        {
    //            var dataUltimaIntegracao = _integracaoControleServico.ObterDataUltimaAtualizacaoContrato(clienteId);

    //            try
    //            {

    //                if (dataUltimaIntegracao == null ||
    //                    dataUltimaIntegracao.UltimaAtualizacaoEm < DateTime.Now.AddDays(-1))
    //                {
    //                    foreach (var contratoIntegracao in contratosClienteIntegracao)
    //                    {
    //                        var produtosContratoIntegracao = servico.ObterProdutosContratoPorContratoIntegracaoId(null,
    //                            contratoIntegracao.ContratoIntegracaoId);

    //                        var produtoContratoIntegracao = new ProdutoContratoIntegracao();

    //                        if (produtosContratoIntegracao.Any())
    //                            produtoContratoIntegracao = produtosContratoIntegracao.FirstOrDefault();

    //                        try
    //                        {
    //                            var servicoIntegracaoDao = new Dao();

    //                            servicoIntegracaoDao.AtualizarDadosDeContratoProduto(clienteId, null,
    //                                criadoPor, contratoIntegracao.TipoProduto, produtoContratoIntegracao.Codigo,
    //                                produtoContratoIntegracao.DescricaoItem, contratoIntegracao.Certificado,
    //                                contratoIntegracao.InicioVigencia, contratoIntegracao.FimVigencia,
    //                                contratoIntegracao.Premio, contratoIntegracao.Lmi, contratoIntegracao.DataAdesao,
    //                                contratoIntegracao.ContratoIntegracaoId, produtoContratoIntegracao.PequenoPorte,
    //                                produtoContratoIntegracao.Marca, contratoIntegracao.Status,
    //                                produtoContratoIntegracao.Nome, produtoContratoIntegracao.Segmento,
    //                                produtoContratoIntegracao.Cobertura, produtoContratoIntegracao.PlanoAxa);
    //                        }
    //                        catch (Exception ex)
    //                        {

    //                        }
    //                    }
    //                }
    //            }
    //            catch (Exception e)
    //            {

    //            }

    //            foreach (var contratoIntegracao in contratosClienteIntegracao)
    //            {
    //                var produtosContratoIntegracao = servico.ObterProdutosContratoPorContratoIntegracaoId(null,
    //                    contratoIntegracao.ContratoIntegracaoId);

    //                //var produtoContratoIntegracao = new ProdutoContratoIntegracao();

    //                var listaProdutos = new List<string>();

    //                if (produtosContratoIntegracao.Any())
    //                {
    //                    foreach (var produtoContrato in produtosContratoIntegracao)
    //                    {
    //                        listaProdutos.Add(produtoContrato.DescricaoItem);
    //                    }
    //                }

    //                if (retorno.ListaContratos == null)
    //                    retorno.ListaContratos = new List<ContratosIntegracaoViewModel>();

    //                ((List<ContratosIntegracaoViewModel>) retorno.ListaContratos).Add(
    //                    new ContratosIntegracaoViewModel(contratoIntegracao.Status, contratoIntegracao.InicioVigencia,
    //                        contratoIntegracao.FimVigencia, contratoIntegracao.Certificado, listaProdutos));
    //            }
    //        }

    //        if (retorno.ListaContratos == null)
    //            retorno.ListaContratos = new List<ContratosIntegracaoViewModel>();

    //        return retorno;
    //    }

    //    public PessoaJuridicaFormViewModel CarregarAbaClienteIntegracaoPj(string documento, long clienteId,
    //        string criadoPor)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    protected PessoaFisicaFormViewModel EntidadeParaViewModelPf(PessoaFisica entidade, CidadeViewModel cidadeModel)
    //    {
    //        var listaUf = _servicoCidade.ObterTodosEstados();
    //        var listaCidade = _servicoCidade.ObterCidadesPorEstado(entidade.NomeEstado);
    //        var listaCanalDeEnvio = _servicoEntidadeCampoValor.ObterPor("pessoasFisicas",
    //            "canalEntidadesCamposValoresID", true, null);
    //        var listaTipo = _servicoEntidadeCampoValor.ObterPor("pessoasFisicas", "tipoEntidadesCamposValoresID",
    //            true, null);

    //        return new PessoaFisicaFormViewModel(entidade.Id, entidade.Nome, entidade.Sobrenome, entidade.Cpf,
    //            entidade.CpfProprio, entidade.DataNascimento, listaUf, entidade.NomeEstado, entidade.CidadeId,
    //            listaCidade, entidade.Email, entidade.Logradouro, entidade.Numero, entidade.Bairro,
    //            entidade.CodigoPostal, entidade.Complemento, null, new CampoDinamicoViewModel(), cidadeModel,
    //            entidade.CriadoEm, entidade.AlteradoEm, listaCanalDeEnvio, listaTipo, entidade.AceitaComunicados,
    //            entidade.CanalEntidadesCamposValoresId, entidade.TipoEntidadesCamposValoresId);
    //    }

    //    public ClienteIntegracaoViewModel SincronizarClienteIntegracao(long? pessoaFisicaId, long? pessoaJuridicaId,
    //        string criadoPor)
    //    {
    //        var retorno = new ClienteIntegracaoViewModel();
    //        var documento = string.Empty;
    //        var tipoCliente = string.Empty;
    //        long identificadorIntegracao = 0;
    //        long id = 0;

    //        if (pessoaFisicaId.HasValue)
    //        {
    //            var pessoaFisica = _pessoaFisicaServico.ObterPorId(pessoaFisicaId.Value);

    //            if (pessoaFisica == null)
    //            {
    //                retorno.ValidationResult.Add(
    //                    new ValidationError("Nenhum registro de Pessoa Fisica foi retornado com o id: " +
    //                                        pessoaFisicaId.Value));
    //                return retorno;
    //            }

    //            tipoCliente = "PF";
    //            documento = Regex.Replace(pessoaFisica.Cpf, @"[^0-9]+", "");
    //            id = pessoaFisica.Id;
    //        }
    //        else if (pessoaJuridicaId.HasValue)
    //        {
    //            tipoCliente = "PJ";
    //            //Aqui entra pessoa Juridica
    //        }
    //        else
    //        {
    //            retorno.ValidationResult.Add(
    //                new ValidationError("Não foram informados o Id do cliente na base do CRM"));
    //            return retorno;
    //        }


    //        var servico = new Integracao(criadoPor);
    //        var retornoClientePorIdentificadorIntegracao = servico.ObterClienteIntegracaoPorIdentificador(null,
    //            documento);

    //        if (retornoClientePorIdentificadorIntegracao == null)
    //        {
    //            retorno.ValidationResult.Add(
    //                new ValidationError("Não foi possível retornar os dados do cliente pela integração"));
    //            return retorno;
    //        }

    //        identificadorIntegracao =
    //            tipoCliente == "PF"
    //                ? retornoClientePorIdentificadorIntegracao.PessoasFisicas.FirstOrDefault()
    //                    .IdentificadorIntegracao.Value
    //                : retornoClientePorIdentificadorIntegracao.PessoasJuridicas.FirstOrDefault()
    //                    .IdentificadorIntegracao.Value;


    //        var enderecoClienteIntegracao = servico.ObterClienteEnderecoIntegracaoPorIdentificador(null,
    //            identificadorIntegracao);

    //        var emailsClienteIntegracao = servico.ObterClienteEmailsPorIdentificador(null,
    //            identificadorIntegracao);

    //        var contratosClienteIntegracao =
    //            servico.ObterClienteContratosPorIdentificador(null, identificadorIntegracao);
    //        var telefonesClienteIntegracao =
    //            servico.ObterClienteTelefonesPorIdentificador(null, identificadorIntegracao);
    //        var telefonesCliente = new List<TelefoneListaViewModel>();

    //        if (telefonesClienteIntegracao.Any())
    //        {
    //            telefonesCliente.AddRange(from telefoneClienteIntegracao in telefonesClienteIntegracao
    //                where telefoneClienteIntegracao.Numero > 0
    //                select new TelefoneListaViewModel
    //                {
    //                    numero = telefoneClienteIntegracao.Numero,
    //                    DDD = telefoneClienteIntegracao.Ddd,
    //                    ativo = true,
    //                    TelefonesTiposID = Convert.ToInt32(TelefoneTipoEnum.Comercial)
    //                });
    //        }

    //        if (retornoClientePorIdentificadorIntegracao.PessoasFisicas.Any())
    //        {
    //            var pessoaFisicaIntegracao = retornoClientePorIdentificadorIntegracao.PessoasFisicas.FirstOrDefault();

    //            var pfModelView = new PessoaFisicaFormViewModel
    //            {
    //                Id = id,
    //                CriadoPor = criadoPor,
    //                Nome = pessoaFisicaIntegracao.Nome,
    //                Sobrenome = pessoaFisicaIntegracao.Sobrenome,
    //                Cpf = pessoaFisicaIntegracao.Cpf,
    //                CpfProprio = true,
    //                DataNascimento = pessoaFisicaIntegracao.DataNascimento,
    //                IdentificadorIntegracao = pessoaFisicaIntegracao.IdentificadorIntegracao
    //            };

    //            if (emailsClienteIntegracao.Any())
    //            {
    //                pfModelView.Email = emailsClienteIntegracao.FirstOrDefault();
    //            }

    //            if (enderecoClienteIntegracao != null)
    //            {
    //                int? cidadeId = null;
    //                var cidade = _cidadeServico.ObterCidadesSemAcento(enderecoClienteIntegracao.Cidade);

    //                if (cidade.Any())
    //                    cidadeId = cidade.FirstOrDefault().Id;

    //                pfModelView.Logradouro = enderecoClienteIntegracao.Logradouro;
    //                pfModelView.Numero = enderecoClienteIntegracao.Numero;
    //                pfModelView.Bairro = enderecoClienteIntegracao.Bairro;
    //                pfModelView.Complemento = enderecoClienteIntegracao.Complemento;
    //                pfModelView.CodigoPostal = enderecoClienteIntegracao.Cep;
    //                pfModelView.CidadesId = cidadeId;
    //            }

    //            pfModelView.TelefoneLista = telefonesCliente;

    //            var retornoPessoaFisicaApp = _pessoaFisicaAppServico.Atualizar(pfModelView, criadoPor);

    //            if (retornoPessoaFisicaApp.ValidationResult.IsValid)
    //            {
    //                retorno.PessoaFisicaId = retornoPessoaFisicaApp.Id;

    //                if (contratosClienteIntegracao.Any())
    //                {
    //                    foreach (var contratoIntegracao in contratosClienteIntegracao)
    //                    {
    //                        var produtosContratoIntegracao = servico.ObterProdutosContratoPorContratoIntegracaoId(null,
    //                            contratoIntegracao.ContratoIntegracaoId);

    //                        var produtoContratoIntegracao = new ProdutoContratoIntegracao();

    //                        if (produtosContratoIntegracao.Any())
    //                            produtoContratoIntegracao = produtosContratoIntegracao.FirstOrDefault();

    //                        try
    //                        {
    //                            var servicoIntegracaoDao = new Dao();

    //                            servicoIntegracaoDao.AtualizarDadosDeContratoProduto(retorno.PessoaFisicaId, null,
    //                                criadoPor, contratoIntegracao.TipoProduto, produtoContratoIntegracao.Codigo,
    //                                produtoContratoIntegracao.DescricaoItem, contratoIntegracao.Certificado,
    //                                contratoIntegracao.InicioVigencia, contratoIntegracao.FimVigencia,
    //                                contratoIntegracao.Premio, contratoIntegracao.Lmi, contratoIntegracao.DataAdesao,
    //                                contratoIntegracao.ContratoIntegracaoId, produtoContratoIntegracao.PequenoPorte,
    //                                produtoContratoIntegracao.Marca, contratoIntegracao.Status,
    //                                produtoContratoIntegracao.Nome, produtoContratoIntegracao.Segmento,
    //                                produtoContratoIntegracao.Cobertura, produtoContratoIntegracao.PlanoAxa);
    //                        }
    //                        catch (Exception ex)
    //                        {

    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                retorno.ValidationResult = retornoPessoaFisicaApp.ValidationResult;
    //            }

    //            return retorno;
    //        }

    //        if (retornoClientePorIdentificadorIntegracao.PessoasJuridicas.Any())
    //        {
    //            var pessoaJuridicaIntegracao =
    //                retornoClientePorIdentificadorIntegracao.PessoasJuridicas.FirstOrDefault();

    //            var pjModelView = new PessoaJuridicaFormViewModel
    //            {
    //                Id = id,
    //                CriadoPor = criadoPor,
    //                RazaoSocial = pessoaJuridicaIntegracao.RazaoSocial,
    //                NomeFantasia = pessoaJuridicaIntegracao.NomeFantasia,
    //                Cnpj = pessoaJuridicaIntegracao.Cnpj,
    //                TelefoneLista = telefonesCliente,
    //                IdentificadorIntegracao = pessoaJuridicaIntegracao.IdentificadorIntegracao
    //            };

    //            if (enderecoClienteIntegracao != null)
    //            {
    //                int? cidadeId = null;
    //                var cidade = _cidadeServico.ObterCidadesSemAcento(enderecoClienteIntegracao.Cidade);

    //                if (cidade.Any())
    //                    cidadeId = cidade.FirstOrDefault().Id;

    //                pjModelView.Logradouro = enderecoClienteIntegracao.Logradouro;
    //                pjModelView.Numero = enderecoClienteIntegracao.Numero;
    //                pjModelView.Bairro = enderecoClienteIntegracao.Bairro;
    //                pjModelView.Complemento = enderecoClienteIntegracao.Complemento;
    //                pjModelView.CodigoPostal = enderecoClienteIntegracao.Cep;
    //                pjModelView.CidadesId = cidadeId;
    //            }

    //            pjModelView.TelefoneLista = telefonesCliente;

    //            if (emailsClienteIntegracao.Any())
    //            {
    //                pjModelView.EmailPrincipal = emailsClienteIntegracao.FirstOrDefault();
    //            }

    //            var retornoPessoaJuridicaApp = _pessoaJuridicaAppServico.Salvar(pjModelView, criadoPor);
    //            if (retornoPessoaJuridicaApp.ValidationResult.IsValid)
    //            {
    //                retorno.PessoaJuridicaId = retornoPessoaJuridicaApp.Id;
    //            }
    //            else
    //            {
    //                retorno.ValidationResult = retornoPessoaJuridicaApp.ValidationResult;
    //            }

    //            return retorno;
    //        }

    //        retorno.ValidationResult.Add(
    //            new ValidationError(
    //                "Não foi possível continuar a ação, o serviço de integração não retornou nenhum cliente"));

    //        return retorno;
    //    }

    //    public DateTime? ObterDataUltimaIntegracao(long? pessoaFisicaId, long? pessoaJuridicaId, long? contratoId)
    //    {
    //        var ultimoControle = _integracaoControleServico.ObterUltimoControlePor(pessoaFisicaId, pessoaJuridicaId,
    //            contratoId);

    //        return ultimoControle != null
    //            ? _integracaoControleServico.ObterUltimoControlePor(pessoaFisicaId, pessoaJuridicaId, contratoId)
    //                .UltimaAtualizacaoEm
    //            : null;
    //    }
    //}
}
