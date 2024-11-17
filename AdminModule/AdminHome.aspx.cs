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
    public partial class AdminHome : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../login.aspx");
            }

            else 
            {
                StudentCount();
                TeacherCount();
                SubjectCount();
                ClassCount();
            }

        }
        void StudentCount()
        {
            DataTable dt = fn.Fetch("select Count(*) from Student");
            Session["student"] = dt.Rows[0][0];
        }
        void TeacherCount()
        {
            DataTable dt = fn.Fetch("select Count(*) from Teacher");
            Session["teacher"] = dt.Rows[0][0];
        }
        void ClassCount()
        {
            DataTable dt = fn.Fetch("select Count(*) from Class");
            Session["Class"] = dt.Rows[0][0];
        }
        void SubjectCount()
        {
            DataTable dt = fn.Fetch("select Count(*) from Subject");
            Session["subject"] = dt.Rows[0][0];
        }
    }
}