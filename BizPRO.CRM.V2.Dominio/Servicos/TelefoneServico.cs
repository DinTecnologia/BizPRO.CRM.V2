using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TelefoneServico : Servico<Telefone>, ITelefoneServico
    {
        private readonly ITelefoneRepositorio _repositorio;
        private DynamicParameters _parametros;

        public TelefoneServico(ITelefoneRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Telefone> ObterTelefonePessoaFisica(long pessoaFisicaId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@PessoaFisicaID", pessoaFisicaId);
            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_sel_telefonesPessoaFisica", _parametros);
            return listaRetorno.AsList();
        }

        public List<Telefone> ObterTelefonePessoaJuridica(long pessoaJuridicaId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@PessoaJuridicaID", pessoaJuridicaId);
            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_sel_telefonesPessoaJuridica", _parametros);
            return listaRetorno.AsList();
        }

        public List<Telefone> ObterTelefoneCliente(long? pessoaFisicaId, long? pessoaJuridicaId, long? potenciaisCliente)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@PessoaJuridicaID", pessoaJuridicaId);
            _parametros.Add("@PessoaFisicaID", pessoaFisicaId);
            _parametros.Add("@PotenciaisCliente", potenciaisCliente);
            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_sel_telefonesCliente", _parametros);
            return listaRetorno.AsList();
        }

        public Telefone AtualizarTelefone(long id, bool ativo)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@id", id);
            _parametros.Add("@ativo", ativo);
            _repositorio.ObterPorProcedimento("usp_front_upd_telefones", _parametros);
            var listaRetorno = _repositorio.ObterPorId(id);
            return listaRetorno;
        }

        public Telefone SalvarTelefone(Telefone telefone)
        {
            _parametros = new DynamicParameters();            

            _parametros.Add("@clientePessoaFisicaID", telefone.ClientePessoaFisicaId);
            _parametros.Add("@clientePessoaJuridicaID", telefone.ClientePessoaJuridicaId);
            _parametros.Add("@ddd", telefone.Ddd);
            _parametros.Add("@numero", telefone.Numero);
            _parametros.Add("@TelefonesTiposID", telefone.TelefonesTiposId);
            _parametros.Add("@criadoPorUserID", telefone.CriadoPorUserId);

            if (telefone.PotenciaisClientesId != null && telefone.PotenciaisClientesId > 0)
                _parametros.Add("@PotenciaisClientesID", telefone.PotenciaisClientesId);

            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_ins_telefones", _parametros);
            return listaRetorno.FirstOrDefault();
        }
    }
}
