using System.Collections.Generic;
using Dapper;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class CampoDinamicoPreenchidoServico : ICampoDinamicoPreenchidoServico
    {
        private readonly ICampoDinamicoPreenchidoRepositorio _repositorio;

        public CampoDinamicoPreenchidoServico(ICampoDinamicoPreenchidoRepositorio repositorio)
        {
            _repositorio = repositorio;
            new ValidationResult();
        }

        public CampoDinamicoPreenchido Adicionar(CampoDinamicoPreenchido entidade, string usuarioId)
        {
            entidade.CriadoPor = usuarioId;

            if (entidade.ValidationResult.IsValid)
                _repositorio.Adicionar(entidade);

            return entidade;
        }

        public IEnumerable<CampoDinamicoPreenchido> ObterPor(long campoDinamicoId, string siglaEntidade, string nomeAba)
        {
            return _repositorio.ObterPor(campoDinamicoId, siglaEntidade, nomeAba);
        }

        public void Deletar(long chaveEntidade, long entidadesSecoesCamposDinamicosId, long camposDinamicosId,
            string usuarioId)
        {
            _repositorio.Deletar(chaveEntidade, entidadesSecoesCamposDinamicosId, camposDinamicosId, usuarioId);
        }

        public IEnumerable<CampoDinamicoPreenchido> ObterRespostasCamposDinamicosPorEntidade(long? campoDinamicoId,
            long? contratoProdutoId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@campoDinamicoID", campoDinamicoId);
            parametros.Add("@contratoProdutoID", contratoProdutoId);

            var listaCampoDinamico =
                _repositorio.ObterRespostasCamposDinamicosPorEntidade(
                    "usp_front_sel_obterRespostasCamposDinamicosPorEntidade", parametros);
            return listaCampoDinamico;
        }

        public CampoDinamicoPreenchido ObterCampoDinamicoPreenchido(string entidadeSigla, string abaSecao,
            string campoDinamicoNome, long chaveEntidade)
        {
            var retorno = _repositorio.ObterPor(entidadeSigla, abaSecao, campoDinamicoNome, chaveEntidade);
            return retorno.OrderByDescending(c => c.Id).FirstOrDefault();
        }

        public IEnumerable<CampoDinamicoPreenchido> ObterCampoDinamicoPreenchidos(string entidadeSigla, string abaSecao,
            string campoDinamicoNome, long chaveEntidade)
        {
            return _repositorio.ObterPor(entidadeSigla, abaSecao, campoDinamicoNome, chaveEntidade);
        }
    }
}
