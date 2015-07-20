<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="ASP.NET_Lesson_6__June_29.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Details</h1>

    <div class="form-group">
        <label for="txtLastName" class="col-sm-3">Last Name: </label>
        <asp:TextBox ID="txtLastName" runat="server" required="true" MaxLength="50"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtFirstMidName" class="col-sm-3">First Middle Name: </label>
        <asp:TextBox ID="txtFirstMidName" runat="server" required="true" MaxLength="50"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtEnrollmentDate" class="col-sm-3">Enrollment Date (YYYY-MM-DD): </label>
        <asp:TextBox ID="txtEnrollmentDate" runat="server" required="true" MaxLength="22"></asp:TextBox>
        <asp:RegularExpressionValidator runat="server" ErrorMessage="Please enter a date in this format (YYYY-MM-DD)" 
                ControlToValidate="txtEnrollmentDate" ValidationExpression="^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$" CssClass="label label-danger"></asp:RegularExpressionValidator>
    </div>

    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

    <asp:Panel ID="pnlCourses" runat="server" Visible="false">

        <h2>Courses</h2>
        <asp:GridView ID="grdCourses" runat="server" CssClass="table table-striped" 
            AutoGenerateColumns="false" DataKeyNames="EnrollmentID" OnRowDeleting="grdCourses_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Name" runat="server" HeaderText="Department" />
                <asp:BoundField DataField="Title" runat="server" HeaderText="Title" />
                <asp:BoundField DataField="Grade" runat="server" HeaderText="Grade" />
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
        
        <table class="table table-striped table-hover">
            <thead>
                <th>Department</th>
                <th>Title</th>
                <th>Add</th>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlDepartment" runat="server" DataValueField="DepartmentID" 
                            DataTextField="Name" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RangeValidator runat="server" ErrorMessage="Required" ControlToValidate="ddlDepartment" 
                            Type="Integer" MinimumValue="1" MaximumValue="99999999" CssClass="label label-danger"></asp:RangeValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourse" runat="server" DataValueField="CourseID" DataTextField="Title">
                        </asp:DropDownList>
                        <asp:RangeValidator runat="server" ErrorMessage="Required" ControlToValidate="ddlCourse" 
                            Type="Integer" MinimumValue="1" MaximumValue="99999999" CssClass="label label-danger"></asp:RangeValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClick="btn btn-primary" OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </tbody>
        </table>

    </asp:Panel>
</asp:Content>
