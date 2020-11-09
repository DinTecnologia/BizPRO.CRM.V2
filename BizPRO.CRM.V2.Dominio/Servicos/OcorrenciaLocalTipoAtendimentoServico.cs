using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class OcorrenciaLocalTipoAtendimentoServico : Servico<OcorrenciaLocalTipoAtendimento>,
        IOcorrenciaLocalTipoAtendimentoServico
    {
        private readonly IOcorrenciaLocalTipoAtendimentoRepositorio _repositorio;

        public OcorrenciaLocalTipoAtendimentoServico(IOcorrenciaLocalTipoAtendimentoRepositorio repositorio)
            : base(repositorio)
        {
            this._repositorio = repositorio;
        }

        public OcorrenciaLocalTipoAtendimento Adicionar(OcorrenciaLocalTipoAtendimento entidade)
        {
            _repositorio.Adicionar(entidade);
            return entidade;
        }

        public ValidationResult DeletarTodosLocaisDaOcorrencia(long ocorrenciaId)
        {
            var retorno = new ValidationResult();

            if (ocorrenciaId < 1)
            {
                retorno.Add(new ValidationError("Ocorrência ID informado inválido"));
                return retorno;
            }

            _repositorio.DeletarOcorrenciasLocaisTipoAtendimentoPorOcorrenciaId(ocorrenciaId);
            return retorno;
        }
    }
}
