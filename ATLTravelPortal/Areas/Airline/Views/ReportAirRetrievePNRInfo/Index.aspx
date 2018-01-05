<%@ Page Title="" Language="C#"  MasterPageFile="~/Views/Shared/AirlineMain.Master"
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.PNRReportModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Report Air Retrieve PNR
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Retrieve PNR</strong>
            </h3>
        </div>
    </div>

     <%  using (Html.BeginForm( 
             ViewContext.RouteData.Values["Action"].ToString(), 
             ViewContext.RouteData.Values["Controller"].ToString(), FormMethod.Post,
        new { @id = "ATForm", @autocomplete = "off" }
        ))
         {%>

         <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>

    <div class="row-1">
        <div class="form-box1 round-corner">

            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(m => m.PNRId)%></label>
                            <%: Html.TextBoxFor(m => m.PNRId)%>
                            <%: Html.ValidationMessageFor(m => m.PNRId)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(m => m.AgentId)%></label>
                            <%: Html.DropDownListFor(m => m.AgentId , Model.ddlAgentIdList, new{ @class="required"})%>
                            <%: Html.ValidationMessageFor(m => m.AgentId, "*")%>
                    </div>
                </div>
                </div>
                <div class="form-box1-row" id="Div1">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(m => m.GDSRefrenceNumber)%></label>
                            <%:Html.TextBoxFor(m => m.GDSRefrenceNumber)%>
                            <%: Html.ValidationMessageFor(m => m.GDSRefrenceNumber)%>
                    </div>
                </div>
            
           
                 <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(m => m.FullName)%></label>
                            <%: Html.TextBoxFor(m => m.FullName)%>
                          
                    </div>
                </div>
            </div>



        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
    </div>
    </div>

    <%
    }
    %>
    <% Html.RenderPartial("VUC_List"); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
 <script src="../../Scripts/jquery.Datepicker-1.8.2.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.Datepicker-1.8.2.js" type="text/javascript"></script>
     <script src="../../Scripts/ATL.function.js" type="text/javascript"></script>
</asp:Content>
