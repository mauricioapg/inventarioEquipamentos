using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAtivosCEB
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarTelaAtiva();
        }

        private void VerificarTelaAtiva()
        {
            if (Request.QueryString["active"] == "a")
            {
                telaAtivos.Style.Add("background-color", "#007792");
            }
            else if (Request.QueryString["active"] == "b")
            {
                telaReparos.Style.Add("background-color", "#007792");
            }
            else if (Request.QueryString["active"] == "c")
            {
                telaRelatorios.Style.Add("background-color", "#007792");
            }
            else if (Request.QueryString["active"] == "d")
            {
                telaEditaAtivos.Visible = true;
            }
        }

        private void SalvarArquivoLogs()
        {
            Response.AddHeader("content-disposition", "attachment; filename=logs.txt");
            Response.Charset = "";
            Response.ContentType = "application/vnd.txt";

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            DataGrid dgDados = new DataGrid();
            this.form1.Controls.Add(dgDados);

            dgDados.DataSource = Conexao.CarregarLogs().Result;
            dgDados.DataBind();

            dgDados.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());
            Response.Flush();
            Response.End();
        }

        protected void DropDownListGerenciar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListGerenciar.SelectedIndex == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalCriarCategoria(); });", true);
            }
            else if (DropDownListGerenciar.SelectedIndex == 2)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalCriarLocal(); });", true);
            }
            else if (DropDownListGerenciar.SelectedIndex == 3)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalCriarFabricante(); });", true);
            }
            else if (DropDownListGerenciar.SelectedIndex == 4)
            {
                SalvarArquivoLogs();
            }
        }

        protected async void btnCriarCategoria_Click(object sender, EventArgs e)
        {
            if (txtNomeCategoria.Text == "")
            {
                LabelFaltamInformacoes.Text = "Informe o nome da Categoria";
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroFaltamInformacoes(); });", true);
            }
            else
            {
                try
                {
                    await Conexao.CriarCategoria(txtNomeCategoria.Text);
                    LabelCriadoSucesso.Text = "Categoria criada com sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalCriadoSucesso(); });", true);
                    txtNomeCategoria.Text = "";
                }
                catch (Exception ex)
                {
                    LabelErro.Text = ex.Message;
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErro(); });", true);
                }
            }
        }

        protected async void btnCriarFabricante_Click(object sender, EventArgs e)
        {
            if (txtNomeFabricante.Text == "")
            {
                LabelFaltamInformacoes.Text = "Informe o nome do Fabricante";
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroFaltamInformacoes(); });", true);
            }
            else
            {
                try
                {
                    await Conexao.CriarFabricante(txtNomeFabricante.Text);
                    LabelCriadoSucesso.Text = "Fabricante criado com sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalCriadoSucesso(); });", true);
                    txtNomeFabricante.Text = "";
                }
                catch (Exception ex)
                {
                    LabelErro.Text = ex.Message;
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErro(); });", true);
                }
            }
        }

        protected async void btnCriarLocal_Click(object sender, EventArgs e)
        {
            if (txtNomeLocal.Text == "")
            {
                LabelFaltamInformacoes.Text = "Informe o nome do Local";
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErroFaltamInformacoes(); });", true);
            }
            else
            {
                try
                {
                    await Conexao.CriarLocal(txtNomeLocal.Text);
                    LabelCriadoSucesso.Text = "Local criado com sucesso!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalCriadoSucesso(); });", true);
                    txtNomeLocal.Text = "";
                }
                catch (Exception ex)
                {
                    LabelErro.Text = ex.Message;
                    ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalErro(); });", true);
                }
            }
        }
    }
}