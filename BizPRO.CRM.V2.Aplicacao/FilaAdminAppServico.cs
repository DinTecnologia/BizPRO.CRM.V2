using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class FilaAdminAppServico : IFilaAdminAppServico
    {
        private readonly IFilaServico _filaServico;

        public FilaAdminAppServico(IFilaServico filaServico)
        {
            _filaServico = filaServico;
        }

        public ViewModels.Admin.FilaViewModel Index(string usuarioId)
        {
            //Quando implementar algum tipo de Filtro, a arquitetura esta pronto para receber tal.
            return new ViewModels.Admin.FilaViewModel();
        }

        public IEnumerable<ViewModels.Admin.FilaListViewModel> Pesquisar(ViewModels.Admin.FilaViewModel viewModel)
        {
            var filas = _filaServico.ObterVisaoAdmin();
            var retorno = new List<ViewModels.Admin.FilaListViewModel>();

            foreach (var fila in filas)
            {
                retorno.Add(new ViewModels.Admin.FilaListViewModel(fila.Id, fila.Nome, fila.CriadoEm, fila.CriadoPorUserId, fila.AlteradoEm, fila.AlteradoPorUserId, fila.ContaEmailDisparo == null ? null : fila.ContaEmailDisparo.Email));
            }

            return retorno;
        }
    }
}
