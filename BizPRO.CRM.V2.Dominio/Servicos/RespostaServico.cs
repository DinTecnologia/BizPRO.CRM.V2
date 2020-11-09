using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class RespostaServico : Servico<Resposta>, IRespostaServico
    {
         private readonly IRespostaRepositorio _repositorio;

         public RespostaServico(IRespostaRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
