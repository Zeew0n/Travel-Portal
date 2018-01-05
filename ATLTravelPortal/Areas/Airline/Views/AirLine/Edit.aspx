<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirLinesModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Edit", "AirLine", FormMethod.Post, new { @id = "ATForm", @autocomplete = "off", enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true) %>
<div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="loadingIndicator">
                    </div>
                </li>
                <li>
                    <input type="submit" value="Save" /></li>
                <li>
                    <input type="button" value="Cancel"  onclick="document.location.href='/Airline/AirLine/'" />
                </li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Edit AirLine</strong>
            </h3>
        </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AirlineCode)%></label>
                        <%: Html.TextBoxFor(model => model.AirlineCode) %>
                        <%: Html.ValidationMessageFor(model => model.AirlineCode) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%
                            string a = Model.AirlineCode;
                            string b = Model.AirlineName;
                            string c = Model.Photo;
                        %>
                        <input type="hidden" id="Code" name="Code" value="<%: a%>" />
                        <input type="hidden" id="Name" name="Name" value="<%: b%>" />
                        <input type="hidden" id="Image" name="Image" value="<%: c%>" />
                        <label>
                            <%: Html.LabelFor(model => model.AirlineName)%></label>
                        <%: Html.TextBoxFor(model => model.AirlineName) %>
                        <%: Html.ValidationMessageFor(model => model.AirlineName) %>
                    </div>
                </div>
            </div>
         <%--   <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <%
                        string photoLocation = "~/AirlineUploads/" + Model.AirlineCode + "/" + Model.AirlineName + "/" + Model.Photo;
                        string photoPath = "~/AirlineUploads/" + Model.AirlineCode + "/" + Model.AirlineName + "/";
                    %>
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Photo)%></label>
                        <img src='<%= ResolveUrl(photoLocation.Replace("_sm","_th")) %>' width="110" height="90"
                            alt="Travel Portal" />
                        <%: Html.HiddenFor(model => model.Photo)%>
                        <input type="hidden" id="OldPhoto" name="OldPhoto" value="<%: photoLocation%>" />
                        <input type="hidden" id="Path" name="Path" value="<%: photoPath%>" />
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            &nbsp;</label>
                        <input name="uploadFile" type="file" id="picField" />
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
               
                
                </div>
                </div>--%>
            </div>


              <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div><label>&nbsp;&nbsp;&nbsp;</label>
                        <label>
                            Settlement with  <%: Html.CheckBoxFor(model => model.chkSettlement)%> Self</label>
                       <%-- <%: Html.CheckBoxFor(model => model.chkSettlement)%> <label>Self</label>--%>
                       
                    </div>
                </div>
            </div>
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AccTypes)%></label>
                        <%: Html.DropDownListFor(model => model.AccTypes, Model.AccTypesList, "--- Select---")%>
                        <%--<%: Html.ValidationMessageFor(model => model.AccTypes, "*")%>--%>
                    </div>
                </div>
            </div>
             <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>&nbsp;&nbsp;&nbsp;
                           </label>
                        <%: Html.DropDownListFor(model => model.BSPorConsolidatorId, Model.BSPorConsolidatorList, "--- Select---")%>
                       <%-- <%: Html.ValidationMessageFor(model => model.BSPorConsolidatorId, "*")%>--%>
                    </div>
                </div>
            </div>


            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AirlineTypId)%></label>
                        <%: Html.DropDownListFor(model => model.AirlineTypId,Model.AirlineTypList,Model.AirlineTypId)%>
                        <%: Html.ValidationMessageFor(model => model.AirlineTypId, "*")%>
                    </div>
                </div>
            </div>


            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.CountryId)%></label>
                        <%: Html.DropDownListFor(model => model.CountryId, Model.CountryList)%>
                        <%: Html.ValidationMessageFor(model => model.CountryId, "*")%>
                    </div>
                </div>
            </div>

          
        </div>
      <%--  <div class="buttonBar">
<input type="submit" value="Save"  />     <input type="button" onclick="document.location.href='/Airline/AirLine/'" value="Cancel"  />  
                </div>--%>

   
    <% } %>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">





        /////// Get BSP or Consolidator Type on selecting AccTypes////////////////////////////////////
        $(document).ready(function () {

            $("#AccTypes").change(function () {
                id = $("#AccTypes").val();
                if (id == "") {
                    return false;
                }
                else {
                    //build the request url
                    var url = "/Airline/AjaxRequest/GetLedgerNameofBSPorConsolidatorBasedonAccTypes";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#BSPorConsolidatorId").empty();
                        $("#BSPorConsolidatorId").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#BSPorConsolidatorId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();

        });
        ////////////////////////////////////////////////////////////////////////

        </script>
</asp:Content>
