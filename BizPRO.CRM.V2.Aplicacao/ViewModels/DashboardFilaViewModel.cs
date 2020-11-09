using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Drawing;
using System.Threading;
using System.Text;


namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class DashboardFilaViewModel
    {
        public SelectList Filas { get; set; }
        public int? FilaId { get; set; }
        public string TempoMedioGeral { get; set; }
        public IEnumerable<Dashboard> Dashboard { get; set; }
        public List<VisaoAtividadeTipoStatusViewModel> VisaoAtividadeTipo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public SelectList Departamentos { get; set; }
        public int? DepartamentoId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public DashboardFilaViewModel()
        {
            ValidationResult = new ValidationResult();
        }

        public DashboardFilaViewModel(IEnumerable<Fila> filas, int? filaId, IEnumerable<Dashboard> dashboard,
            DateTime? dataInicio, DateTime? dataFim, IEnumerable<Departamento> departamentos, int? departamentoId)
        {
            VisaoAtividadeTipo = new List<VisaoAtividadeTipoStatusViewModel>();
            Filas = new SelectList(filas, "id", "nome");
            Dashboard = dashboard;
            FilaId = filaId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            var listab = dashboard.Where(x => x.PlaSigla.Contains("TEMD")).ToList();

            foreach (var tempoMedio in listab)
            {
                var d = DateTime.Today.AddMinutes(tempoMedio.PlaQuantidade);
                if (tempoMedio.PlaSigla == "TEMDGE")
                    TempoMedioGeral = ConvertMinutosEmTempo(tempoMedio.PlaQuantidade);
            }

            var listaVisaoAtividadeTipoStatus =
                dashboard.GroupBy(u => new {plaAtividadeTipoID = u.PlaAtividadeTipoId, plaAtividadeTipoNome = u.PlaAtividadeTipoNome},
                    (Key, group) =>
                        new
                        {
                            atividadeTipoID = Key.plaAtividadeTipoID,
                            atividadeTipoNome = Key.plaAtividadeTipoNome,
                            Itens = group.ToList()
                        });

            foreach (var visaoAtividadeTipoStatus in listaVisaoAtividadeTipoStatus)
            {
                VisaoAtividadeTipo.Add(new VisaoAtividadeTipoStatusViewModel(visaoAtividadeTipoStatus.Itens));
            }

            Departamentos = new SelectList(departamentos, "id", "nome");
            DepartamentoId = departamentoId;
        }

        public string ConvertMinutosEmTempo(int minutos)
        {
            var dia = 0;
            var hora = 0;
            var minuto = 0;

            if (minutos > 1440)
            {
                dia = minutos / 1440;
                minutos = minutos - (dia * 1440);
            }

            if (minutos > 60)
            {
                hora = minutos / 60;
                minutos = minutos - (hora * 60);
            }

            minuto = minutos;

            if (dia > 0)
                return dia + "d" + hora.ToString().PadLeft(2, '0') + "h" + minuto.ToString().PadLeft(2, '0');
            return hora.ToString().PadLeft(2, '0') + "h" + minuto.ToString().PadLeft(2, '0');
        }
    }

    public class VisaoAgenteViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public List<VisaoAgentItem> Itens { get; set; }

        public VisaoAgenteViewModel(string id, string usuario, List<Dashboard> itens)
        {
            Id = id;
            Nome = usuario;
            Itens = new List<VisaoAgentItem>();

            foreach (var item in itens)
            {
                Itens.Add(new VisaoAgentItem(item.PlaDescricao, item.PlaQuantidade, item.PlaSituacaoId));
            }
        }
    }

    public class VisaoAgentItem
    {
        public int SituacaoId { get; set; }
        public string Status { get; set; }
        public int Total { get; set; }

        public VisaoAgentItem(string status, int total, int situacaoId)
        {
            SituacaoId = situacaoId;
            Status = status;
            Total = total;
        }
    }

    public class VisaoStatusViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int Valor { get; set; }
        public double Porcentagem { get; set; }
        public string Cor { get; set; }

        public VisaoStatusViewModel(string nome, int valor, double porcentagem, int? id)
        {
            Porcentagem = porcentagem;
            Nome = nome;
            Valor = valor;
            var corGraficos = new CorGraficos();
            Cor = corGraficos.RetornaNomeCor();
            Id = id;
        }
    }

    public class CorGraficos
    {
        public string RetornaNomeCor()
        {
            var random = new Random();
            var r = int.Parse(random.Next(255).ToString());
            var g = int.Parse(random.Next(255).ToString());
            var b = int.Parse(random.Next(255).ToString());
            var a = int.Parse(random.Next(255).ToString());
            var cor = string.Format("#{0}", Color.FromArgb(a, r, g, b).Name.ToUpper().Substring(0, 6));
            return cor;
        }
    }

    public class VisaoAtividadeTipoStatusViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string VisaoStatusNome { get; set; }
        public string VisaoStatusCor { get; set; }
        public string VisaoStatusValor { get; set; }
        public string Script { get; set; }
        public List<VisaoStatusViewModel> Itens { get; set; }
        public List<VisaoAgenteViewModel> VisaoAgente { get; set; }
        public int Ordem { get; set; }

        public VisaoAtividadeTipoStatusViewModel(IEnumerable<Dashboard> dados)
        {
            if (dados == null) return;

            Id = dados.FirstOrDefault().PlaAtividadeTipoId;
            Ordem = dados.FirstOrDefault().PlaOrdem;
            Nome = string.IsNullOrEmpty(dados.FirstOrDefault().PlaAtividadeTipoNome)
                ? "Geral"
                : dados.FirstOrDefault().PlaAtividadeTipoNome;
            VisaoAgente = new List<VisaoAgenteViewModel>();
            Itens = new List<VisaoStatusViewModel>();

            var listaVisaoStatus = dados.Where(x => x.PlaSigla == "ATSTNO").ToList();
            foreach (var visaoStatus in listaVisaoStatus)
            {
                Itens.Add(new VisaoStatusViewModel(visaoStatus.PlaDescricao, visaoStatus.PlaQuantidade,
                    visaoStatus.PlaPorcentagem, visaoStatus.PlaStatusAtividadeId));
                Thread.Sleep(20);
            }

            var listaVisaoAgente =
                dados.Where(x => x.PlaSigla == "USATAD")
                    .GroupBy(u => new {plaUsuario = u.PlaUsuario, plaUsuarioId = u.PlaUsuarioId},
                        (Key, group) =>
                            new {id = Key.plaUsuarioId, usuario = Key.plaUsuario, Informacoes = @group.ToList()});
            foreach (var visaoAgente in listaVisaoAgente)
            {
                VisaoAgente.Add(new VisaoAgenteViewModel(visaoAgente.id, visaoAgente.usuario,
                    visaoAgente.Informacoes));
            }


            var contador = 0;
            var sbNome = new StringBuilder();
            var sbCor = new StringBuilder();
            var sbValor = new StringBuilder();

            foreach (var visaoStatus in this.Itens)
            {
                if (contador > 0)
                {
                    sbNome.Append(", " + visaoStatus.Nome);
                    sbCor.Append("," + visaoStatus.Cor);
                    sbValor.Append(", " + visaoStatus.Valor);
                }
                else
                {
                    sbNome.Append(visaoStatus.Nome);
                    sbCor.Append(visaoStatus.Cor);
                    sbValor.Append(visaoStatus.Valor);
                }
                contador++;
            }

            VisaoStatusNome = sbNome.ToString();
            VisaoStatusCor = sbCor.ToString();
            VisaoStatusValor = sbValor.ToString();
            Script = "<script>$(document).ready(function () {init_chart_doughnut(" + Id + "); });</script>";
        }
    }
}
