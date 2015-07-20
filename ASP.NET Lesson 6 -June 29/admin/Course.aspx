<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="ASP.NET_Lesson_6__June_29.course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Course Details</h1>

    <div class="form-group">
        <label for="txtTitle" class="col-sm-3">Title: </label>
        <asp:TextBox ID="txtTitle" runat="server" required="true" MaxLength="50"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtCredits" class="col-sm-3">Credits: </label>
        <asp:TextBox ID="txtCredits" runat="server" required="true" MaxLength="50"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="ddlDepartment" class="col-sm-3">Departments: </label>
        <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="DepartmentID"></asp:DropDownList>
    </div>

    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
