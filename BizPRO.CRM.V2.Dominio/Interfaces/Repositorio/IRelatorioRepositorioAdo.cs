using System;
using System.Data;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IRelatorioRepositorioAdo
    {
        DataSet ObterDadosRelatorioFluxoDeAtendimento(DateTime? dataInicio, DateTime? dataFim,
            int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido, string usuarioId);

        DataSet ObterDadosRelatorioFluxoDeAtendimentoProdutivo(DateTime? dataInicio,
            DateTime? dataFim, int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido,
            string usuarioId);
    }
}
