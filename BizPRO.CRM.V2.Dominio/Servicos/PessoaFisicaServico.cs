using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using BizPRO.CRM.V2.Dominio.Validacoes.PessoasFisica;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class PessoaFisicaServico : Servico<PessoaFisica>, IPessoaFisicaServico
    {
        private readonly IPessoaFisicaRepositorio _repositorio;

        public PessoaFisicaServico(IPessoaFisicaRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public PessoaFisica Adicionar(PessoaFisica entidade)
        {
            if (!entidade.IsValid())
                return entidade;

            entidade.ValidationResult = new ClienteAptoParaCadastroValidation(_repositorio).Validate(entidade);

            if (!entidade.ValidationResult.IsValid)
                return entidade;

            _repositorio.Adicionar(entidade);

            return entidade;
        }

        public IEnumerable<PessoaFisica> PesquisarPessoaFisica(string nome, string documento, string telefone,
            long? pessoaFisicaId, string protocolo)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(nome))
                parametros.Add("@nome", string.IsNullOrEmpty(nome) ? null : nome.Trim());

            if (!string.IsNullOrEmpty(documento))
                parametros.Add("@documento", string.IsNullOrEmpty(documento) ? null : documento.Trim());

            if (!string.IsNullOrEmpty(telefone))
                parametros.Add("@telefone", string.IsNullOrEmpty(telefone) ? null : telefone.Trim());

            if (pessoaFisicaId.HasValue)
                parametros.Add("@pessoaFisicaID", pessoaFisicaId);

            if (!string.IsNullOrEmpty(protocolo))
                parametros.Add("@protocolo", string.IsNullOrEmpty(protocolo) ? null : protocolo.Trim());

            return _repositorio.ObterPorProcedimento("usp_front_sel_PesquisarPessoaFisica", parametros);
        }

        public PessoaFisica Editar(PessoaFisica entidade)
        {
            var parametros = new DynamicParameters();
            if (!entidade.IsValid())
                return entidade;

            entidade.ValidationResult = new ClienteAptoParaEditarValidation(_repositorio).Validate(entidade);

            if (!entidade.ValidationResult.IsValid)
                return entidade;

            if (entidade.ValidationResult.IsValid)
            {
                parametros.Add("@id", entidade.Id);
                parametros.Add("@nome", entidade.Nome);
                parametros.Add("@sobrenome", entidade.Sobrenome);
                parametros.Add("@CPF", entidade.Cpf);
                parametros.Add("@cpfProprio", entidade.CpfProprio);
                parametros.Add("@outroDocumento", entidade.OutroDocumento);
                parametros.Add("@dataNascimento", entidade.DataNascimento);
                parametros.Add("@codigoPostal", entidade.CodigoPostal);
                parametros.Add("@logradouro", entidade.Logradouro);
                parametros.Add("@numero", entidade.Numero);
                parametros.Add("@bairro", entidade.Bairro);
                parametros.Add("@cidadesID", entidade.CidadeId);
                parametros.Add("@complemento", entidade.Complemento);
                parametros.Add("@email", entidade.Email);
                parametros.Add("@alteradoPorUserID", entidade.AlteradoPorUserId);
                parametros.Add("@aceitaComunicados", entidade.AceitaComunicados);
                parametros.Add("@canalEntidadesCamposValoresID", entidade.CanalEntidadesCamposValoresId);
                parametros.Add("@tipoEntidadesCamposValoresID", entidade.TipoEntidadesCamposValoresId);
                _repositorio.ExecutarProcedimento("usp_upd_pessoaFisica", parametros);
            }
            return entidade;
        }
    }
}
