using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference owin
using Microsoft.Owin.Security;

namespace ASP.NET_Lesson_6__June_29
{
    public partial class monday : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated) {
                plhPrivate.Visible = true;
                plhPublic.Visible = false;
            }
            else
            {
                plhPublic.Visible = true;
                plhPrivate.Visible = false;
            }
        }
    }
}