using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EquipeServico : Servico<Equipe>, IEquipeServico
    {
        private readonly IEquipeRepositorio _repositorio;

        public EquipeServico(IEquipeRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Equipe> ObterEquipes()
        {
            return _repositorio.ObterEquipes();
        }

        public IEnumerable<Equipe> ObterPorDepartamentoId(int DepartamentoId)
        {
            return _repositorio.ObterPorDepartamentoId(DepartamentoId);
        }

        public Equipe ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<Equipe> ObterPorUsuario(string usuarioId)
        {
            return _repositorio.ObterPorUsuario(usuarioId);
        }
    }
}
