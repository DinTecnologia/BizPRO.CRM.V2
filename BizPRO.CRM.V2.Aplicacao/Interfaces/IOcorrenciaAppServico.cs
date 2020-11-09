using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IOcorrenciaAppServico
    {
        OcorrenciaFormViewModel Carregar(long? pessoaFisicaId, long? pessoaJuridicaId, long? atendimentoId,
            long? contratoId);

        OcorrenciaFormViewModel Adicionar(OcorrenciaFormViewModel viewModel, string usuarioId);

        OcorrenciaFormViewModel CarregarListas(OcorrenciaFormViewModel viewModel, long? pessoaFisicaId,
            long? pessoaJuridicaId);

        OcorrenciaFormViewModel CarregarVisualizar(long ocorrenciaId);
        OcorrenciaFormViewModel ObterPorId(long id, string userId, long? atendimentoId);
        OcorrenciaFormViewModel Atualizar(OcorrenciaFormViewModel viewModel, string usuarioId);
        OcorrenciaFormViewModel CarregarDadosMinhasOcorrencia(string userId);
        OcorrenciaFormViewModel ObterOcorrenciasHistoricoCliente(long? pessoaFisicaId, long? pessoaJuridicaId);
        SelectList ObterOcorrenciasTipo(long ocorrenciasTipoPaiId);
        bool VincularLocal(long ocorrenciasTipoId);
        IEnumerable<OcorrenciaListaItemViewModel> ObterOcorrenciasLocalPorUserId(string userId);
        IEnumerable<OcorrenciaTipoDdlViewModel> CarregarOcorrenciaTipoGravadas(long id);
        void AdicionarOcorrenciaAtendimento(long atendimentoId, long ocorrenciaId);

        object SelectDinamicoExportacaoOcorrencia(string campos, String[] dinamicos, String[] dinamicosContrato,
            string userId, string dataInicial, string dataFinal, string status, string cliente, long? ocorrenciaTipoId);

        OcorrenciaExportacaoCamposDinamicosViewModel ListarCamposDinamicos();
        ValidationResult ExcluirLocalOcorrencia(long ocorrenciaId);
        string ObterNomeExibicaoOcorrenciaTipoSelecionado(long ocorrenciaTipoId);
        OcorrenciaDetalheViewModel ObterOcorrenciaDetalhe(long id);
        OcorrenciaLaudoViewModel OcorrenciaLaudo(string userId, string protocolo, string cliente, long? ocorrenciaTipoId);

        IEnumerable<OcorrenciaListaItemViewModel> ObterOcorrenciasLocal(string userId, string protocolo, string cliente,
            long? ocorrenciaTipoId, string documento);

        IEnumerable<OcorrenciaListaItemViewModel> BuscarOcorrenciasCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId, long? atendimentoId);

        OcorrenciaViewModel Index(string userId);
        IEnumerable<OcorrenciaAcompanhamento> BuscarOcorrenciaSupervisao(OcorrenciaViewModel model);

        object SelectDinamicoExportacaoOcorrencia2(string campos, string[] dinamicos, string[] dinamicosContrato,
            string usuarioId, string dataInicial, string dataFinal, string status, string cliente,
            long? ocorrenciaTipoId, string camposDinamicosOcorrenciaId, string camposDinamicosContratoId);

        AlterarMotivoViewModel CarregarAlterarMotivo(long ocorrenciaId);

        ValidationResult AtualizarMotivo(long ocorrenciaId, long ocorrenciaTipoId, string usuarioId);

        AlterarContratoViewModel CarregarAlterarContrato(long ocorrenciaId);

        ValidationResult AtualizarContrato(long ocorrenciaId, long contratoId, string usuarioId);
    }
}