using System;
using System.IO;

namespace BizPRO.CRM.V2.Core.Comum
{
    public static class Log
    {
        public static void ErrorLog(string nomeAplicacao, string diretorioLog, string mensagem)
        {
            var sLogFormat = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " ==> ";
            var sYear = DateTime.Now.Year.ToString();
            var sMonth = DateTime.Now.Month.ToString().PadLeft(2, '0');
            var sDay = DateTime.Now.Day.ToString().PadLeft(2, '0');
            var sErrorTime = sYear + sMonth + sDay;
            var dirAnexoDownloadArquivo = new DirectoryInfo(diretorioLog);

            if (!dirAnexoDownloadArquivo.Exists)
                dirAnexoDownloadArquivo.Create();

            var sw2 = new StreamWriter(string.Format("{0}{1}-{2}.{3}", diretorioLog, nomeAplicacao, sErrorTime, "txt"),
                true);
            sw2.WriteLine(sLogFormat + mensagem);
            sw2.Flush();
            sw2.Close();
        }
    }
}
