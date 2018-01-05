<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/HotelMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelInfos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%if (ViewData["success"] != null)
      { %>
    <%: ViewData["success"] %>
    <%} %>
    <% Html.EnableClientValidation();%>
    <% using (Html.BeginForm("Create", "HotelInfo", FormMethod.Post,
         new { @id = "ATForm", @autocomplete = "off" }))
       {%>
    <div class="buttons-panel">
        <ul>
            <li>
                <input type="submit" value="submit" class="save" />
            </li>
            <li>
                <%:Html.ActionLink("Cancel", "List", new { controller = "HotelInfo" }, new { @class = "cancel" })%>
            </li>
        </ul>
    </div>
    <h2>
        General Information</h2>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelName)%></label>
                        <%: Html.TextBoxFor(model => model.HotelName)%>
                        <%: Html.ValidationMessageFor(model => model.HotelName)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelCode)%></label>
                        <%: Html.TextBoxFor(model => model.HotelCode)%>
                        <%: Html.ValidationMessageFor(model => model.HotelCode)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Country")%></label>
                        <%: Html.DropDownListFor(model => model.HotelInfo.CountryId, Model.CountryList)%>
                        <%= Html.ValidationMessageFor(m => m.CountryId)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Web)%></label>
                        <%: Html.TextBoxFor(model => model.Web)%>
                        <%: Html.ValidationMessageFor(model => model.Web)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelType)%>
                        </label>
                        <%: Html.DropDownListFor(model => model.HotelType, Model.HotelTypeList)%>
                        <%= Html.ValidationMessageFor(m => m.HotelType)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Email)%></label>
                        <%: Html.TextBoxFor(model => model.Email)%>
                        <%: Html.ValidationMessageFor(model => model.Email)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.OptionalEmail)%></label>
                        <%: Html.TextBoxFor(model => model.OptionalEmail)%>
                        <%: Html.ValidationMessageFor(model => model.OptionalEmail)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Address)%></label>
                        <%: Html.TextBoxFor(model => model.Address)%>
                        <%: Html.ValidationMessageFor(model => model.Address)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Phone)%></label>
                        <%: Html.TextBoxFor(model => model.Phone)%>
                        <%: Html.ValidationMessageFor(model => model.Phone)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.OptionalPhone)%></label>
                        <%: Html.TextBoxFor(model => model.OptionalPhone)%>
                        <%: Html.ValidationMessageFor(model => model.OptionalPhone)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.Details)%></label>
                        <%: Html.TextAreaFor(model => model.Details)%>
                        <%: Html.ValidationMessageFor(model => model.Details)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%:Html.Label("Image")%></label>
                        <input type="file" id="File1" name="Logo" />
                    </div>
                </div>
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.isActive)%></label>
                    <%=Html.CheckBoxFor(model => model.isActive)%>
                    <%= Html.ValidationMessageFor(m => m.isActive)%>
                </div>
            </div>
        </div>
    </div>
    <h2>
        Contact Person Information</h2>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.OwnerFullName)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.OwnerFullName)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.OwnerFullName)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.Label("OwnerDesignation")%></label>
                        <%= Html.DropDownListFor(model=> model.HotelContactInfo.OwnerDesignationId, new SelectList(Model.DesignationList, "DesignationId", "Designation"))%>
                        <%= Html.ValidationMessageFor(m => m.HotelContactInfo.OwnerDesignationId)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.OwnerEmail)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.OwnerEmail)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.OwnerEmail)%>
                    </div>
                </div>
               <%-- <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.Label("Owner Country")%></label>
                        <%: Html.DropDownListFor(model => model.HotelInfo.CountryId, Model.CountryList)%>
                        <%= Html.ValidationMessageFor(m => m.CountryId)%>
                    </div>
                </div>
            </div>--%>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.OwnerMobile)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.OwnerMobile)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.OwnerMobile)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.OwnerLandline)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.OwnerLandline)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.OwnerLandline)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.OwnerTempAddress)%></label>
                        <%: Html.TextAreaFor(model => model.HotelContactInfo.OwnerTempAddress)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.OwnerTempAddress)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.OwnerPermAddress)%></label>
                        <%: Html.TextAreaFor(model => model.HotelContactInfo.OwnerPermAddress)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.OwnerPermAddress)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.OwnerDOB)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.OwnerDOB)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.OwnerDOB)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.ContactFullName)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.ContactFullName)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.ContactFullName)%>
                    </div>
                </div>
            </div>
           <%-- <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.Label("Contact Designation")%></label>
                        <%= Html.DropDownListFor(model => model.HotelContactInfo.ContactDesignationId, new SelectList(Model.DesignationList, "DesignationId", "Designation"))%>
                        <%= Html.ValidationMessageFor(m => m.HotelContactInfo.ContactDesignationId)%>
                    </div>
                </div>--%>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.ContactEmail)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.ContactEmail)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.ContactEmail)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Contact Country")%></label>
                    <%: Html.DropDownListFor(model => model.HotelInfo.CountryId, Model.CountryList)%>
                    <%= Html.ValidationMessageFor(m => m.CountryId)%>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.ContactMobile)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.ContactMobile)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.ContactMobile)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.ContactLandline)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.ContactLandline)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.ContactLandline)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.ContactTempAddress)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.ContactTempAddress)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.ContactTempAddress)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.ContactPermAddress)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.ContactPermAddress)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.ContactPermAddress)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.HotelContactInfo.ContactDOB)%></label>
                        <%: Html.TextBoxFor(model => model.HotelContactInfo.ContactDOB)%>
                        <%: Html.ValidationMessageFor(model => model.HotelContactInfo.ContactDOB)%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="box3">
        <div class="userinfo">
            <h3>
                Location/City Information</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                    <%:Html.ActionLink("Add New", "PopupCityInfo", "HotelInfo", new { id = "" }, new { @class = "new" })%></li>
            </ul>
        </div>
    </div>
    <fieldset>
        <p>
            <input type="checkbox" name="ChkIdAll" id="_parent" class="permissionDetailParentCheck" />Select
            All
            <br />
        </p>
        <%
            foreach (var o in Model.HotelCityInfoList)
            {
                string checkvalue = "";

                if (Model.HotelCityInfoList != null)
                {
                    foreach (var selected in Model.HotelCityInfoList)
                    {
                        if (o.CityId == selected.CityId)
                        {
                            checkvalue = "checked=checked";
                            break;
                        }
                        else
                            checkvalue = "";
                    }
                }
        %>
        <input type="checkbox" name="city_<%: o.CityId %>_chkbox" value="<%=o.CityId %>"
            <%=checkvalue %> id="city_<%: o.CityId %>_chkbox" class="_parent" />
        <%=Html.Encode(o.CityName )%>
        <%} %>
    </fieldset>
    <div class="box3">
        <div class="userinfo">
            <h3>
                Additional Charge
            </h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                    <%:Html.ActionLink("Add New", "PopupAdditionalCharge", "HotelInfo", new { id = "" }, new { @class = "new" })%></li>
            </ul>
        </div>
    </div>
    <p>
        <input type="checkbox" name="ChkIdAll" id="Checkbox1" class="permissionDetailParentCheck" />Select
        All
        <br />
    </p>
    <fieldset>
        <p>
            <%   foreach (var o in Model.HotelAdditionalChargeList)
                 {
                     string checkvalue = "";
                     if (Model.HotelAdditionalChargeList != null)
                     {
                         foreach (var selected in Model.HotelAdditionalChargeList)
                         {
                             if (o.ChargeId == selected.ChargeId)
                             {
                                 checkvalue = "checked=checked";
                                 break;
                             }
                             else
                                 checkvalue = "";
                         }
                     }
            %>
            <input type="checkbox" name="additionalcharge_<%: o.ChargeId %>_chkbox" value="<%=o.ChargeId %>"
                <%=checkvalue %> id="additionalcharge_<%: o.ChargeId %>_chkbox" class="Checkbox1" />
            <%=Html.Encode(o .ChargeName  )%>
            <% }          
            %>
        </p>
    </fieldset>
    <div class="box3">
        <div class="userinfo">
            <h3>
                Room Type</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                    <%:Html.ActionLink("Add New", "PopupHotelRoomType", "HotelInfo", new { id = "" }, new { @class = "new" })%>
                </li>
            </ul>
        </div>
    </div>
    <fieldset>
        <p>
            <input type="checkbox" name="ChkIdAll" id="Checkbox2" class="permissionDetailParentCheck" />Select
            All
            <br />
        </p>
        <%           
            foreach (var o in Model.HotelRoomTypeList)
            {
                string checkvalue = "";
                if (Model.HotelRoomTypeList != null)
                {

                    foreach (var selected in Model.HotelRoomTypeList)
                    {
                        if (o.HotelRoomTypeId == selected.HotelRoomTypeId)
                        {
                            checkvalue = "checked=checked";
                            break;
                        }
                        else
                            checkvalue = "";
                    }
                }
        %>
        <input type="checkbox" name="roomtype_<%: o.HotelRoomTypeId %>_chkbox" value="<%=o.HotelRoomTypeId %>"
            <%=checkvalue %> id="roomtype_<%: o.HotelRoomTypeId %>_chkbox" class="Checkbox2" />
        <%=Html.Encode(o.TypeName )%>
        <% }
          
        %>
    </fieldset>
    <div class="box3">
        <div class="userinfo">
            <h3>
                Facility</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                    <%:Html.ActionLink("Add New", "PopupHotelFacility", "HotelInfo", new { id = "" }, new { @class = "new" })%>
                </li>
            </ul>
        </div>
    </div>
    <p>
        <input type="checkbox" name="ChkIdAll" id="Checkbox3" class="permissionDetailParentCheck" />Select
        All
        <br />
    </p>
    <fieldset>
        <p>
            <%           
                foreach (var o in Model.HotelFacityList)
                {
                    string checkvalue = "";
                    if (Model.HotelFacityList != null)
                    {
                        foreach (var selected in Model.HotelFacityList)
                        {
                            if (o.FacilityId == selected.FacilityId)
                            {
                                checkvalue = "checked=checked";
                                break;
                            }
                            else
                                checkvalue = "";
                        }
                    }
            
            %>
            <input type="checkbox" name="facility_<%: o.FacilityId %>_chkbox" value="<%=o.FacilityId %>"
                <%=checkvalue %> id="facility__<%: o.FacilityId %>_chkbox" class="Checkbox3" />
            <%=Html.Encode(o.FacilityName )%>
            <% }
          
            %>
        </p>
    </fieldset>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ATL.PopUp.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /////////////////////// POP UP Function //////////////////////////////////////
            $(function () {

                //                $('a.edit').live("click", function (event) {
                //                    loadEditDialog(this, event, '#contentGrid');

                //                });
                $('a.new').live("click", function (event) {
                    loadDialog(this, event, '#contentGrid');

                });
                //                $('a.Details').live("click", function (event) {
                //                    loadDetailsDialog(this, event, '#contentGrid');

                //                });

            });
            /////////////////End of new fucntion/////////////////

            //            $('.ChkBoxParent').click(function () {
            //                $('.ChkBoxChild').attr('checked', $(this).attr('checked'));
            //            });

            //            $('.ChkBoxChild').click(function () {
            //                var childCheckBox = $('.ChkBoxChild');
            //                var checkedAllStatus = true;
            //                for (var i = 0; i < childCheckBox.length; i++) {
            //                    if (!$(childCheckBox[i]).is(':checked')) {
            //                        checkedAllStatus = false;
            //                    }
            //                }
            //                $('.ChkBoxParent').attr('checked', checkedAllStatus);
            //            });
        });   /* end document.ready() */
        
       

    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('.validate').validate();
            //Cheked/UnChecked all child check box if parent check box is Checked/Unchecked .
            $('.permissionDetailParentCheck').live("click", function () {
                var e = $(this).attr('id');
                if ($(this).attr('checked') == true) {
                    $('.' + e).attr('checked', 'checked');
                }
                else {
                    $('.' + e).removeAttr('checked');
                }
            });

            $('._parent').live("click", function () {
                var e = $(this).attr('id');
                var childCheckBox = $('._parent');
                var checkedAllStatus = true;
                for (var i = 0; i < childCheckBox.length; i++) {
                    if (!$(childCheckBox[i]).is(':checked')) {
                        checkedAllStatus = false;
                    }
                }
                $('.ChkBoxParent').attr('checked', checkedAllStatus);
            });
        }); </script>
</asp:Content>
