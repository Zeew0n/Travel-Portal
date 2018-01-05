<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.RoleBasedRoleModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
      <%: Html.TextBoxFor(m => m.ProductName)%> 
        <%: Html.ValidationMessageFor(m => m.ProductName)%>
        <%: Html.HiddenIndexerInputForModel() %>