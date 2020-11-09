using System;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class EquipeAppServico : IEquipeAppServico
    {
        private readonly IEquipeServico _equipeServico;
        public EquipeAppServico(IEquipeServico equipeServico)
        {
            _equipeServico = equipeServico;
        }
        public bool Adicionar(EquipeViewModel model)
        {
            var oEquipe = new Equipe
            {
                Id = model.Id,
                Nome = model.Nome,
                Ativo = model.Ativo,
                DepartamentoId = model.DepartamentoID,
                CriadoEm = DateTime.Now,
                CriadoPorUserId = model.CriadoPorUserId
            };

            var retorno = _equipeServico.Adicionar(oEquipe);
            return retorno.IsValid;
        }

        public bool Atualizar(EquipeViewModel model)
        {
            var oEquipe = new Equipe
            {
                Id = model.Id,
                Nome = model.Nome,
                Ativo = model.Ativo,
                DepartamentoId = model.DepartamentoID,
                CriadoEm = model.CriadoEm,
                CriadoPorUserId = model.CriadoPorUserId
            };

            var retorno = _equipeServico.Atualizar(oEquipe);
            return retorno.IsValid;
        }

        public IEnumerable<EquipeViewModel> ObterEquipes()
        {
            var obj = _equipeServico.ObterEquipes();
            var model = obj.Select(x => new EquipeViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                DepartamentoID = x.DepartamentoId,
                CriadoEm = x.CriadoEm,
                CriadoPorUserId = x.CriadoPorUserId
            }).ToList();
            return model;
        }

        public EquipeViewModel ObterPorId(int id)
        {
            var obj = _equipeServico.ObterPorId(id);
            var model = new EquipeViewModel
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Ativo = obj.Ativo,
                DepartamentoID = obj.DepartamentoId,
                CriadoEm = obj.CriadoEm,
                CriadoPorUserId = obj.CriadoPorUserId
            };
            return model;
        }
    }
}