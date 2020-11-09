using System;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class DepartamentoAppServico : IDepartamentoAppServico
    {
        private readonly IDepartamentoServico _departamentoServico;
        public DepartamentoAppServico(IDepartamentoServico departamentoServico)
        {
            _departamentoServico = departamentoServico;
        }
        public IEnumerable<DepartamentoViewModel> ObterDepartamentos()
        {
            var obj = _departamentoServico.ObterDepartamentos();
            var model = obj.Select(x => new DepartamentoViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                CriadoEm = x.CriadoEm,
                CriadoPorUserId = x.CriadoPorUserId
            }).ToList();
            return model;
        }
        public DepartamentoViewModel ObterPorId(int id)
        {
            var obj = _departamentoServico.ObterPorId(id);
            var model = new DepartamentoViewModel
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Ativo = obj.Ativo,
                CriadoEm = obj.CriadoEm,
                CriadoPorUserId = obj.CriadoPorUserId
            };
            return model;
        }
        public bool Adicionar(DepartamentoViewModel model)
        {
            var oDepartamento = new Departamento
            {
                Id = model.Id,
                Nome = model.Nome,
                Ativo = model.Ativo,
                CriadoEm = DateTime.Now,
                CriadoPorUserId = model.CriadoPorUserId
            };

            var retorno = _departamentoServico.Adicionar(oDepartamento);
            return retorno.IsValid;
        }
        public bool Atualizar(DepartamentoViewModel model)
        {
            var oDepartamento = new Departamento
            {
                Id = model.Id,
                Nome = model.Nome,
                Ativo = model.Ativo,
                CriadoEm = model.CriadoEm,
                CriadoPorUserId = model.CriadoPorUserId
            };

            var retorno = _departamentoServico.Atualizar(oDepartamento);
            return retorno.IsValid;
        }
    }
}