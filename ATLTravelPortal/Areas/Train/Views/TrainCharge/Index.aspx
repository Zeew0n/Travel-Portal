<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TrainMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Train.Models.TrainChargeModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="pageTitle">
        <h3>
            <a class="icon_plane" href="#"></a> Train Setting<span>&nbsp;</span><strong>Train Charges</strong>
        </h3>
    </div>
            
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Index", "TrainCharge", FormMethod.Post))
       {%>
    <%: Html.ValidationSummary(true)%>
   <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo.
                    </th>
                    <th>
                         Train Name (Code)
                    </th>
                    <th>
                         IRCTCS Charge
                    </th>
                    <th>
                         Agent Charge
                    </th>
                    <th>
                         AH Markup
                    </th>
                    <th>
                         Agent Commission
                    </th>
                    <th>
                         Supplier Commission
                    </th>                   
                </tr>
            </thead>
              
                   <%int id = 0; var sno = 0; if (Model.List != null)
                     {
                         if (Model.List.Count() > 0)
                         {
                            
                             foreach (var item in Model.List)
                             {
                                 sno++;
                                 var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                                 %> 
                 <tr>
                     <td><%:sno %></td>
                     <td><%=item.ClassName%>(<%=item.ClassCode %>)<input type="hidden" name="List[<%=id %>].ClassCode" id="List_<%=id %>__ClassCode" value="<%=item.ClassCode %>" /></td>
                     <td><input type="text" disabled id="List_<%=id %>__IrctcsCharge" name="List[<%=id %>].IrctcsCharge" value="<%=item.IrctcsCharge %>" /></td>
                     <td><input type="text" disabled id="List_<%=id %>__AgentCharge" name="List[<%=id %>].AgentCharge" value="<%=item.AgentCharge %>" /></td>
                     <td><input type="text" disabled id="List_<%=id %>__AhMarkUp" name="List[<%=id %>].AhMarkUp" value="<%=item.AhMarkUp %>" /></td>
                     <td><input type="text" disabled id="List_<%=id %>__AgentCommission" name="List[<%=id %>].AgentCommission" value="<%=item.AgentCommission %>" /></td>
                     <td><input type="text" disabled id="List_<%=id %>__SupplierCommission" name="List[<%=id %>].SupplierCommission" value="<%=item.SupplierCommission %>" /></td>
                </tr>                   
                   <% id++;
                             }  
                             }   
                             
                         else
                         
                             foreach (var item in Model.ClassList)
                             {
                                 sno++;
                                 var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                                  %> 
                 <tr>
                     <td><%:sno %></td>
                     <td><%=item.Text%>(<%=item.Value%>)<input type="hidden" name="List[<%=id %>].ClassCode" id="list_<%=id %>__ClassCode" value="<%=item.Value %>" /></td>
                     <td><input type="text"  id="List_<%=id %>__IrctcsCharge" name="List[<%=id %>].IrctcsCharge" value="" /></td>
                     <td><input type="text"  id="List_<%=id %>__AgentCharge" name="List[<%=id %>].AgentCharge" value="" /></td>
                     <td><input type="text"  id="List_<%=id %>__AhMarkUp" name="List[<%=id %>].AhMarkUp" value="" /></td>
                     <td><input type="text"  id="List_<%=id %>__AgentCommission" name="List[<%=id %>].AgentCommission" value="" /></td>
                     <td><input type="text"  id="List_<%=id %>__SupplierCommission" name="List[<%=id %>].SupplierCommission" value="" /></td>
                </tr>
                   <%id++;
                             }
                     }
                     else { 
                     foreach (var item in Model.ClassList)
                             {
                                 sno++;
                                 var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                         %> 
                  <tr>
                     <td><%:sno %></td>
                     <td><%=item.Text%>(<%=item.Value%>)<input type="hidden" name="List[<%=id %>].ClassCode" id="list_<%=id %>__ClassCode" value="<%=item.Value %>" /></td>
                     <td><input type="text"  id="List_<%=id %>__IrctcsCharge" name="List[<%=id %>].IrctcsCharge" value="" /></td>
                     <td><input type="text"  id="List_<%=id %>__AgentCharge" name="List[<%=id %>].AgentCharge" value="" /></td>
                     <td><input type="text"  id="List_<%=id %>__AhMarkUp" name="List[<%=id %>].AhMarkUp" value="" /></td>
                     <td><input type="text"  id="List_<%=id %>__AgentCommission" name="List[<%=id %>].AgentCommission" value="" /></td>
                     <td><input type="text"  id="List_<%=id %>__SupplierCommission" name="List[<%=id %>].SupplierCommission" value="" /></td>
                  </tr>
                   <%id++;
                             }
                     }
                      %>
        </table>
   </div>

  <%if (Model.List == null)
    {%>
            <div class="buttonBar">
              <ul class="buttons-panel">
                <li>
                   <input id="submit" type="submit" value="Save" />
                </li>
             </ul>
           </div>
           <%} %>
           
   
<%} %>

<%if (Model.List!=null)
  {%>
       <div>
         <input type="button" onclick="document.location.href='/Train/TrainCharge/Edit'" value="Edit" />
    </div>
    <%} %>
   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
