using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ChatUraServico : IChatUraServico
    {
        private readonly IChatUraRepositorio _repositorio;

        public ChatUraServico(IChatUraRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ChatUra ObterUra(long atividadeId, long? chatUraId, int? ordem)
        {
            var chatUraUnificado = _repositorio.ObterUnificado(atividadeId, chatUraId, ordem);
            if (chatUraUnificado == null) return null;

            var entidadePai = chatUraUnificado.FirstOrDefault(w => w.ChatUraId == null && w.Titulo);
            if (entidadePai == null) return null;
            {
                foreach (
                    var opcao in
                    chatUraUnificado.Where(w => w.ChatUraId == entidadePai.Id && w.Titulo == false).ToList())
                {
                    entidadePai.Opcoes.Add(new ChatUra(opcao.Id, opcao.ChatUraId, opcao.ProximaUraId,
                        opcao.Descricao, opcao.Padrao, opcao.CriadoEm, opcao.CriadoPorUserId, opcao.Titulo,
                        opcao.Ordem));
                }

                return entidadePai;
            }
        }
    }
}
