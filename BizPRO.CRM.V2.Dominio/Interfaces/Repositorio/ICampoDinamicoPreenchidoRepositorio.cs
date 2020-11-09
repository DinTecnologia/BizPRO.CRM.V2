using BizPRO.CRM.V2.Dominio.Entidades;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ICampoDinamicoPreenchidoRepositorio : IRepositorio<CampoDinamicoPreenchido>
    {
        IEnumerable<CampoDinamicoPreenchido> ObterPor(long campoDinamicoId, string siglaEntidade, string nomeAba);

        void Deletar(long chaveEntidade, long entidadesSecoesCamposDinamicosId, long camposDinamicosId, string usuarioId);

        IEnumerable<CampoDinamicoPreenchido> ObterPor(long campoDinamicoId, long entidadesSecoesCamposDinamicosId,
            long chaveEntidadeId);

        IEnumerable<CampoDinamicoPreenchido> ObterRespostasCamposDinamicosPorEntidade(string procedimento,
            DynamicParameters parametros);

        IEnumerable<CampoDinamicoPreenchido> ObterPor(string entidadeSigla, string abaSecao, string campoDinamicoNome,
            long chaveEntidade);
    }
}
