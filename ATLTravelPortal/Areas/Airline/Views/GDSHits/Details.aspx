<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.GDSHitsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
            <input type="button" onclick="javascript: history.go(-1)" value="Back"  />   

               </li>
            <li>
                
            </li>
        </ul>
        <h3>
            Reports<span>&nbsp;</span><strong>Details Transaction Hits of <%:Model.AgentName %></strong>
        </h3>
    </div>
     <% var q = (from p in Model.GDSHitLists select new { p.ServiceProvider }).Distinct().ToList();

        for (int i = 0; i < q.Count(); i++)
        {
            var k = (from l in Model.GDSHitLists where l.ServiceProvider == q.ToList()[i].ServiceProvider select l).ToList();
            %>
             <fieldset class="style1" >
            <legend><%:q.ToList()[i].ServiceProvider%></legend>
      
                  <div class="contentGrid">
         
           <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>S.N.</th>
                    <th>
                        Transaction Name
                    </th>
                    <th>
                        Hits
                    </th>
                  
                </tr>
            </thead>
            <% var sno = 0;
               foreach (var item in k)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                  <td><% =sno%></td>
                    <td>
                        <%: item.TransactionName%>
                    </td>
                    <td>
                        <%: item.GDSHitCount%>
                    </td>
                </tr>
            </tbody>

            <% } %>

        </table>
         </div>
          
 </fieldset>
  <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
<%--<link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet"
        type="text/css" />--%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
 <%--<script language="javascript" type="text/javascript">
 $(function () {
            $("#accordion-D,#accordion-A").accordion({
                autoHeight: false
            });
        });
         </script>--%>
</asp:Content>
