using System.Text.RegularExpressions;

namespace BizPRO.CRM.V2.Core.ValueObjects
{
    public class EmailObjeto
    {
        public const int EnderecoMaxLength = 254;
        public const int EnderecoMinLength = 5;
        public string Endereco { get; private set; }


        protected EmailObjeto()
        {

        }

        public EmailObjeto(string endereco)
        {
            Endereco = endereco;
        }

        public static bool IsValid(string email)
        {
            var regexEmail =
                new Regex(
                    @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}