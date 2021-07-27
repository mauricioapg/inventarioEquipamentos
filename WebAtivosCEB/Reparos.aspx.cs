using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAtivosCEB
{
    public partial class Reparos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PreencherGridReparos();
        }

        private void PreencherGridReparos()
        {
            gridViewDados.DataSource = Conexao.CarregarTodosReparos().Result;
            gridViewDados.DataBind();
        }

        protected void gridViewDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewDados.PageIndex = e.NewPageIndex;
            PreencherGridReparos();
        }

        private Button BotaoFinaliza()
        {
            Button btn = new Button();
            btn.ControlStyle.CssClass = "btn-info";
            btn.CommandName = "finalizaReparo";
            btn.Text = "Finalizar Reparo";
            btn.Click += Btn_Click;
            return btn;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            GridViewRow linha = (GridViewRow)botao.Parent.Parent;
            Session["idReparo"] = linha.Cells[0].Text;
            Session["idAtivo"] = linha.Cells[1].Text;
            ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalFinalizaReparo(); });", true);
        }

        protected void gridViewDados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text == "Finalizado")
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[6].Controls.Add(BotaoFinaliza());
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Orange;
                }
            }
        }

        protected async void btnFinalizaReparo_Click(object sender, EventArgs e)
        {
            try
            {
                await Conexao.FinalizarReparo(Session["idReparo"].ToString(), DateTime.Now.ToShortDateString(), "Finalizado");
                await Conexao.AlterarCondicaoAtivo(Session["idAtivo"].ToString(), "Em uso");
                PreencherGridReparos();
                ScriptManager.RegisterStartupScript(this, GetType(), "LaunchServerSide", "$(function() { abrirModalReparoFinalizadoSucesso(); });", true);
                await Conexao.RegistrarLog(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
                       "Finalizou o reparo do equipamento " + Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.Item
                       + " (patrimônio" + Conexao.CarregarAtivosPorId(Session["idAtivo"].ToString()).Result.Patrimonio + ") na base de dados)", Session["idAtivo"].ToString());
            }
            catch(Exception ex)
            {
                labelMensagemErro.ForeColor = System.Drawing.Color.Red;
                labelMensagemErro.Text = ex.Message;
            }
        }
    }
}