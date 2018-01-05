<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.TrainingInquiryModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Training Inquiry List</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null){ %>
    <%: TempData["success"]%>
    <% }%>
    
        <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="loadingIndicator">
                    </div>
                </li>
                <%--<li><a href="/Airline/AirPackageInquiry/Add" class="new linkButton" title="New">New Package</a>
                </li>--%>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Inquiry</a> <span>&nbsp;</span><strong>Training</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
                   
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">

            <thead>
                <tr>
                    <th>SNo.</th>                    
                    <th>Name</th>           
                    <th>Contact</th>         
                    <th>Email</th>
                    <th>Company</th>
                    <th>Objective Of Training</th>    
                    <th>PreferredDay</th>    
                    <th>Remark</th>        
                    <th>Action</th>                   
                </tr>
            </thead>
          <% if (Model != null)
           { %>

             <% if (Model.TablularRecordList != null && Model.TablularRecordList.Count() > 0)
              { %>  
           
            <% var sno = 0;
               foreach (var item in Model.TablularRecordList)
               {

                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                    %>
            <tr>
            <td><%:sno%></td>                       
            <td><%: item.FullName%></td>
            <td><%: item.ContactNo%></td>
            <td><%: item.EmailAddress%></td> 
            <td><%: item.CompanyName%></td>         
            <td><%: item.ObjectiveOfTraning%></td>         
            <td><%: item.PreferredDay%></td>         
            <td><%: item.Remarks%></td>   
            <td>
                <p>
                    <%--<a href="/Airline/AirPackageInquiry/Edit/<%: item.PId %>" class="edit" title="Edit"></a>--%>
                    <a href="/Administrator/TrainingInquiry/Detail/<%: item.PId %>" class="details" title="Detail"></a>
                    <a href="/Administrator/TrainingInquiry/Delete/<%: item.PId %>" class="delete" title="Delete"
                        onclick="return confirm('Are you sure you want to delete?')"></a>
                    </p>
               </td>
            </tr>
          
          <%}

              }
           } %>

        </table>
       <%
            #region Data for paging
            //int TotalPages =Int32.Parse(ViewData["TotalPages"].ToString());
            //int CurrentPage = Int32.Parse(ViewData["CurrentPage"].ToString());
            //Html.RenderPartial("~/Views/Shared/Utility/VUC_Pagination.ascx", new ViewDataDictionary { { "TotalPages", TotalPages }, { "CurrentPage", CurrentPage } });
            #endregion
        %> 
        <%           
            if (Model.TablularRecordList != null && Model.TablularRecordList.Count() > 0)
            { 
         %>   
         <div class="paging">
         <%=MvcHtmlString.Create(Html.Pager(ATLTravelPortal.App_Class.AppGeneral.DefaultPageSize, Model.TablularRecordList.PageNumber, Model.TablularRecordList.TotalItemCount))%>
         </div>
        <% }
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
      


    </div>
    <div class="buttonBar">
        <%--<a href="/Airline/AirPackage/Add" class="new linkButton" title="New">New Package</a>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="/Scripts/ATL.function.js" type="text/javascript"></script>   
</asp:Content>
