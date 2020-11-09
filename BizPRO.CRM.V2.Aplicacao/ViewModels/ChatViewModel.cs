using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ChatViewModel
    {
        public long Id { get; set; }
        public long AtendimentoId { get; set; }
        public long AtividadeId { get; set; }
        public DateTime? criadoEm { get; set; }
        public string criadoPor { get; set; }
        public string alteradoPor { get; set; }
        public string alteradoEm { get; set; }
        public string conectorCodigo { get; set; }
        public string tipo { get; set; }
        public string sugestao { get; set; }
        //public Apoio apoio { get; set; }

        public List<ChatMensagemViewModel> ChatMsg { get; set; }
        public AtendimentoViewModel Atendimento { get; set; }
        public ClientePerfilViewModel Cliente { get; set; }
        public IEnumerable<StatusAtividade> ListaStatusAtividade { get; set; }
        public IEnumerable<ClienteListaViewModel> ListaPesquisaCliente { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public IEnumerable<OcorrenciaListaItemViewModel> ListaOcorrenciaCliente { get; set; }
        public long? pessoaFisicaID { get; set; }
        public long? pessoaJuridicaID { get; set; }
        public long? potencialClienteID { get; set; }
        public int? statusAtividadeID { get; set; }
        public bool atividadeFinalizada { get; set; }

        public bool? Finalizada { get; set; }

        public ChatViewModel()
        {
            ValidationResult = new ValidationResult();
            ListaPesquisaCliente = new List<ClienteListaViewModel>();
            ListaOcorrenciaCliente = new List<OcorrenciaListaItemViewModel>();
        }

        public ChatViewModel(long? atividadeid, long? id, long? atendimentoid, long? pj, long? pf, int? statusatividade)
        {
            ValidationResult = new ValidationResult();
            if (atividadeid != null) AtividadeId = (long) atividadeid;
            if (id != null) Id = (long) id;
            if (atendimentoid != null) AtendimentoId = (long) atendimentoid;
            pessoaJuridicaID = pj;
            pessoaFisicaID = pf;
            statusAtividadeID = statusatividade;
            sugestao = string.Empty;
        }

        public void Popular(IEnumerable<StatusAtividade> listaStatusAtividade,
            string numeroProtocolo, IEnumerable<Cliente> listaCliente, long? atendimentoId, long? pessoaFisicaId,
            long? pessoaJuridicaId, string Sugestao)
        {
            ListaStatusAtividade = listaStatusAtividade;
            if (atendimentoId != null)
                Atendimento = new AtendimentoViewModel(numeroProtocolo, (long) atendimentoId, "");
            var minhaLista = new List<ClienteListaViewModel>();

            if (listaCliente != null)
                minhaLista
                    .AddRange(listaCliente
                        .Select(
                            cliente => new ClienteListaViewModel
                            (
                                cliente.Id,
                                cliente.Nome,
                                cliente.TipoCliente,
                                cliente.Documento,
                                cliente.DataNascimento,
                                null,
                                false
                            )));
            ListaPesquisaCliente = minhaLista;

            sugestao = sugestao;
            pessoaFisicaID = pessoaFisicaId;
            pessoaJuridicaID = pessoaJuridicaId;
        }

        public string FormatarMsgAgenteCrm(string nome, string msg, string dataHora)
        {
            var sBuilder = new StringBuilder();
            var data = string.Format(@"{0:dd/MM/yyyy HH:mm:ss}", dataHora);
            sBuilder.AppendLine("<div class='bubble2'>");
            sBuilder.AppendLine("<span class='personName2'>");
            sBuilder.AppendLine(nome);
            sBuilder.AppendLine("</span>");
            sBuilder.AppendLine("<br/>");
            sBuilder.AppendLine("<span class='personSay2'>");
            if (msg.Contains("2|*Anexo"))
            {
                var id = msg.Substring(msg.LastIndexOf("|", StringComparison.Ordinal) + 1).Replace(";", "");
                var caminho = string.Empty;
                var nomeArquivo = string.Empty;

                if (msg.Split('|').Length > 2)
                {
                    caminho = msg.Split('|')[2].Replace(";", "");
                    nomeArquivo = caminho.Substring(caminho.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                    sBuilder.AppendLine("<a href='/Chat/DownloadFile?id=" + id + "'>");
                }
                else
                    sBuilder.AppendLine("<a href='/Chat/DownloadFile?id='0'>");
                //sBuilder.AppendLine("<a href='/Chat/ObterAnexo?id=" + msg.Split('|')[3].Replace(";", "") + "'>");
                //sBuilder.AppendLine("<a href='#' onclick='AbrirArquivo();' target='_blank'>");
                sBuilder.AppendLine("<i class='fa fa-file-text' aria-hidden='true'></i>");
                sBuilder.AppendLine(nomeArquivo);
                sBuilder.AppendLine("</a>");
            }
            else
                sBuilder.AppendLine(msg);
            sBuilder.AppendLine("<br/>");
            sBuilder.AppendLine("<span class='pull-right' style='font-size:7pt;color:gray;'>");
            sBuilder.AppendLine("<i>");
            sBuilder.AppendLine(data);
            sBuilder.AppendLine("</i>");
            sBuilder.AppendLine("</span>");
            sBuilder.AppendLine("</span>");
            sBuilder.AppendLine("</div>");
            return sBuilder.ToString();
        }

        public string FormatarMsgClienteCrm(string nome, string msg, string dataHora)
        {
            var sBuilder = new StringBuilder();
            var data = string.Format(@"{0:dd/MM/yyyy HH:mm:ss}", dataHora);
            sBuilder.AppendLine("<div class='bubble'>");
            sBuilder.AppendLine("<span class='personName'>");
            sBuilder.AppendLine(nome);
            sBuilder.AppendLine("</span>");
            sBuilder.AppendLine("<br/>");
            sBuilder.AppendLine("<span class='personSay'>");
            if (msg.Contains("2|*Anexo"))
            {
                var id = msg.Substring(msg.LastIndexOf("|", StringComparison.Ordinal) + 1).Replace(";", "");
                var caminho = string.Empty;
                var nomeArquivo = string.Empty;

                if (msg.Split('|').Length > 2)
                {
                    caminho = msg.Split('|')[2].Replace(";", "");
                    nomeArquivo = caminho.Substring(caminho.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                    sBuilder.AppendLine("<a href='/Chat/DownloadFile?id=" + id + "'>");
                }
                else
                    sBuilder.AppendLine("<a href='/Chat/DownloadFile?id='0'>");
                //sBuilder.AppendLine("<a href='/Chat/ObterAnexo?id=" + msg.Split('|')[3].Replace(";", "") + "'>");
                //sBuilder.AppendLine("<a href='#' onclick='AbrirArquivo();' target='_blank'>");
                sBuilder.AppendLine("<i class='fa fa-file-text' aria-hidden='true'></i>");
                sBuilder.AppendLine(nomeArquivo);
                sBuilder.AppendLine("</a>");
            }
            else
                sBuilder.AppendLine(msg);
            sBuilder.AppendLine("<br/>");
            sBuilder.AppendLine("<span class='pull-right' style='font-size:7pt;color:gray;'>");
            sBuilder.AppendLine("<i>");
            sBuilder.AppendLine(data);
            sBuilder.AppendLine("</i>");
            sBuilder.AppendLine("</span>");
            sBuilder.AppendLine("</span>");
            sBuilder.AppendLine("</div>");
            return sBuilder.ToString();
        }

        public string FormatarMsgChat(string nome, string mensagem, DateTime criadoEm, bool ehAgente, long? arquivoId)
        {
            var sBuilder = new StringBuilder();
            var data = string.Format(@"{0:dd/MM/yyyy HH:mm:ss}", criadoEm);
            sBuilder.AppendLine("<div class='bubble2'>");
            sBuilder.AppendLine("<span class='personName2'>");
            sBuilder.AppendLine(nome);
            sBuilder.AppendLine(ehAgente ? " (Agente)" : " (Cliente)");
            sBuilder.AppendLine("</span>");
            sBuilder.AppendLine("<br/>");
            sBuilder.AppendLine("<span class='personSay2'>");

            if (arquivoId.HasValue)
            {
                sBuilder.AppendLine("<a href='/Chat/DownloadFile?id=" + arquivoId + "'>");
                sBuilder.AppendLine("<i class='fa fa-file-text' aria-hidden='true'></i>");
                sBuilder.AppendLine(mensagem);
                sBuilder.AppendLine("</a>");
            }
            else
                sBuilder.AppendLine(mensagem);


            //if (mensagem.Contains("2|*Anexo"))
            //{
            //    var id = mensagem.Substring(mensagem.LastIndexOf("|", StringComparison.Ordinal) + 1).Replace(";", "");
            //    var caminho = string.Empty;
            //    var nomeArquivo = string.Empty;

            //    if (mensagem.Split('|').Length > 2)
            //    {
            //        caminho = mensagem.Split('|')[2].Replace(";", "");
            //        nomeArquivo = caminho.Substring(caminho.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            //        sBuilder.AppendLine("<a href='/Chat/DownloadFile?id=" + id + "'>");
            //    }
            //    else
            //        sBuilder.AppendLine("<a href='/Chat/DownloadFile?id='0'>");
            //    //sBuilder.AppendLine("<a href='/Chat/ObterAnexo?id=" + msg.Split('|')[3].Replace(";", "") + "'>");
            //    //sBuilder.AppendLine("<a href='#' onclick='AbrirArquivo();' target='_blank'>");
            //    sBuilder.AppendLine("<i class='fa fa-file-text' aria-hidden='true'></i>");
            //    sBuilder.AppendLine(nomeArquivo);
            //    sBuilder.AppendLine("</a>");
            //}
            //else
            //    sBuilder.AppendLine(mensagem);

            sBuilder.AppendLine("<br/>");
            sBuilder.AppendLine("<span class='pull-right' style='font-size:7pt;color:gray;'>");
            sBuilder.AppendLine("<i>");
            sBuilder.AppendLine(data);
            sBuilder.AppendLine("</i>");
            sBuilder.AppendLine("</span>");
            sBuilder.AppendLine("</span>");
            sBuilder.AppendLine("</div>");
            return sBuilder.ToString();
        }
    }
}