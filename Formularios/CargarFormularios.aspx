<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CargarFormularios.aspx.cs" Inherits="Formularios.CargarFormularios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2 class="offcanvas-title">Cargar Formularios</h2>
        <hr class="w-75" style="margin-left: 0.5rem" />
    </div>

    <div class="row">
        <div class="form-group col-md-3">
            <asp:DropDownList runat="server" CssClass="form-control bg-light" ID="cboFormularios">
            </asp:DropDownList>
        </div>
    </div>

    <div>
        <asp:Button runat="server" CssClass="btn btn-dark" Text="Cargar Formulario" ID="cargarFormulario" OnClick="cargarFormulario_Click" />
    </div>
    <asp:Panel runat="server" ID="contentArea" CssClass="row g-3 my-3"></asp:Panel>

    <div>
        <asp:Button runat="server" CssClass="btn btn-dark" Text="GuardarDatos" ID="guardarDatos" OnClientClick="inputValues()" />
    </div>


    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js" integrity="sha384-7+zCNj/IqJ95wo16oMtfsKbZ9ccEh31eOz1HGyDuCQ6wgnyJNSYdrPa03rtR1zdB" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js" integrity="sha384-QJHtvGhmr9XOIpI6YVutG+2QOK9T+ZnN4kzFN1RtK3zEFEIsxhlmWl5/YESvpZ13" crossorigin="anonymous"></script>

</asp:Content>
