using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ICampoDinamicoPreenchidoServico
    {
        CampoDinamicoPreenchido Adicionar(CampoDinamicoPreenchido entidade, string usuarioId);

        IEnumerable<CampoDinamicoPreenchido> ObterPor(long campoDinamicoId, string siglaEntidade, string nomeAba);

        void Deletar(long chaveEntidade, long entidadesSecoesCamposDinamicosId, long camposDinamicosId, string usuarioId);

        IEnumerable<CampoDinamicoPreenchido> ObterRespostasCamposDinamicosPorEntidade(long? campoDinamicoId,
            long? contratoProdutoId);

        CampoDinamicoPreenchido ObterCampoDinamicoPreenchido(string entidadeSigla, string abaSecao,
            string campoDinamicoNome, long chaveEntidade);

        IEnumerable<CampoDinamicoPreenchido> ObterCampoDinamicoPreenchidos(string entidadeSigla, string abaSecao,
            string campoDinamicoNome, long chaveEntidade);
    }
}
