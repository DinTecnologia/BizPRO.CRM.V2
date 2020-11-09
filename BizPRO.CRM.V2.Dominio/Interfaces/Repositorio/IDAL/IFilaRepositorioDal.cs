using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL
{
    public interface IFilaRepositorioDal
    {
        IEnumerable<Fila> ObterFilasPorUsuarioDal(string userId, bool? aceitaLigacao, bool? aceitaEmail,
            bool? aceitaTarefa, bool? aceitaChatSms, bool? aceitaChatWeb, bool? aceitaChatMessenger, bool? ativo);

        Fila ObterPorIdDal(int filaId);
    }
}
