using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class EmailTodosAnexosAppServico : IEmailTodosAnexosAppServico
    {

        private readonly IEmailServico _emailServico;
        private readonly IEmailAnexoServico _emailAnexoServico;
        private readonly IConfiguracaoServico _configuracaoServico;

        public EmailTodosAnexosAppServico(IEmailServico emailServico, IEmailAnexoServico emailAnexoServico,
            IConfiguracaoServico configuracaoServico)
        {
            _emailServico = emailServico;
            _emailAnexoServico = emailAnexoServico;
            _configuracaoServico = configuracaoServico;
        }


        public TodosAnexosViewModel TodosAnexos(long atividadeId)
        {
            var retorno = new TodosAnexosViewModel();

            try
            {


                var anexos = _emailAnexoServico.ObterAnexos(atividadeId).Where(c => c.ImagemCorpo == false);
                var mail = _emailServico.ObterEmailCompletoPor(null, atividadeId);
                var diretorio = _configuracaoServico.SetarUrlTodosAnexosEmail();
                var diretorioImagens = _configuracaoServico.BuscarDiretorioEmailAnexos();

                DirectoryInfo di = new DirectoryInfo(diretorio.Valor);

                if (!di.Exists)
                    di.Create();

                var arquivoZip = mail.Assunto.Replace("\"", "").Replace("\t", "").Replace(" ", "_")
                    .Replace("\\\\", "\\").Replace(":", "").Replace("*", "").Replace("|", "").Replace("?", "")
                    .Replace("<", "").Replace(">", "").Replace("/", "");
                ;
                string zipFile = string.Format("{0}\\{1}.zip", diretorio.Valor, arquivoZip);

                retorno.Arquivo = arquivoZip + ".zip";
                retorno.Diretorio = zipFile;
                retorno.Valido = true;

                //string extractPath = @"\\srvwsapp03\HOME_SHARED\aigbr.bizpro.com.br\crm\storageEmails\Entrada\2018\4\16\156cc586-38d6-4cf1-b324-3c364608a6fe";



                if (File.Exists(zipFile))
                    File.Delete(zipFile);

                using (var zipArchive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
                {
                    foreach (var item in anexos)
                    {
                        zipArchive.CreateEntryFromFile(diretorioImagens.Valor + item.Path, item.Nome,
                            CompressionLevel.Optimal);
                    }


                    //DirectoryInfo di = new DirectoryInfo(extractPath);
                    //FileInfo[] filesToArchive = di.GetFiles();

                    //if (filesToArchive != null && filesToArchive.Length > 0)
                    //{
                    //    foreach (FileInfo fileToArchive in filesToArchive)
                    //    {
                    //        zipArchive.CreateEntryFromFile(fileToArchive.FullName, fileToArchive.Name, CompressionLevel.Optimal);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                retorno.Valido = false;
            }

            return retorno;
        }
    }
}
