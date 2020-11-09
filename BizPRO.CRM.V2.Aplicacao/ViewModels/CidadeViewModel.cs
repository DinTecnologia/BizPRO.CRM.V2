namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class CidadeViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

        public CidadeViewModel()
        {

        }

        public CidadeViewModel( int id , string nome , string uf)
        {
            this.id = id;
            this.nome = nome;
            this.uf = uf;
        }
    }
}
