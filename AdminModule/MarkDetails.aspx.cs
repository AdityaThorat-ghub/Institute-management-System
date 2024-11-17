using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static InstituteManagementSystemCsharp.net.Models.Commonfn;

namespace InstituteManagementSystemCsharp.net.Admin
{
    public partial class MarkDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["admin"] == null)
            {
                Response.Redirect("../login.aspx");
            }

        }

       
    }
}