<%@ Page Title="" Debug="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="WebAtivosCEB.Relatorios" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-3">
            <h5>Página em construção</h5>
            <br />
            <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ver Relatório" />--%>
            <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
            <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
                AutoDataBind="True" Height="50px" ReuseParameterValuesOnRefresh="True"
                Width="350px" EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="RelatorioTodos.rpt">
            </Report>
        </CR:CrystalReportSource>--%>
        </div>
    </div>
</asp:Content>
