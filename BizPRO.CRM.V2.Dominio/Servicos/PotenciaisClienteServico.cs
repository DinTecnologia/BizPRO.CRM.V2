using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using BizPRO.CRM.V2.Dominio.Validacoes.PotenciaisClientes;
using System.Linq;
namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class PotenciaisClienteServico : Servico<PotenciaisCliente>, IPotenciaisClienteServico
    {
        private readonly IPotenciaisClienteRepositorio _repositorio;

        public PotenciaisClienteServico(IPotenciaisClienteRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public PotenciaisCliente AdicionarPotenciaisCliente(PotenciaisCliente entidade)
        {
            var parametros = new DynamicParameters();
            if (!entidade.IsValid())
                return entidade;

            entidade.ValidationResult = new PotencialClienteAptoParaCadastroValidation(_repositorio).Validate(entidade);

            if (!entidade.ValidationResult.IsValid)
                return entidade;
            
            parametros.Add("@nome", entidade.nome);
            parametros.Add("@documento", entidade.documento);
            parametros.Add("@contato", entidade.contato);
            parametros.Add("@contatoDocumento", entidade.contatoDocumento);
            parametros.Add("@email", entidade.email);
            parametros.Add("@logradouro", entidade.logradouro);
            parametros.Add("@numero", entidade.numero);
            parametros.Add("@bairro", entidade.bairro);
            parametros.Add("@cidadesID", entidade.CidadesID);
            parametros.Add("@criadoPorAspNetUserID", entidade.criadoPorAspNetUserID);
            parametros.Add("@tipo", entidade.tipo);
            parametros.Add("@cep", entidade.cep);
            parametros.Add("@contatoEmail", entidade.contatoEmail);

            var retorno = _repositorio.ObterPorProcedimento("usp_front_ins_potenciaisClientes", parametros);

            return retorno.FirstOrDefault();

        }

        public IEnumerable<PotenciaisCliente> PesquisarPotenciaisCliente(string nome, string documento, string protocolo)
        {
            var parametros = new DynamicParameters();

            parametros.Add("@nome", nome);

            if (!string.IsNullOrEmpty(documento.Trim()))
                parametros.Add("@documento", documento.Replace("-", "").Replace("/", "").Replace(".", "").Trim());

            parametros.Add("@protocolo", protocolo);
            var retorno = _repositorio.ObterPorProcedimento("usp_front_sel_PesquisarPotenciaisCliente", parametros);
            return retorno;
        }

        public PotenciaisCliente EditarPotenciaisCliente(PotenciaisCliente entidade)
        {
            var parametros = new DynamicParameters();
            if (!entidade.IsValid())
                return entidade;

            entidade.ValidationResult = new PotencialClienteAptoParaEditarValidation(_repositorio).Validate(entidade);

            if (!entidade.ValidationResult.IsValid)
                return entidade;

            parametros.Add("@id", entidade.id);
            parametros.Add("@nome", entidade.nome);
            parametros.Add("@documento", entidade.documento);
            parametros.Add("@contato", entidade.contato);
            parametros.Add("@contatoDocumento", entidade.contatoDocumento);
            parametros.Add("@email", entidade.email);
            parametros.Add("@logradouro", entidade.logradouro);
            parametros.Add("@numero", entidade.numero);
            parametros.Add("@bairro", entidade.bairro);
            parametros.Add("@cidadesID", entidade.CidadesID);
            parametros.Add("@alteradoPorAspNetUserID", entidade.alteradoPorAspNetUserID);
            parametros.Add("@tipo", entidade.tipo);
            parametros.Add("@cep", entidade.cep);
            parametros.Add("@contatoEmail", entidade.contatoEmail);

            var retorno = _repositorio.ObterPorProcedimento("usp_front_upd_potenciaisClientes", parametros);

            return retorno.FirstOrDefault();
        }

        public PotenciaisCliente AtualizarConverterCliente(PotenciaisCliente entidade)
        {
            var parametros = new DynamicParameters();
            if (!entidade.IsValid())
                return entidade;

            parametros.Add("@id", entidade.id);
            parametros.Add("@convertidoEmClienteEm", entidade.convertidoEmClienteEm);
            parametros.Add("@convertidoEmClientePorAspNetUserID", entidade.convertidoEmClientePorAspNetUserID);
            parametros.Add("@convertidoEmClientePessoasFisicasID", entidade.convertidoEmClientePessoasFisicasID);
            parametros.Add("@convertidoEmClientePessoasJuridicasID", entidade.convertidoEmClientePessoasJuridicasID);
            parametros.Add("@nome", entidade.nome);
            parametros.Add("@documento", entidade.documento);
            parametros.Add("@contato", entidade.contato);
            parametros.Add("@contatoDocumento", entidade.contatoDocumento);
            parametros.Add("@email", entidade.email);
            parametros.Add("@logradouro", entidade.logradouro);
            parametros.Add("@numero", entidade.numero);
            parametros.Add("@bairro", entidade.bairro);
            parametros.Add("@cidadesID", entidade.CidadesID);
            parametros.Add("@alteradoPorAspNetUserID", entidade.alteradoPorAspNetUserID);
            parametros.Add("@tipo", entidade.tipo);
            parametros.Add("@cep", entidade.cep);
            parametros.Add("@contatoEmail", entidade.contatoEmail);

            var retorno = _repositorio.ObterPorProcedimento("usp_front_upd_ConverterClientes", parametros);
            return retorno.FirstOrDefault();
        }
    }
}
