<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ASP.NET_Lesson_6__June_29.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login</h1>

    <div>
        <asp:Label runat="server" ID="lblStatus" CssClass="label label-danger"></asp:Label>
    </div>

    <div class="form-group">
        <label for="txtUsername" class="col-sm-2">Username: </label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtPassword" class="col-sm-2">Password: </label>
        <asp:TextBox ID="txtPassword" runat="server" textmode="password"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button id="btnLogin" Text="Login" runat="Server" OnClick="btnLogin_Click" cssClass="btn btn-primary" />
    </div>
</asp:Content>
