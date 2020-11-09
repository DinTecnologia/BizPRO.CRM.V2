using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ContratoListaViewModel
    {
        public long ContratoId { get; set; }
        public string Status { get; set; }
        public string Vigencia { get; set; }
        public string Apolice { get; set; }
        public string Produtos { get; set; }
        public string Apelido { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? AtendimentoId { get; set; }

        public string NomeCombo
        {
            get
            {
                var retorno = "";

                if (!string.IsNullOrEmpty(Apelido))
                    retorno = Apelido;

                if (!string.IsNullOrEmpty(Apolice))
                    retorno += string.Format(" ({0})", Apolice);

                return retorno;
            }
        }

        public ContratoListaViewModel(Contrato contrato, long? atendimentoId)
        {
            ContratoId = contrato.Id;
            PessoaFisicaId = contrato.ClientePessoaFisicaId;
            PessoaJuridicaId = contrato.ClientePessoaJuridicaId;
            AtendimentoId = atendimentoId;
            Status = contrato.StatusEntidade.nome;

            if (contrato.DataInicio.HasValue || contrato.DataTermino.HasValue)
                Vigencia = (contrato.DataInicio.HasValue
                               ? contrato.DataInicio.Value.ToString("dd/MM/yyyy")
                               : "Não Informado") + " até " +
                           (contrato.DataTermino.HasValue
                               ? contrato.DataTermino.Value.ToString("dd/MM/yyyy")
                               : "Não Informado");
            else
                Vigencia = "Não Informado";

            Apolice = contrato.NumeroContrato;
            Apelido = string.IsNullOrEmpty(contrato.Apelido) ? "--" : contrato.Apelido;

            if (contrato.Produtos == null) return;

            foreach (var produto in contrato.Produtos)
            {
                if (Produtos != null)
                    Produtos = Produtos + ", " + produto.nome;
                else
                    Produtos = produto.nome;
            }
        }
    }
}
