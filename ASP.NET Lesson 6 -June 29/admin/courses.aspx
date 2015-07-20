<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="ASP.NET_Lesson_6__June_29.courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Courses</h2>
    <a href="course.aspx">Add Course</a>
    <div>
        <label for="ddlPageSize">Records Per Page: </label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem value="3" Text="3"/>
            <asp:ListItem value="5" Text="5"/>
            <asp:ListItem value="10" Text="10"/>
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdCourses" runat="server" CssClass="table table-striped" 
        AutoGenerateColumns="false" OnRowDeleting="grdCourses_RowDeleting" DataKeyNames="CourseID"
        AllowPaging="true" AllowSorting="true" OnPageIndexChanging="grdCourses_PageIndexChanging" 
        OnSorting="grdCourses_Sorting" PageSize="3" OnRowDataBound="grdCourses_RowDataBound">
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="Course ID" SortExpression="CourseID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
            <asp:BoundField DataField="Name" HeaderText="Department" SortExpression="Name" />
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="~/course.aspx" Text="Edit"
                DataNavigateUrlFields="CourseID" DataNavigateUrlFormatString="course.aspx?CourseID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
