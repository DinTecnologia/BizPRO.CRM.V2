using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AtividadeParteEnvolvida
    {
        public long Id { get; set; }
        public long AtividadesId { get; private set; }
        public long? PessoasFisicasId { get; private set; }
        public long? PessoasJuridicasId { get; private set; }
        public long? PotenciaisClientesId { get; private set; }
        public string AspNetUsersId { get; private set; }
        public string TipoParteEnvolvida { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public int? Ordem { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public AtividadeParteEnvolvida()
        {
            ValidationResult = new ValidationResult();
        }

        public AtividadeParteEnvolvida(long atividadeId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potenciaisClientesId, string aspNetUsersId, string tipoParteEnvolvida, string email, string nome)
        {
            AtividadesId = atividadeId;
            PessoasFisicasId = pessoaFisicaId;
            PessoasJuridicasId = pessoaJuridicaId;
            PotenciaisClientesId = potenciaisClientesId;
            AspNetUsersId = aspNetUsersId;
            TipoParteEnvolvida = tipoParteEnvolvida;
            ValidationResult = new ValidationResult();
            Email = email;
            Nome = nome;
        }

        public AtividadeParteEnvolvida(string email, string nome, string tipoParteEnvolvida)
        {
            Email = string.IsNullOrEmpty(email) ? "" : email.Replace(" ", "");
            Nome = nome;
            TipoParteEnvolvida = tipoParteEnvolvida;
        }

        public void SetarAtividadeId(long id)
        {
            AtividadesId = id;
        }

        public void SetarOrdem(int ordem)
        {
            Ordem = ordem;
        }

        public void SetarPessoaFisicaId(long? pessoaFisicaId)
        {
            PessoasFisicasId = pessoaFisicaId;
        }
        public void SetarPessoaJuridicaId(long? pessoaJuridicaId)
        {
            PessoasJuridicasId = pessoaJuridicaId;
        }
    }

    public class TipoParteEnvolvida
    {
        public string Value { get; set; }

        private TipoParteEnvolvida(string value)
        {
            Value = value;
        }

        public static TipoParteEnvolvida Remetente
        {
            get { return new TipoParteEnvolvida("R"); }
        }

        public static TipoParteEnvolvida Destinatario
        {
            get { return new TipoParteEnvolvida("D"); }
        }

        public static TipoParteEnvolvida DestinatarioCopia
        {
            get { return new TipoParteEnvolvida("DC"); }
        }

        public static TipoParteEnvolvida DestinatarioOculto
        {
            get { return new TipoParteEnvolvida("DO"); }
        }

        public static TipoParteEnvolvida ClienteContato
        {
            get { return new TipoParteEnvolvida("CC"); }
        }

        public static TipoParteEnvolvida ClienteTratado
        {
            get { return new TipoParteEnvolvida("CT"); }
        }

        public static TipoParteEnvolvida Agente
        {
            get { return new TipoParteEnvolvida("A"); }
        }
    }
}