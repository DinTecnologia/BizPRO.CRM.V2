using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL
{
    public interface IAtividadeFilaApoioRepositorioDal
    {

        long ObterTotalAtividadesFilaDal(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente,
            string assuntoAtividade);
    }
}
