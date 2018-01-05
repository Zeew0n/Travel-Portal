<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ import namespace="ATLTravelPortal.App_Class" %>
<script type="text/javascript">
    function ShowMessageBox(msg, imgIndex) {    
        var imgArr = new Array();
        imgArr[0] = "/Content/Icons/success.png";
        imgArr[1] = "/Content/Icons/error.png";
        imgArr[2] = "/Content/Icons/info.png";
        //imgArr[3] = "/Content/Icons/exclamation.png";        
        $("#imgFooterMessage").attr({ src: imgArr[imgIndex], alt: "Message Image: " });
        $("#lblFooterMessage").empty().append(msg);
        $("#myMessageBox").show();

    }
    $(document).ready(function () {
        $('.errorBubbleClose').live("click", function (event) {
            event.preventDefault();
            $("#myMessageBox").hide();
        });
    });
</script>
<div id="myMessageBox" class="errorBox"  style="display:none;">  
    <a class="errorBubbleClose" href="javascript:void();" rel="close" title="Close"><img src="/Content/Icons/bubble_close.gif" alt="close" /></a>
    <img id="imgFooterMessage" class="float-left" alt="" />&nbsp;&nbsp;
    <span id="lblFooterMessage" style="display:inline;"></span>
    
</div>
<%

    var actionResponseMessage = "";

    var response = TempData["ActionResponse"] as ServiceResponse;
    if (response != null)
    {
        string search = "\r\n";
        string replace = " ";
        System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(search);
        var responseMsg = rgx.Replace(response.ResponseMessage.ToString(), replace);
        var responseIcon = 0;
        var responseClass = "";
        if (response.ResponseStatus == true && response.ResponseMessageType == MessageType.Success)
        {
            if (response.ResponseTransactionMode == "N")
            {
                responseIcon = 0;
                responseClass = "successBox";        
                //if (Model.ShowMask==true){
                //    actionResponseMessage += "ShowMaskBox('contentFormElement');";
                //}
            }
            else
            {
                responseIcon = 0; responseClass = "successBox";         
                

            }

        }
        else if (response.ResponseStatus == false
            && (response.ResponseMessageType == MessageType.Error           
            )
            )
        {

            responseIcon = 1; responseClass = "errorBox";        


        }
        else if (response.ResponseStatus == false
           && (response.ResponseMessageType == MessageType.Warning
           || response.ResponseMessageType == MessageType.Exception
           || response.ResponseMessageType == MessageType.SqlException
           )
           )
        {

            responseIcon = 2; responseClass = "infoBox";        


        }
        actionResponseMessage = "ShowMessageBox('" + responseMsg + "', '" + responseIcon + "');";
        
    }
    
if (actionResponseMessage != "")
{
%>    
    <%:MvcHtmlString.Create("<script type=\"text/javascript\">" + actionResponseMessage + " </script>")%>
<%
}  
%>
