using System;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace BizPRO.CRM.V2.Aplicacao.Adaptadores
{
    public class OcorrenciaAdaptador
    {
        public static Ocorrencia ParaDominioModelo(OcorrenciaFormViewModel model)
        {
            return new Ocorrencia(Convert.ToInt32(model.ocorrenciasTiposID), model.decritivoDeAbertura,
                model.pessoaFisicaID, model.pessoaJuridicaID, model.contratoID, model.criadoPorUserID, model.CampoChave1, model.Previsao);
        }
    }
}
