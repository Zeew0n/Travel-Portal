<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HomePage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AccessDenied
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AccessDenied</h2>
    <div class="row-1" style="margin-top:20px">
      <img src="../../Content/images/access-denied.png" />              
      <h3 style="border:none; border-top:1px solid #ccc; padding-top:5px; width:355px; margin-left:10px;" > Sorry you are not authorized to view this page.</h3>
                   
   </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
