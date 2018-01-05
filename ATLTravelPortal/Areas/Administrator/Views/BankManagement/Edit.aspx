<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.BankManagementsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation();%>
    <%--<% using (Html.BeginForm("Edit", "BankManagements", FormMethod.Post, new {id="AtForm" }))--%>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true)%>
    <%:Html.HiddenFor(model =>model.BankId) %>
    

    <div class="pageTitle">
         <div class="float-right">
            
                    <input type="submit" value="Save" />
                        <%:Html.HiddenFor(model => model.hfCheckBankOrBranch)%>
                        <%:Html.HiddenFor(model => model.hfCount)%>
                        <%:Html.HiddenFor(model => model.BankId)%>
                        <%:Html.HiddenFor(model=>model.hfBranchId)%>
               
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "BankManagement" }, new { @class = "linkButton float-right" })%>
                
        </div>
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Bank Management</strong><span>&nbsp;</span><strong>Edit</strong>
        </h3>
    </div>


    <div id="tabs" class="tabes">
        <ul>
            <li><a href="#fragment-1"><span>Edit Bank</span></a></li>
            <li><a href="#fragment-2"><span>Edit Branch</span></a></li>
        </ul>
        <div id="fragment-1">
            <div class="form-box1 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Bank")%>
                            </label>
                            <%: Html.TextBoxFor(model => model.BankName, new { id = "BankName" })%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.BankName)%>
                            <div id="check_agentname" style="display: block;">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Address")%></label>
                            <%: Html.TextAreaFor(model => model.BankAddress)%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.BankAddress)%></div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Country")%></label>
                            <%: Html.DropDownListFor(model => model.CountryId, Model.ddlCountriesList)%>
                            <%: Html.ValidationMessageFor(model => model.BankName)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Phone No")%></label>
                            <%: Html.TextBoxFor(model => model.PhoneNo)%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.PhoneNo)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Contact Person")%></label>
                            <%: Html.TextBoxFor(model => model.ContactPerson)%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.ContactPerson)%></div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Contact Phone No")%></label>
                            <%: Html.TextBoxFor(model => model.ContactPersonPhoneNo)%>
                            <%: Html.ValidationMessageFor(model => model.ContactPersonPhoneNo)%></div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Contact Mobile No")%></label>
                            <%: Html.TextBoxFor(model => model.ContactPersonMobileNo)%>
                            <%: Html.ValidationMessageFor(model => model.ContactPersonMobileNo)%></div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Contact Person Email")%></label>
                            <%: Html.TextBoxFor(model => model.ContactPersonEmail)%>
                            <%: Html.ValidationMessageFor(model => model.ContactPersonEmail)%></div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="contentGrid">
              <table id="Branchtable" cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
                <thead>
                    <tr>
                        <th>Branch</th>
                        <th>Branch Phone No</th>
                        <th>Contact Person</th>
                        <th>Contact Phone No;</th>
                        <th>&nbsp;</th>
                        
                    </tr>
                </thead>
                <tbody>
                    <%if (Model.GetAllBranch != null)
                      {%>
                    <%
                        var sno = 0;
                          foreach (var item in Model.GetAllBranch)
                          {
                              sno++;
                              var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                   
                    %>
                    <tr id="Branch-method-<%= item.BankBranchId %> tr_<%=sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">
                        <td><%=Html.Encode(item.BranchName) %></td>
                        <td><%= Html.Encode(item.BranchPhoneNumber)%></td>
                        <td><%= Html.Encode(item.BranchContactPerson)%></td>
                        <td><%= Html.Encode(item.BranchContactPhoneNo)%>
                        </td>
                        
                        <td>
                            <%--<input type = "button" value="Detail" class="detail" onclick ="alert('hello')"; meta:id="<%=item.BankBranchId %>" />
                    <input type = "button" value="Edit" class="edit" onclick ="alert('hello')"; meta:id="<%=item.BankBranchId %>" />
                    <input type = "button" value="Delete" class="delete" onclick ="alert('hello')"; meta:id="<%=item.BankBranchId %>" />--%>
                            <a href="#" class="edit-Branch" meta:id="<%= item.BankBranchId %>" >
                                <img border="0" class="edit" src="" title="Edit" /></a> 
                                <a href="#" class="delete-Branch"
                                     meta:id="<%= item.BankBranchId %>">
                                    <img border="0" class="delete" src="" title="Delete" /></a> <a href="#" class="detail-Branch"
                                        meta:id="<%= item.BankBranchId %>" >
                                        <img border="0" class="details" src="" title="Details" /></a>
                        </td>
                        <td style="display: none;">
                                        <%=item.BranchAddress%>
                                    </td>
                                    <td style="display: none;">
                                        <%=item.BranchContactEmail%>
                                    </td>
                                    <td style="display: none;">
                                        <%=item.CountryId%>
                                    </td>
                                    <td style="display: none;">
                                        <%=item.BankId%>
                                    </td>
                        <%--a href="#" class="edit-AgentBank-method-button" meta:id="<%= item.BankBranchId %>"><img border="0" class="detail" src="" title="Detail"/><a href="#" class="edit-AgentBank-method-button" meta:id="<%= item.BankBranchId %>"><img border="0" class="edit" src="" title="Edit"/></a>
         <a href="#" class="delete-AgentBank-method-button" meta:id="<%= item.BankBranchId %>" ><img border="0" class="delete" src="" title="Delete"/></a></td>
         <td style="display: none;"><%=item.BankId%></td><td style="display: none;"><%=item.BankId%></td> <td style="display: none;"><%=item.BankId%></td>--%>
                    </tr>
                    <%}
           }%>
                </tbody>
            </table>
            </div>

            <%-- <div id="ListPartial">
                <%Html.RenderPartial("BranchList"); %>
            </div>--%>
            <%if (Model.GetAllBranch != null)
              { %>
            <input type="button" name="Add" value="Add Branch" id="AddSector" onclick="UnHideTable();"
                class="btn1" />

            <table id="ListBranch" style="width: 100%; border: 1px solid gray; visibility: hidden">
                <tr>
                    <td >
                        <%: Html.Label("Branch")%>
                        <%:Html.TextBoxFor(model => model.BranchName)%>
                            
                    </td>
                    <td >
                        <%: Html.Label("Country")%>
                        <%: Html.DropDownListFor(model => model.BranchCountryId, Model.ddlCountriesList)%>
                    </td>
                    <td >
                        <%: Html.Label("Phone No")%>
                        <%:Html.TextBoxFor(model => model.BranchPhoneNumber)%>
                    </td>
                </tr>
                <tr>
                    <td >
                        <%:Html.Label("Address")%>
                        <%:Html.TextAreaFor(model => model.BranchAddress)%>
                            
                    </td>
                    <td>
                        <%: Html.Label("Contact Phone No")%>
                        <%:Html.TextBoxFor(model => model.BranchContactPhoneNo)%>
                    </td>
                    <td>
                        <%: Html.Label("Contact Person")%>
                        <%:Html.TextBoxFor(model => model.BranchContactPerson)%>
                    </td>
                    <td>
                        <%: Html.Label("Contact Person Email")%>
                        <%:Html.TextBoxFor(model => model.BranchContactEmail)%>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <input type="button" value="Cancel" class="btn1" onclick="HideTable();" />
                    </td>
                    <td>
                        <input type="button" value="Save" class="btn1" id="BranchSave" onclick="SaveBranch();" />
                    </td>
                </tr>
            </table>
            <div id="Detail" style="visibility: hidden;">
                <%Html.RenderPartial("BranchDetails"); %>
            </div>
            <div id="Edit" style="visibility: hidden;">
                <%Html.RenderPartial("EditBranch"); %>
            </div>
           
        </div>
        <%} %>
    </div>
   
    <% }
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
  <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ddaccordion.js" type="text/javascript"></script>
   <script src="../../../../Scripts/ATL.core.function.js" type="text/javascript"></script>
    <script type="text/javascript">
        
        $(document).ready(function () {
            var selectedTab = 0;
            var branch = 0;
            $("#tabs").tabs({
                select: function (event, ui) {
                    selectedTab = ui.index;
                    $("#hfCheckBankOrBranch").val(selectedTab);
                    
                }
            });
            resetId(tableId);
            $("#sabmit").click(function () {

                $("#hfCount").val(tblRowIncrease);

            });
            $(window).keydown(function (event) {
                if (event.keyCode == 13) {
                    event.preventDefault();
                    return false;
                }
            });
        });
        function UnHideTable() {
            $("#ListBranch").css('visibility', 'visible');
            $("#ListBranch").insertBefore("#Detail");
            // AddTableRowsClone('Sectors');

        }
        function HideTable() {
            $("#ListBranch").css('visibility', 'hidden');
            $("#BranchName").val("");
            $("#BranchCountryId").val("");
            $("#BranchPhoneNumber").val("");
            $("#BranchAddress").val("");
            $("#BranchContactPhoneNo").val("");
            $("#BranchContactPerson").val("");
            $("#BranchContactEmail").val("");

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////For Saving Branch////////////////////////////////////////////////////////////////       
        function SaveBranch() {

            var BankId = $("#BankId").val();
            var BranchName = $("#BranchName").val();
            var BranchCountryId = $("#BranchCountryId").val();
            
            var BranchPhoneNumber = $("#BranchPhoneNumber").val();
            var BranchAddress = $("#BranchAddress").val();
            var ContactPhoneNo = $("#BranchContactPhoneNo").val();
            var ContactPerson = $("#BranchContactPerson").val();
            var ContactEmail = $("#BranchContactEmail").val();
            var BranchId = $("#hfBranchId").val();
            $("#ListBranch").css('visibility', 'hidden');
            $.post(
		"/Administrator/AjaxRequest/AddUpdateBranch",
		{ BankId: BankId, BranchId: BranchId, BranchCountryId: BranchCountryId, BranchName: BranchName, BranchPhoneNumber: BranchPhoneNumber, BranchAddress: BranchAddress, ContactPhoneNo: ContactPhoneNo, ContactPerson: ContactPerson, ContactEmail: ContactEmail },
		function (data) {

		    var checkrow = $("#Branchtable").find(" #Branch-method-" + data.BankBranchId);

		    //		    $("#Branch-method-" + data.BankBranchId).fadeOut("slow", function () { $(this).remove() });
		    var html = '<tr id="Branch-method-' + data.BankBranchId + '">';
		    html += '<td>' + data.BranchName + '</td>';
		    html += '<td>' + data.BranchPhoneNumber + '</td>';
		    html += '<td>' + data.BranchContactPerson + '</td>';
		    html += '<td>' + data.BranchContactPhoneNo + '</td>';
		    html += '<td><a href="#" class="edit-Branch" meta:id="' + data.BankBranchId + '" ><img border="0" class="edit" src="" title="Edit"/></a><a href="#" class="delete-Branch" meta:id="' + data.BankBranchId + '" ><img border="0" class="delete" src="" title="Delete"/></a><a href="#" class="detail-Branch" meta:id="' + data.BankBranchId + '" ><img border="0" class="details" src="" title="Details" /></a></td>';
		    html += '<td style = "display: none;">' + data.BranchAddress + '</td>';
		    html += '<td style = "display: none;">' + data.BranchContactEmail + '</td>';
		    html += '<td style = "display: none;">' + data.BranchCountryId + '</td>';
		    html += '<td style = "display: none;">' + data.BankId + '</td>';

		    html += '</tr>';

		    if (("Branch-method-" + data.BankBranchId) == checkrow.attr("id")) {
		        $("#Branch-method-" + data.BankBranchId).remove();
		        $("#Branch-method-" + data.BankBranchId).replaceWith(html);
		    }
		    $("#Branchtable").append(html);
		    $("#BranchName").val("");
		    $("#BranchCountryId").val("");
		    $("#BranchPhoneNumber").val("");
		    $("#BranchAddress").val("");
		    $("#BranchContactPhoneNo").val("");
		    $("#BranchContactPerson").val("");
		    $("#BranchContactEmail").val("");
		},
		"json"
	);
		
            return false;
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////For Editing Branch//////////////////////////////////////////////////////////////////////////////

        $(".edit-Branch").live("click", function () {

            var BranchId = $(this).attr("meta:id");
            var BranchName = $(this).closest('tr').find('td').eq(0).text();
            BranchName = jQuery.trim(BranchName);
            //var BranchName = $(this).closest('tr').find('td').eq(1).text();
            var BranchPhoneNumber = $(this).closest('tr').find('td').eq(1).text();
            BranchPhoneNumber = jQuery.trim(BranchPhoneNumber);
            var BranchContactPerson = $(this).closest('tr').find('td').eq(2).text();
            BranchContactPerson = jQuery.trim(BranchContactPerson);
            var BranchContactPhoneNo = $(this).closest('tr').find('td').eq(3).text();
            BranchContactPhoneNo = jQuery.trim(BranchContactPhoneNo);
            var BranchAddress = $(this).closest('tr').find('td').eq(5).text();
            BranchAddress = jQuery.trim(BranchAddress);
            var BranchContactEmail = $(this).closest('tr').find('td').eq(6).text();
            BranchContactEmail = jQuery.trim(BranchContactEmail);
            var BranchCountryId = $(this).closest('tr').find('td').eq(7).text();
            var BankId = $(this).closest('tr').find('td').eq(8).text();
            BankId = jQuery.trim(BankId);
            // $("#BankId").append("<option value='" + BankId + "' selected=\"selected\">" + BankName + "</option>");
            $('#BranchName').val(BranchName);
            $('#BankBranchId').val(BranchId);
            $('#BranchPhoneNumber').val(BranchPhoneNumber);
            $('#BranchAddress').val(BranchAddress);
            $('#BranchContactPhoneNo').val(BranchContactPhoneNo);
            $('#BranchContactEmail').val(BranchContactEmail);
            $('#BranchContactPerson').val(BranchContactPerson);
            $("#BankId").val(BankId);
            $("#ListBranch").css('visibility', 'visible');
            $("#hfBranchId").val(BranchId);

            return false;
        });

        ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////// Deleting Branch /////////////////////////////////////////////////

        $(".delete-Branch").live("click", function () {
            var BranchId = $(this).attr("meta:id");
            
            if (confirm("Do you want to delete this record?")) {
                $.post(
		"/Administrator/BankManagement/DeleteBranch",
		{ id: BranchId },
		function (data) {
		    $("#Branch-method-" + data).css("background-color", "lightgreen");
		    $("#Branch-method-" + data).fadeOut("slow", function () { $(this).remove() });
		},
		"json"
	);
            }
            return false;
        });
        
    </script>
</asp:Content>
