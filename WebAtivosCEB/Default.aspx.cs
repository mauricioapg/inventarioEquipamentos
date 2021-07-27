using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAtivosCEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = Server.MapPath("RelatorioCategoria.rpt").ToString();
            //PreencherGridTodos();
            DesabilitarCacheCaixasTexto();
            PopularFabricantes();
            PopularCategorias();
            PopularLocais();
            PopularNovaCategoria();
            PopularNovoFabricante();
            PopularNovoLocal();
            PopularNovoPiso();
        }

        private void DesabilitarCacheCaixasTexto()
        {
            txtItem.Attributes.Add("autocomplete", "off");
            txtModelo.Attributes.Add("autocomplete", "off");
            txtPatrimonio.Attributes.Add("autocomplete", "off");
            txtNumeroSerie.Attributes.Add("autocomplete", "off");
            txtServiceTag.Attributes.Add("autocomplete", "off");
            txtValor.Attributes.Add("autocomplete", "off");
            txtBuscaPatrimonio.Attributes.Add("autocomplete", "off");
            txtBuscaNumeroSerie.Attributes.Add("autocomplete", "off");
            txtBuscaServiceTag.Attributes.Add("autocomplete", "off");
        }

        private Boolean ValidarCamposInserir()
        {
            if (txtItem.Text == "" || txtModelo.Text == "" || txtPatrimonio.Text == "")
            {
                Session["erroInserir"] = "Os campos 'Item', 'Modelo' e 'Patrimônio' são de preenchimento obrigatório";
                return true;
            }
            else if (ObterListaPatrimonios().Contains(txtPatrimonio.Text))
            {
                Session["erroInserir"] = "Este patrimônio já existe na base de dados";
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean VerificarPatrimonio(string patrimonio)
        {
            if (patrimonio != "" && ObterListaPatrimonios().Contains(patrimonio))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void PreencherGridTodos()
        {
            gridViewDados.DataSource = Conexao.CarregarTodosAtivos().Result;
            gridViewDados.DataBind();
        }

        private void PreencherGridFabricante()
        {
            gridViewDados.DataSource = Conexao.CarregarAtivosPorFabricante(DropDownListFabricantes.SelectedValue).Result;
            gridViewDados.DataBind();
        }

        private void PreencherGridCategoria()
        {
            gridViewDados.DataSource = Conexao.CarregarAtivosPorCategorias(DropDownListCategorias.SelectedValue).Result;
            gridViewDados.DataBind();
        }

        private void PreencherGridLocal()
        {
            gridViewDados.DataSource = Conexao.CarregarAtivosPorLocal(DropDownListLocais.SelectedValue).Result;
            gridViewDados.DataBind();
        }

        private List<Ativo> ObterListaBuscaPatrimonio()
        {
            List<Ativo> lista = new List<Ativo>();
            lista.Add(Conexao.CarregarAtivosBuscaAvancadaPatrimonio(txtBuscaPatrimonio.Text).Result);
            return lista;
        }

        private List<Ativo> ObterListaBuscaNumeroSerie()
        {
            List<Ativo> lista = new List<Ativo>();
            lista.Add(Conexao.CarregarAtivosBuscaAvancadaNumeroSerie(txtBuscaNumeroSerie.Text).Result);
            return lista;
        }

        private List<Ativo> ObterListaBuscaServiceTag()
        {
            List<Ativo> lista = new List<Ativo>();
            lista.Add(Conexao.CarregarAtivosBuscaAvancadaServiceTag(txtBuscaServiceTag.Text).Result);
            return lista;
        }

        private void PreencherGridBuscaAvancada()
        {
            if (RadioButtonListFiltrosBuscaAvancada.SelectedItem.Text == "Patrimônio")
            {
                gridViewDados.DataSource = ObterListaBuscaPatrimonio();
                gridViewDados.DataBind();
            }
            else if (RadioButtonListFiltrosBuscaAvancada.SelectedItem.Text == "Nº de Série")
            {
                gridViewDados.DataSource = ObterListaBuscaNumeroSerie();
                gridViewDados.DataBind();
            }
            else if (RadioButtonListFiltrosBuscaAvancada.SelectedItem.Text == "ServiceTag")
            {
                gridViewDados.DataSource = ObterListaBuscaServiceTag();
                gridViewDados.DataBind();
            }
        }

        private void PopularFabricantes()
        {
            if (!IsPostBack)
            {
                DropDownListFabricantes.DataSource = Conexao.CarregarFabricantes().Result;
                DropDownListFabricantes.DataValueField = "idFabricante";
                DropDownListFabricantes.DataTextField = "descFabricante";
                DropDownListFabricantes.DataBind();
            }
        }

        private void PopularCategorias()
        {
            if (!IsPostBack)
            {
                DropDownListCategorias.DataSource = Conexao.CarregarCategorias().Result;
                DropDownListCategorias.DataValueField = "idCategoria";
                DropDownListCategorias.DataTextField = "descCategoria";
                DropDownListCategorias.DataBind();
            }
        }

        private void PopularLocais()
        {
            if (!IsPostBack)
            {
                DropDownListLocais.DataSource = Conexao.CarregarLocais().Result;
                DropDownListLocais.DataValueField = "idLocal";
                DropDownListLocais.DataTextField = "descLocal";
                DropDownListLocais.DataBind();
            }
        }

        private void PopularNovoFabricante()
        {
            if (!IsPostBack)
            {
                DropDownListInserirFabricante.DataSource = Conexao.CarregarFabricantes().Result;
                DropDownListInserirFabricante.DataValueField = "idFabricante";
                DropDownListInserirFabricante.DataTextField = "descFabricante";
                DropDownListInserirFabricante.DataBind();
            }
        }

        private void PopularNovoLocal()
        {
            if (!IsPostBack)
            {
                DropDownListInserirLocal.DataSource = Conexao.CarregarLocais().Result;
                DropDownListInserirLocal.DataValueField = "idLocal";
                DropDownListInserirLocal.DataTextField = "descLocal";
                DropDownListInserirLocal.DataBind();
            }
        }

        private void PopularNovaCategoria()
        {
            if (!IsPostBack)
            {
                DropDownListInserirCategoria.DataSource = Conexao.CarregarCategorias().Result;
                DropDownListInserirCategoria.DataValueField = "idCategoria";
                DropDownListInserirCategoria.DataTextField = "descCategoria";
                DropDownListInserirCategoria.DataBind();
            }
        }

        private void PopularNovoPiso()
        {
            if (!IsPostBack)
            {
                DropDownListInserirPiso.DataSource = Conexao.CarregarPisos().Result;
                DropDownListInserirPiso.DataValueField = "idPiso";
                DropDownListInserirPiso.DataTextField = "descPiso";
                DropDownListInserirPiso.DataBind();
            }
        }

        private void PreencherValorPadraoCamposEmBranco()
        {
            if (txtNumeroSerie.Text == "")
            {
                Session["numeroSerie"] = "não possui";
            }
            else
            {
                Session["numeroSerie"] = txtNumeroSerie.Text;
            }

            if (txtServiceTag.Text == "")
            {
                Session["serviceTag"] = "não possui";
            }
            else
            {
                Session["serviceTag"] = txtServiceTag.Text;
            }

            if (txtComentarios.InnerText == "")
            {
                Session["comentarios"] = "nenhum";
            }
            else
            {
                Session["comentarios"] = txtComentarios.InnerText;
            }
        }

        private String PreencherValorPadraoGarantia()
        {
            if (txtGarantia.Value == "")
            {
                return "não possui";
            }
            else
            {
                return txtGarantia.Value;
            }
        }

        protected void gridViewDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewDados.PageIndex = e.NewPageIndex;
            if (DropDownListFiltros.SelectedItem.Text == "Fabricante")
            {
                PreencherGridFabricante();
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Categoria")
            {
                PreencherGridCategoria();
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Local")
            {
                PreencherGridLocal();
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Todos")
            {
                PreencherGridTodos();
            }
        }

        private List<string> ObterListaPatrimonios()
        {
            Task<DataTable> table = Conexao.CarregarTodosAtivos();
            List<string> listaPatrimonios = new List<string>();
            for (int i = 0; i < table.Result.Rows.Count; i++)
            {
                listaPatrimonios.Add(table.Result.Rows[i].ItemArray[13].ToString());
            }
            return listaPatrimonios;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (DropDownListFiltros.SelectedItem.Text == "Fabricante")
            {
                PreencherGridFabricante();
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Categoria")
            {
                PreencherGridCategoria();
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Local")
            {
                PreencherGridLocal();
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Todos")
            {
                PreencherGridTodos();
            }
            colunaOrdenacao.Visible = true;
        }

        protected void gridViewDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "detalhes")
            {
                int idLinha = Convert.ToInt32(e.CommandArgument);
                Session["idAtivo"] = gridViewDados.Rows[idLinha].Cells[0].Text;
                //labelID.Text = Session["idAtivo"].ToString();
                labelItem.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.Item;
                labelLocal.Text = Conexao.ObterDescricaoLocais(Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.idLocal).Result;
                labelFabricante.Text = Conexao.ObterDescricaoFabricantes(Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.idFabricante).Result;
                labelModelo.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.Modelo;
                labelPiso.Text = Conexao.ObterDescricaoPisos(Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.idPiso).Result;
                labelPatrimônio.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.Patrimonio;
                labelCategoria.Text = Conexao.ObterDescricaoCategoria(Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.idCategoria).Result;
                labelComentarios.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.Comentarios;
                labelDataRegistro.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.DataRegistro;
                labelDataRetirada.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.DataRetirada;
                labelGarantia.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.Garantia;
                labelNumeroSerie.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.NumeroSerie;
                labelServiceTag.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.ServiceTag;
                labelValor.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.Valor;
                labelCondicao.Text = Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.Condicao;
                if (labelCondicao.Text == "Em uso")
                {
                    labelCondicao.ForeColor = System.Drawing.Color.Green;
                }
                else if (labelCondicao.Text == "Em reparo")
                {
                    labelCondicao.ForeColor = System.Drawing.Color.Orange;
                }
                else
                {
                    labelCondicao.ForeColor = System.Drawing.Color.Red;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalDetalhesAtivo(); });", true);
            }
        }

        protected void gridViewDados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text == "Em uso")
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
                }
                else if (e.Row.Cells[5].Text == "Em reparo")
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Orange;
                }
                else
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnEditarAtivo_Click(object sender, EventArgs e)
        {
            //Response.Redirect(@"/EditaAtivo.aspx?active=d&idAtivo=" + Session["idAtivo"].ToString()); //CAMINHO DE TESTE
            Response.Redirect(@"/webativos/EditaAtivo.aspx?idAtivo=" + Session["idAtivo"].ToString());
        }

        protected async void btnInserirAtivo_Click(object sender, EventArgs e)
        {
            if (ValidarCamposInserir() == true)
            {
                LabelErroCamposInsercao.Text = Session["erroInserir"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroCamposInsercao(); });", true);
            }
            else
            {
                Session["garantia"] = PreencherValorPadraoGarantia();
                PreencherValorPadraoCamposEmBranco();
                try
                {
                    await Conexao.InserirAtivo(txtItem.Text, DropDownListInserirPiso.SelectedValue, DropDownListInserirLocal.SelectedValue, DropDownListInserirCategoria.SelectedValue,
                    DropDownListInserirFabricante.SelectedValue, txtModelo.Text, DateTime.Now.ToShortDateString(), Session["comentarios"].ToString(), "Em uso", txtPatrimonio.Text,
                    Session["garantia"].ToString(), Session["numeroSerie"].ToString(), Session["serviceTag"].ToString(), txtValor.Text);
                    if (PainelGarantia.Visible == true)
                    {
                        await Conexao.InformarGarantiaAtivo(Conexao.ObterUltimoIdInserido(), txtGarantia.Value);
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalEquipamentoInseridoSucesso(); });", true);
                    await Conexao.RegistrarLog(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                        "cadastrou o equipamento " + txtItem.Text + " (patrimônio" + txtPatrimonio.Text + ") na base de dados)", Conexao.ObterUltimoIdInserido());
                }
                catch (Exception ex)
                {
                    LabelErroInserirAtivo.Text = ex.Message;
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroInserirAtivo(); });", true);
                }
            }
        }

        protected void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (RadioButtonListFiltrosBuscaAvancada.SelectedItem == null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroFaltamInformacoesBuscaAtivo(); });", true);
            }
            else
            {
                PreencherGridBuscaAvancada();
            }
        }

        protected void btnNovoAtivo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalNovoAtivo(); });", true);
        }

        protected void btnBuscaAvancada_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalBuscaAvancada(); });", true);
        }

        private void LimparCampoBuscaAvancada()
        {
            txtBuscaNumeroSerie.Text = String.Empty;
            txtBuscaPatrimonio.Text = String.Empty;
            txtBuscaServiceTag.Text = String.Empty;
        }

        protected void RadioButtonListFiltrosBuscaAvancada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonListFiltrosBuscaAvancada.SelectedItem.Text == "Patrimônio")
            {
                LimparCampoBuscaAvancada();
                txtBuscaPatrimonio.Visible = true;
                txtBuscaNumeroSerie.Visible = false;
                txtBuscaServiceTag.Visible = false;
            }
            else if (RadioButtonListFiltrosBuscaAvancada.SelectedItem.Text == "Nº de Série")
            {
                LimparCampoBuscaAvancada();
                txtBuscaPatrimonio.Visible = false;
                txtBuscaNumeroSerie.Visible = true;
                txtBuscaServiceTag.Visible = false;
            }
            else if (RadioButtonListFiltrosBuscaAvancada.SelectedItem.Text == "ServiceTag")
            {
                LimparCampoBuscaAvancada();
                txtBuscaPatrimonio.Visible = false;
                txtBuscaNumeroSerie.Visible = false;
                txtBuscaServiceTag.Visible = true;
            }
        }

        protected void checkBoxGarantia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGarantia.Checked == true)
            {
                PainelGarantia.Visible = true;
            }
            else
            {
                PainelGarantia.Visible = false;
            }
        }

        private String VerificarOrdenacao(int filtro)
        {
            string ordenacao = "";
            switch (filtro)
            {
                case 0:
                    ordenacao = "item asc";
                    break;
                case 1:
                    ordenacao = "patrimonio asc";
                    break;
                case 2:
                    ordenacao = "modelo asc";
                    break;
            }
            return ordenacao;
        }

        protected void DropDownListOrdenacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListFiltros.SelectedItem.Text == "Fabricante")
            {
                DataView dv = Conexao.CarregarAtivosPorFabricante(DropDownListFabricantes.SelectedValue).Result.DefaultView;
                dv.Sort = VerificarOrdenacao(DropDownListOrdenacao.SelectedIndex);
                DataTable dt = dv.ToTable();
                gridViewDados.DataSource = dt;
                gridViewDados.DataBind();
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Categoria")
            {

                DataView dv = Conexao.CarregarAtivosPorCategorias(DropDownListCategorias.SelectedValue).Result.DefaultView;
                dv.Sort = VerificarOrdenacao(DropDownListOrdenacao.SelectedIndex);
                DataTable dt = dv.ToTable();
                gridViewDados.DataSource = dt;
                gridViewDados.DataBind();
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Local")
            {
                DataView dv = Conexao.CarregarAtivosPorLocal(DropDownListLocais.SelectedValue).Result.DefaultView;
                dv.Sort = VerificarOrdenacao(DropDownListOrdenacao.SelectedIndex);
                DataTable dt = dv.ToTable();
                gridViewDados.DataSource = dt;
                gridViewDados.DataBind();
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Todos")
            {
                DataView dv = Conexao.CarregarTodosAtivos().Result.DefaultView;
                dv.Sort = VerificarOrdenacao(DropDownListOrdenacao.SelectedIndex);
                DataTable dt = dv.ToTable();
                gridViewDados.DataSource = dt;
                gridViewDados.DataBind();
            }
        }

        protected void DropDownListFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownListFiltros.SelectedItem.Text == "Fabricante")
            {
                colunaFabricantes.Visible = true;
                colunaCategoria.Visible = false;
                colunaLocal.Visible = false;
                colunaBotao.Visible = true;                
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Categoria")
            {
                colunaFabricantes.Visible = false;
                colunaCategoria.Visible = true;
                colunaLocal.Visible = false;
                colunaBotao.Visible = true;
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Local")
            {
                colunaFabricantes.Visible = false;
                colunaCategoria.Visible = false;
                colunaLocal.Visible = true;
                colunaBotao.Visible = true;
            }
            else if (DropDownListFiltros.SelectedItem.Text == "Todos")
            {
                colunaFabricantes.Visible = false;
                colunaCategoria.Visible = false;
                colunaLocal.Visible = false;
                colunaBotao.Visible = true;
            }
            else
            {
                colunaFabricantes.Visible = false;
                colunaCategoria.Visible = false;
                colunaLocal.Visible = false;
                colunaBotao.Visible = false;
                colunaOrdenacao.Visible = false;
            }
        }
    }
}