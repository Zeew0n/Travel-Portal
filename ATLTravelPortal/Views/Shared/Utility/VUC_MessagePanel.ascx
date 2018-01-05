<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div id="myMessageBox" class="">

        <%------------for error message---------------%>


<% if (TempData["ActionResponse"] != null && TempData["ActionResponse"].ToString() != "")
   { %>
  <div class="errorBox" id="errorpopupregion">
  <a class="errorBubbleClose" href="#" rel="close" title="Close">
   <img src="../../../Content/Icons/bubble_close.gif" /></a>
   <img src="../../../Content/Icons/error.png" class="float-left" />
   &nbsp;<%:TempData["ActionResponse"]%>
   </div>
   <% } %>


         <%------------for info message---------------%>

   <% if (TempData["InfoMessage"] != null && TempData["InfoMessage"].ToString() != "")
      { %>
    <div class="infoBox" id="infopopupregion">
        <a class="infoBubbleClose" href="#" rel="close" title="Close">
            <img src="../../../Content/Icons/bubble_close.gif" /></a>
        <img src="../../../Content/Icons/info.png" class="float-left" />
        &nbsp;<%:TempData["InfoMessage"]%>
    </div>
    <%} %>


       <%------------for success message---------------%>

       <% if (TempData["SuccessMessage"] != null && TempData["SuccessMessage"].ToString() != "")
          { %>
    <div class="successBox" id="successpopupregion">
        <a class="successBubbleClose" href="#" rel="close" title="Close">
            <img src="../../../Content/Icons/bubble_close.gif" /></a>
        <img src="../../../Content/Icons/success.png" class="float-left" />
        &nbsp;<%:TempData["SuccessMessage"]%>
    </div>
         <%} %>


</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('.errorBubbleClose').live("click", function (event) {
            event.preventDefault();
            $("#errorpopupregion").css('display', 'none');
        });
        $('.infoBubbleClose').live("click", function (event) {
            event.preventDefault();
            $("#infopopupregion").css('display', 'none');
        });
        $('.successBubbleClose').live("click", function (event) {
            event.preventDefault();
            $("#successpopupregion").css('display', 'none');
        });
        $('.GeneralinfoMessageBoxBubbleClose').live("click", function (event) {
            event.preventDefault();
            $("#GeneralinfoMessageBoxpopupregion").css('display', 'none');
        });
    });
</script>
