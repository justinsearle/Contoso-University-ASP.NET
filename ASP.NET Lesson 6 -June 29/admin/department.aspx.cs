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
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page isn't posted back, check the url for an id to see know add or edit
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    //we have a URL parameter if the count is > 0
                    GetDepartment();
                }
            }
        }

        protected void GetDepartment()
        {
            try { 
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    //get id from url parameter and store in a variable
                    Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    var d = (from dep in conn.Departments
                             where dep.DepartmentID == DepartmentID
                             select dep).FirstOrDefault();

                    //populate the form from our department object
                    txtName.Text = d.Name;
                    txtBudget.Text = d.Budget.ToString();
                }
            }
            catch (Exception e)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //connect
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    //instantsiate a new department object in memory
                    Department d = new Department();

                    //decide if updating or adding then save
                    if (Request.QueryString.Count > 0)
                    {
                        Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                        d = (from dep in conn.Departments
                             where dep.DepartmentID == DepartmentID
                             select dep).FirstOrDefault();
                    }

                    //fill the properties of our object from the form inputs
                    d.Name = txtName.Text;
                    d.Budget = Convert.ToDecimal(txtBudget.Text);

                    if (Request.QueryString.Count == 0)
                    {
                        conn.Departments.Add(d);
                    }
                    conn.SaveChanges();

                    //redirect to updated departments page
                    Response.Redirect("departments.aspx");
                }
            }
            catch (Exception e2)
            {
                Response.Redirect("/error.aspx");
            }
        }
    }
}