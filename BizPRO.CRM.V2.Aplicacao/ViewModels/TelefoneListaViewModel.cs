namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class TelefoneListaViewModel
    {
        public long? ID { get; set; }
        public long? PessoaFisicaID { get; set; }
        public long? PessoaJuridicaID { get; set; }
        public long? numero { get; set; }
        public int? DDD { get; set; }
        public int? TelefonesTiposID { get; set; }
        public string tipo { get; set; }
        public bool ativo { get; set; }
        public long? PotenciaisClientesID { get; set; }
        public int? Dddi { get; set; }

        public string TelefoneFormatado
        {
            get
            {
                return string.Format("({0}) {1} - {2}", (DDD != null ? DDD.ToString() : "0"),
                    (numero != null ? numero.ToString() : "Não Identificado"), tipo);
            }
        }

        public TelefoneListaViewModel()
        {

        }

        public TelefoneListaViewModel(long? id, long? pessoaFisicaId, long? pessoaJuridicaId, int? ddd, long? numero,
            string tipo, int? telefonesTiposId, long? potenciaisClientesId, int? ddi = null)
        {
            ID = id;
            PessoaFisicaID = pessoaFisicaId;
            PessoaJuridicaID = pessoaJuridicaId;
            DDD = ddd;
            this.numero = numero;
            this.tipo = tipo;
            TelefonesTiposID = telefonesTiposId;
            PotenciaisClientesID = potenciaisClientesId;
            Dddi = ddi;
        }

        public TelefoneListaViewModel(int? ddi, int? ddd, long? numero)
        {
            DDD = ddd;
            this.numero = numero;
            Dddi = ddi;
        }
    }
}
