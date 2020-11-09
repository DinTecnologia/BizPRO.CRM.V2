using System.Web.Mvc;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class PausaAppServico : IPausaAppServico
    {
        private IPausaMotivoServico _pausaMotivoServico;
        private IPausaServico _pausaServico;

        public PausaAppServico(IPausaMotivoServico pausaMotivoServico, IPausaServico pausaServico)
        {
            _pausaMotivoServico = pausaMotivoServico;
            _pausaServico = pausaServico;
        }

        public PausaFormViewModel Carregar(string canalIds, string usuarioId)
        {
            var retorno = new PausaFormViewModel();

            if (!string.IsNullOrEmpty(canalIds) && !canalIds.Contains("|"))
            {
                canalIds = canalIds + "|";
            }

            retorno.CanalIds = canalIds;
            retorno.UsuarioId = usuarioId;

            var pausas = _pausaServico.ObterPor(usuarioId, canalIds);

            foreach (var pausa in pausas)
            {
                retorno.Pausas.Add(new PausaViewModel(pausa.Id, pausa.IniciadoEm, pausa.Motivo.Nome, pausa.Canal.Nome));
            }

            retorno.Motivos = new SelectList(_pausaMotivoServico.ObterPorCanalIds(canalIds), "Id", "Nome");
            return retorno;
        }

        public PausaFormViewModel Salvar(PausaFormViewModel viewModel)
        {
            viewModel.ValidationResult = _pausaServico.Salvar(viewModel.UsuarioId, viewModel.MotivoId,
                viewModel.CanalIds,
                viewModel.UsuarioAcaoId);

            return viewModel;
        }
    }
}
