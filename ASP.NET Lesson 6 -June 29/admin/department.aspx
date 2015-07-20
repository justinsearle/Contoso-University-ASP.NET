<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="ASP.NET_Lesson_6__June_29.department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Department Details</h1>

    <div class="form-group">
        <label for="txtName" class="col-sm-3">Name: </label>
        <asp:TextBox ID="txtName" runat="server" required MaxLength="50"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtBudget" class="col-sm-3">Budget: </label>
        <asp:TextBox ID="txtBudget" runat="server" required MaxLength="22"></asp:TextBox>
        <asp:RangeValidator runat="server" ErrorMessage="Must be between 0 and 10,000,000" 
            ControlToValidate="txtBudget" CssClass="label label-danger" 
            MinimumValue="0" MaximumValue="10000000" Type="Currency"></asp:RangeValidator>
    </div>
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
