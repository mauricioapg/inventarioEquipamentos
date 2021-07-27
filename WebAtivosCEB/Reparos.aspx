<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Reparos.aspx.cs" Inherits="WebAtivosCEB.Reparos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function abrirModalFinalizaReparo() {
            $('#modalFinalizaReparo').modal();
        }
    </script>

    <script>
        function abrirModalReparoFinalizadoSucesso() {
            $('#modalReparoFinalizadoSucesso').modal();
        }
    </script>

    <div class="row">
        <div class="col-md-12">
            <br />
            <div class="form-group" style="margin-left: 10px; margin-right: 10px">
                <div class="row" style="margin-bottom: 20px;">
                    <div class="col-md-12">
                        <asp:GridView ID="gridViewDados" CssClass="table" AllowPaging="true" OnPageIndexChanging="gridViewDados_PageIndexChanging"
                            AutoGenerateColumns="false" PageSize="20" HeaderStyle-BackColor="#848484" HeaderStyle-ForeColor="White"
                            OnRowDataBound="gridViewDados_RowDataBound" runat="server">
                            <Columns>
                                <asp:BoundField
                                    DataField="idReparo"
                                    HeaderText="ID do Reparo" />
                                <asp:BoundField
                                    DataField="idAtivo"
                                    HeaderText="ID do Ativo" />
                                <asp:BoundField
                                    DataField="dataEnvio"
                                    HeaderText="Data de Envio" />
                                <asp:BoundField
                                    DataField="dataRetorno"
                                    HeaderText="Data de Retorno" />
                                <asp:BoundField
                                    DataField="descDefeito"
                                    HeaderText="Defeito" />
                                <asp:BoundField
                                    DataField="situacao"
                                    HeaderText="Situação" />
                                <asp:TemplateField HeaderText="Ação">
                                    <ItemTemplate></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <p>Nenhum Resultado Encontrado</p>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- MODAIS -->
    <div class="modal fade" id="modalFinalizaReparo" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Finalizar Reparo</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-12">
                                <h6>Tem certeza que você quer finalizar este reparo?</h6>
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnFinalizaReparo" OnClick="btnFinalizaReparo_Click" class="btn btn-success" runat="server" Text="Finalizar" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelarFinalizaReparo" class="btn btn-danger" runat="server" Text="Cancelar" />
                                        </td>
                                    </tr>
                                </table>                                
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Label ID="labelMensagemErro" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalReparoFinalizadoSucesso" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-2">
                                <img src="http://srvceb01/webativos/sucesso1.png" style="padding: 10px" />
                            </div>
                            <div class="col-10" style="align-self:center">
                                <asp:Label ID="LabelFinalizadoSucesso" runat="server" Text="Reparo finalizado com sucesso!" style="font-weight:500"></asp:Label>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
