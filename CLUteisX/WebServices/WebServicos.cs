using CLUteisX.WebServices.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CLUteisX.WebServices
{
    public static class WebServicos
    {
        public async static Task<WebCEPModel> PesquisaCEP(string _cep)
        {
            WebCEPModel modelwebcep = new WebCEPModel();
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("https://viacep.com.br/ws/" + _cep + "/json"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var resposta = await response.Content.ReadAsStringAsync();
                            modelwebcep = JsonConvert.DeserializeObject<WebCEPModel>(resposta);
                        }
                    }
                }

                return modelwebcep;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async static Task<WebDadosCNPJModel> PesquisaCnpj(string cnpj)
        {
            WebDadosCNPJModel modelwebcnpj = new WebDadosCNPJModel();
            modelwebcnpj = null;
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("https://www.receitaws.com.br/v1/cnpj/" + cnpj))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var resposta = await response.Content.ReadAsStringAsync();
                            modelwebcnpj = JsonConvert.DeserializeObject<WebDadosCNPJModel>(resposta);
                        }
                    }
                }
                return modelwebcnpj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ProdutoDTO> PesquisaIBPT(string token, string cnpj, string codigo, string uf, int ex, 
                                                 string codigoInterno = "", string descricao = "", string unidadeMedida = "", decimal valor = 0, string gtin = "")
        {
            //https://apidoni.ibpt.org.br/api/v1/produtos?token=rtPTNlMg0SPLTHkhhph4AdhjraYe6Jrv2EvZBhzhXNcAapv6xy2dL4XSs1vNPkoW&cnpj=02468872000104&codigo=85437099&uf=SP&ex=0&codigoInterno=0&descricao=sat%20dimep&unidadeMedida=un&valor=0&gtin=sem%20gtin

            try
            {
                using (var client = new HttpClient())
                {
                    var url = string.Format("https://apidoni.ibpt.org.br/api/v1/produtos?token={0}&cnpj={1}&codigo={2}&uf={3}&ex={4}&codigoInterno={5}&descricao={6}&unidadeMedida={7}&valor={8}&gtin={9}", 
                                            token, cnpj, codigo, uf, ex, codigoInterno, descricao, unidadeMedida, valor.ToString().Replace(",","."), gtin);

                    using (var _response = await client.GetAsync(url))
                    {
                        if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var _resposta = await _response.Content.ReadAsStringAsync();

                            return JsonConvert.DeserializeObject<ProdutoDTO>(_resposta);
                        }
                        else
                        {
                            throw new Exception(_response.ReasonPhrase);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
