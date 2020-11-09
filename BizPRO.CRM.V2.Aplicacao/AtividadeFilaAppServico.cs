using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AtividadeFilaAppServico : IAtividadeFilaAppServico
    {
        private readonly IAtividadeFilaServico _atividadeFilaServico;
        private readonly IFilaServico _filaServico;
        private readonly IFilaRepositorioDal _filaRepositorio;

        public AtividadeFilaAppServico(IAtividadeFilaServico atividadeFilaServico, IFilaServico filaServico, IFilaRepositorioDal filaRepositorio)
        {
            _atividadeFilaServico = atividadeFilaServico;
            _filaServico = filaServico;
            _filaRepositorio = filaRepositorio;
        }
        public AtividadeFilaViewModel AdicionarAtividadeFila(AtividadeFilaViewModel model)
        {
            var atividadeFila = new AtividadeFila(model.AtividadeId, model.FilaId);
            var resultado = _atividadeFilaServico.Adicionar(atividadeFila);
            return new AtividadeFilaViewModel(atividadeFila.Id, atividadeFila.AtividadeId, atividadeFila.FilaId, atividadeFila.EntrouNaFilaEm, resultado);
        }

        public AtividadeFilaViewModel AddFinalizarAtividadeFila(AtividadeFilaViewModel model)
        {
            var atividadeFila = new AtividadeFila(model.AtividadeId, model.FilaId, DateTime.Now);
            var resultado = _atividadeFilaServico.Adicionar(atividadeFila);
            return new AtividadeFilaViewModel(atividadeFila.Id, atividadeFila.AtividadeId, atividadeFila.FilaId,
                atividadeFila.EntrouNaFilaEm, resultado);
        }

        public AtividadesFilaViewModel Carregar(string usuarioId, int filaId)
        {
            var fila = _filaServico.ObterPorId(filaId);
            if (fila != null) return new AtividadesFilaViewModel(filaId, fila.Nome);

            var retorno = new AtividadesFilaViewModel();
            retorno.ValidationResult.Add(
                new DomainValidation.Validation.ValidationError(
                    string.Format("Não possui fila cadastrada no Sistema com o id: {0}", filaId)));
            return retorno;
        }


        public AtividadesFilaViewModel CarregarViaDal(string usuarioId, int filaId)
        {
            var fila = _filaRepositorio.ObterPorIdDal(filaId);
            if (fila != null) return new AtividadesFilaViewModel(filaId, fila.Nome);

            var retorno = new AtividadesFilaViewModel();
            retorno.ValidationResult.Add(
                new DomainValidation.Validation.ValidationError(
                    string.Format("Não possui fila cadastrada no Sistema com o id: {0}", filaId)));
            return retorno;
        }


    }
}
