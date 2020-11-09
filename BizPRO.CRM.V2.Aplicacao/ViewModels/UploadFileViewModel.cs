using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class UploadFileViewModel
    {
        public HttpPostedFile PostFile { get; set; }

        public string Name { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public string ID { get; set; }

        public string TamanhoAmigavel()
        {
            long bytes = 0;

            bytes = Length;

            if (bytes < 0) throw new ArgumentException("bytes");

            double humano;
            string sufixo;

            if (bytes >= 1152921504606846976L) // Exabyte (1024^6)
            {
                humano = bytes >> 50;
                sufixo = "EB";
            }
            else if (bytes >= 1125899906842624L) // Petabyte (1024^5)
            {
                humano = bytes >> 40;
                sufixo = "PB";
            }
            else if (bytes >= 1099511627776L) // Terabyte (1024^4)
            {
                humano = bytes >> 30;
                sufixo = "TB";
            }
            else if (bytes >= 1073741824) // Gigabyte (1024^3)
            {
                humano = bytes >> 20;
                sufixo = "GB";
            }
            else if (bytes >= 1048576) // Megabyte (1024^2)
            {
                humano = bytes >> 10;
                sufixo = "MB";
            }
            else if (bytes >= 1024) // Kilobyte (1024^1)
            {
                humano = bytes;
                sufixo = "KB";
            }
            else return "1 KB"; //bytes.ToString("0 B"); // Byte

            humano /= 1024;
            return humano.ToString("0.## ") + sufixo;
        }
    }
}

