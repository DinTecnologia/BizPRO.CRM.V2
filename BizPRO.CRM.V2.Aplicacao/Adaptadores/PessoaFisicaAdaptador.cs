using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Adaptadores
{
    public class PessoaFisicaAdaptador
    {
        public static PessoaFisica ParaDominioModelo(PessoaFisicaFormViewModel registro)
        {
            var pessoaFisica = new PessoaFisica(
                registro.Id,
                registro.Nome,
                registro.Sobrenome,
                registro.Cpf.Replace(".", "").Replace("-", ""),
                registro.CpfProprio,
                registro.DataNascimento,
                registro.CriadoPor,
                registro.OutroDocumento,
                registro.Logradouro,
                registro.Numero,
                registro.Bairro,
                registro.CidadesId,
                registro.Complemento,
                registro.CodigoPostal,
                registro.Email,
                registro.AceitaComunicados,
                registro.CanalEntidadesCamposValoresId,
                registro.TipoEntidadesCamposValoresId,
                registro.AtendimentoId
            );
            return pessoaFisica;
        }

        public static PessoaFisicaFormViewModel ParaAplicacaoViewModel(PessoaFisica registro)
        {
            var pessoaFisicaFormViewModel = new PessoaFisicaFormViewModel(registro.Nome,
                registro.Sobrenome,
                registro.Cpf,
                registro.CpfProprio,
                registro.DataNascimento,
                registro.CriadoPorUserId,
                registro.ValidationResult,
                registro.Id,
                registro.AceitaComunicados,
                registro.CanalEntidadesCamposValoresId,
                registro.TipoEntidadesCamposValoresId
            );
            return pessoaFisicaFormViewModel;
        }
    }
}
