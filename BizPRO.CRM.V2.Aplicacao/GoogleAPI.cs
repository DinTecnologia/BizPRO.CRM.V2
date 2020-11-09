using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class GoogleAPI
    {
        protected static dynamic ConsultarApiGoogle(string endereco, string chave)
        {
            try
            {
                //var url =
                //    string.Format(
                //        "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key=AIzaSyDPNtA5l-75cZgoMPvgsVC8vzLealNnouQ",
                //        endereco.Replace(" ", "+"));

                if (string.IsNullOrEmpty(chave))
                    chave = "AIzaSyDPNtA5l-75cZgoMPvgsVC8vzLealNnouQ";


                var url =
                    string.Format(
                        "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}",
                        endereco.Replace(" ", "+"), chave);

                var resultado = new System.Net.WebClient().DownloadString(url);
                var jss = new JavaScriptSerializer();
                return jss.Deserialize<dynamic>(resultado);
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public static double ObterLatitudeLongitudePorEndereco(string chave, string cep, string logradouro,
        //    string numero, string bairro, string cidade, string uf, out double longitude)
        //{
        //    var latitude = 0;
        //    longitude = 0;

        //    for (int i = 0; i < 6; i++)
        //    {
        //        var endereco = "";
        //        switch (i)
        //        {
        //            case 0:
        //                endereco = RemoverAcentuacao(logradouro) + "," + RemoverAcentuacao(numero) + "," +
        //                           RemoverAcentuacao(bairro) + "," + RemoverAcentuacao(cidade) + "," +
        //                           RemoverAcentuacao(uf) + "," + RemoverAcentuacao(cep) + ",Brasil";
        //                break;
        //            case 1:
        //                endereco = cep;
        //                break;
        //            case 2:
        //                endereco = logradouro + "," + bairro + "," + cidade + "," + uf + ",Brasil";
        //                break;
        //            case 3:
        //                endereco = bairro + "," + cidade + "," + uf + ",Brasil";
        //                break;
        //            case 4:
        //                endereco = cidade + "," + uf + ",Brasil";
        //                break;
        //            case 5:
        //                endereco = uf + ",Brasil";
        //                break;
        //        }

        //        var retornoApi = ConsultarApiGoogle(endereco, chave);

        //        try
        //        {
        //            if (retornoApi != null)
        //            {
        //                if (retornoApi["status"] == "OK")
        //                {
        //                    try
        //                    {
        //                        dynamic[] resultado = retornoApi["results"];
        //                        longitude = Convert.ToDouble(resultado[0]["geometry"]["location"]["lng"]);
        //                        latitude = Convert.ToDouble(resultado[0]["geometry"]["location"]["lat"]);
        //                    }
        //                    catch
        //                    {
        //                        latitude = double.MinValue;
        //                        longitude = double.MinValue;
        //                    }

        //                    if (longitude != double.MinValue && latitude != double.MinValue)
        //                        break;
        //                }
        //            }
        //            else
        //            {

        //            }
        //        }
        //        catch (Exception)
        //        {
        //            //definir qual vai ser o tipo de monitoramento de erros do CRM produto}
        //        }
        //    }

        //    return latitude;
        //}

        public static DadosEnderecoGoogle ObterLatitudeLongitudePorEndereco(string chave, string cep, string logradouro,
            string numero, string bairro, string cidade, string uf)
        {
            var retorno = new DadosEnderecoGoogle();
            var sbEndereco = new StringBuilder();

            if (!string.IsNullOrEmpty(logradouro))
            {
                sbEndereco.Append(RemoverAcentuacao(logradouro) + ",");
            }
            else
            {
                sbEndereco.Append(",");
            }


            if (!string.IsNullOrEmpty(numero) && numero != ".")
            {
                sbEndereco.Append(RemoverAcentuacao(numero) + ",");
            }
            else
            {
                sbEndereco.Append(",");
            }


            if (!string.IsNullOrEmpty(bairro) && bairro != ".")
            {
                sbEndereco.Append(RemoverAcentuacao(bairro) + ",");
            }
            else
            {
                sbEndereco.Append(",");
            }

            if (!string.IsNullOrEmpty(cidade) && cidade != ".")
            {
                sbEndereco.Append(RemoverAcentuacao(cidade) + ",");
            }
            else
            {
                sbEndereco.Append(",");
            }


            if (!string.IsNullOrEmpty(uf) && uf != ".")
            {
                sbEndereco.Append(RemoverAcentuacao(uf) + ",");
            }
            else
            {
                sbEndereco.Append(",");
            }

            if (!string.IsNullOrEmpty(cep) && cep != ".")
            {
                sbEndereco.Append(RemoverAcentuacao(cep) + ",");
            }
            else
            {
                sbEndereco.Append(",");
            }

            sbEndereco.Append("Brasil");
            var retornoApi = ConsultarApiGoogle(sbEndereco.ToString(), chave);

            try
            {
                if (retornoApi["status"] == "OK")
                {
                    dynamic[] resultado = retornoApi["results"];

                    foreach (var resultadoApi in resultado)
                    {
                        retorno.Enderecos.Add(new EnderecoRetornoGoogle
                        {
                            Longitude = Convert.ToDouble(resultadoApi["geometry"]["location"]["lng"]),
                            Latidude = Convert.ToDouble(resultadoApi["geometry"]["location"]["lat"])
                        });
                    }

                    //retorno.Enderecos.Add(new EnderecoRetornoGoogle
                    //{
                    //    Longitude = Convert.ToDouble(resultado[0]["geometry"]["location"]["lng"]),
                    //    Latidude = Convert.ToDouble(resultado[0]["geometry"]["location"]["lat"])
                    //});
                }
                else
                {
                    retorno.ValidationResult.Add(new ValidationError(retornoApi["error_message"]));
                }
            }
            catch (Exception ex)
            {
                retorno.ValidationResult.Add(new ValidationError(ex.Message));
            }

            return retorno;
        }

        public static string RemoverAcentuacao(string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }


    public class DadosEnderecoGoogle
    {
        public List<EnderecoRetornoGoogle> Enderecos { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public DadosEnderecoGoogle()
        {
            ValidationResult = new ValidationResult();
            Enderecos = new List<EnderecoRetornoGoogle>();
        }
    }

    public class EnderecoRetornoGoogle
    {
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public double? Longitude { get; set; }
        public double? Latidude { get; set; }
    }
}