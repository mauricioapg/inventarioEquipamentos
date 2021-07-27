using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAtivosCEB
{
    public partial class Relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load(Server.MapPath("RelatorioTodos.rpt"));
            ////cryRpt.SetParameterValue("parametroCategoria", 1);
            ////cryRpt.DataSourceConnections[0].SetConnection(@"TI02\SQLEXPRESS", "ATIVOS", "sqladmin", "Anchor3128");
            //CrystalReportViewer1.ReportSource = cryRpt;
            //CrystalReportViewer1.DataBind();
        }
    }
}