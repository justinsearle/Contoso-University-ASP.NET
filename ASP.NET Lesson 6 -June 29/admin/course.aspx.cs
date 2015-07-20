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
    public partial class course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page isn't posted back, check the url for an id to see know add or edit
            if (!IsPostBack)
            {
                GetDepartment();

                if (!String.IsNullOrEmpty(Request.QueryString["CourseID"]))
                {
                    GetCourse();
                }
            }
        }

        protected void GetCourse()
        {
            try
            {
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    //get id from url parameter and store in a variable
                    Int32 CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);

                    var course = (from c in conn.Courses
                                  where c.CourseID == CourseID
                                  select c).FirstOrDefault();

                    //populate the form from our department object
                    txtTitle.Text = course.Title;
                    txtCredits.Text = course.Credits.ToString();
                }
            }
            catch (Exception e)
            {
                Response.Redirect("/error.aspx");
            }
        }

        protected void GetDepartment()
        {
            try {
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    //get id from url parameter and store in a variable
                    Int32 DepertmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    var deps = (from d in conn.Departments
                             orderby d.Name
                             select d);

                    ddlDepartment.DataSource = deps.ToList();
                    ddlDepartment.DataBind();
                }
            }
            catch (Exception e2)
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
                    //instantsiate a new course object in memory
                    Course objC = new Course();

                    //decide if updating or adding then save
                    if (!String.IsNullOrEmpty(Request.QueryString["CourseID"]))
                    {
                        Int32 CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
                        objC = (from c in conn.Courses
                                where c.CourseID == CourseID
                                select c).FirstOrDefault();
                    }

                    //fill the properties of our object from the form inputs
                    objC.Title = txtTitle.Text;
                    objC.Credits = Convert.ToInt32(txtCredits.Text);
                    objC.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

                    if (String.IsNullOrEmpty(Request.QueryString["CourseID"])) {
                        conn.Courses.Add(objC);
                    }

                    conn.SaveChanges();

                    //redirect to updated departments page
                    Response.Redirect("courses.aspx");
                }
            }
            catch (Exception e3)
            {
                Response.Redirect("/error.aspx");
            }
        }
    }
}