<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirOfflineSettingViewModel.AirOfflineSettingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Index", "AirOfflineSetting", FormMethod.Post, new { @id = "ATForm", @autocomplete = "off", enctype = "multipart/form-data" }))
       {%>
       <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "AirOfflineSetting" }, new { @class = "linkButton" })%>
                          <input type="submit" value="Save" />
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">Indian LCC</a> <span>&nbsp;</span><strong>Offline Airlines</strong></h3>
        </div>
    </div>
    <%:Html.ValidationSummary(true)%>
    <%
           if (Model != null)
               if (Model.AirlineList.Count > 0)
               { %>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo.
                    </th>
                    <th>
                        Airline
                    </th>
                    <th>
                        Airline Code
                    </th>
                    <th>
                        Status [Is Offline]
                    </th>
                    <th>
                        Action
                    </th>
                </tr>
            </thead>
            <tbody>
                <% var sno = 0;
                   var countList = Model.AirlineList.Count;
                   for (int i = 0; i < countList; i++)
                   {
                       sno++;
                       var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem"; %>
                <tr>
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%:Model.AirlineList[i].AirlineName%>
                        <%: Html.HiddenFor(model=>model.AirlineList[i].PId) %>
                    </td>
                    <td>
                        <%:Model.AirlineList[i].AirlineCode%>
                    </td>
                    <td>
                        <%:Html.CheckBoxFor(model => model.AirlineList[i].IsOffline)%>
                    </td>
                    <td style="width: 55px;">
                      
                  <a href="/Airline/AirOfflineSetting/Delete/<%:Model.AirlineList[i].PId%>" class="delete"
                            title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                        </a>
                    </td>
                </tr>
                <% } %>
            </tbody>
        </table>
           
    </div>
  <%--  <input type="submit" value="Save" />--%>
    <% }

       } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
    function deleteConfirm(id) { 
    if(confirm("Are you sure you want to Delete ?")) {
        $.ajax({
            url: "/Airline/AirOfflineSetting/Delete", type: "POST", dataType: "json",
            data: { id : id }
        });
    }
    else 
    return false;
    }
    </script>
</asp:Content>
