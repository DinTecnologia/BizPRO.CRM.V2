using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class PausaServico : Servico<Pausa>, IPausaServico
    {
        private readonly IPausaRepositorio _repositorio;

        public PausaServico(IPausaRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public ValidationResult Salvar(string usuarioId, int? motivoId, string canalIds,
          string usuarioAcaoId)
        {
            return motivoId.HasValue
                ? _repositorio.EntrarEmPausa(usuarioId, motivoId.Value, canalIds, usuarioAcaoId)
                : _repositorio.SairDaPausa(usuarioId, canalIds, usuarioAcaoId);
        }

        public IEnumerable<Pausa> ObterPor(string usuarioId, string canalIds)
        {
            return _repositorio.ListarPausas(usuarioId, canalIds);
        }
    }
}
