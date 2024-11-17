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
    public partial class ExpenseDetails : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../login.aspx");
            }

            if (!IsPostBack)
            {
                GetExpenseDetails();
                 
            }
        }

        private void GetExpenseDetails()
        {
            DataTable dt = fn.Fetch(@"Select Row_NUMBER() over(Order by(select 1))as [Sr.No], e.ExpenseId, e.ClassId , c.ClassName ,e.SubjectId ,s.SubjectName , 
                                    e.ChargeAmount from Expense e inner join Class c on e.ClassId =c.ClassId inner join Subject s on e.SubjectId = s.SubjectId ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}