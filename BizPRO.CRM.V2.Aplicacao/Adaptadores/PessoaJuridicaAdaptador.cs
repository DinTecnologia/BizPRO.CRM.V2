using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Adaptadores
{
    public class PessoaJuridicaAdaptador
    {
        public static PessoaJuridica ParaDominioModelo(PessoaJuridicaFormViewModel registro)
        {
            var pessoaJuridica = new PessoaJuridica(registro.RazaoSocial,
                registro.NomeFantasia,
                registro.Cnpj.Replace(".", "").Replace("/", "").Replace("-", ""),
                registro.InscricaoEstadual,
                registro.DataDeConstituicao,
                registro.CriadoPor,
                registro.EmailPrincipal,
                registro.CriadoEm,
                registro.Logradouro,
                registro.Numero,
                registro.Bairro,
                registro.CidadesId,
                registro.Complemento,
                registro.CodigoPostal,
                registro.Id,
                registro.AceitaComunicados,
                registro.CanalEntidadesCamposValoresId,
                registro.TipoEntidadesCamposValoresId,
                registro.AtendimentoId);
            return pessoaJuridica;
        }

        public static PessoaJuridicaFormViewModel ParaAplicacaoViewModel(PessoaJuridica registro)
        {
            var pessoaJuridicaFormViewModel = new PessoaJuridicaFormViewModel(registro.RazaoSocial,
                registro.NomeFantasia,
                registro.Cnpj,
                registro.InscricaoEstadual,
                registro.DataDeConstituicao,
                registro.CriadoPorUserId,
                registro.EmailPrincipal,
                registro.ValidationResult,
                registro.Id,
                registro.AceitaComunicados,
                registro.CanalEntidadesCamposValoresId,
                registro.TipoEntidadesCamposValoresId
            );
            return pessoaJuridicaFormViewModel;
        }
    }
}
