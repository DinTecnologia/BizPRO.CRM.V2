namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class OcorrenciaTiposXOcorrencia
    {

        public string decritivoDeAbertura { get; set; }
        public long contratoID { get; set; }
        public long pessoaFisicaID { get; set; }
        public long pessoaJuridicaID { get; set; }
        public string nome { get; set; }
        public string nomeExibicao { get; set; }
        public string numeroContrato { get; set; }
        public string apelido { get; set; }
    }
}
