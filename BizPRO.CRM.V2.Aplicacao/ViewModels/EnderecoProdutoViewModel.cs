using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;
using ValidationResult = DomainValidation.Validation.ValidationResult;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class EnderecoProdutoViewModel
    {
        [Key]
        public long? ID { get; set; }
        public long? OcorrenciaID { get; set; }
        public int? LocalID { get; set; }
        public int? LocaisTiposAtendimentoID { get; set; }
        public long? PessoaFisicaID { get; set; }
        public long? PessoaJuridicaID { get; set; }
        public long? ContratoID { get; set; }
        public string EnderecoID { get; set; }
        public int? CidadeID { get; set; }
        public long? SegmentoID { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        public SelectList Segmentos { get; set; }

        public string EnderecoCompleto
        {
            get
            {
                if (string.IsNullOrEmpty(Complemento))
                    return string.Format("{0}, {1} - {2}, {3} - {4}, {5}",
                        string.IsNullOrEmpty(Logradouro) ? "" : Logradouro.ToUpper(),
                        string.IsNullOrEmpty(Numero) ? "" : Numero.ToUpper(),
                        string.IsNullOrEmpty(Bairro) ? "" : Bairro.ToUpper(),
                        string.IsNullOrEmpty(Cidade) ? "" : Cidade.ToUpper(),
                        string.IsNullOrEmpty(Estado) ? "" : Estado.ToUpper(),
                        string.IsNullOrEmpty(Cep) ? "" : Cep.ToUpper());
                return string.Format("{0}, {1} - {2}, {3} - {4}, {5}  - ({6})",
                    string.IsNullOrEmpty(Logradouro) ? "" : Logradouro.ToUpper(),
                    string.IsNullOrEmpty(Numero) ? "" : Numero.ToUpper(),
                    string.IsNullOrEmpty(Bairro) ? "" : Bairro.ToUpper(),
                    string.IsNullOrEmpty(Cidade) ? "" : Cidade.ToUpper(),
                    string.IsNullOrEmpty(Estado) ? "" : Estado.ToUpper(), string.IsNullOrEmpty(Cep) ? "" : Cep.ToUpper(),
                    Complemento);
            }
        }

        public SelectList ListaEnderecos { get; set; }
        public IEnumerable<LocalListaViewModel> ListaPesquisaLocal { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public LocaTipoAtendimentoViewModel LocalTipoAtendimento { get; set; }

        public string EnderecoProduto { get; set; }
        public string EnderecoLocal { get; set; }
        public string Complemento { get; set; }

        public EnderecoProdutoViewModel()
        {
            ValidationResult = new ValidationResult();
            Segmentos = new SelectList(new List<CampoDinamicoOpcao>(), "id", "nome");
        }

        public EnderecoProdutoViewModel(long? ocorrenciaId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? contratoId, IEnumerable<Endereco> enderecos)
        {
            ValidationResult = new ValidationResult();
            OcorrenciaID = ocorrenciaId;
            PessoaFisicaID = pessoaFisicaId;
            PessoaJuridicaID = pessoaJuridicaId;
            ListaEnderecos = new SelectList(enderecos, "valorCombo", "enderecoCompleto");
            ContratoID = contratoId;
        }

        public EnderecoProdutoViewModel(AdicionarEnderecoProdutoViewModel model, string cidade, string estado,
            IEnumerable<CampoDinamicoOpcao> segmentos, long? segmentoId, double latitude, double longitude,
            List<LocalListaViewModel> listaLocal)
        {
            ValidationResult = new ValidationResult();
            Logradouro = model.Logradouro;
            Cep = model.Cep;
            Numero = model.Numero;
            Bairro = model.Bairro;
            Cidade = cidade;
            Estado = estado;
            CidadeID = model.CidadeId;
            ContratoID = model.ContratoID;
            Segmentos = new SelectList(segmentos, "id", "nome");
            SegmentoID = segmentoId;
            Latitude = latitude;
            Longitude = longitude;
            ListaPesquisaLocal = listaLocal;
            Complemento = model.Complemento;

            try
            {
                EnderecoProduto = EnderecoCompleto;
            }
            catch
            {
            }
        }

        public EnderecoProdutoViewModel(EnderecoProdutoViewModel model, PessoaFisica pf, string cidade, string estado,
            IEnumerable<CampoDinamicoOpcao> segmentos, long? segmentoID, double latitude, double longitude)
        {
            ID = model.ID;
            OcorrenciaID = model.OcorrenciaID;
            LocalID = model.LocalID;
            LocaisTiposAtendimentoID = model.LocaisTiposAtendimentoID;
            PessoaFisicaID = model.PessoaFisicaID;
            PessoaJuridicaID = model.PessoaJuridicaID;
            ContratoID = model.ContratoID;
            EnderecoID = model.EnderecoID;
            CidadeID = model.CidadeID;
            SegmentoID = model.SegmentoID;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            Logradouro = pf.Logradouro;
            Cep = pf.CodigoPostal;
            Numero = pf.Numero;
            Bairro = pf.Bairro;
            Cidade = cidade;
            Estado = estado;
            CidadeID = pf.CidadeId;
            Segmentos = new SelectList(segmentos, "id", "nome");
            SegmentoID = segmentoID;
            Latitude = latitude;
            Longitude = longitude;
            ValidationResult = new ValidationResult();
            Complemento = model.Complemento;

            try
            {
                EnderecoProduto = EnderecoCompleto;
            }
            catch
            {
            }

        }

        public EnderecoProdutoViewModel(EnderecoProdutoViewModel model, PessoaJuridica pj, string cidade, string estado,
            IEnumerable<CampoDinamicoOpcao> segmentos, long? segmentoID, double latitude, double longitude)
        {
            ID = model.ID;
            OcorrenciaID = model.OcorrenciaID;
            LocalID = model.LocalID;
            LocaisTiposAtendimentoID = model.LocaisTiposAtendimentoID;
            PessoaFisicaID = model.PessoaFisicaID;
            PessoaJuridicaID = model.PessoaJuridicaID;
            ContratoID = model.ContratoID;
            EnderecoID = model.EnderecoID;
            CidadeID = model.CidadeID;
            SegmentoID = model.SegmentoID;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            Logradouro = pj.Logradouro;
            Cep = pj.CodigoPostal;
            Numero = pj.Numero;
            Bairro = pj.Bairro;
            Cidade = cidade;
            Estado = estado;
            CidadeID = pj.CidadeId;
            Segmentos = new SelectList(segmentos, "id", "nome");
            SegmentoID = segmentoID;
            Latitude = latitude;
            Longitude = longitude;
            ValidationResult = new ValidationResult();
            Complemento = model.Complemento;

            try
            {
                EnderecoProduto = EnderecoCompleto;
            }
            catch
            {
            }
        }

        public EnderecoProdutoViewModel(string logradouro, string numero, string cep, string bairro, string cidade,
            string estado, string complemento)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Complemento = complemento;
        }
    }
}
