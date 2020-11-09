using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ContatoAppServico : AppServicoDapper, IContatoAppServico
    {
        private readonly IAtividadeServico _servicoAtividade;
        private readonly IStatusAtividadeServico _servicoStatusAtividade;
        private readonly IAtividadeTipoServico _servicoAtividadeTipo;

        public ContatoAppServico(IAtividadeServico servicoAtividade, IStatusAtividadeServico servicoStatusAtividade,
            IAtividadeTipoServico servicoAtividadeTipo)
        {
            _servicoAtividade = servicoAtividade;
            _servicoStatusAtividade = servicoStatusAtividade;
            _servicoAtividadeTipo = servicoAtividadeTipo;
        }

        public IEnumerable<ContatoViewModel> ObterContatosPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            int? quantidade)
        {
            var atividades = _servicoAtividade.ObterAtividadesPorCliente(pessoaFisicaId, pessoaJuridicaId,
                quantidade);

            var retorno = atividades.Select(item => new ContatoViewModel(item)).ToList();

            //if (atividades != null)
            //    foreach (var atividade in atividades)
            //    {
            //        atividade.StatusAtividade = _servicoStatusAtividade.ObterPorId(atividade.StatusAtividadeId);
            //        if (atividade.AtividadeTipoId != null)
            //            atividade.AtividadeTipo = _servicoAtividadeTipo.ObterPorId((long) atividade.AtividadeTipoId);
            //        retorno.Add(new ContatoViewModel(atividade));
            //    }

            return retorno;
        }
    }
}
