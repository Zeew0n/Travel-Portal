<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusSearchLogModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="pageTitle">
      <h3>
            Bus <span>&nbsp;</span> Search Logs
        </h3>
    </div>

   <form action="" method="post" style="margin-left:20px;padding:20px 0px;">
    From: <%:Html.TextBoxFor(m => m.FromDate, new {@readOnly = "readOnly" })%> &nbsp&nbsp&nbsp
    To: <%:Html.TextBoxFor(m => m.ToDate, new { @readOnly = "readOnly" })%> &nbsp&nbsp&nbsp
    Agent: <%:Html.DropDownListFor(m=>m.AgentId,Model.AgentListddl) %> 
    <input type="submit" value="Search" style="margin-top:-1px;" />
   </form>

    
        <% if (Model.SeachList != null && Model.SeachList.Any())
           {%>

           <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
        <thead>
            <tr>
                <th>S.No</th>
                <th>Name</th>
                <th>No of Search</th>
            </tr>
        </thead>
        <tbody>
              <% int Sn = 1;
               foreach (var item in Model.SeachList)
               {%>

            <tr>
                <td><%=Sn%></td>
                <td><%=item.AgentName%></td>
                <td><%=item.NoOfSearch%></td>
            </tr>

            <% Sn++;
                }
               %>
               </tbody>

    </table>
               
           <%}
           else
           { %>
           <div style="min-height:30px;color:Red;text-align:center;font-size:2em;padding-top:5px;">No Record Found</div>
           <%} %>
        

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">  
    <script language="javascript" type="text/javascript">

        $(function () {
            var dates = $("#FromDate, #ToDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "FromDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });
</script>
</asp:Content>