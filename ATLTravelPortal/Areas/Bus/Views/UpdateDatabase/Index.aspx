<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Online Database Update
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="pageTitle">
      <h3>
            Bus <span>&nbsp;</span> Online Update Database
        </h3>
    </div>
    <div id="OnlineUpdatecheck">
    
    
        <div id="cityupdate"><input type="checkbox" id="Updatecity" /> :<span class="textupdate"> Cities</span></div>
        <div id="stationupdate"><input type="checkbox" id="UpdateStation" /> :<span class="textupdate"> Stations</span></div>
        <div id="categoryupdate"><input type="checkbox" id="UpdateCategory" /> :<span class="textupdate"> Categories</span></div>
        <div id="operatorupdate"><input type="checkbox" id="UpdateOperator" /> :<span class="textupdate"> Operators</span></div>
        <div id="routescheduleupdate"><input type="checkbox" id="UpdateRouteSchedule" /> :<span class="textupdate"> RouteSchedules</span></div>
    </div>
    <div id="lowbtn">
        <ul>
            <li><input type="button" value="Update" onclick="beginupdate();" /></li>            
        </ul>        
    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <style type="text/css">
        
        #OnlineUpdatecheck
        {
            margin-top:20px;
            padding-left:10%; width:250px;            
        }
        
        .textupdate
        {
            padding-left:10px;
            color:#2222DD;
        }
        #lowbtn { width:30%; border-top: 1px solid #DDD;margin-top:10px; }
        #lowbtn ul {float:right;}
        #lowbtn ul li {padding-left:10px; float:left; }
        .removestatus{float:right;}
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        function beginupdate() {

            $(".removestatus").remove();
            var str = "";
            if ($('#Updatecity').is(':checked')) {
                str = '<text class="removestatus" id="removetextcity"></text>'; $("#cityupdate").append(str);
                $("#removetextcity").html('<text style="color:Orange;">Updating...</text>');
                 getUpdateResult('/Bus/UpdateDatabase/CityUpdate', 'removetextcity');
                               
            }
             if ($('#UpdateStation').is(':checked')) {
                 str = '<text class="removestatus" id="removetextstation"></text>'; $("#stationupdate").append(str);
                 $("#removetextstation").html('<text style="color:Orange;">Updating...</text>');
                 getUpdateResult('/Bus/UpdateDatabase/StationUpdate', 'removetextstation');
            }
            if ($('#UpdateCategory').is(':checked')) {
                str = '<text class="removestatus" id="removetextcategory"></text>'; $("#categoryupdate").append(str);
                $("#removetextcategory").html('<text style="color:Orange;">Updating...</text>');
                getUpdateResult('/Bus/UpdateDatabase/CategoryUpdate', 'removetextcategory');
            }
            if ($('#UpdateOperator').is(':checked')) {
                str = '<text class="removestatus" id="removetextOperator"></text>'; $("#operatorupdate").append(str);
                $("#removetextOperator").html('<text style="color:Orange;">Updating...</text>');
                getUpdateResult('/Bus/UpdateDatabase/OperatorUpdate', 'removetextOperator');
            }
            if ($('#UpdateRouteSchedule').is(':checked')) {
                str = '<text class="removestatus" id="removetextrouteschedule"></text>'; $("#routescheduleupdate").append(str);
                $("#removetextrouteschedule").html('<text style="color:Orange;">Updating...</text>');
                getUpdateResult('/Bus/UpdateDatabase/RouteScheduleUpdate', 'removetextrouteschedule');
            }
         }

         function getUpdateResult(getUrl, fillDiv) {
             //formData = $("form[id$=" + formName + "]").serialize();
             $.ajax(
                {
                    type: 'POST',
                    url: getUrl,
                    data: "",
                    dataType: "HTML",
                    async: false,
                    cache: false,
                    success: function (getData) {                       
                        $("#" + fillDiv).html(getData)
                    }
                })
                var elem = document.getElementById(fillDiv);
                var res = $("#"+fillDiv).html();
                if (res == "Updated") { elem.style.color = "Green"; }
                else if (res == "Failed") { elem.style.color = "Red"; }
               

         }

    </script>
  
</asp:Content>
