using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class StatusEntidadeServico : Servico<StatusEntidade>, IStatusEntidadeServico
    {
        private readonly IStatusEntidadeRepositorio _repositorio;

        public StatusEntidadeServico(IStatusEntidadeRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<StatusEntidade> ObterStatusEntidadeNovaOcorrencia()
        {
            return _repositorio.ObterPor("ocorrencia", true, false);
        }

        public IEnumerable<StatusEntidade> ObterStatusEntidadeOcorrencia()
        {
            return _repositorio.ObterPor("ocorrencia", null, null);
        }

        public IEnumerable<StatusEntidade> ObterStatusEntidadeVendas()
        {
            return _repositorio.ObterPor("venda", null, null);
        }

        public StatusEntidade ObterPorId(long id)
        {
            return _repositorio.ObterPorId(id);
        }

        public StatusEntidade AxaObterStatusEntidadeNovoLaudo()
        {
            return _repositorio.AxaObterStatusNovoLaudo();
        }

        public IEnumerable<StatusEntidade> AxaObterStatusEntidadeLaudo()
        {
            return _repositorio.AxaObterStatusLaudo();
        }

        public IEnumerable<StatusEntidade> AxaObterStatusLojista()
        {
            return _repositorio.AxaObterStatusLojista();
        }

        public StatusEntidade ObterStatusEntidadeNovoContrato()
        {
            var listaStatus = _repositorio.ObterPor("contrato", true, false);

            return listaStatus.Any()
                ? (listaStatus.FirstOrDefault(c => c.nome.Contains("Ativa")) == null
                    ? listaStatus.FirstOrDefault()
                    : listaStatus.FirstOrDefault(c => c.nome.Contains("Ativa")))
                : null;
        }

        public IEnumerable<StatusEntidade> ObterPorOcorrenciaTipoId(long ocorrenciaTipoId)
        {
            return _repositorio.ObterPorOcorrenciaTipoId(ocorrenciaTipoId);
        }

        public StatusEntidade ObterStatusOcorrenciaFinalizadoraPadrao()
        {
            return _repositorio.ObterStatusOcorrenciaFinalizadoraPadrao();
        }
    }
}
