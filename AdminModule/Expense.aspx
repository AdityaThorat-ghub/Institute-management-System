﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmst.Master" AutoEventWireup="true" CodeBehind="Expense.aspx.cs" Inherits="InstituteManagementSystemCsharp.net.Admin.Expense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container p-md-4 p-sm-4">

             <div>

                     <asp:Label ID="lblMsg" runat="server"></asp:Label>
             </div>
            
             <h3 class="text-center"> Add Expence </h3>

             <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                 <div class="col-md-6">
                    <label for="ddlClass" > Class </label>
                     <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="true" 
                         OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Class Is Required .." 
                         ControlToValidate="ddlClass" Display="Dynamic" ForeColor="Red" InitialValue="Select Class" SetFocusOnError="True">
                     </asp:RequiredFieldValidator>
                 </div>
                
                 
                 <div class="col-md-6">
                    <label for="ddlSubject" > Subject </label>
                      <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Subject Is Required .." 
                         ControlToValidate="ddlSubject" Display="Dynamic" ForeColor="Red" InitialValue="Select Subject" SetFocusOnError="True">
                     </asp:RequiredFieldValidator>     
                 </div>

                  <div class="col-md-6 mt-2">
                    <label for="txtExpenceAmt" > Charge Amount (Per Lecture) </label>
                      <asp:TextBox ID="txtExpenceAmt" runat="server" CssClass="form-control" placeholder="Enter Charge Amount" TextMode="Number" required ></asp:TextBox>
                     
                 </div>

             </div>
             
             <div class="row mb-3 mr-lg-5 ml-lg-5">
                 <div class="col-md-3 col-md-offset-2 mb-3">
                     <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Expence" OnClick="btnAdd_Click"  />
                 </div>
             </div>

              <div class="row mb-3 mr-lg-5 ml-lg-5 ">
                 <div class="col-md-8">
                     <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Record To Display!" 
                         AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                         OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="5" DataKeyNames="ExpenseId" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
                         <Columns>
                             <asp:BoundField DataField="Sr.No" HeaderText="Sr.No" ReadOnly="True">
                             <ItemStyle HorizontalAlign="Center" />
                             </asp:BoundField>


                             <asp:TemplateField HeaderText="Class">
                                 <EditItemTemplate>
                                     <asp:DropDownList ID="ddlClassGv" runat="server" DataSourceID="SqlDataSource1" DataTextField="ClassName" 
                                         DataValueField="ClassId" SelectedValue='<%# Eval("ClassId") %>' CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlClassGv_SelectedIndexChanged" >
                                         <asp:ListItem>Select Class</asp:ListItem>
                                     </asp:DropDownList>
                                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolCS %>" 
                                         SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                             </asp:TemplateField>


                             <asp:TemplateField HeaderText="Subject">
                                 <EditItemTemplate>
                                        <asp:DropDownList ID="ddlSubjectGv" runat="server" CssClass="form-control" > </asp:DropDownList>
                                            </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("SubjectName") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText="Charge Rs.(Per Lecture)">
                                 <EditItemTemplate>
                                   <asp:TextBox ID="txtExpenceAmt" runat="server" CssClass="form-control"  TextMode="Number" Text='<%# Eval("ChargeAmount") %>'></asp:TextBox>
                                 </EditItemTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("ChargeAmount") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                             </asp:TemplateField>

                             <asp:CommandField CausesValidation="false" HeaderText="Operation"  ShowEditButton="True" ShowDeleteButton="true">
                             <ItemStyle HorizontalAlign="Center" />
                             </asp:CommandField>
                         </Columns>
                              <HeaderStyle BackColor="#5558C9" ForeColor="White" />
                     </asp:GridView>

                 </div>
              </div>
         </div>

</asp:Content>
