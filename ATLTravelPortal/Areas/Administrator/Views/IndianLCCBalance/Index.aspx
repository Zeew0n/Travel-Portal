<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Indian LCC Balance
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div class="pageTitle">


        <div class="float-right">
            	<ul>
               
                       <li><%Html.RenderPartial("Utility/PVC_MessagePanel"); %> </li>
                	<li>
                    
                    </li>
                    
                   
                </ul>
            </div>
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Indian LCC Balance</strong>
        </h3>
        </div>
        <% Html.EnableClientValidation(); %>
    <%using (Ajax.BeginForm("Index", "IndianLCCBalance", new AjaxOptions()
                      {
                          UpdateTargetId = "SearchResult",
                          OnBegin = "beginList",
                          OnSuccess = "successList",
                          InsertionMode = InsertionMode.Replace,
                          HttpMethod = "Post",

                      }))
      { %>
    <%: Html.ValidationSummary(true)%>
             <div class="row-1">
         <div class="divRight">
            <input type="submit" value="Check" name="Check" class="float-left" />
            <div id="lblloading"></div><br />
            <div class="clearboth"></div>
            <div style="border:1px solid #ccc;  margin-top: 10px;">
                <p  style=" line-height:32px;"><span class="float_left" style="border-right:1px solid #ccc;  display: inline-block; height: 32px;  line-height: 32px; padding: 10px;"><img src="../../../../Content/images/balance.png" width="32px" />INR</span><span id="SearchResult" style="font-size:16px; color:Green; padding:10px; line-height:32px; height:32px;"></span></p>
            </div>
            </div>
          </div>
        
    
      
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" language="javascript">
        function beginList(args) {
            $("#lblloading").html('<img src="<%=Url.Content("../../../../Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />');

        }
        function successList() {
            $("#lblloading").html('');
        }        
    </script>
</asp:Content>
