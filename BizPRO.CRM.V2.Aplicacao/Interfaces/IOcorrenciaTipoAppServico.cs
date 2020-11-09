using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IOcorrenciaTipoAppServico
    {
        IEnumerable<OcorrenciaTipoViewModel> ListarOcorrenciaTipo(bool? ativo);
        IEnumerable<OcorrenciaTipoViewModel> ListarOcorrenciaTipoPai(bool ativo);
        OcorrenciaTipoViewModel SalvarOcorrenciaTipo(OcorrenciaTipoViewModel view);
        OcorrenciaTipoViewModel EditarOcorrenciaTipo(OcorrenciaTipoViewModel view);
        OcorrenciaTipoViewModel CarregarDadosOcorrenciaTipo(long id);
        OcorrenciaTipoViewModel ObterDadosPorId(long ocorrenciaTipoId);
        OcorrenciaTipoViewModel MotivoOcorrenciaSelecionado(long ocorrenciaTipoId, bool carregarUltimoNivel = true);
        MotivoSelecionadoViewModel CarregarMotivoSelecionado(MotivoSelecionadoViewModel model);
    }
}
