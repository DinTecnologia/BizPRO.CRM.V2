using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ContratoViewModel
    {
        public long ContratoId { get; set; }
        public string Numero { get; set; }
        public string Vigencia { get; set; }
        public string Status { get; set; }
        public string DatadeEncerramento { get; set; }
        public CampoDinamicoViewModel ViewDinamica { get; set; }

        public ContratoViewModel()
        {
            ViewDinamica = new CampoDinamicoViewModel();
        }

        //public ContratoViewModel(Contrato contrato, IEnumerable<Produto> listaProduto, StatusEntidade statusEntidade,
        //    CampoDinamicoViewModel viewDinamica)
        public ContratoViewModel(Contrato contrato, CampoDinamicoViewModel viewDinamica)
        {
            ContratoId = contrato.Id;
            Numero = contrato.NumeroContrato;
            Status = contrato.StatusEntidade != null ? contrato.StatusEntidade.nome : "--";
            Vigencia = (contrato.DataInicio.HasValue ? contrato.DataInicio.Value.ToString("dd/MM/yyyy") : "--") +
                       " até " +
                       (contrato.DataTermino.HasValue ? contrato.DataTermino.Value.ToString("dd/MM/yyy") : "--");
            DatadeEncerramento = "Informação não disponivel";
            //Status = statusEntidade.nome;
            ViewDinamica = viewDinamica;
        }
    }
}
