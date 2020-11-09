using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class PessoaJuridicaContatosAppServico : IPessoaJuridicaContatosAppServico
    {
        private readonly IPessoaJuridicaContatoServico _pessoaJuridicaContatoServico;

        public PessoaJuridicaContatosAppServico(IPessoaJuridicaContatoServico pessoaJuridicaContatoServico)
        {
            _pessoaJuridicaContatoServico = pessoaJuridicaContatoServico;
        }

        public PessoaJuridicaContatoViewModel InserirContato(long pessoaFisicaId, long pessoaJuridicaId, string userId)
        {
            var retorno = _pessoaJuridicaContatoServico.InserirContato(pessoaFisicaId, pessoaJuridicaId, userId);
            var view = new PessoaJuridicaContatoViewModel(retorno.id, retorno.PessoasFisicasID, retorno.principal,
                retorno.tiposContatoPessoaJuridicaID, retorno.criadoEm, retorno.criadoPorUserID,
                retorno.PessoasJuridicasID);
            return view;
        }

        public IEnumerable<PessoaJuridicaContatoViewModel> ListarPessoaJuridicaContato(long? pessoaJuridicaId,
            long? pessoaFisicaId)
        {
            var lista = new List<PessoaJuridicaContatoViewModel>();
            var retorno = _pessoaJuridicaContatoServico.ListarContatos(pessoaJuridicaId, pessoaFisicaId);

            foreach (var item in retorno)
            {
                var listaPessoaJuridica =
                (new PessoaJuridicaFormViewModel(item.PessoaJuridica.RazaoSocial, item.PessoaJuridica.NomeFantasia,
                    item.PessoaJuridica.Cnpj, item.PessoaJuridica.DataDeConstituicao,
                    item.PessoaJuridica.InscricaoEstadual, item.PessoaJuridica.Id));
                var listaPessoaFisica =
                (new PessoaFisicaFormViewModel(item.PessoaFisica.Nome, item.PessoaFisica.Sobrenome,
                    item.PessoaFisica.Email, item.PessoaFisica.Cpf, item.PessoaFisica.CpfProprio,
                    item.PessoaFisica.DataNascimento, item.PessoaFisica.Id));
                var listaTipo =
                (new PessoaJuridicaTiposContatoViewModel(item.PessoaJuridicaTiposContato.id,
                    item.PessoaJuridicaTiposContato.nome, item.PessoaJuridicaTiposContato.ativo));
                lista.Add(new PessoaJuridicaContatoViewModel(item.id, item.PessoasFisicasID, item.PessoasJuridicasID,
                    listaPessoaFisica, listaTipo, listaPessoaJuridica));
            }

            return lista;
        }

        public IEnumerable<PessoaJuridicaContatoViewModel> InserirListarPessoaJuridicaContato(long pessoaFisicaId,
            long pessoaJuridicaId, string userId)
        {
            var lista =
                ListarPessoaJuridicaContato(pessoaJuridicaId, null)
                    .Where(
                        c => c.PessoasJuridicasId.Equals(pessoaJuridicaId) && c.PessoasFisicasId.Equals(pessoaFisicaId));
            if (lista.Any())
            {
                return ListarPessoaJuridicaContato(pessoaJuridicaId, null);
            }
            InserirContato(pessoaFisicaId, pessoaJuridicaId, userId);
            return ListarPessoaJuridicaContato(pessoaJuridicaId, null);
        }

        public IEnumerable<PessoaJuridicaContatoViewModel> InserirListarPessoaFisicaContato(long pessoaFisicaId,
            long pessoaJuridicaId, string userId)
        {
            var lista =
                ListarPessoaJuridicaContato(null, pessoaFisicaId)
                    .Where(
                        c => c.PessoasJuridicasId.Equals(pessoaJuridicaId) && c.PessoasFisicasId.Equals(pessoaFisicaId));
            if (lista.Any())
            {
                return ListarPessoaJuridicaContato(null, pessoaFisicaId);
            }
            InserirContato(pessoaFisicaId, pessoaJuridicaId, userId);
            return ListarPessoaJuridicaContato(null, pessoaFisicaId);
        }

        public PessoaJuridicaContatoViewModel AtualizarContato(long pessoaJuridicaTipoContatoId,
            long pessoaJuridicaContatoId, string userId)
        {
            var retorno = _pessoaJuridicaContatoServico.AtualizarContato(pessoaJuridicaTipoContatoId,
                pessoaJuridicaContatoId, userId);
            return new PessoaJuridicaContatoViewModel();
        }

        public PessoaJuridicaContatoViewModel DeletarContato(long pessoaJuridicaContatoId, string userId)
        {
            var retorno = _pessoaJuridicaContatoServico.DeletarContato(pessoaJuridicaContatoId, userId);
            return new PessoaJuridicaContatoViewModel();
        }

        public IEnumerable<PessoaJuridicaContatoViewModel> DeletarListarContatoPessoaJuridica(
            long pessoaJuridicaContatoId, long pessoaJuridicaId, string userId)
        {
            _pessoaJuridicaContatoServico.DeletarContato(pessoaJuridicaContatoId, userId);
            return ListarPessoaJuridicaContato(pessoaJuridicaId, null);
        }

        public IEnumerable<PessoaJuridicaContatoViewModel> DeletarListarContatoPessoaFisica(
            long pessoaJuridicaContatoId, long pessoaFisicaId, string userId)
        {
            _pessoaJuridicaContatoServico.DeletarContato(pessoaJuridicaContatoId, userId);
            return ListarPessoaJuridicaContato(null, pessoaFisicaId);
        }
    }
}
