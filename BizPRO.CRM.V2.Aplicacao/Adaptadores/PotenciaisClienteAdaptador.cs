using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Adaptadores
{
    public class PotenciaisClienteAdaptador
    {
        public static PotenciaisCliente ParaDominioModelo(PotenciaisClienteViewModel registro)
        {
            var potenciaisCliente = new PotenciaisCliente(
                registro.id,
                registro.nome,
                registro.documento == null
                    ? null
                    : registro.documento.Replace("-", "").Replace("/", "").Replace(".", "").Trim(),
                registro.contato,
                registro.contatoDocumento == null
                    ? null
                    : registro.contatoDocumento.Replace("-", "").Replace("/", "").Replace(".", "").Trim(),
                registro.email,
                registro.logradouro,
                registro.numero,
                registro.bairro,
                registro.CidadesID,
                registro.criadoPorAspNetUserID,
                registro.tipo,
                registro.cep,
                registro.contatoEmail,
                registro.alteradoPorAspNetUserID,
                registro.convertidoEmClienteEm,
                registro.convertidoEmClientePorAspNetUserID,
                registro.convertidoEmClientePessoasFisicasID,
                registro.convertidoEmClientePessoasJuridicasID
            );
            return potenciaisCliente;
        }
    }
}
