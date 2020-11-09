using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class DepartamentoServico : Servico<Departamento>, IDepartamentoServico
    {
        private readonly IDepartamentoRepositorio _repositorio;

        public DepartamentoServico(IDepartamentoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Departamento> ObterDepartamentos()
        {
            return _repositorio.ObterDepartamentos();
        }

        public Departamento ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<Departamento> ObterPorUsuario(string usuarioId)
        {
            return _repositorio.ObterPorUsuario(usuarioId);
        }

        public IEnumerable<Departamento> ObterDepartamentoPorUser(string usuarioId)
        {
            return _repositorio.ObterDepartamentoPorUser(usuarioId);
        }
    }
}
