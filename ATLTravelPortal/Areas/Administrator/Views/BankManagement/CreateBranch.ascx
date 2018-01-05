<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.BankManagementsModel>" %>

<div id="fragment-2">
            <div class="form-box1 round-corner" id="Allrows">
                <table id="Sectors">
                    <tr>
                        <td>
                            <table style="width: 100%; border: 1px solid gray;">
                                <tr>
                                    <td width="170px" height="50px">
                                        <%: Html.Label("Branch")%>
                                        <%:Html.TextBoxFor(model => model.BranchName, new { style="width:140px"})%><span
                                            class="redtxt">*</span>
                                    </td>
                                    <td width="170px" height="50px">
                                        <%: Html.Label("Country")%>
                                        <%: Html.DropDownListFor(model => model.CountryId, new SelectList((List<TravelPortalEntity.Countries>)ViewData["Countries"], "CountryId", "CountryName"), new { style = "width:140px" })%>
                                    </td>
                                    <td width="170px" height="50px">
                                        <%: Html.Label("Phone No")%>
                                        <%:Html.TextBoxFor(model => model.BranchPhoneNumber, new { style = "width:140px" })%>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="170px" height="50px">
                                        <%:Html.Label("Address")%>
                                        <%:Html.TextAreaFor(model => model.BranchAddress, new {style="height:40px" })%><span
                                            class="redtxt">*</span>
                                    </td>
                                    <td width="170px" height="50px">
                                        <%: Html.Label("Contact Phone No")%>
                                        <%:Html.TextBoxFor(model => model.BranchContactPhoneNo, new { style = "width:140px" })%>
                                    </td>
                                    <td width="170px" height="50px">
                                        <%: Html.Label("Contact Person")%>
                                        <%:Html.TextBoxFor(model => model.BranchContactPerson, new { style = "width:140px" })%><span
                                            class="redtxt">*</span>
                                    </td>
                                    <td width="170px" height="50px">
                                        <%: Html.Label("Contact Person Email")%>
                                        <%:Html.TextBoxFor(model => model.BranchContactEmail, new { style = "width:140px" })%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <input type="button" name="Add" value="AddMore" id="AddSector" onclick="AddTableRowsClone('Sectors');"
                    class="btn1" />
            </div>
        </div>