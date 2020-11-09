using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class LocalListaViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string Distancia { get; set; }
        public string Detalhe { get; set; }

        public LocalListaViewModel()
        {

        }

        public LocalListaViewModel(Local local)
        {
            if (local == null) return;

            Id = local.id;
            Nome = local.nome.ToUpper();
            Endereço = string.Format("{0}, {1} - {2}, {3} - {4}, {5}", local.logradouro, local.numero, local.bairro,
                local.cidade, local.estado, local.cep);
            Distancia = local.distancia != null
                ? string.Format("{0} KM", string.Format("{0:0.0}", local.distancia))
                : "";

            Detalhe = string.IsNullOrEmpty(local.Detalhe) ? null : local.Detalhe;
        }
    }
}
