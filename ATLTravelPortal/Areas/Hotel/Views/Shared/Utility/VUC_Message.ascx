<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.HotelMessageModel>" %>
<% if (Model.MsgStatus == true)
   {
       string imgUrl = "";
       string css = "";
       string alt = "";
       string closeUrl = "";
       string style = "left:33%; top:25%;";
       string h1Style = "text-align: left; color: #5b7255; font-size: 11px; font-weight: bold;";
       string h2Style = "";
       // ErrType =0=Success
       // ErrType =1=information
       // ErrType =2=Alart
       // ErrType =3=Error
       // ErrType =4= Medium Success
       // ErrType =5= Mediuminformation
       // ErrType =6= MediumAlart
       // ErrType =7= MediumError
       // ErrType =8= Big Success
       // ErrType =9= Big information
       // ErrType =10= Big Alart
       // ErrType =11= Big Error
       if (Model.MsgType == 0)
       {
           imgUrl = "success.png";
           css = "htl-successBox";
           alt = "Success";
           closeUrl = Url.Content("~/Content/Icons/Success_Close.gif");
       }
       else if (Model.MsgType == 1)
       {
           imgUrl = "info.png";
           css = "htl-infoBox";
           alt = "Information";
           closeUrl = Url.Content("~/Content/Icons/Information_Close.gif");
       }
        else if (Model.MsgType == 2)
       {
           imgUrl = "alart.png";
           css = "htl-alartBox";
           alt = "Alart";
           closeUrl = Url.Content("~/Content/Icons/Alart_Close.gif");
       }
       else if (Model.MsgType == 3)
       {
           imgUrl = "error.png";
           css = "htl-errorBox";
           alt = "Error";
           closeUrl = Url.Content("~/Content/Icons/Error_Close.gif");
       }
       else if (Model.MsgType == 10)
       {
           imgUrl = "alart.png";
           css = "htl-alartBox";
           alt = "Alart";
           closeUrl = Url.Content("~/Content/Icons/Alart_Close.gif");
           style = "left:11%; top:20%;width:972px;height:200px;";
           h1Style = "text-align: left; color: #5b7255; font-size: 15px; font-weight: bold;";
           h2Style = "text-align: left; color: #5b7255; font-size: 20px; font-weight: bold;";
       }
       var url = Url.Content("~/Content/Icons/");
       url = url + imgUrl;
%>
<div class="<%=css %>" style="<%=style%>" id="MessagePupUp">
    <img src="<%=closeUrl%>" onclick="javascript:closeMessage()" style="position: relative;
        float: right;  cursor:pointer;" />
    <div class="float-left" style="padding: 22px;">
        <img alt="<%=alt %>" src="<%=url%>" class="float-left" /></div>
    <div class="float-right" style=" width: 78%; text-align: left; padding: 5px;">
        <h2 style="<%=h2Style %>">
            <%=alt %> Notification</h2>
        <h1 style="<%=h1Style %>">
            <%=Model.ActionMessage %></h1>
    </div>
</div>
<script type="text/javascript">
    function closeMessage() {
         $("#MessagePupUp").remove();
    }
</script>
<% }%>
