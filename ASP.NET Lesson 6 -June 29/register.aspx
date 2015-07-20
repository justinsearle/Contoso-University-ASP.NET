<%@ Page Title="Register" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ASP.NET_Lesson_6__June_29.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register</h1>
    <h6>All fields are required</h6>

    <div class="form-group-lg">
        <asp:label id="lblStatus" runat="Server" cssClass="label label-info"></asp:label>
    </div>
    <div class="form-group">
        <label for="txtUsername" class="col-sm-2">Username:</label>
        <asp:textbox id="txtUsername" runat="server"></asp:textbox>
    </div>
    <div class="form-group">
        <label for="txtPassword" class="col-sm-2">Password:</label>
        <asp:textbox id="txtPassword" runat="server" textmode="password"></asp:textbox>
    </div>
    <div class="form-group">
        <label for="txtConfirm" class="col-sm-2">Confirm Password:</label>
        <asp:textbox id="txtConfirm" runat="server" textmode="password"></asp:textbox>
        <asp:comparevalidator runat="server" errormessage="Passwords Must Match" 
            Controltovalidate="txtPassword" Controltocompare="txtConfirm"
            operator="equal" cssClass="label label-danger"></asp:comparevalidator>
    </div>
    <div class="form-group">
        <asp:button id="btnRegister" text="Register" runat="server" cssClass="btn btn-primary" OnClick="btnRegister_Click" />
    </div>
</asp:Content>
