using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ContatoViewModel
    {
        public string Tipo { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Status { get; set; }
        public string CriadoPor { get; set; }

        public ContatoViewModel()
        {

        }

        public ContatoViewModel(Atividade atividade)
        {
            Tipo = atividade.AtividadeTipo != null ? atividade.AtividadeTipo.Nome : "--";
            Data = atividade.CriadoEm.ToString("dd/MM/yyyy");
            Hora = atividade.CriadoEm.ToString("HH:mm");
            Status = atividade.StatusAtividade != null ? atividade.StatusAtividade.Descricao : "--";
            CriadoPor = atividade.Usuario != null ? atividade.Usuario.Nome : "--";
        }
    }
}
