using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using BizPRO.CRM.V2.Identity.Model;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class RoleAdminAppServico : IRoleAdminAppServico
    {
        private readonly IRoleClaimServico _servicoRoleClaim;
        private readonly IAspNetMatrizServico _servicoAspNetMatriz;

        public RoleAdminAppServico(IRoleClaimServico servicoRoleClaim, IAspNetMatrizServico servicoAspNetMatriz)
        {
            _servicoRoleClaim = servicoRoleClaim;
            _servicoAspNetMatriz = servicoAspNetMatriz;
        }

        public IEnumerable<MatrizClaim> Editar(string roleID, List<Claims> claims)
        {
            var model = new List<MatrizClaim>();
            var claimsPerfil = _servicoRoleClaim.ObteRoleClaims(roleID);

            //Claims
            foreach (var claim in claims)
            {
                var a = new MatrizClaim();
                a.Nome = claim.Name;
                a.ID = claim.Id.ToString();
                var subClaims = _servicoAspNetMatriz.ObterPor(claim.Id.ToString(), "Y");

                //SubItens
                foreach (var subClaim in subClaims)
                {
                    var subClaimModel = new SubClaim {Nome = subClaim.Texto};

                    var subClaimColunaA = new SubClaimColuna
                    {
                        valor = claim.Id + "|" + claim.Name + "|" + subClaim.Valor + "EU",
                        valorLimpo = subClaim.Valor + "EU"
                    };

                    var subClaimColunaB = new SubClaimColuna
                    {
                        valor = claim.Id + "|" + claim.Name + "|" + subClaim.Valor + "OUTROS",
                        valorLimpo = subClaim.Valor + "OUTROS"
                    };

                    var subClaimColunaC = new SubClaimColuna
                    {
                        valor = claim.Id + "|" + claim.Name + "|" + subClaim.Valor + "ORGANIZACAO",
                        valorLimpo = subClaim.Valor + "ORGANIZACAO"
                    };

                    foreach (var item in claimsPerfil)
                    {
                        if (item.claimType == claim.Name)
                        {
                            if (item.claimValue == subClaimColunaA.valorLimpo)
                                subClaimColunaA.selecionado = true;

                            if (item.claimValue == subClaimColunaB.valorLimpo)
                                subClaimColunaB.selecionado = true;

                            if (item.claimValue == subClaimColunaC.valorLimpo)
                                subClaimColunaC.selecionado = true;
                        }
                    }

                    subClaimModel.Colunas.Add(subClaimColunaA);
                    subClaimModel.Colunas.Add(subClaimColunaB);
                    subClaimModel.Colunas.Add(subClaimColunaC);
                    a.SubClaims.Add(subClaimModel);
                }

                model.Add(a);
            }

            return model;
        }

        public bool Atualizar(RoleViewModel model)
        {
            _servicoRoleClaim.Deletar(model.Id);

            if (model.selectedClaims != null)
                foreach (var item in model.selectedClaims)
                {
                    //CLAIMID|CLAIMTYPE|ClaimVALUE
                    var aspNetRolesClaim = new RoleClaim()
                    {
                        claimID = item.Split('|')[0],
                        claimType = item.Split('|')[1],
                        claimValue = item.Split('|')[2],
                        roleID = model.Id
                    };
                    _servicoRoleClaim.Adicionar(aspNetRolesClaim);
                }

            _servicoRoleClaim.AtualizarUsuariosNovaRoleClaim(model.Id);
            return true;
        }
    }
}