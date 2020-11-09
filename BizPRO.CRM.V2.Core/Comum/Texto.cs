using System;
using System.Text.RegularExpressions;

namespace BizPRO.CRM.V2.Core.Comum
{
    public static class TextoApoio
    {
        public static string PrimeiraMaiuscula(string texto)
        {
            var strResult = "";
            if (texto.Length <= 0) return strResult;
            strResult += texto.Substring(0, 1).ToUpper();
            strResult += texto.Substring(1, texto.Length - 1).ToLower();
            return strResult;
        }

        public static string PrimeiraMaiusculaTodasPalavras(string texto)
        {
            if (texto == null) throw new ArgumentNullException("texto");
            var strResult = "";
            var booPrimeira = true;
            if (texto.Length <= 0) return strResult;
            for (int intCont = 0; intCont <= texto.Length - 1; intCont++)
            {
                if ((booPrimeira) && (!texto.Substring(intCont, 1).Equals(" ")))
                {
                    strResult += texto.Substring(intCont, 1).ToUpper();
                    booPrimeira = false;
                }
                else
                {
                    strResult += texto.Substring(intCont, 1).ToLower();
                    if (texto.Substring(intCont, 1).Equals(" "))
                    {
                        booPrimeira = true;
                    }
                }
            }
            return strResult;
        }

        public static string SomenteNumeros(string texto)
        {
            var regexObj = new Regex(@"[^\d]");
            var resultString = regexObj.Replace(texto, "");
            return resultString;
        }
    }
}
