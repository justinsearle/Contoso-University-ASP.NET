using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//reference our entity framework models
using ASP.NET_Lesson_6__June_29.Models;
using System.Web.ModelBinding;

namespace ASP.NET_Lesson_6__June_29
{
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDepartments();
            }
        }

        protected void GetDepartments()
        {
            try { 
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {

                    //use link to query the Departments model
                    var deps = from d in conn.Departments
                               select d;

                    //bind the query result to the gridview
                    grdDepartments.DataSource = deps.ToList();
                    grdDepartments.DataBind();
                }
            }
            catch (Exception e2)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try { 
                //connect
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    //get selected department ID
                    Int32 DepartmentID = Convert.ToInt32(grdDepartments.DataKeys[e.RowIndex].Values["DepartmentID"]);

                    var d = (from dep in conn.Departments
                             where dep.DepartmentID == DepartmentID
                             select dep).FirstOrDefault();
                    //save
                    conn.Departments.Remove(d);
                    conn.SaveChanges();

                    //redirect to updated departments page
                    GetDepartments();
                }
            }
            catch (Exception e2)
            {
                Response.Redirect("/error.aspx");
            }
        }
    }
}