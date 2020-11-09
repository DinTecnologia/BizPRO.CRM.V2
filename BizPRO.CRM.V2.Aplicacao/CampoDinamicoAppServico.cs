using System.Linq;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class CampoDinamicoAppServico : ICampoDinamicoAppServico
    {
        private readonly IOcorrenciaServico _ocorrenciaServico;
        private readonly ICampoDinamicoOpcaoServico _campoDinamicoOpcaoServico;

        public CampoDinamicoAppServico(IOcorrenciaServico ocorrenciaServico,
            ICampoDinamicoOpcaoServico campoDinamicoOpcaoServico)
        {
            _ocorrenciaServico = ocorrenciaServico;
            _campoDinamicoOpcaoServico = campoDinamicoOpcaoServico;
        }

        public CampoDinamicoBuscaViewModel ObterOcorrenciaOriginal(CampoDinamicoBuscaViewModel model)
        {
            if (!model.PossuiParametroPesquisa())
                return model;

            var ocorrencias = _ocorrenciaServico.ObterOcorrenciasOriginal(model.NomeCliente, model.Protocolo,
                model.PessoaJuridicaId, model.PessoaFisicaId, model.OcorrenciaId);

            if (!ocorrencias.Any())
                return model;

            foreach (var ocorrencia in ocorrencias)
            {
                model.Items.Add(new ItemOcorrenciaOriginalViewModel(ocorrencia, model.ComponenteId));
            }

            return model;
        }

        public string ObterNomeOcorrenciaOriginal(long ocorrenciaId)
        {
            var ocorrencias = _ocorrenciaServico.ObterOcorrenciasOriginal(null, null, null, null, ocorrenciaId);

            if (!ocorrencias.Any())
                return "Id Ocorrência Vinculada Não Encontrado";

            var ocorrencia = ocorrencias.FirstOrDefault();
            var cliente = ocorrencia.PessoaFisica != null
                ? ocorrencia.PessoaFisica.Nome
                : ocorrencia.PessoaJuridica != null ? ocorrencia.PessoaJuridica.NomeFantasia : "--";
            return string.Format("{0} | {1} | {2}", cliente, ocorrencia.OcorrenciaTipo.NomeExibicao,
                ocorrencia.CriadoEm);
        }

        public IEnumerable<CampoDinamicoOpcao> ObterOpcoes(int campoDinamicoId,long? id, string termo, int? quantidade)
        {
            return _campoDinamicoOpcaoServico.BuscaPor(campoDinamicoId, termo, quantidade);
        }
    }
}
