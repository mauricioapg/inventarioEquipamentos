<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditaAtivo.aspx.cs" Inherits="WebAtivosCEB.EditaAtivo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function abrirModalNovoReparo() {
            $('#modalNovoReparo').modal();
        }
    </script>

    <script>
        function abrirModalHistoricoReparos() {
            $('#modalHistoricoReparos').modal();
        }
    </script>

    <script>
        function abrirModalReparoInseridoSucesso() {
            $('#modalReparoInseridoSucesso').modal();
        }
    </script>

    <script>
        function abrirModalEquipamentoAtualizadoSucesso() {
            $('#modalEquipamentoAtualizadoSucesso').modal();
        }
    </script>

    <script>
        function abrirModalErroFaltamInformacoes() {
            $('#modalErroFaltamInformacoes').modal();
        }
    </script>

    <script>
        function abrirModalErroInserirReparo() {
            $('#modalErroInserirReparo').modal();
        }
    </script>

    <script>
        function abrirModalErroAtualizarAtivo() {
            $('#modalErroAtualizarAtivo').modal();
        }
    </script>

    <div class="row">
        <div class="col-md-12">
            <br />
            <div class="form-group" style="margin-left: 10px; margin-right: 10px">
                <div class="row" style="margin-bottom: 20px;">
                    <div class="col-md-12">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnNovoReparo" OnClick="btnNovoReparo_Click" CssClass="btn btn-outline-info" runat="server" Text="Novo Reparo" />
                                </td>
                                <td>
                                    <asp:Button ID="btnHistoricoReparos" CssClass="btn btn-outline-info" OnClick="btnHistoricoReparos_Click" runat="server" Text="Histórico de Reparos" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <h5 class="h5">Detalhes do Ativo</h5>
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <h6>Item:</h6>
                        <asp:TextBox ID="txtItem" CssClass="form-control" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <h6>Piso:</h6>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="labelPiso" Visible="true" runat="server"></asp:Label>
                                            <asp:DropDownList ID="DropDownListPisos" Visible="false" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding-left: 15px">
                                            <asp:LinkButton ID="LinkButtonAlterarPiso" OnClick="LinkButtonAlterarPiso_Click" runat="server">Alterar</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <br />
                        <h6>Local:</h6>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="labelLocal" Visible="true" runat="server"></asp:Label>
                                            <asp:DropDownList ID="DropDownListLocais" Visible="false" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding-left: 15px">
                                            <asp:LinkButton ID="LinkButtonAlterarLocal" OnClick="LinkButtonAlterarLocal_Click" runat="server">Alterar</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <br />
                        <h6>Fabricante:</h6>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="labelFabricante" Visible="true" runat="server"></asp:Label>
                                            <asp:DropDownList ID="DropDownListFabricantes" Visible="false" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding-left: 15px">
                                            <asp:LinkButton ID="LinkButtonAlterarFabricante" OnClick="LinkButtonAlterarFabricante_Click" runat="server">Alterar</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <br />
                        <h6>Categoria:</h6>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="labelCategoria" Visible="true" runat="server"></asp:Label>
                                            <asp:DropDownList ID="DropDownListCategorias" Visible="false" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding-left: 15px">
                                            <asp:LinkButton ID="LinkButtonAlterarCategoria" OnClick="LinkButtonAlterarCategoria_Click" runat="server">Alterar</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <br />
                        <h6>Modelo:</h6>
                        <asp:TextBox ID="txtModelo" CssClass="form-control" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <h6>Patrimônio:</h6>
                        <asp:TextBox ID="txtPatrimonio" CssClass="form-control" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <h6>Condição:</h6>
                        <asp:Label ID="labelCondicao" Font-Bold="true" runat="server"></asp:Label>
                        <br />
                        <br />
                        <h6>Nº de Série:</h6>
                        <asp:TextBox ID="txtNumeroSerie" CssClass="form-control" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <h6>Service Tag:</h6>
                        <asp:TextBox ID="txtServiceTag" CssClass="form-control" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <h6>Valor:</h6>
                        <asp:TextBox ID="txtValor" CssClass="form-control" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <h6>Comentários:</h6>
                        <textarea style="resize: none" id="txtComentarios" class="form-control" cols="20" rows="6" runat="server"></textarea>
                        <br />
                        <br />
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="checkBoxDescontinuar" OnCheckedChanged="checkBoxDescontinuar_CheckedChanged"
                                    AutoPostBack="true" Visible="false" class="form-control" Text="Descontinuar equipamento" runat="server" />
                                <br />
                                <br />
                                <asp:Panel ID="PainelDescontinuar" Visible="false" runat="server">
                                    <h6>Data de retirada:</h6>
                                    <input type="date" class="form-control" id="txtDataRetirada" runat="server" />
                                    <br />
                                    <br />
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSalvarAlteracoes" class="btn btn-success" OnClick="btnSalvarAlteracoes_Click" runat="server" Text="Salvar Alterações" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancelar" class="btn btn-danger" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalNovoReparo" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Novo Reparo</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-12">
                                <h6>Descreva o defeito do equipamento:</h6>
                                <br />
                                <textarea style="resize: none" id="txtDescricaoDefeito" class="form-control" cols="20" rows="6" runat="server"></textarea>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnInserirNovoReparo" OnClick="btnInserirNovoReparo_Click" class="btn btn-success" runat="server" Text="Inserir" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelarNovoReparo" class="btn btn-danger" runat="server" Text="Cancelar" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalHistoricoReparos" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Histórico de Reparos</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-12-md">
                                <asp:GridView ID="gridViewDados" AllowPaging="true" OnPageIndexChanging="gridViewDados_PageIndexChanging" runat="server"
                                    HeaderStyle-BackColor="#848484" AutoGenerateColumns="false" OnRowDataBound="gridViewDados_RowDataBound" HeaderStyle-ForeColor="White" CssClass="table">
                                    <Columns>
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
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <p>Este equipamento não passou por nenhum reparo</p>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnFechar" class="btn btn-danger" runat="server" Text="Fechar" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalReparoInseridoSucesso" role="dialog">
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
                                <asp:Label ID="LabelInseridoSucesso" runat="server" Text="Reparo inserido com sucesso!" style="font-weight:500"></asp:Label>
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
    <div class="modal fade" id="modalErroFaltamInformacoes" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h6></h6>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-2">
                                <img src="http://srvceb01/webativos/erro2.png" style="padding: 10px" />
                            </div>
                            <div class="col-10" style="align-self:center">
                                <asp:Label ID="LabelFaltamInformacoes" runat="server" Text="Por favor, descreva o defeito do equipamento" style="font-weight:500"></asp:Label>
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
    <div class="modal fade" id="modalErroInserirReparo" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h6></h6>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-2">
                                <img src="http://srvceb01/webativos/erro2.png" style="padding: 10px" />
                            </div>
                            <div class="col-10" style="align-self:center">
                                <asp:Label ID="labelMensagemErro" runat="server" style="font-weight:500"></asp:Label>
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
    <div class="modal fade" id="modalEquipamentoAtualizadoSucesso" role="dialog">
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
                                <asp:Label ID="Label1" runat="server" Text="Equipamento atualizado com sucesso!" style="font-weight:500"></asp:Label>
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
    <div class="modal fade" id="modalErroAtualizarAtivo" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h6></h6>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-2">
                                <img src="http://srvceb01/webativos/erro2.png" style="padding: 10px" />
                            </div>
                            <div class="col-10" style="align-self:center">
                                <asp:Label ID="labelErroAtualizarAtivo" runat="server" style="font-weight:500"></asp:Label>
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
