using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference models
using ASP.NET_Lesson_6__June_29.Models;
using System.Web.ModelBinding;

namespace ASP.NET_Lesson_6__June_29
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page isn't posted back, check the url for an id to see know add or edit
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    //we have a URL parameter if the count is > 0
                    GetStudents();
                }
            }
        }

        protected void GetStudents()
        {
            try { 
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    //get id from url parameter and store in a variable
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    var s = (from dep in conn.Students
                             where dep.StudentID == StudentID
                             select dep).FirstOrDefault();

                    //populate the form from our student object                
                    txtLastName.Text = s.LastName;
                    txtFirstMidName.Text = s.FirstMidName;
                    txtEnrollmentDate.Text = s.EnrollmentDate.ToString("yyyy-MM-dd");

                    //enrollments - this code goes in the same method that populates the student 
                    //  form but below the existing code that's already in GetStudent()               
                    var objE = (from en in conn.Enrollments1
                                join c in conn.Courses on en.CourseID equals c.CourseID
                                join d in conn.Departments on c.DepartmentID equals d.DepartmentID
                                where en.StudentID == StudentID
                                select new { en.EnrollmentID, en.Grade, c.Title, d.Name});
               
                    grdCourses.DataSource = objE.ToList();
                    grdCourses.DataBind();

                    ddlDepartment.ClearSelection();
                    ddlCourse.ClearSelection();

                    //fill departments dropdown
                    var deps = (from d in conn.Departments
                                orderby d.Name
                                select d);

                    ddlDepartment.DataSource = deps.ToList();
                    ddlDepartment.DataBind();

                    ListItem newItem = new ListItem("-Select-", "0");
                    ddlDepartment.Items.Insert(0, newItem);                
                    ddlCourse.Items.Insert(0, newItem);

                    pnlCourses.Visible = true;
                }
            }
            catch (Exception e)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try { 
                //connect
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    //instantsiate a new department object in memory
                    Student s = new Student();

                    //decide if updating or adding then save
                    if (Request.QueryString.Count > 0)
                    {
                        Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                        s = (from dep in conn.Students
                             where dep.StudentID == StudentID
                             select dep).FirstOrDefault();
                    }

                    //fill the properties of our object from the form inputs
                    s.LastName = txtLastName.Text;
                    s.FirstMidName = txtFirstMidName.Text;
                    s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                    if (Request.QueryString.Count == 0)
                    {
                        conn.Students.Add(s);
                    }
                    conn.SaveChanges();

                    //redirect to updated departments page
                    Response.Redirect("students.aspx");
                }
            }
            catch (Exception e2)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //get the selected EnrollmentID
            Int32 EnrollmentID = Convert.ToInt32(grdCourses.DataKeys[e.RowIndex].Values["EnrollmentID"]);

            try { 
                using(DefaultConnectionEF conn = new DefaultConnectionEF()) {
                    Enrollments objE = (from en in conn.Enrollments1
                                           where en.EnrollmentID == EnrollmentID
                                           select en).FirstOrDefault();
                    conn.Enrollments1.Remove(objE);
                    conn.SaveChanges();
                    GetStudents();
                }
            }
            catch (Exception e3)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try { 
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                    Int32 CourseID = Convert.ToInt32(ddlCourse.SelectedValue);

                    Enrollments objE = new Enrollments();
                    objE.StudentID = StudentID;
                    objE.CourseID = CourseID;

                    conn.Enrollments1.Add(objE);
                    conn.SaveChanges();
                    GetStudents();
                }
            }
            catch (Exception e4)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
                using (DefaultConnectionEF conn = new DefaultConnectionEF()) { 
                    Int32 DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
                    var objC = (from c in conn.Courses
                                where c.DepartmentID == DepartmentID
                                orderby c.Title
                                select c);

                    ddlCourse.DataSource = objC.ToList();
                    ddlCourse.DataBind();

                    ListItem newItem = new ListItem("-Select-", "0");
                    ddlCourse.Items.Insert(0, newItem);
                }
            }
            catch (Exception e5)
            {
                Response.Redirect("/error.aspx");
            }
        }
    }
}