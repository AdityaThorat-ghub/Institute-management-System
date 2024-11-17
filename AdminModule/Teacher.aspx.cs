﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static InstituteManagementSystemCsharp.net.Models.Commonfn;

namespace InstituteManagementSystemCsharp.net.Admin
{
    public partial class Teacher : System.Web.UI.Page
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
                GetTeachers();
            }
        }

        private void GetTeachers()
        {

            DataTable dt = fn.Fetch(@"Select ROW_NUMBER() OVER(ORDER BY(SELECT 1))as [Sr.No], TeacherId, [Name], Dob,Gender,
            Mobile,Email, [Address],[password] from Teacher");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try 
            {
                if (ddlGender.SelectedValue != "0")
                {
                    string email = txtEmail.Text.Trim();
                    DataTable dt = fn.Fetch("Select * from Teacher where Email='" + email + "' ");
                    if (dt.Rows.Count == 0)
                    {
                        string query = "insert into Teacher values ('" + txtName.Text.Trim() + "','" + txtDoB.Text.Trim() + "', '" +
                            ddlGender.SelectedValue + "' , '" + txtMobile.Text.Trim() + "' , '" + txtEmail.Text.Trim() + "' , '" +
                            txtAddress.Text.Trim() + "'  ,  '" + TxtPassword.Text.Trim() + "')";
                        fn.Query(query);
                        lblMsg.Text = "Inserted Succesfully !";
                        lblMsg.CssClass = "alert alert-success";
                        ddlGender.SelectedIndex = 0;
                        txtName.Text = string.Empty;
                        txtDoB.Text = string.Empty;
                        txtMobile.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                        txtAddress.Text = string.Empty;
                        TxtPassword.Text = string.Empty;
                        GetTeachers();
                    }
                    else
                    {
                        lblMsg.Text = "Entered <b>'" + email + "'</b> Already Exists !";
                        lblMsg.CssClass = "alert alert-danger";

                    }
                }


                else
                {
                    lblMsg.Text = " Gender is required !";
                    lblMsg.CssClass = "alert alert-danger";
                }
            
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetTeachers();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetTeachers();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int TeacherId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("Delete from Teacher where TeacherId = '" + TeacherId + "' ");
                lblMsg.Text = "Teacher Deleted Succesfully !";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetTeachers();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetTeachers();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int TeacherId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string name = (row.FindControl("txtName") as TextBox).Text;
                string mobile = (row.FindControl("txtMobile") as TextBox).Text;
                string password = (row.FindControl("txtpassword") as TextBox).Text;
                string address = (row.FindControl("txtAddress") as TextBox).Text;
                fn.Query("Update Teacher set Name = '" + name.Trim() + "' , Mobile='" + mobile.Trim() + "', Address='" + address.Trim() + 
                    "', password='" + password.Trim() + "' where TeacherId = '" + TeacherId + "' ");
                lblMsg.Text = "Subject Updated Succesfully !";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetTeachers();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
        }
    }
}