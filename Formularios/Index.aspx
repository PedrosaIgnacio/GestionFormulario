<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Formularios.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <h1 class="text-center" id="txtUserTittle" runat="server">Bienvenido</h1>
        <hr class="w-75" style="margin-left: 0.5rem" />
    </div>
    <h3 class="text-center mt-3" id="txtTop5Formularios">Últimos Formularios Cargados</h3>
    <div class="d-flex justify-content-center">
        <div class="w-50">
            <asp:GridView runat="server" CssClass="table bg-dark text-white text-center" ID="GVUltimosFormularios" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Nombre del Formulario" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
