<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.BankManagementsModel>" %>

<%using (Ajax.BeginForm(new AjaxOptions {  }))
  {
             %>
<table style="width: 100%; border: 1px solid gray;">
                                <tr>
                                    <td width="200px" height="60px" >
                                        <%: Html.Label("Branch")%>
                                        <%:Html.TextBoxFor(model => model.BranchName, new { style = "width:130px" })%><span
                                            class="redtxt">*</span>
                                    </td>
                                    <td width="200px" height="60px">
                                        <%: Html.Label("Country")%>
                                        <%: Html.DropDownListFor(model => model.BranchCountryId, Model.ddlCountriesList)%>
                                    </td>
                                    <td width="200px" height="60px">
                                        <%: Html.Label("Phone No")%>
                                        <%:Html.TextBoxFor(model => model.BranchPhoneNumber, new { style = "width:140px" })%>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="200px" height="60px">
                                        <%:Html.Label("Address")%>
                                        <%:Html.TextAreaFor(model => model.BranchAddress, new { style = "height:40px" })%><span
                                            class="redtxt">*</span>
                                    </td>
                                    <td width="200px" height="60px">
                                        <%: Html.Label("Contact Phone No")%>
                                        <%:Html.TextBoxFor(model => model.BranchContactPhoneNo, new { style = "width:140px" })%>
                                    </td>
                                    <td width="200px" height="60px">
                                        <%: Html.Label("Contact Person")%>
                                        <%:Html.TextBoxFor(model => model.BranchContactPerson, new { style = "width:140px" })%><span
                                            class="redtxt">*</span>
                                    </td>
                                    <td width="200px" height="60px">
                                        <%: Html.Label("Contact Person Email")%>
                                        <%:Html.TextBoxFor(model => model.BranchContactEmail, new { style = "width:140px" })%>
                                    </td>
                                </tr>
                                <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                 <%--<%:Ajax.ActionLink("Save", "Edit", "BankManagements", new { id = Model.BankBranchId }, new AjaxOptions { UpdateTargetId = "BranchList", OnSuccess = "Hide",HttpMethod="POST" }, new {@class="btn1",@title="Save" })%>--%>
                                 <input type="submit" value="Save" class="btn1"  />
                                 <%--<input type = "button" value="Save" class="btn1" onclick="Details();" />--%>
                                 <input type="button" value="Cancel" class="btn1" onclick="Hide();" />
                                </td>
                                </tr>
                                <%--<%:Html.HiddenFor(model=>model.BankBranchId) %>--%>
                              <%-- <%:Html.HiddenFor(model => model.hfCheckBankOrBranch)%>--%>
                                <%:Html.HiddenFor(model=>model.BankBranchId) %>
                            </table>


       <%} %>

                            <script language="javascript" type="text/javascript">
                                function Hide() {
                                    $("#Detail").css('visibility', 'hidden');
                                }

                                
                            </script>