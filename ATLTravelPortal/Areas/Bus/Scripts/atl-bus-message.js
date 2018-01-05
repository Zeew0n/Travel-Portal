resMessage = new Object();
resMessage.MsgStatus = false;
resMessage.MsgType = 0;
resMessage.Message = "";
function getMessage(_res) {
    var html = '';
    if (_res != null) {
        if (_res.MsgStatus == true) {
            var imgUrl = "";
            var css = "";
            var alt = "";
            var closeUrl = "";
            var style = "";
            var h1Style = "text-align: left; color: #5b7255; font-size: 11px; font-weight: bold;";
            var h2Style = "";
            // MsgType =0=Success
            // MsgType =1=information
            // MsgType =2=Alart
            // MsgType =3=Error
            // MsgType =4= Medium Success
            // MsgType =5= Mediuminformation
            // MsgType =6= MediumAlart
            // MsgType =7= MediumError
            // MsgType =8= Big Success
            // MsgType =9= Big information
            // MsgType =10= Big Alart
            // MsgType =11= Big Error
            if (_res.MsgType == 0) {
                imgUrl = "success.png";
                css = "successBox";
                alt = "Success";
                closeUrl = '/Content/icons/Success_Close.gif';
               
            }
            else if (_res.MsgType == 1) {
                imgUrl = "info.png";
                css = "infoBox";
                alt = "Information";
                closeUrl = '/Content/icons/Information_Close.gif';
            }
            else if (_res.MsgType == 2) {
                imgUrl = "alart.png";
                css = "alartBox";
                alt = "Alert";
                closeUrl = '/Content/icons/Alart_Close.gif';
            }
            else if (_res.MsgType == 3) {
                imgUrl = "error.png";
                css = "errorBox";
                alt = "Error";
                closeUrl = '/Content/icons/Error_Close.gif';
            }
            else if (_res.MsgType == 10) {
                imgUrl = "alart.png";
                css = "alartBox";
                alt = "Alart";
                closeUrl = '/Content/icons/Alart_Close.gif';
                style = "left:11%; top:20%;width:972px;height:200px;";
                h1Style = "text-align: left; color: #5b7255; font-size: 15px; font-weight: bold;";
                h2Style = "text-align: left; color: #5b7255; font-size: 20px; font-weight: bold;";
            }
            var url = '/Content/Icons/';
            url = url + imgUrl;
            html += '<div class="message-box ' + css + '" style="' + style + '" id="MessagePupUp">';
            html += '<img src="' + closeUrl + '" onclick="javascript:closeMessage()" style="position: relative; float: right;  cursor:pointer;" />';
            html += ' <div  style="padding: 12px; float:left"><img alt="' + alt + '" src="' + url + '" /></div>';
            html += '<div  style=" float:left; text-align: left; padding: 2px;">';
            html += '<h2 style="' + h2Style + '">' + alt + ' Notification</h2><h1 style="' + h1Style + '">' + _res.ActionMessage + '</h1>';
            html += '</div></div>';
        }
    }
    return html;
}
function closeMessage() {
    $("#MessagePupUp").remove();
}