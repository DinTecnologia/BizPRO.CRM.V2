using BizPRO.CRM.V2.Core.Helpers;

namespace BizPRO.CRM.V2.Core.ValueObjects
{
    public class CnpjObjeto
    {
        public const int ValorMaxCpf = 14;
        public string Codigo { get; private set; }

        protected CnpjObjeto()
        {

        }

        public CnpjObjeto(string cpf)
        {
            Codigo = cpf;
        }

        public static string CnpjLimpo(string cnpj)
        {
            cnpj = TextoHelper.GetNumeros(cnpj);

            if (string.IsNullOrEmpty(cnpj))
                return "";

            while (cnpj.StartsWith("0"))
                cnpj = cnpj.Substring(1);

            return cnpj;
        }

        public string GetCpfCompleto()
        {
            var cnpj = Codigo;

            if (string.IsNullOrEmpty(cnpj))
                return "";

            while (cnpj.Length < 14)
                cnpj = "0" + cnpj;

            return cnpj;
        }

        public static bool Validar(string cnpj)
        {
            var multiplicador1 = new int[12] {5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};
            var multiplicador2 = new int[13] {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            var tempCnpj = cnpj.Substring(0, 12);

            var soma = 0;
            for (var i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            var resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (var i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto;
            return cnpj.EndsWith(digito);
        }
    }
}