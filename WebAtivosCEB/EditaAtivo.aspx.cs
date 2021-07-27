using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAtivosCEB
{
    public partial class EditaAtivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesabilitarCacheCaixasTexto();
            PopularLocais();
            PopularCategorias();
            PopularFabricantes();
            PopularPisos();
            PreencherGridReparosAtivo();
            if (!IsPostBack)
            {
                ObterDadosAtivos();
            }
            ExibirOpcaoDescontinuar();
        }

        private void DesabilitarCacheCaixasTexto()
        {
            txtItem.Attributes.Add("autocomplete", "off");
            txtModelo.Attributes.Add("autocomplete", "off");
            txtPatrimonio.Attributes.Add("autocomplete", "off");
            txtNumeroSerie.Attributes.Add("autocomplete", "off");
            txtServiceTag.Attributes.Add("autocomplete", "off");
            txtValor.Attributes.Add("autocomplete", "off");
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

        private void PopularPisos()
        {
            if (!IsPostBack)
            {
                DropDownListPisos.DataSource = Conexao.CarregarPisos().Result;
                DropDownListPisos.DataValueField = "idPiso";
                DropDownListPisos.DataTextField = "descPiso";
                DropDownListPisos.DataBind();
            }
        }

        private void PreencherGridReparosAtivo()
        {
            gridViewDados.DataSource = Conexao.CarregarReparosPorAtivo(Session["idAtivo"].ToString()).Result;
            gridViewDados.DataBind();
        }

        private void ExibirOpcaoDescontinuar()
        {
            if (labelCondicao.Text != "Descontinuado")
            {
                checkBoxDescontinuar.Visible = true;
            }
            else
            {
                checkBoxDescontinuar.Visible = false;
            }
        }

        private void ObterDadosAtivos()
        {
            txtItem.Text = Conexao.CarregarAtivosPorId(Request.QueryString["idAtivo"]).Result.Item;
            labelPiso.Text = Conexao.ObterDescricaoPisos(Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.idPiso).Result;
            labelLocal.Text = Conexao.ObterDescricaoLocais(Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.idLocal).Result;
            labelFabricante.Text = Conexao.ObterDescricaoFabricantes(Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.idFabricante).Result;
            labelCategoria.Text = Conexao.ObterDescricaoCategoria(Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.idCategoria).Result;
            txtModelo.Text = Conexao.CarregarAtivosPorId(Request.QueryString["idAtivo"]).Result.Modelo;
            txtPatrimonio.Text = Conexao.CarregarAtivosPorId(Request.QueryString["idAtivo"]).Result.Patrimonio;
            txtDataRetirada.Value = Conexao.CarregarAtivosPorId(Request.QueryString["idAtivo"]).Result.DataRetirada;
            labelCondicao.Text = Conexao.CarregarAtivosPorId(Request.QueryString["idAtivo"]).Result.Condicao;
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
            txtNumeroSerie.Text = Conexao.CarregarAtivosPorId(Request.QueryString["idAtivo"]).Result.NumeroSerie;
            txtServiceTag.Text = Conexao.CarregarAtivosPorId(Request.QueryString["idAtivo"]).Result.ServiceTag;
            txtValor.Text = Conexao.CarregarAtivosPorId(Request.QueryString["idAtivo"]).Result.Valor;
            txtComentarios.InnerText = Conexao.CarregarAtivosPorId(Request.QueryString["idAtivo"]).Result.Comentarios;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"Default.aspx");
        }

        protected void btnNovoReparo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalNovoReparo(); });", true);
        }

        protected void gridViewDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewDados.PageIndex = e.NewPageIndex;
            PreencherGridReparosAtivo();
        }

        protected void btnHistoricoReparos_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalHistoricoReparos(); });", true);
        }

        protected void gridViewDados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[3].Text == "Finalizado")
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Orange;
                }
            }
        }

        protected async void btnInserirNovoReparo_Click(object sender, EventArgs e)
        {
            if (txtDescricaoDefeito.InnerText == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroFaltamInformacoes(); });", true);
            }
            else
            {
                try
                {
                    await Conexao.InserirReparo(Session["idAtivo"].ToString(), DateTime.Now.ToShortDateString(), txtDescricaoDefeito.InnerText, "Em aberto");
                    await Conexao.AlterarCondicaoAtivo(Session["idAtivo"].ToString(), "Em reparo");
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalReparoInseridoSucesso(); });", true);
                    await Conexao.RegistrarLog(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                       "Registrou um reparo no equipamento " + txtItem.Text + " (patrimônio" + txtPatrimonio.Text + ") na base de dados)", Request.QueryString["idAtivo"]);
                }
                catch (Exception ex)
                {
                    labelMensagemErro.Text = ex.Message;
                    labelMensagemErro.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroInserirReparo(); });", true);
                }
            }
        }

        protected void checkBoxDescontinuar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDescontinuar.Checked == true)
            {
                PainelDescontinuar.Visible = true;
            }
            else
            {
                PainelDescontinuar.Visible = false;
            }
        }

        protected async void btnSalvarAlteracoes_Click(object sender, EventArgs e)
        {
            try
            {
                await Conexao.AtualizarAtivo(Session["idAtivo"].ToString(), txtItem.Text, txtModelo.Text, txtComentarios.InnerText, txtPatrimonio.Text,
                    txtNumeroSerie.Text, txtServiceTag.Text, txtValor.Text);
                if (PainelDescontinuar.Visible == true)
                {
                    await Conexao.DescontinuarAtivo(Session["idAtivo"].ToString(), DateTime.Now.ToShortDateString(), "Descontinuado");
                }

                if (LinkButtonAlterarPiso.Text == "Cancelar")
                {
                    await Conexao.AlterarPisoAtivo(Session["idAtivo"].ToString(), DropDownListPisos.SelectedValue);
                }

                if (LinkButtonAlterarLocal.Text == "Cancelar")
                {
                    await Conexao.AlterarLocalAtivo(Session["idAtivo"].ToString(), DropDownListLocais.SelectedValue);
                }

                if (LinkButtonAlterarFabricante.Text == "Cancelar")
                {
                    await Conexao.AlterarFabricanteAtivo(Session["idAtivo"].ToString(), DropDownListFabricantes.SelectedValue);
                }

                if (LinkButtonAlterarCategoria.Text == "Cancelar")
                {
                    await Conexao.AlterarCategoriaAtivo(Session["idAtivo"].ToString(), DropDownListCategorias.SelectedValue);
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalEquipamentoAtualizadoSucesso(); });", true);
                await Conexao.RegistrarLog(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                       "atualizou informações do equipamento " + txtItem.Text + " (patrimônio" + txtPatrimonio.Text + ") na base de dados)", Request.QueryString["idAtivo"]);
            }
            catch (Exception ex)
            {
                labelErroAtualizarAtivo.Text = ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroAtualizarAtivo(); });", true);
            }
        }

        protected void LinkButtonAlterarPiso_Click(object sender, EventArgs e)
        {
            if (labelPiso.Visible == true)
            {
                labelPiso.Visible = false;
                DropDownListPisos.Visible = true;
                LinkButtonAlterarPiso.Text = "Cancelar";
            }
            else
            {
                labelPiso.Visible = true;
                DropDownListPisos.Visible = false;
                LinkButtonAlterarPiso.Text = "Alterar";
            }
        }

        protected void LinkButtonAlterarLocal_Click(object sender, EventArgs e)
        {
            if (labelLocal.Visible == true)
            {
                labelLocal.Visible = false;
                DropDownListLocais.Visible = true;
                LinkButtonAlterarLocal.Text = "Cancelar";
            }
            else
            {
                labelLocal.Visible = true;
                DropDownListLocais.Visible = false;
                LinkButtonAlterarLocal.Text = "Alterar";
            }
        }

        protected void LinkButtonAlterarFabricante_Click(object sender, EventArgs e)
        {
            if (labelFabricante.Visible == true)
            {
                labelFabricante.Visible = false;
                DropDownListFabricantes.Visible = true;
                LinkButtonAlterarFabricante.Text = "Cancelar";
            }
            else
            {
                labelFabricante.Visible = true;
                DropDownListFabricantes.Visible = false;
                LinkButtonAlterarFabricante.Text = "Alterar";
            }
        }

        protected void LinkButtonAlterarCategoria_Click(object sender, EventArgs e)
        {
            if (labelCategoria.Visible == true)
            {
                labelCategoria.Visible = false;
                DropDownListCategorias.Visible = true;
                LinkButtonAlterarCategoria.Text = "Cancelar";
            }
            else
            {
                labelCategoria.Visible = true;
                DropDownListCategorias.Visible = false;
                LinkButtonAlterarCategoria.Text = "Alterar";
            }
        }
    }
}