using BizPRO.CRM.V2.Aplicacao.Interfaces;
using System;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class OcorrenciaXstatusEntidadeAppServico : IOcorrenciaXstatusEntidadeAppServico
    {
        private readonly IOcorrenciaXstatusEntidadeApoioServico _ocorrenciaXstatusEntidadeServico;
        public OcorrenciaXstatusEntidadeAppServico(IOcorrenciaXstatusEntidadeApoioServico ocorrenciaXstatusEntidadeServico)
        {
            _ocorrenciaXstatusEntidadeServico = ocorrenciaXstatusEntidadeServico;
        }

        public OcorrenciaXstatusEntidadeViewModel LIstarOcorrenciaXstatusEntidade(string userId, string dataInicio,
            string dataFim, string status, string cliente, long? ocorrenciaTipoId)
        {
            DateTime data;
            DateTime? DataInicio;
            DateTime? DataFim;

            if (DateTime.TryParse(dataInicio, out data))
            {
                DataInicio = data;
            }
            else
            {
                DataInicio = null;
            }

            if (DateTime.TryParse(dataFim, out data))
            {
                DataFim = data;
            }
            else
            {
                DataFim = null;
            }
            var view = new OcorrenciaXstatusEntidadeViewModel
            {
                listarOcorrenciaXstatusEntidadeApoio =
                    _ocorrenciaXstatusEntidadeServico.ListarOcorrenciaXstatusEntidadeApoio(userId, DataInicio, DataFim,
                        status, cliente, ocorrenciaTipoId).Take(300)
            };
            return view;
        }
    }
}
