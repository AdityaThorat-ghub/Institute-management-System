﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmst.Master" AutoEventWireup="true" CodeBehind="MarkDetails.aspx.cs" Inherits="InstituteManagementSystemCsharp.net.Admin.MarkDetails" %>
<%@ Register Src="~/MarksDetailUserControl.ascx" TagPrefix="uc" TagName="MarksDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            
        <uc:MarksDetail  runat="server" ID="MarksDetail1"/>

</asp:Content>
