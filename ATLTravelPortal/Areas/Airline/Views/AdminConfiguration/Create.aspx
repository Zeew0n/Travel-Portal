<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AdminConfigurationModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Admin Configuration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>


    <% Html.EnableClientValidation(); %>

     <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Settings</a> <span>&nbsp;</span><strong>Configuration</strong>
            </h3>
        </div>
    </div>

    <%using (Html.BeginForm("Create", "AdminConfiguration", FormMethod.Post))
      { %>
    <%: Html.ValidationSummary(true) %>
    <div class="box3">
      
        <div class="buttons-panel float-right">
            <ul>
                <li>
                    <input type="submit" value="Save" class="save" />
                </li>
                
            </ul>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">

           <%-- Notifications--%>
           
           <legend>__________Notifications________________________________________________________________</legend>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                   <div>
                            <%: Html.CheckBoxFor(model => model.chkEmailEveryTimeBookingIsMade)%>Email me everytime a booking
                            is made.
                        </div>
                </div>
            </div>
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                            <%: Html.CheckBoxFor(model => model.chkEmailEveryTimePNRIsMade)%>Email me everytime a PNR is released.
                        </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                            <label>Send Email to:</label>
                        </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                             <%: Html.TextBoxFor(model => model.txtSendMailTo)%>
                        </div>
                </div>
            </div>


         
           <br /><br />
           <legend>__________MarkUp________________________________________________________________</legend>
           <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                            <%: Html.RadioButtonFor(model => model.rdbMarkupCharge, "includeinTax", new { @checked = "checked" })%>Include
                            in Tax
                        </div>
                </div>
                <div class="form-box1-row-content float-right">
                   <div>
                              <%: Html.RadioButtonFor(model => model.rdbMarkupCharge, "includeinFare")%>Include in Fare
                        </div>
                </div>
            </div>

            <br />
             <label>Domestic</label>
             <div class="form-box1-row">
            
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Type</label>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                   <div>
                              <% List<SelectListItem> listDomestic = new List<SelectListItem>{
                                        new SelectListItem {Selected = true, Text = "Fixed", Value = "1"},
                                        new SelectListItem {Selected = false, Text = "Percent", Value = "2"}
                                       
                                    };%>
                        <%:Html.DropDownListFor(model => model.ddlDomesticType, listDomestic)%>
                        </div>
                </div>

                <div class="form-box1-row-content float-left">
                  <div>
                        <label>
                            Value</label>
                    </div>
                </div>
                 <div class="form-box1-row-content float-right">
                  <div>
                         <%: Html.TextBoxFor(model => model.txtDomesticValue)%>
                    </div>
                </div>

            </div>
            <label>International</label>
            <div class="form-box1-row">
             <%--<label>International</label>--%>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Type</label>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                   <div>
                            <% List<SelectListItem> listInternational = new List<SelectListItem>{
                                        new SelectListItem {Selected = true, Text = "Fixed", Value = "1"},
                                        new SelectListItem {Selected = false, Text = "Percent", Value = "2"}
                                       
                                    };%>
                        <%:Html.DropDownListFor(model => model.ddlInternationType, listInternational)%>
                        </div>
                </div>

                <div class="form-box1-row-content float-left">
                  <div>
                        <label>
                            Value</label>
                    </div>
                </div>
                 <div class="form-box1-row-content float-right">
                  <div>
                        <%: Html.TextBoxFor(model => model.txtInternationalValue)%>
                    </div>
                </div>

            </div>

            <br /><br />
             <div class="form-box1-row">

             <div class="form-box1-row-content float-left">
                    <div>
                            <label>TTL</label>
                        </div>
                </div>


                <div class="form-box1-row-content float-right">
                    <div>
                            <%: Html.TextBoxFor(model => model.TTL)%>
                        </div>
                </div>
                </div>

           
         
        </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Content/themes/base/jquery.ui.dialog.css" />
    <link href="../../Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/themes/base/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/themes/base/jquery.ui.base.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
    .type-option { margin:0px 0px 0px 5px; padding:5px 10px; width:250px; overflow:hidden;
border: 1px solid #ccc;
border-bottom:none;
background-color: #F9F9BB;
border-radius: 6px 6px 0px 0px;
-moz-border-radius: 6px 6px 0px 0px;
-webkit-border-bottom-right-radius: 0px;
-webkit-border-bottom-left-radius: 0px;
}
div.type-option label { float:left; width:auto; margin-right:15px; font:11px/18px Arial;}
div.type-option input[type="radio"] { width:20px; margin-left:15px; font:11px/18px Arial;}
div.type-option span {font:11px/18px Arial;}
</style>
</asp:Content>
