<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="ATLTravelPortal.Models" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<% if (Session["ActionResponse"] != null)
   {
       ActionResponse obj = (ActionResponse)Session["ActionResponse"];
   %>
<% 
       if (obj.ResponseStatus == true)
       {
           string style = "";
           if (obj.ErrNumber > 0)
           {
               style = "errorBox";
           }
           else { style = "messageBox"; } %>
<div class="<%=style%>" id="errorpopupregion">
   
    <a class="errorBubbleClose" href="#" rel="close" title="Close">
        <img src="../../Content/Icons/cancel.png" /></a>
    <img src="../../Content/Icons/error.png" class="float-left" />&nbsp;<%=obj.ActionMessage%>
   
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('.errorBubbleClose').live("click", function (event) {
            event.preventDefault();
            $("#errorpopupregion").css('display', 'none');
        });

    });
</script>
<% 
           Session["ActionResponse"] = null;
       }
   } %>


  