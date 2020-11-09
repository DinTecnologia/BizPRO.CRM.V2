using System.Collections.Generic;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class LocalOcorrenciaViewModel
    {
        public long? OcorrenciaId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? ContratoId { get; set; }
        public int? LocalId { get; set; }
        public long? EnderecoId { get; set; }
        public LocalViewModel Local { get; set; }
        public int? LocalTipoAtendimentoId { get; set; }
        public LocaTipoAtendimentoViewModel LocalTipoAtendimento { get; set; }
        public long? SegmentoId { get; set; }
        public string NomeSegmento { get; set; }
        public SelectList ListaEnderecosCadastrados { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public EnderecoProdutoViewModel EnderecoProdutoViewModel { get; set; }
        public SelectList ListaLocalTipoAtendimento { get; set; }
        public IEnumerable<LocalListaViewModel> ListaPesquisaLocal { get; set; }
        public SelectList ListaSegmentos { get; set; }

        public LocalOcorrenciaViewModel()
        {
            ValidationResult = new ValidationResult();
        }

        public LocalOcorrenciaViewModel(long? ocorrenciaId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? contratoId, IEnumerable<Endereco> enderecos)
        {
            OcorrenciaId = ocorrenciaId;
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            ContratoId = contratoId;
            ListaEnderecosCadastrados = new SelectList(enderecos, "valorCombo", "enderecoCompleto");
            ValidationResult = new ValidationResult();
        }

        public LocalOcorrenciaViewModel(AdicionarEnderecoProdutoViewModel model, string cidade, string estado,
            IEnumerable<CampoDinamicoOpcao> segmentos, long? segmentoId, double latitude, double longitude,
            List<LocalListaViewModel> listaLocal)
        {
            ValidationResult = new ValidationResult();
            EnderecoProdutoViewModel = new EnderecoProdutoViewModel(model, cidade, estado, null, null, latitude,
                longitude, null);
            ListaSegmentos = new SelectList(segmentos, "id", "nome");
            SegmentoId = segmentoId;
            ListaPesquisaLocal = listaLocal;
        }
    }
}
