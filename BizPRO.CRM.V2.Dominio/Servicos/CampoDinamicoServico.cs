using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class CampoDinamicoServico : ICampoDinamicoServico
    {
        private readonly ICampoDinamicoRepositorio _repositorio;
        private readonly ICampoDinamicoOpcaoRepositorio _repositorioCampoDinamicoOpcao;
        private readonly ICampoDinamicoPreenchidoRepositorio _repositorioCampoDinamicoPreenchido;

        public CampoDinamicoServico(ICampoDinamicoRepositorio repositorio,
            ICampoDinamicoOpcaoRepositorio repositorioCampoDinamicoOpcao,
            ICampoDinamicoPreenchidoRepositorio repositorioCampoDinamicoPreenchido)
        {
            _repositorio = repositorio;
            _repositorioCampoDinamicoOpcao = repositorioCampoDinamicoOpcao;
            _repositorioCampoDinamicoPreenchido = repositorioCampoDinamicoPreenchido;
        }

        public IEnumerable<CampoDinamico> ObterPor(long? chaveEntidadeId, string siglaEntidade, string nomeAba,
            string secao)
        {
            var listaCampoDinamico = _repositorio.ObterPor(siglaEntidade, nomeAba, secao);
            if (listaCampoDinamico == null) return listaCampoDinamico;
            foreach (var campoDinamico in listaCampoDinamico)
            {
                if (campoDinamico.Tipo.ToLower() == "dl" || campoDinamico.Tipo.ToLower() == "cl" ||
                    campoDinamico.Tipo.ToLower() == "rl")
                {
                        campoDinamico.ListaOpcoes = _repositorioCampoDinamicoOpcao.ObterPor(campoDinamico.Id);
                }

                if (chaveEntidadeId > 0)
                {
                    campoDinamico.ListaCampoDinamicoPreenchido =
                        _repositorioCampoDinamicoPreenchido.ObterPor(campoDinamico.Id,
                            campoDinamico.EntidadeSecaoCampoDinamico.Id, (long) chaveEntidadeId);
                }
            }
            return listaCampoDinamico;
        }

        public IEnumerable<CampoDinamico> ObterCamposDinamicosPorEntidade(string siglaEntidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@siglaEntidade", siglaEntidade);
            var listaCampoDinamico =
                _repositorio.ObterCamposDinamicosPorEntidade("usp_front_sel_obterCamposDinamicosPorEntidade", parametros);
            return listaCampoDinamico;
        }
    }
}
