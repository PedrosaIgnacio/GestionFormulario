<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarFormularios.aspx.cs" Inherits="Formularios.GestionarFormularios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2 class="offcanvas-title">Gestionar Formularios</h2>
        <hr class="w-75" style="margin-left: 0.5rem" />
    </div>
    <div class="row">
        <div class="form-group col-md-3">
            <asp:Label runat="server" Text="Nombre del Campo"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" placeholder="Nombre del Campo" ID="txtNombreCampo"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <asp:Label runat="server" Text="Datos Aceptados"></asp:Label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="cboDatos">
                <asp:ListItem Text="< Seleccionar Opcion >"></asp:ListItem>
                <asp:ListItem Text="Valor Numérico"></asp:ListItem>
                <asp:ListItem Text="Texto"></asp:ListItem>
                <asp:ListItem Text="Valor Booleano"></asp:ListItem>
                <asp:ListItem Text="Fecha"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-3">
            <br />
            <asp:Button runat="server" Text="Agregar Campo" CssClass="btn btn-dark" Style="background: #343a40;" ID="btnAgregarDetalle" OnClick="btnAgregarDetalle_Click" />
        </div>
    </div>

    <div>
        <asp:GridView runat="server" AutoGenerateColumns="false" CssClass="table" ID="GVDetallesForm">
            <Columns>
                <asp:BoundField HeaderText="Nro" DataField="id" />
                <asp:BoundField HeaderText="Nombre del Campo" DataField="name" />
                <asp:BoundField HeaderText="Tipo de Datos del Campo" DataField="datatype" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Modificar" CssClass="btn btn-dark"></asp:Button>
                        <asp:Button runat="server" Text="" CssClass="btn btn-close" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>

    <!-- Button trigger modal -->

    <button type="button" class="btn btn-dark" runat="server" data-bs-toggle="modal" data-bs-target="#staticBackdrop" id="btnGenerarFormularioValidate">
        Generar Formulario
    </button>

    <!-- Modal -->
    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content" style="background: #fafafa">
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel">Confirmar Generacion del Formulario</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="background: #fafafa">
                    <div class="row">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Nombre del Formulario"></asp:Label>
                            <asp:TextBox runat="server" placeholder="Nombre del Formulario" CssClass="form-control" ID="txtNombreForm"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="background: #fafafa">
                    <button type="button" class="btn btn-dark" data-bs-dismiss="modal">Cerrar</button>
                    <asp:Button runat="server" CssClass="btn btn-dark" OnClick="btnConfirmar_Click" ID="btnConfirmar" Text="Confirmar" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
