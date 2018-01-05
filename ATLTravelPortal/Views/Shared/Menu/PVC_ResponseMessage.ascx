<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<string>>" %>
<div class="atsfltsearchWrap clearfix">
    <div class="PNRsuccessBoxWrap">
        <p class="PNRsuccessBox">
        </p>
       <%-- <img src="../../../../Content/images/icons/success-big.png" style="vertical-align: middle" />&nbsp;--%>
        <img src="../../../Content/Icons/success.png" style="vertical-align: middle"  />&nbsp;
        <ul>
        
            <%
                if(Model != null)
                foreach (var msg in Model)
               {
            %>
             <li>
             <%: msg %>
            </li>
       
            <% } %>
        </ul>
    </div>
</div>
