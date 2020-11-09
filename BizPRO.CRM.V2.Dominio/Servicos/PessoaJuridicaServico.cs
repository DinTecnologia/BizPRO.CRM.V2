using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Validacoes.PessoasJuridica;
using DapperExtensions;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class PessoaJuridicaServico : Servico<PessoaJuridica>, IPessoaJuridicaServico
    {
        private readonly IPessoaJuridicaRepositorio _repositorio;

        public PessoaJuridicaServico(IPessoaJuridicaRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
            new ValidationResult();
        }

        public PessoaJuridica Adicionar(PessoaJuridica entidade)
        {
            if (!entidade.IsValid())
                return entidade;

            entidade.ValidationResult = new ClienteAptoParaCadastroValidation(_repositorio).Validate(entidade);

            if (!entidade.ValidationResult.IsValid)
                return entidade;

            if (entidade.ValidationResult.IsValid)
                _repositorio.Adicionar(entidade);

            return entidade;
        }
        public IEnumerable<PessoaJuridica> PesquisarPessoaJuridica(string razaoSocial, string documento, string telefone, long? pessoaJuridicaID, string protocolo)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@razaoSocial", string.IsNullOrEmpty(razaoSocial) ? null : razaoSocial.Trim());
            parametros.Add("@documento", string.IsNullOrEmpty(documento) ? null : documento.Trim());
            parametros.Add("@telefone", string.IsNullOrEmpty(telefone) ? null : telefone.Trim());
            parametros.Add("@pessoaJuridicaID", pessoaJuridicaID);
            parametros.Add("@protocolo", string.IsNullOrEmpty(protocolo) ? null : protocolo.Trim());

            return _repositorio.ObterPorProcedimento("usp_front_sel_PesquisarPessoaJuridica", parametros);
        }
        public PessoaJuridica Editar(PessoaJuridica entidade)
        {
            var parametros = new DynamicParameters();
            if (!entidade.IsValid())
                return entidade;

            entidade.ValidationResult = new ClienteAptoParaEditarValidation(_repositorio).Validate(entidade);

            if (!entidade.ValidationResult.IsValid)
                return entidade;

            parametros.Add("@id", entidade.Id);
            parametros.Add("@razaoSocial", entidade.RazaoSocial);
            parametros.Add("@nomeFantasia", entidade.NomeFantasia);
            parametros.Add("@CNPJ", entidade.Cnpj);
            parametros.Add("@inscricaoEstadual", entidade.InscricaoEstadual);
            parametros.Add("@dataDeConstituicao", entidade.DataDeConstituicao);
            parametros.Add("@codigoPostal", entidade.CodigoPostal);
            parametros.Add("@logradouro", entidade.Logradouro);
            parametros.Add("@numero", entidade.Numero);
            parametros.Add("@bairro", entidade.Bairro);
            parametros.Add("@cidadesID", entidade.CidadeId);
            parametros.Add("@complemento", entidade.Complemento);
            parametros.Add("@email", entidade.EmailPrincipal);
            parametros.Add("@alteradoPorUserID", entidade.AlteradoPorUserId);
            parametros.Add("@aceitaComunicados", entidade.AceitaComunicados);
            parametros.Add("@canalEntidadesCamposValoresID", entidade.CanalEntidadesCamposValoresId);
            parametros.Add("@tipoEntidadesCamposValoresID", entidade.TipoEntidadesCamposValoresId);
            parametros.Add("@atendimentoId", entidade.AtendimentoId);
            _repositorio.ExecutarProcedimento("usp_upd_pessoaJuridica", parametros);
            return entidade;
        }
        public IEnumerable<PessoaJuridica> ObterPor(long? tipoId, string letrasBusca)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<PessoaJuridica>(f => f.TipoEntidadesCamposValoresId, Operator.Eq,
                tipoId));

            if (!string.IsNullOrEmpty(letrasBusca))
            {
                where.Predicates.Add(Predicates.Field<PessoaJuridica>(f => f.NomeFantasia, Operator.Like,
                    string.Format("%{0}%", letrasBusca)));
            }

            return _repositorio.ObterPor(where);
        }
    }
}
