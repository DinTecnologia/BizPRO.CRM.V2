using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IEmailTodosAnexosAppServico
    {
        TodosAnexosViewModel TodosAnexos(long atividadeId);
    }
}
