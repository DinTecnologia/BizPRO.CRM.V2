using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AtividadeApoioAppServico : IAtividadeApoioAppServico
    {
        public readonly IAtividadeApoioServico _atividadeApoioServico;
        public AtividadeApoioAppServico(IAtividadeApoioServico atividadeApoioServico)
        {
            _atividadeApoioServico = atividadeApoioServico;
        }
        //public AtividadeApoioViewModel ListarAtividadesOcorrencia(long id)
        //{
        //    var viewModel = new AtividadeApoioViewModel();
        //    viewModel.listarAtividadeApoio = _atividadeApoioServico.ObterPorOcorrenciaID(id);
        //    return viewModel;
        //}
        //public AtividadeApoioViewModel ListarAtividadesCliente(long? pessoaFisicaID, long? pessoaJuridicaID)
        //{
        //    var viewModel = new AtividadeApoioViewModel();
        //    viewModel.listarAtividadeApoio = _atividadeApoioServico.ObterPorCliente(pessoaFisicaID, pessoaJuridicaID);
        //    return viewModel;
        //}
    }
}
