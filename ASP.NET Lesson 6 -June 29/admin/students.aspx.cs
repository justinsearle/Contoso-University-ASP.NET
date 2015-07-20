using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ASP.NET_Lesson_6__June_29.Models;
using System.Web.ModelBinding;
using System.Data;

namespace ASP.NET_Lesson_6__June_29
{
    public partial class students : System.Web.UI.Page
    {
        protected String SortDirection = "ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page isn't posted back, check the url for an id to see know add or edit
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            try { 
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    var students = from s in conn.Students
                                   select s;

                    grdStudents.DataSource = students.ToList();
                    grdStudents.DataBind();
                }
            }
            catch (Exception e)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try { 
                //connect
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    //get selected department ID
                    Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

                    var s = (from stu in conn.Students
                             where stu.StudentID == StudentID
                             select stu).FirstOrDefault();
                    //save
                    conn.Students.Remove(s);
                    conn.SaveChanges();

                    //redirect to updated departments page
                    GetStudents();
                }
            }
            catch (Exception e2)
            {
                Response.Redirect("/error.aspx");
            }
        }
    }
}