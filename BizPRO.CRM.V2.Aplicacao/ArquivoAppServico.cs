using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ArquivoAppServico : IArquivoAppServico
    {
        private readonly IEntidadeServico _servicoEntidade;
        private readonly IArquivoServico _servicoArquivo;
        private readonly IConfiguracaoServico _configuracaoServico;
        private readonly IUsuarioServico _usuarioServico;

        public ArquivoAppServico(IEntidadeServico servicoEntidade, IArquivoServico servicoArquivo,
            IConfiguracaoServico configuracaoServico, IUsuarioServico usuarioServico)
        {
            _servicoEntidade = servicoEntidade;
            _servicoArquivo = servicoArquivo;
            _configuracaoServico = configuracaoServico;
            _usuarioServico = usuarioServico;
        }

        public ArquivoFormViewModel Novo(long? ocorrenciaId, long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            var model = new ArquivoFormViewModel();
            Entidade entidade = null;

            model.OcorrenciaId = ocorrenciaId;
            model.PessoaFisicaId = pessoaFisicaId;
            model.PessoaJuridicaId = pessoaJuridicaId;

            if (ocorrenciaId.HasValue)
            {
                entidade = _servicoEntidade.ObterPorNomeLogico("Ocorrencia");
                model.ChaveEntidadeId = (long) ocorrenciaId;
            }
            else if (pessoaFisicaId.HasValue)
            {
                entidade = _servicoEntidade.ObterPorNomeLogico("pessoasFisicas");
                model.ChaveEntidadeId = (long) pessoaFisicaId;
            }
            else if (pessoaJuridicaId.HasValue)
            {
                entidade = _servicoEntidade.ObterPorNomeLogico("pessoasJuridicas");
                model.ChaveEntidadeId = (long) pessoaJuridicaId;
            }

            if (entidade == null)
                model.ValidationResult.Add(
                    new DomainValidation.Validation.ValidationError(
                        "Entidade Não encontrada para os parametros informados"));
            else
                model.EntidadeId = entidade.Id;

            return model;
        }

        public ArquivoFormViewModel Adicionar(ArquivoFormViewModel model, string criadoPor)
        {
            if (string.IsNullOrEmpty(criadoPor))
            {
                var usuarioAdm = _usuarioServico.ObterPorEmail("sistemas@bizpro.com.br");
                criadoPor = usuarioAdm != null ? usuarioAdm.Id : "f712efbb-4646-4870-8f37-a687cb2e8978";
            }

            var arquivo = new Arquivo(model.Caminho, model.Nome, model.Tamanho, model.Extensao, criadoPor,
                model.ChaveEntidadeId, model.EntidadeId);
            model.ValidationResult = _servicoArquivo.Adicionar(arquivo);
            model.Id = arquivo.Id;
            return model;
        }

        public IEnumerable<ArquivoListaViewModel> ListarArquivos(long? ocorrenciaId, long? pessoaFisicaId,
            long? pessoaJuridicaId)
        {
            Entidade objEntidade = null;
            long chaveEntidadeId = 0;
            long entidadeId = 0;

            if (ocorrenciaId.HasValue)
            {
                objEntidade = _servicoEntidade.ObterPorNomeLogico("Ocorrencia");
                chaveEntidadeId = (long) ocorrenciaId;
            }
            else if (pessoaFisicaId.HasValue)
            {
                objEntidade = _servicoEntidade.ObterPorNomeLogico("pessoasFisicas");
                chaveEntidadeId = (long) pessoaFisicaId;
            }
            else if (pessoaJuridicaId.HasValue)
            {
                objEntidade = _servicoEntidade.ObterPorNomeLogico("pessoasJuridicas");
                chaveEntidadeId = (long) pessoaJuridicaId;
            }

            entidadeId = objEntidade.Id;
            var lista = _servicoArquivo.ObterPor(chaveEntidadeId, entidadeId);

            return (from arquivo in lista
                let criadoPor = _usuarioServico.ObterPorUserId(arquivo.CriadoPor)
                select
                new ArquivoListaViewModel(arquivo.Id, arquivo.Nome, arquivo.TamanhoAmigavel(), arquivo.CriadoEm,
                    criadoPor.Nome.ToUpper())).ToList();
        }

        public ArquivoFormViewModel AbrirArquivo(long id)
        {
            var arquivo = _servicoArquivo.ObterPorId(id);
            var entidade = _servicoEntidade.ObterPorId(arquivo.EntidadeId);
            Configuracao diretorio;


            switch (entidade.NomeLogico.ToLower().Trim())
            {
                case "chat":
                    diretorio = _configuracaoServico.ObterDiretorioArquivosChat();
                    break;
                    
                default:
                    diretorio = _configuracaoServico.BuscarDiretorioEmailAnexos();
                    break;
            }


            // Alterado aqui, porque quando era anexado um arquivo dentro de um ocorrência, o mesmo não abria por procurar a pasta de Chat    
            //var diretorio = entidade.Nome.Contains("email")
            //    ? _configuracaoServico.BuscarDiretorioEmailAnexos()
            //    : _configuracaoServico.ObterDiretorioArquivosChat();

            var diretorioArquivo = string.Format("{0}\\{1}", diretorio.Valor, arquivo.Caminho);
            return new ArquivoFormViewModel(arquivo.Nome, diretorioArquivo, arquivo.Tamanho, arquivo.Extensao,
                arquivo.ChaveEntidadeId, arquivo.EntidadeId, arquivo.ContentType());
        }
    }
}

