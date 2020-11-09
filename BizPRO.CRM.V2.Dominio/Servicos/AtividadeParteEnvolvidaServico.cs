using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtividadeParteEnvolvidaServico : IAtividadeParteEnvolvidaServico
    {
        private readonly IAtividadeParteEnvolvidaRepositorio _repositorio;
        private readonly ValidationResult _validationResult;

        public AtividadeParteEnvolvidaServico(IAtividadeParteEnvolvidaRepositorio repositorio)
        {
            _repositorio = repositorio;
            _validationResult = new ValidationResult();
        }
        public IEnumerable<AtividadeParteEnvolvida> ObterPorAtividadeId(long atividadeId)
        {
            return _repositorio.ObterPorAtividadeId(atividadeId);
        }
        public int BuscarOrdem(long atividadeId, string tipoParteEnvolvida)
        {
            int ordem = 1;

            var listaPartesEnvolvidas = _repositorio.BuscarPor(atividadeId, tipoParteEnvolvida);
            if (listaPartesEnvolvidas.Any())
            {
                ordem = (int)listaPartesEnvolvidas.OrderByDescending(c => c.Ordem).FirstOrDefault().Ordem + 1;
            }

            return ordem;
        }
        public ValidationResult Adicionar(AtividadeParteEnvolvida entidade)
        {
            if (!entidade.Ordem.HasValue)
                entidade.SetarOrdem(BuscarOrdem(entidade.AtividadesId, entidade.TipoParteEnvolvida));

            var adicionou = _repositorio.Adicionar(entidade);

            if (adicionou == null)
                _validationResult.Add(new ValidationError("A Entidade que você está tentando gravar está nula, por favor tente novamente!" + entidade));

            return _validationResult;
        }

        public AtividadeParteEnvolvida BuscarUltimoClienteTratativa(long atividadeId)
        {
            var atividadePartesEnvolvidas = ObterPorAtividadeId(atividadeId);
            return atividadePartesEnvolvidas.Any(x => x.TipoParteEnvolvida == TipoParteEnvolvida.ClienteTratado.Value)
                ? atividadePartesEnvolvidas.Where(x => x.TipoParteEnvolvida == TipoParteEnvolvida.ClienteTratado.Value)
                    .OrderByDescending(c => c.Ordem)
                    .FirstOrDefault()
                : null;
        }

        public bool PossuiClienteContato(long atividadeId)
        {
            return
                ObterPorAtividadeId(atividadeId)
                    .Any(x => x.TipoParteEnvolvida == TipoParteEnvolvida.ClienteContato.Value);
        }

        public AtividadeParteEnvolvida BuscarClienteContato(long atividadeId)
        {
            var atividadePartesEnvolvidas = ObterPorAtividadeId(atividadeId);

            if (atividadePartesEnvolvidas.Any())
            {
                return
                    atividadePartesEnvolvidas
                        .Any(c => c.TipoParteEnvolvida == TipoParteEnvolvida.ClienteContato.Value)
                        ? atividadePartesEnvolvidas.FirstOrDefault(
                            c => c.TipoParteEnvolvida == TipoParteEnvolvida.ClienteContato.Value)
                        : atividadePartesEnvolvidas.FirstOrDefault(
                            c => c.TipoParteEnvolvida == TipoParteEnvolvida.ClienteTratado.Value);
            }

            return null;
        }

        public void Excluir(long atividadeId, long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            var atividadeParteEnvolvida = _repositorio.BuscarPor(atividadeId, pessoaFisicaId, pessoaJuridicaId);

            if (atividadeParteEnvolvida.Any())
            {
                var atividadeExcluir = atividadeParteEnvolvida.FirstOrDefault();

                if (atividadeExcluir != null)
                {
                    _repositorio.Deletar(atividadeExcluir);
                }
            }
        }

        public bool Atualizar(AtividadeParteEnvolvida entidade)
        {
            return _repositorio.Atualizar(entidade);
        }
    }
}
