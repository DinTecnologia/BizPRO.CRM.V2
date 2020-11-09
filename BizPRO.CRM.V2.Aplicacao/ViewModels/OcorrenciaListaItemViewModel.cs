using System;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class OcorrenciaListaItemViewModel
    {
        public long Id { get; set; }
        public string Cliente { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string IdEncrito { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
        public string Responsavel { get; set; }

        public int QuantidadeDia
        {
            get
            {
                TimeSpan data = DateTime.Now - CriadoEm;
                return data.Days;
            }
        }

        public long? AtendimentoId { get; set; }
        public string PossuiLaudo { get; set; }
        public bool VincularManual { get; set; }
        public bool PossuiVinculoComAtendimentoId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public bool Finalizada { get; set; }

        public OcorrenciaListaItemViewModel()
        {

        }

        public OcorrenciaListaItemViewModel(long ocorrenciaId, string nomeCliente, DateTime criadoEm,
            string ocorrenciaStatus, string ocorrenciaResponsavel, DateTime? dataUltimaAtualizacao, bool vincularManual,
            bool possuiVinculoComAtendimentoId, bool finalizada)
        {
            Id = ocorrenciaId;
            Cliente = nomeCliente;
            CriadoEm = criadoEm;
            Status = ocorrenciaStatus;
            Responsavel = ocorrenciaResponsavel;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            VincularManual = vincularManual;
            PossuiVinculoComAtendimentoId = possuiVinculoComAtendimentoId;
            Finalizada = finalizada;
        }

        public OcorrenciaListaItemViewModel(Ocorrencia ocorrencia, long? atendimentoId, string possuiLaudo,
            bool vincularManual, bool possuiVinculoComAtendimentoId, long? pessoaFisicaId, long? pessoaJuridicaId,
            bool finalizada)
        {
            Id = ocorrencia.Id;
            Cliente = ocorrencia.PessoaFisica != null
                ? ocorrencia.PessoaFisica.Nome.ToUpper()
                : (ocorrencia.PessoaJuridica != null
                    ? ocorrencia.PessoaJuridica.NomeFantasia.ToUpper()
                    : "Não informado");
            CriadoEm = ocorrencia.CriadoEm;
            Tipo = ocorrencia.OcorrenciaTipo != null ? ocorrencia.OcorrenciaTipo.NomeExibicao : "Não informado";
            Status = ocorrencia.StatusEntidade != null ? ocorrencia.StatusEntidade.nome.ToUpper() : "Não informado";
            Responsavel = ocorrencia.Usuario != null ? ocorrencia.Usuario.Nome.ToUpper() : "Não indentificado";
            DataUltimaAtualizacao = ocorrencia.FinalizadoEm;
            AtendimentoId = atendimentoId;
            PossuiLaudo = possuiLaudo;
            VincularManual = vincularManual;
            PossuiVinculoComAtendimentoId = possuiVinculoComAtendimentoId;
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            Finalizada = finalizada;
        }
    }
}
