using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebAtivosCEB
{
    public class Conexao
    {
        public static string HostBase = @"http://srvceb01";
        public static string APIAtivosBase = @"/ativosceb/api/";

        public static async Task<List<Categoria>> CarregarCategorias()
        {
            Categoria objCategoria = new Categoria();
            List<Categoria> lista = new List<Categoria>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "categoria").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Categoria>>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return lista;
        }

        public static async Task<List<Fabricante>> CarregarFabricantes()
        {
            Fabricante objFabricante = new Fabricante();
            List<Fabricante> lista = new List<Fabricante>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "fabricante").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Fabricante>>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return lista;
        }

        public static async Task<List<Local>> CarregarLocais()
        {
            Local objFabricante = new Local();
            List<Local> lista = new List<Local>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "local").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Local>>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return lista;
        }

        public static async Task<List<Piso>> CarregarPisos()
        {
            Piso objPiso = new Piso();
            List<Piso> lista = new List<Piso>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "piso").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Piso>>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return lista;
        }

        public static async Task<DataTable> CarregarTodosAtivos()
        {
            DataTable table = new DataTable();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "ativo").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                table = JsonConvert.DeserializeObject<DataTable>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return table;
        }

        public static async Task<DataTable> CarregarTodosReparos()
        {
            DataTable table = new DataTable();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "reparo").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                table = JsonConvert.DeserializeObject<DataTable>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return table;
        }

        public static async Task<DataTable> CarregarReparosPorAtivo(string idAtivo)
        {
            DataTable table = new DataTable();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "reparo?idAtivo=" + idAtivo).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                table = JsonConvert.DeserializeObject<DataTable>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return table;
        }

        public static async Task<Ativo> CarregarAtivosBuscaAvancadaNumeroSerie(string numeroSerie)
        {
            Ativo objAtivo = new Ativo();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "ativo?numeroSerie=" + numeroSerie).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                objAtivo = JsonConvert.DeserializeObject<Ativo>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return objAtivo;
        }

        public static async Task<Ativo> CarregarAtivosBuscaAvancadaPatrimonio(string patrimonio)
        {
            Ativo objAtivo = new Ativo();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "ativo?patrimonio=" + patrimonio).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                objAtivo = JsonConvert.DeserializeObject<Ativo>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return objAtivo;
        }

        public static async Task<Ativo> CarregarAtivosBuscaAvancadaServiceTag(string serviceTag)
        {
            Ativo objAtivo = new Ativo();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "ativo?serviceTag=" + serviceTag).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                objAtivo = JsonConvert.DeserializeObject<Ativo>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return objAtivo;
        }


        public static async Task<Ativo> CarregarAtivosPorId(string idAtivo)
        {
            Ativo objAtivo = new Ativo();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "ativo/" + idAtivo).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                objAtivo = JsonConvert.DeserializeObject<Ativo>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return objAtivo;
        }

        public static async Task<DataTable> CarregarAtivosPorCategorias(string idCategoria)
        {
            DataTable table = new DataTable();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "ativo?idCategoria=" + idCategoria).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                table = JsonConvert.DeserializeObject<DataTable>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return table;
        }

        public static async Task<DataTable> CarregarAtivosPorFabricante(string idFabricante)
        {
            DataTable table = new DataTable();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "ativo?idFabricante=" + idFabricante).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                table = JsonConvert.DeserializeObject<DataTable>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return table;
        }

        public static async Task<DataTable> CarregarAtivosPorLocal(string idLocal)
        {
            DataTable table = new DataTable();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "ativo?idLocal=" + idLocal).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                table = JsonConvert.DeserializeObject<DataTable>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return table;
        }

        public static async Task<String> ObterDescricaoPisos(string idPiso)
        {
            Piso objPiso = new Piso();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "piso/" + idPiso).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                objPiso = JsonConvert.DeserializeObject<Piso>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return objPiso.descPiso;
        }

        public static async Task<String> ObterDescricaoFabricantes(string idFabricante)
        {
            Fabricante objFabricante = new Fabricante();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "fabricante/" + idFabricante).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                objFabricante = JsonConvert.DeserializeObject<Fabricante>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return objFabricante.descFabricante;
        }

        public static async Task<String> ObterDescricaoCategoria(string idCategoria)
        {
            Categoria objCategoria = new Categoria();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "categoria/" + idCategoria).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                objCategoria = JsonConvert.DeserializeObject<Categoria>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return objCategoria.descCategoria;
        }

        public static async Task<String> ObterDescricaoLocais(string idLocal)
        {
            Local objLocal = new Local();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "local/" + idLocal).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                objLocal = JsonConvert.DeserializeObject<Local>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return objLocal.descLocal;
        }

        public static async Task AlterarCondicaoAtivo(string idAtivo, string condicao)
        {
            using (var client = new HttpClient())
            {
                var dados = new Dictionary<string, object>
                 {
                    {"condicao", condicao}
                 };

                var requestContent = new StringContent(JsonConvert.SerializeObject(dados));
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PatchAsync(new Uri(Conexao.HostBase + Conexao.APIAtivosBase + "ativo/AlterarCondicao/" + idAtivo), requestContent);
                var data = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        public static async Task FinalizarReparo(string idReparo, string dataRetorno, string situacao)
        {
            using (var client = new HttpClient())
            {
                var dados = new Dictionary<string, object>
                 {
                    {"dataRetorno", dataRetorno},
                    {"situacao", situacao}
                 };

                var requestContent = new StringContent(JsonConvert.SerializeObject(dados));
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PatchAsync(new Uri(Conexao.HostBase + Conexao.APIAtivosBase + "reparo/FinalizarReparo/" + idReparo), requestContent);
                var data = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        public static async Task InserirReparo(string idAtivo, string dataEnvio, string descDefeito, string situacao)
        {
            var values = new Dictionary<string, string>
                {
                    { "idAtivo", idAtivo },
                    { "dataEnvio", dataEnvio },
                    { "descDefeito", descDefeito },
                    { "situacao", situacao }
                };

            var dados = new FormUrlEncodedContent(values);

            using (var client = new HttpClient())
            {
                using (var res = await client.PostAsync(Conexao.HostBase + Conexao.APIAtivosBase + "reparo", dados))
                {
                    using (HttpContent content = res.Content)
                    {
                        var responseString = await content.ReadAsStringAsync();
                    }
                }
            }
        }

        public static async Task InserirAtivo(string item, string idPiso, string idLocal, string idCategoria, string idFabricante, string modelo, string dataRegistro,
            string comentarios, string condicao, string patrimonio, string garantia, string numeroSerie, string serviceTag, string valor)
        {
            var values = new Dictionary<string, string>
                {
                    { "item", item },
                    { "idPiso", idPiso },
                    { "idLocal", idLocal },
                    { "idFabricante", idFabricante },
                    { "idCategoria", idCategoria },
                    { "modelo", modelo },
                    { "dataRegistro", dataRegistro },
                    { "comentarios", comentarios },
                    { "condicao", condicao },
                    { "patrimonio", patrimonio },
                    { "garantia", garantia },
                    { "numeroSerie", numeroSerie },
                    { "serviceTag", serviceTag },
                };

            var dados = new FormUrlEncodedContent(values);

            using (var client = new HttpClient())
            {
                using (var res = await client.PostAsync(Conexao.HostBase + Conexao.APIAtivosBase + "ativo", dados))
                {
                    using (HttpContent content = res.Content)
                    {
                        var responseString = await content.ReadAsStringAsync();
                    }
                }
            }
        }

        public static async Task AtualizarAtivo(string idAtivo, string item, string modelo, string comentarios, string patrimonio, string numeroSerie,
            string serviceTag, string valor)
        {
            using (var client = new HttpClient())
            {
                var dados = new Dictionary<string, object>
                 {
                    { "item", item },
                    { "modelo", modelo },
                    { "comentarios", comentarios },
                    { "patrimonio", patrimonio },
                    { "numeroSerie", numeroSerie },
                    { "serviceTag", serviceTag },
                    { "valor", valor }
                 };

                var requestContent = new StringContent(JsonConvert.SerializeObject(dados));
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PutAsync(new Uri(Conexao.HostBase + Conexao.APIAtivosBase + "ativo/" + idAtivo), requestContent);
                var data = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        public static async Task AlterarPisoAtivo(string idAtivo, string idPiso)
        {
            using (var client = new HttpClient())
            {
                var dados = new Dictionary<string, object>
                 {
                    {"idPiso", idPiso}
                 };

                var requestContent = new StringContent(JsonConvert.SerializeObject(dados));
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PatchAsync(new Uri(Conexao.HostBase + Conexao.APIAtivosBase + "ativo/AlterarPisoAtivo/" + idAtivo), requestContent);
                var data = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        public static async Task AlterarLocalAtivo(string idAtivo, string idLocal)
        {
            using (var client = new HttpClient())
            {
                var dados = new Dictionary<string, object>
                 {
                    {"idLocal", idLocal}
                 };

                var requestContent = new StringContent(JsonConvert.SerializeObject(dados));
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PatchAsync(new Uri(Conexao.HostBase + Conexao.APIAtivosBase + "ativo/AlterarLocalAtivo/" + idAtivo), requestContent);
                var data = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        public static async Task AlterarFabricanteAtivo(string idAtivo, string idFabricante)
        {
            using (var client = new HttpClient())
            {
                var dados = new Dictionary<string, object>
                 {
                    {"idFabricante", idFabricante}
                 };

                var requestContent = new StringContent(JsonConvert.SerializeObject(dados));
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PatchAsync(new Uri(Conexao.HostBase + Conexao.APIAtivosBase + "ativo/AlterarFabricanteAtivo/" + idAtivo), requestContent);
                var data = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        public static async Task AlterarCategoriaAtivo(string idAtivo, string idCategoria)
        {
            using (var client = new HttpClient())
            {
                var dados = new Dictionary<string, object>
                 {
                    {"idCategoria", idCategoria}
                 };

                var requestContent = new StringContent(JsonConvert.SerializeObject(dados));
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PatchAsync(new Uri(Conexao.HostBase + Conexao.APIAtivosBase + "ativo/AlterarCategoriaAtivo/" + idAtivo), requestContent);
                var data = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        public static async Task InformarGarantiaAtivo(string idAtivo, string garantia)
        {
            using (var client = new HttpClient())
            {
                var dados = new Dictionary<string, object>
                 {
                    {"garantia", garantia}
                 };

                var requestContent = new StringContent(JsonConvert.SerializeObject(dados));
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PatchAsync(new Uri(Conexao.HostBase + Conexao.APIAtivosBase + "ativo/InformarGarantiaAtivo/" + idAtivo), requestContent);
                var data = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        public static async Task DescontinuarAtivo(string idAtivo, string dataRetirada, string condicao)
        {
            using (var client = new HttpClient())
            {
                var dados = new Dictionary<string, object>
                 {
                    {"dataRetirada", dataRetirada},
                    {"condicao", condicao}
                 };

                var requestContent = new StringContent(JsonConvert.SerializeObject(dados));
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PatchAsync(new Uri(Conexao.HostBase + Conexao.APIAtivosBase + "ativo/DescontinuarAtivo/" + idAtivo), requestContent);
                var data = response.Content.ReadAsStringAsync().Result.ToString();
            }
        }

        public static String ObterUltimoIdInserido()
        {
            Task<DataTable> table = CarregarTodosAtivos();
            List<string> listaAtivos = new List<string>();
            for (int i = 0; i < table.Result.Rows.Count; i++)
            {
                listaAtivos.Add(table.Result.Rows[i].ItemArray[0].ToString());
            }
            return listaAtivos[listaAtivos.Count - 1];
        }

        public static async Task CriarCategoria(string descCategoria)
        {
            var values = new Dictionary<string, string>
                {
                    { "descCategoria", descCategoria }
                };

            var dados = new FormUrlEncodedContent(values);

            using (var client = new HttpClient())
            {
                using (var res = await client.PostAsync(Conexao.HostBase + Conexao.APIAtivosBase + "categoria", dados))
                {
                    using (HttpContent content = res.Content)
                    {
                        var responseString = await content.ReadAsStringAsync();
                    }
                }
            }
        }

        public static async Task CriarLocal(string descLocal)
        {
            var values = new Dictionary<string, string>
                {
                    { "descLocal", descLocal }
                };

            var dados = new FormUrlEncodedContent(values);

            using (var client = new HttpClient())
            {
                using (var res = await client.PostAsync(Conexao.HostBase + Conexao.APIAtivosBase + "local", dados))
                {
                    using (HttpContent content = res.Content)
                    {
                        var responseString = await content.ReadAsStringAsync();
                    }
                }
            }
        }

        public static async Task CriarFabricante(string descFabricante)
        {
            var values = new Dictionary<string, string>
                {
                    { "descFabricante", descFabricante }
                };

            var dados = new FormUrlEncodedContent(values);

            using (var client = new HttpClient())
            {
                using (var res = await client.PostAsync(Conexao.HostBase + Conexao.APIAtivosBase + "fabricante", dados))
                {
                    using (HttpContent content = res.Content)
                    {
                        var responseString = await content.ReadAsStringAsync();
                    }
                }
            }
        }

        public static async Task RegistrarLog(string data, string hora, string mensagem, string idAtivo)
        {
            var values = new Dictionary<string, string>
                {
                    { "data", data },
                    { "hora", hora },
                    { "mensagem", mensagem },
                    { "idAtivo", idAtivo }
                };

            var dados = new FormUrlEncodedContent(values);

            using (var client = new HttpClient())
            {
                using (var res = await client.PostAsync(Conexao.HostBase + Conexao.APIAtivosBase + "log", dados))
                {
                    using (HttpContent content = res.Content)
                    {
                        var responseString = await content.ReadAsStringAsync();
                    }
                }
            }
        }

        public static async Task<DataTable> CarregarLogs()
        {
            DataTable table = new DataTable();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Conexao.HostBase);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "log").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                table = JsonConvert.DeserializeObject<DataTable>(json);
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
            }
            return table;
        }

        //public static async Task<DataTable> CarregarLogs()
        //{
        //    DataTable table = new DataTable();
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(Conexao.HostBase);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    HttpResponseMessage response = client.GetAsync(Conexao.APIAtivosBase + "log").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var json = await response.Content.ReadAsStringAsync();
        //        table = JsonConvert.DeserializeObject<DataTable>(json);
        //    }
        //    else
        //    {
        //        //ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroBuscaDados(); });", true);
        //    }
        //    return table;
        //}
    }

    //CLASSE AUXILIAR MÉTODO PATCH (NÃO APAGAR)
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent iContent)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = iContent
            };

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.SendAsync(request);
            }
            catch
            {
                //Debug.WriteLine("ERROR: " + e.ToString());
            }

            return response;
        }
    }
};