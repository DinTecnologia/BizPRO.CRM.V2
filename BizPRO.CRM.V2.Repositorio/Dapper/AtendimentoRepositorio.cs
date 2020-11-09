using System;
using System.Linq;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AtendimentoRepositorio : Repositorio<Atendimento>, IAtendimentoRepositorio
    {
        public AtendimentoRepositorio(IDapperContexto context)
            : base(context)
        {

        }
        public IEnumerable<Atendimento> BuscarPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId, int? quantidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@pessoaFisicaID", pessoaFisicaId);
            parametros.Add("@pessoaJuridicaID", pessoaJuridicaId);
            parametros.Add("@quantidade", quantidade);
            return ObterPorProcedimento("usp_front_sel_AtendimentosPorCliente", parametros).OrderByDescending(c => c.CriadoEm);
        }

        public Atendimento BuscarPorProtocolo(string protocolo)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@protocolo", protocolo);
            return ObterPorProcedimento("usp_front_sel_AtendimentoPorProtocolo", parametros).FirstOrDefault();
        }

        public Atendimento AdicionarAtendimento(Atendimento entidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@protocolo", entidade.Protocolo);
            parametros.Add("@criadoEm", entidade.CriadoEm);
            parametros.Add("@criadoPorUserId", entidade.CriadoPorUserId);

            return ObterPorProcedimento("usp_front_ins_atendimento", parametros).FirstOrDefault();
        }

        public string GerarNumeroProtocolo(DateTime? data)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@data", data);

            var retorno = Conn.Query<Atendimento>("usp_front_sel_sequenciaAtendimentoDia", parametros,
                commandType: CommandType.StoredProcedure);

            return retorno.Any() ? retorno.First().Protocolo : null;
        }

        public Atendimento AdicionarAtendimentoCompleto(Atendimento entidade)
        {
            try
            {

                var parametros = new DynamicParameters();

                if (string.IsNullOrEmpty(entidade.Protocolo))
                    parametros.Add("@Protocolo", entidade.Protocolo);

                if (entidade.CanalOrigemId.HasValue)
                    parametros.Add("@canalOrigemId", entidade.CanalOrigemId);

                parametros.Add("@UsuarioId", entidade.CriadoPorUserId);

                if (entidade.MidiasId.HasValue)
                    parametros.Add("@MidiaId", entidade.MidiasId);

                parametros.Add("@clienteSomenteContato", entidade.ClienteSomenteContato);

                if (entidade.TipoClienteContatoEntidadesCamposValoresId.HasValue)
                    parametros.Add("@tipoClienteContatoEntidadesCamposValoresId", entidade.TipoClienteContatoEntidadesCamposValoresId);


                return ObterPorProcedimento("usp_front_ins_AtendimentoCompleto", parametros).FirstOrDefault();
            }
            catch (Exception ex)
            {
                entidade.ValidationResult.Add(new DomainValidation.Validation.ValidationError(ex.Message));
                return entidade;
            }
        }
    }
}
