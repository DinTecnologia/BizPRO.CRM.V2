using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Servicos;
using DapperExtensions;
using System.Data;
using BizPRO.CRM.V2.Dominio.Validacoes;
using BizPRO.CRM.V2.Dominio.Interfaces.Validacoes;
using Dapper;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ProdutoTipoServico : Servico<ProdutoTipo>, IProdutoTipoServico
    {
        private readonly IProdutoTipoRepositorio _repositorio;
        private readonly ValidationResult _validationResult;

        public ProdutoTipoServico(IProdutoTipoRepositorio repositorio)
            : base(repositorio)
        {
            this._repositorio = repositorio;
            _validationResult = new ValidationResult();
        }

        public IEnumerable<ProdutoTipo> ObterProdutoTipoAtivo(long? idProdutoTipo)
        {
            return _repositorio.ObterProdutoTipoAtivo(idProdutoTipo);
        }


    }
}
