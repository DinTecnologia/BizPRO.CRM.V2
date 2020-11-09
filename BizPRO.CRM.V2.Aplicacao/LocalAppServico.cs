using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class LocalAppServico : ILocalAppServico
    {
        private readonly ILocalServico _servicoLocal;
        private readonly ICidadeServico _servicoCidade;
        private readonly IPessoaFisicaServico _servicoPessoaFisica;
        private readonly IPessoaJuridicaServico _servicoPessoaJuridica;
        private readonly IEnderecoServico _servicoEndereco;
        private readonly ICampoDinamicoOpcaoServico _servicoCampoDinamicoOpcao;
        private readonly ICampoDinamicoPreenchidoServico _servicoCampodDinamicoPreenchido;
        private readonly ILocalTipoServico _servicoLocalTipo;
        private readonly ILocalTipoAtendimentoServico _servicoLocalAtendimentoTipo;
        private readonly IConfiguracaoServico _configuracaoServico;
        string _chaveGoogleApi;


        public LocalAppServico(ILocalServico servicoLocal, ICidadeServico servicoCidade,
            IPessoaFisicaServico servicoPessoaFisica, IPessoaJuridicaServico servicoPessoaJuridica,
            IEnderecoServico servicoEndereco,
            ICampoDinamicoOpcaoServico servicoCampoDinamicoOpcao,
            ICampoDinamicoPreenchidoServico servicoCampodDinamicoPreenchido, ILocalTipoServico servicoLocalTipo,
            ILocalTipoAtendimentoServico servicoLocalAtendimentoTipo
            , IConfiguracaoServico configuracaoServico)
        {
            _servicoLocal = servicoLocal;
            _servicoCidade = servicoCidade;
            _servicoPessoaFisica = servicoPessoaFisica;
            _servicoPessoaJuridica = servicoPessoaJuridica;
            _servicoEndereco = servicoEndereco;
            _servicoCampoDinamicoOpcao = servicoCampoDinamicoOpcao;
            _servicoCampodDinamicoPreenchido = servicoCampodDinamicoPreenchido;
            _servicoLocalTipo = servicoLocalTipo;
            _servicoLocalAtendimentoTipo = servicoLocalAtendimentoTipo;
            _configuracaoServico = configuracaoServico;
        }

        public LocalPesquisaViewModel Carregar()
        {
            return new LocalPesquisaViewModel();
        }

        public IEnumerable<Cidade> ObterCidadesPorUf(string uf)
        {
            return _servicoCidade.ObterCidadesPorEstado(uf);
        }

        public SelecionarEnderecoViewModel SelecionarEndereco(long? ocorrenciaId, long? pessoaFisicaId,
            long? pessoaJuridicaId, long? contratoId)
        {
            return new SelecionarEnderecoViewModel(ocorrenciaId, pessoaFisicaId, pessoaJuridicaId,
                _servicoEndereco.ObterEnderecosProduto(ocorrenciaId, pessoaFisicaId, pessoaJuridicaId), contratoId);
        }

        private bool Chave()
        {
            var retorno = _configuracaoServico.ObterPorSigla("KEYGO");

            if (retorno.ValidationResult.IsValid)
                _chaveGoogleApi = retorno.Valor;
            else
                foreach (var erro in retorno.ValidationResult.Erros)
                {

                    _chaveGoogleApi += erro.Message + ' ';
                }

            return retorno.ValidationResult.IsValid;
        }

        public LocalOcorrenciaViewModel AdicionarEnderecoProduto(AdicionarEnderecoProdutoViewModel model)
        {
            var retorno = new LocalOcorrenciaViewModel();
            var segmentos = _servicoCampoDinamicoOpcao.ObterPor("CTRPRODUT", "Padrão", "DL", "Segmento");
            long? segmentoId = null;
            string cidade = "", estado = "";
            //double latitude, longitude;
            var locaisLista = new List<LocalListaViewModel>();

            var chaveGoogleApi = Chave();
            if (!chaveGoogleApi)
            {
                retorno.ValidationResult.Add(new ValidationError(_chaveGoogleApi));
                return retorno;
            }

            if (model.ContratoID != null)
            {
                var valorPreenchido = _servicoCampodDinamicoPreenchido.ObterCampoDinamicoPreenchido("CTRPRODUT",
                    "Padrão", "Segmento", (long) model.ContratoID);
                if (valorPreenchido != null)
                    segmentoId = valorPreenchido.CamposDinamicosOpcoesId;
            }

            if (model.CidadeId != null)
            {
                var Cidade = _servicoCidade.ObterPorId((long) model.CidadeId);
                if (Cidade != null)
                {
                    cidade = Cidade.Nome;
                    estado = Cidade.Uf;
                }
            }

            var retornoEnderecoGoogleApi = GoogleAPI.ObterLatitudeLongitudePorEndereco(_chaveGoogleApi, model.Cep,
                model.Logradouro,
                model.Numero, model.Bairro, cidade, estado);

            //latitude = GoogleAPI.ObterLatitudeLongitudePorEndereco(_chaveGoogleApi, model.Cep, model.Logradouro,
            //    model.Numero, model.Bairro, cidade, estado, out longitude);


            if (retornoEnderecoGoogleApi.ValidationResult.IsValid && retornoEnderecoGoogleApi.Enderecos.Any())
            {
                if (segmentoId != null)
                {
                    var segmento = _servicoCampoDinamicoOpcao.ObterPorId((long) segmentoId);

                    if (segmento != null)
                    {
                        var locais = _servicoLocal.Pesquisar(segmento.Nome,
                            retornoEnderecoGoogleApi.Enderecos.FirstOrDefault().Latidude.Value,
                            retornoEnderecoGoogleApi.Enderecos.FirstOrDefault().Latidude.Value);

                        if (locais != null)
                            foreach (var local in locais)
                            {
                                locaisLista.Add(new LocalListaViewModel(local));
                            }
                    }
                }

                retorno.EnderecoProdutoViewModel = new EnderecoProdutoViewModel(model, cidade, estado, segmentos,
                    segmentoId,
                    retornoEnderecoGoogleApi.Enderecos.FirstOrDefault().Latidude.Value,
                    retornoEnderecoGoogleApi.Enderecos.FirstOrDefault().Longitude.Value, locaisLista);

                retorno.ListaSegmentos = new SelectList(segmentos, "id", "nome");
                retorno.SegmentoId = segmentoId;
            }
            else
            {
                retorno.ValidationResult = retornoEnderecoGoogleApi.ValidationResult;
            }

            return retorno;
        }

        public LocalOcorrenciaViewModel CarregarSelecionarLocal(int? segmentoId, double latitude, double longitude,
            string enderecoProduto)
        {
            var retorno = new LocalOcorrenciaViewModel();
            var segmentos = _servicoCampoDinamicoOpcao.ObterPor("CTRPRODUT", "Padrão", "DL", "Segmento");

            var locaisLista = new List<LocalListaViewModel>();

            if (segmentoId != null)
            {
                var segmento = _servicoCampoDinamicoOpcao.ObterPorId((long) segmentoId);

                if (segmento != null)
                {
                    var locais = _servicoLocal.Pesquisar(segmento.Nome, latitude, longitude);

                    if (locais != null)
                        locaisLista.AddRange(locais.Select(local => new LocalListaViewModel(local)));
                }
            }

            retorno.EnderecoProdutoViewModel = new EnderecoProdutoViewModel {EnderecoProduto = enderecoProduto};
            retorno.ListaSegmentos = new SelectList(segmentos, "id", "nome");
            retorno.SegmentoId = segmentoId;
            retorno.ListaPesquisaLocal = locaisLista;
            return retorno;
        }

        public EnderecoProdutoViewModel Pesquisar(EnderecoProdutoViewModel model)
        {
            model.ListaPesquisaLocal = new List<LocalListaViewModel>();

            if (model.SegmentoID == null) return model;

            var segmento = _servicoCampoDinamicoOpcao.ObterPorId((long) model.SegmentoID);

            if (segmento == null) return model;

            var locais = _servicoLocal.Pesquisar(segmento.Nome, (double) model.Latitude,
                (double) model.Longitude);
            var locaisLista = new List<LocalListaViewModel>();
            if (locais != null)
                locaisLista.AddRange(locais.Select(local => new LocalListaViewModel(local)));
            model.ListaPesquisaLocal = locaisLista;
            return model;
        }

        public EnderecoProdutoViewModel ObterLocalTiposAtendimento(EnderecoProdutoViewModel model)
        {
            //Mudar
            if (model.LocalID == null) return model;
            var local = _servicoLocal.ObterPorId((long) model.LocalID);
            model.EnderecoLocal = local.nome.ToUpper();
            model.LocalTipoAtendimento = new LocaTipoAtendimentoViewModel(local.id,
                _servicoLocalAtendimentoTipo.ObterLocalTiposAtendimentoPorLocalId(local.id));

            return model;
        }

        public LocalOcorrenciaViewModel Carregar(long? ocorrenciaId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? contratoId)
        {
            //Carregando todos os endereços previamentes cadastrados para produtos do mesmo cliente.
            var enderecosProduto = _servicoEndereco.ObterEnderecosProduto(ocorrenciaId, pessoaFisicaId, pessoaJuridicaId);
            return new LocalOcorrenciaViewModel(ocorrenciaId, pessoaFisicaId, pessoaJuridicaId, contratoId,
                enderecosProduto);
        }

        public AdicionarEnderecoProdutoViewModel NovoEnderecoProduto()
        {
            var estados = _servicoCidade.ObterTodosEstados();
            return new AdicionarEnderecoProdutoViewModel(estados);
        }

        public LocalOcorrenciaViewModel ObterLocalTiposAtendimento(long localId, string enderecoProduto,
            string nomeSegmento)
        {
            var local = _servicoLocal.ObterPorId(localId);
            var listaLocalTipoAtendimento = _servicoLocalAtendimentoTipo.ObterLocalTiposAtendimentoPorLocalId(localId);
            var retorno = new LocalOcorrenciaViewModel
            {
                EnderecoProdutoViewModel = new EnderecoProdutoViewModel {EnderecoProduto = enderecoProduto},
                NomeSegmento = nomeSegmento,
                ListaLocalTipoAtendimento = new SelectList(listaLocalTipoAtendimento, "id", "nome"),
                Local = new LocalViewModel(local.nome, local.nomeContato, "", local.logradouro, local.numero,
                    local.bairro, local.cidade, local.estado, local.cep, local.latitude, local.longitude,
                    local.telefone01,
                    local.telefone02, local.telefone03, local.email01, local.email02, local.webSite, null, null)
            };

            return retorno;
        }

        public LocalViewModel CarregarPerfil(long localId, long localAtendimentoId, string nomeTipoAtendimento,
            string enderecoProduto, long? segmentoId)
        {
            var local = _servicoLocal.ObterPorId(localId);
            var cidade = _servicoCidade.ObterPorId(local.cidadesID);
            var localTipo = _servicoLocalTipo.ObterPorId(local.locaisTiposID);

            if (cidade == null)
                cidade = new Cidade();

            var retorno = new LocalViewModel(local.nome, local.nomeContato, localTipo.Nome, local.logradouro,
                local.numero, local.bairro, cidade.Nome, cidade.Uf, local.cep, local.latitude, local.longitude,
                local.telefone01, local.telefone02, local.telefone03, local.email01, local.email02, local.webSite,
                localAtendimentoId, enderecoProduto);

            if (segmentoId != null)
            {
                var segmento = _servicoCampoDinamicoOpcao.ObterPorId((long) segmentoId);

                if (segmento != null)
                {
                    retorno.NomeSegmento = segmento.Nome;
                }
            }

            retorno.NomeTipoAtendimento = nomeTipoAtendimento;
            retorno.EnderecoProduto = enderecoProduto;
            return retorno;
        }

        public LocalOcorrenciaViewModel ObterEnderecoEntidadeSelecionada(EnderecoProdutoViewModel model)
        {
            var retorno = new LocalOcorrenciaViewModel();

            if (model.EnderecoID != null)
            {
                long entidadeId;
                var tipoEntidade = model.EnderecoID.Substring(0, 2);
                long.TryParse(model.EnderecoID.Substring(3, (model.EnderecoID.Length - 3)), out entidadeId);
                var segmentos = _servicoCampoDinamicoOpcao.ObterPor("CTRPRODUT", "Padrão", "DL", "Segmento");
                long? segmentoId = null;
                string cidade = "", estado = "";
                //double latitude, longitude;

                if (model.ContratoID != null)
                {
                    var valorPreenchido = _servicoCampodDinamicoPreenchido.ObterCampoDinamicoPreenchido("CTRPRODUT",
                        "Padrão", "Segmento", (long) model.ContratoID);
                    if (valorPreenchido != null)
                        segmentoId = valorPreenchido.CamposDinamicosOpcoesId;
                }

                retorno.SegmentoId = segmentoId;
                retorno.ListaSegmentos = new SelectList(segmentos, "id", "nome");

                var chaveGoogleApi = Chave();
                if (!chaveGoogleApi)
                {
                    retorno.ValidationResult.Add(new ValidationError(_chaveGoogleApi));
                    return retorno;
                }

                DadosEnderecoGoogle retornoEnderecoGoogleApi;
                switch (tipoEntidade.ToLower())
                {
                    case "pf":
                        var pessoaFisica = _servicoPessoaFisica.ObterPorId(entidadeId);
                        if (pessoaFisica.CidadeId != null)
                        {
                            var Cidade = _servicoCidade.ObterPorId((long) pessoaFisica.CidadeId);
                            if (Cidade != null)
                            {
                                cidade = Cidade.Nome;
                                estado = Cidade.Uf;
                            }
                        }

                        retornoEnderecoGoogleApi = GoogleAPI.ObterLatitudeLongitudePorEndereco(_chaveGoogleApi,
                            pessoaFisica.CodigoPostal, pessoaFisica.Logradouro, pessoaFisica.Numero, pessoaFisica.Bairro,
                            cidade, estado);

                        //latitude = GoogleAPI.ObterLatitudeLongitudePorEndereco(_chaveGoogleApi,
                        //    pessoaFisica.CodigoPostal, pessoaFisica.Logradouro, pessoaFisica.Numero, pessoaFisica.Bairro,
                        //    cidade, estado, out longitude);

                        if (retornoEnderecoGoogleApi.ValidationResult.IsValid &&
                            retornoEnderecoGoogleApi.Enderecos.Any())
                        {
                            retorno.EnderecoProdutoViewModel = new EnderecoProdutoViewModel(model, pessoaFisica, cidade,
                                estado, segmentos, segmentoId,
                                retornoEnderecoGoogleApi.Enderecos.FirstOrDefault().Latidude.Value,
                                retornoEnderecoGoogleApi.Enderecos.FirstOrDefault().Longitude.Value);
                        }
                        else
                        {
                            retorno.ValidationResult = retornoEnderecoGoogleApi.ValidationResult;
                        }

                        break;
                    case "pj":
                        var pessoaJuridica = _servicoPessoaJuridica.ObterPorId(entidadeId);
                        if (pessoaJuridica.CidadeId != null)
                        {
                            var Cidade = _servicoCidade.ObterPorId((long) pessoaJuridica.CidadeId);
                            if (Cidade != null)
                            {
                                cidade = Cidade.Nome;
                                estado = Cidade.Uf;
                            }
                        }

                        retornoEnderecoGoogleApi = GoogleAPI.ObterLatitudeLongitudePorEndereco(_chaveGoogleApi,
                            pessoaJuridica.CodigoPostal, pessoaJuridica.Logradouro, pessoaJuridica.Numero,
                            pessoaJuridica.Bairro, cidade, estado);

                        //latitude = GoogleAPI.ObterLatitudeLongitudePorEndereco(_chaveGoogleApi,
                        //    pessoaJuridica.CodigoPostal, pessoaJuridica.Logradouro, pessoaJuridica.Numero, pessoaJuridica.Bairro, cidade, estado, out longitude);

                        if (retornoEnderecoGoogleApi.ValidationResult.IsValid &&
                            retornoEnderecoGoogleApi.Enderecos.Any())
                        {
                            retorno.EnderecoProdutoViewModel = new EnderecoProdutoViewModel(model, pessoaJuridica,
                                cidade,
                                estado, segmentos, segmentoId,
                                retornoEnderecoGoogleApi.Enderecos.FirstOrDefault().Latidude.Value,
                                retornoEnderecoGoogleApi.Enderecos.FirstOrDefault().Longitude.Value);
                        }
                        else
                        {
                            retorno.ValidationResult = retornoEnderecoGoogleApi.ValidationResult;
                        }

                        break;
                }
            }

            return retorno;
        }
    }
}
