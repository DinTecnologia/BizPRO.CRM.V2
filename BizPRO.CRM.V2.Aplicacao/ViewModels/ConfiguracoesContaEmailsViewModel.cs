namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ConfiguracoesContaEmailsViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string ServidorPop { get; set; }
        public string ServidorSmtp { get; set; }
        public bool NecessarioSsl { get; set; }
        public string Email { get; set; }
        public string SenhaEmail { get; set; }
        public string UsuarioEmail { get; set; }
        public int? FilasId { get; set; }
        public bool ContaPadrao { get; set; }
        public string Assinatura { get; set; }

        public ConfiguracoesContaEmailsViewModel()
        {

        }

        public ConfiguracoesContaEmailsViewModel(int id, string descricao, string servidorPop, string servidorSmtp,
            bool necessarioSsl, string email, string senhaEmail, string usuarioEmail,
            int? filasId, bool contaPadrao)
        {
            Id = id;
            Descricao = descricao;
            ServidorPop = servidorPop;
            ServidorSmtp = servidorSmtp;
            NecessarioSsl = necessarioSsl;
            Email = email;
            SenhaEmail = senhaEmail;
            UsuarioEmail = usuarioEmail;
            FilasId = filasId;
            ContaPadrao = contaPadrao;
        }
    }
}