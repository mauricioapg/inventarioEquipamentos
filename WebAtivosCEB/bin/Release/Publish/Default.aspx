<%@ Page Title="Lista de Ativos" Async="true" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAtivosCEB.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function abrirModalDetalhesAtivo() {
            $('#modalDetalhesAtivo').modal();
        }
    </script>

    <script>
        function abrirModalNovoAtivo() {
            $('#modalNovoAtivo').modal();
        }
    </script>

    <script>
        function abrirModalBuscaAvancada() {
            $('#modalBuscaAvancada').modal();
        }
    </script>

    <script>
        function abrirModalErroFaltamInformacoesBuscaAtivo() {
            $('#modalErroFaltamInformacoesBuscaAtivo').modal();
        }
    </script>

    <script>
        function abrirModalEquipamentoInseridoSucesso() {
            $('#modalEquipamentoInseridoSucesso').modal();
        }
    </script>

    <script>
        function abrirModalErroInserirAtivo() {
            $('#modalErroInserirAtivo').modal();
        }
    </script>

    <script>
        function abrirModalErroCamposInsercao() {
            $('#modalErroCamposInsercao').modal();
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
                                    <asp:Button ID="btnNovoAtivo" CssClass="btn btn-outline-info" OnClick="btnNovoAtivo_Click" runat="server" Text="Novo Ativo" />
                                </td>
                                <td>
                                    <asp:Button ID="btnBuscaAvancada" CssClass="btn btn-outline-info" OnClick="btnBuscaAvancada_Click" runat="server" Text="Busca Avançada" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <h5 class="h5">Busca por Filtros:</h5>
                        <asp:DropDownList ID="DropDownListFiltros" CssClass="form-control" OnSelectedIndexChanged="DropDownListFiltros_SelectedIndexChanged"
                            AutoPostBack="true" runat="server">
                            <asp:ListItem Text="Selecione um filtro" />
                            <asp:ListItem Text="Fabricante" />
                            <asp:ListItem Text="Categoria" />
                            <asp:ListItem Text="Local" />
                            <asp:ListItem Text="Todos" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-8">
                        <div class="row">
                            <div id="colunaFabricantes" runat="server" visible="false" class="col-md-4">
                                <h5 class="h5">Fabricante:</h5>
                                <asp:DropDownList ID="DropDownListFabricantes" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div id="colunaCategoria" runat="server" visible="false" class="col-md-4">
                                <h5 class="h5">Categoria:</h5>
                                <asp:DropDownList ID="DropDownListCategorias" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div id="colunaLocal" runat="server" visible="false" class="col-md-4">
                                <h5 class="h5">Local:</h5>
                                <asp:DropDownList ID="DropDownListLocais" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div id="colunaBotao" runat="server" visible="false">
                                <h5 style="color: white" class="h5">.</h5>
                                <asp:Button ID="btnBuscar" class="btn btn-success" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
                            </div>
                            <div style="padding-left: 30px" id="colunaOrdenacao" runat="server" visible="false">
                                <h5 class="h5">Ordenar por:</h5>
                                <asp:DropDownList ID="DropDownListOrdenacao" OnSelectedIndexChanged="DropDownListOrdenacao_SelectedIndexChanged"
                                    AutoPostBack="true" CssClass="form-control" runat="server">
                                    <asp:ListItem>Item</asp:ListItem>
                                    <asp:ListItem>Patrimônio</asp:ListItem>
                                    <asp:ListItem>Modelo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <asp:GridView ID="gridViewDados" CssClass="table" AllowPaging="True" OnRowCommand="gridViewDados_RowCommand"
                    PageSize="20" HeaderStyle-BackColor="#848484" AutoGenerateColumns="false" HeaderStyle-ForeColor="White"
                    OnPageIndexChanging="gridViewDados_PageIndexChanging" OnRowDataBound="gridViewDados_RowDataBound" runat="server">
                    <Columns>
                        <asp:BoundField
                            DataField="idAtivo"
                            HeaderText="ID" />
                        <asp:BoundField
                            DataField="item"
                            HeaderText="Item" />
                        <asp:BoundField
                            DataField="modelo"
                            HeaderText="Modelo" />
                        <asp:BoundField
                            DataField="dataRegistro"
                            HeaderText="Data de Registro" />
                        <asp:BoundField
                            DataField="patrimonio"
                            HeaderText="Patrimônio" />
                        <asp:BoundField
                            DataField="condicao"
                            HeaderText="Condição" />
                        <asp:ButtonField
                            ControlStyle-CssClass="btn-info"
                            ButtonType="Button"
                            CommandName="detalhes"
                            Text="Detalhes" />
                    </Columns>
                    <EmptyDataTemplate>
                        <p>Nenhum Resultado Encontrado</p>
                    </EmptyDataTemplate>
                </asp:GridView>                
                <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
            </div>
        </div>
    </div>
    <!-- MODAIS -->
    <div class="modal fade" id="modalDetalhesAtivo" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Detalhes do Ativo</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-12">
                                <h6>Item</h6>
                                <asp:Label ID="labelItem" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Piso</h6>
                                <asp:Label ID="labelPiso" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Local</h6>
                                <asp:Label ID="labelLocal" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Fabricante</h6>
                                <asp:Label ID="labelFabricante" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Categoria</h6>
                                <asp:Label ID="labelCategoria" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Modelo</h6>
                                <asp:Label ID="labelModelo" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Patrimônio</h6>
                                <asp:Label ID="labelPatrimônio" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Comentários</h6>
                                <asp:Label ID="labelComentarios" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Data Registro</h6>
                                <asp:Label ID="labelDataRegistro" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>DataRetirada</h6>
                                <asp:Label ID="labelDataRetirada" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Garantia</h6>
                                <asp:Label ID="labelGarantia" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Nº de Série</h6>
                                <asp:Label ID="labelNumeroSerie" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Service Tag</h6>
                                <asp:Label ID="labelServiceTag" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Valor</h6>
                                <asp:Label ID="labelValor" runat="server"></asp:Label>
                                <br />
                                <br />
                                <h6>Condição</h6>
                                <asp:Label ID="labelCondicao" Font-Bold="true" runat="server"></asp:Label>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditarAtivo" class="btn btn-success" OnClick="btnEditarAtivo_Click" runat="server" Text="Editar" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelarEdicao" class="btn btn-danger" runat="server" Text="Cancelar" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalNovoAtivo" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Novo Ativo</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-12">
                                <h6>Item:</h6>
                                <asp:TextBox ID="txtItem" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <h6>Piso:</h6>
                                <asp:DropDownList ID="DropDownListInserirPiso" CssClass="form-control" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <h6>Local:</h6>
                                <asp:DropDownList ID="DropDownListInserirLocal" CssClass="form-control" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <h6>Fabricante:</h6>
                                <asp:DropDownList ID="DropDownListInserirFabricante" CssClass="form-control" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <h6>Categoria:</h6>
                                <asp:DropDownList ID="DropDownListInserirCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
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
                                <h6>Nº de Série:</h6>
                                <asp:TextBox ID="txtNumeroSerie" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <h6>ServiceTag:</h6>
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
                                        <asp:CheckBox ID="checkBoxGarantia" OnCheckedChanged="checkBoxGarantia_CheckedChanged"
                                            AutoPostBack="true" class="form-control" Text="Informar garantia" runat="server" />
                                        <br />
                                        <br />
                                        <asp:Panel ID="PainelGarantia" Visible="false" runat="server">
                                            <h6>Garantia:</h6>
                                            <input type="date" class="form-control" id="txtGarantia" runat="server" />
                                            <br />
                                            <br />
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnInserirAtivo" class="btn btn-success" OnClick="btnInserirAtivo_Click" runat="server" Text="Inserir" />
                                <br />
                                <%--<asp:Label ID="LabelTeste" runat="server"></asp:Label>--%>
                            </td>
                            <td>
                                <asp:Button ID="btnCancelarInsercao" class="btn btn-danger" runat="server" Text="Cancelar" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalBuscaAvancada" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Busca Avançada</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-12">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="RadioButtonListFiltrosBuscaAvancada" AutoPostBack="true" RepeatDirection="Horizontal"
                                            OnSelectedIndexChanged="RadioButtonListFiltrosBuscaAvancada_SelectedIndexChanged" runat="server">
                                            <asp:ListItem>Patrimônio</asp:ListItem>
                                            <asp:ListItem>Nº de Série</asp:ListItem>
                                            <asp:ListItem>ServiceTag</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <asp:TextBox ID="txtBuscaPatrimonio" CssClass="form-control" Visible="false" placeholder="Digite o Patrimônio" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtBuscaNumeroSerie" CssClass="form-control" Visible="false" placeholder="Digite o Nº de Série" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtBuscaServiceTag" CssClass="form-control" Visible="false" placeholder="Digite a ServiceTag" runat="server"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnLocalizar" class="btn btn-success" OnClick="btnLocalizar_Click" runat="server" Text="Buscar" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancelarBuscaAvanada" class="btn btn-danger" runat="server" Text="Cancelar" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalEquipamentoInseridoSucesso" role="dialog">
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
                                <asp:Label ID="LabelInseridoSucesso" runat="server" Text="Equipamento inserido com sucesso!" style="font-weight:500"></asp:Label>
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
    <div class="modal fade" id="modalErroInserirAtivo" role="dialog">
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
                                <asp:Label ID="LabelErroInserirAtivo" runat="server" style="font-weight:500"></asp:Label>
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
    <div class="modal fade" id="modalErroCamposInsercao" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h6></h6>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-2">
                                <img src="http://srvceb01/webativos/erro2.png" style="padding: 10px"/>
                            </div>
                            <div class="col-10" style="align-self:center">
                                <asp:Label ID="LabelErroCamposInsercao" runat="server" style="font-weight:500"></asp:Label>
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
