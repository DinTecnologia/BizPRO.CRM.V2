using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ClientePerfilViewModel
    {
        public long? ClienteId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string TelefoneOriginal { get; set; }
        public string Email { get; set; }
        public bool Visualizar { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public Cidade Cidade { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
        public string Endereco { get; set; }
        public string Tipo { get; set; }
        public bool TrocarCliente { get; set; }

        public ClientePerfilViewModel()
        {
            Cidade = new Cidade();
            TrocarCliente = true;
        }

        public ClientePerfilViewModel(PessoaFisica entidade, string numeroTelefoneOriginal, Cidade cidade,
            bool trocarCliente)
        {
            Cidade = new Cidade();
            if (entidade.Id != 0)
                ClienteId = entidade.Id;
            Nome = entidade.Nome + " " + entidade.Sobrenome;
            Documento = entidade.Cpf;
            Email = entidade.Email;
            TelefoneOriginal = String.IsNullOrEmpty(numeroTelefoneOriginal) ? null : numeroTelefoneOriginal;
            Logradouro = entidade.Logradouro;
            Numero = entidade.Numero;
            Bairro = entidade.Bairro;
            Tipo = "PF";
            if (cidade != null)
            {
                Cidade.Uf = cidade.Uf;
                Cidade.Nome = cidade.Nome;
                Cidade.Id = cidade.Id;
            }
            Endereco = entidade.Logradouro == null ? "" : entidade.Logradouro + ",";
            Endereco += entidade.Numero != null ? entidade.Numero + "," : "";
            Endereco += entidade.Bairro != null ? entidade.Bairro + "," : "";
            Endereco += Cidade.Nome + ",";
            Endereco += Cidade.Uf + "";
            Endereco = Endereco.Trim();
            TrocarCliente = trocarCliente;
        }

        public ClientePerfilViewModel(PessoaJuridica entidade, string numeroTelefoneOriginal, Cidade cidade,
            bool trocarCliente)
        {
            Cidade = new Cidade();

            if (entidade.Id != 0)
                ClienteId = entidade.Id;
            Nome = entidade.RazaoSocial;
            Documento = entidade.Cnpj;
            Email = entidade.EmailPrincipal;
            TelefoneOriginal = String.IsNullOrEmpty(numeroTelefoneOriginal) ? null : numeroTelefoneOriginal;
            Logradouro = entidade.Logradouro;
            Numero = entidade.Numero;
            Bairro = entidade.Bairro;
            Tipo = "PJ";
            if (cidade != null)
            {
                Cidade.Uf = cidade.Uf;
                Cidade.Nome = cidade.Nome;
                Cidade.Id = cidade.Id;
            }

            Endereco = entidade.Logradouro == null ? "" : entidade.Logradouro + ",";
            Endereco += entidade.Numero != null ? entidade.Numero + "," : "";
            Endereco += entidade.Bairro != null ? entidade.Bairro + "," : "";
            Endereco += Cidade.Nome + ",";
            Endereco += Cidade.Uf + "";
            Endereco = Endereco.Trim();
            TrocarCliente = trocarCliente;
        }
    }
}
