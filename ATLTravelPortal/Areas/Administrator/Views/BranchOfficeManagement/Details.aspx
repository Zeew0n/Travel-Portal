<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.BranchOfficeManagementModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "BranchOfficeManagement" }, new { @class = "linkButton" })%></li>
            </ul>
        </div>
        <h3>
            <a href="#">System Setup</a> <span>&nbsp;</span><strong>Branch Office Management</strong><span>&nbsp;</span><strong>Details
            </strong>
        </h3>
    </div>

    <div class="wiz-container">
        <ul>
            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                <h2>
                    1. Branch Office Basic Info</h2>
            </a></li>
        </ul>
        <div class="wiz-body">
            <div>
                <div class="wiz-content">
                    <div class="row-1">
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.BranchOffice) %></label>:
                                    <%: Model.BranchOffice %>
                                  
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.NativeCountry) %></label>:
                                  <%: Model.NativeCountryName %>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Zone) %></label>:
                                 <%: Model.ZoneName %>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.District) %></label>:
                                   <%: Model.DistrictName %>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Address )%></label>:
                                   <%: Model.Address %>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Phone) %></label>:
                                 <%: Model.Phone %>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Email )%></label>:
                                   <%: Model.Email %>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Fax )%></label>:
                                  <%: Model.Fax %>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.PanNo) %></label>:
                                   <%: Model.PanNo %>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Web) %></label>:
                                   <%: Model.Web %>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.status )%></label>:
                                  <%: Model.status %>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.TimeZone) %></label>:
                                    <%: Model.TimeZoneName %>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

    </div>






     <div class="wiz-container">
        <ul>
            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                <h2>
                    1. Branch Authorize User</h2>
            </a></li>
        </ul>
        <div class="wiz-body">
            <div>
                <div class="wiz-content">
                    <div class="row-1">
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.FullName) %></label>:
                                  <%: Model.FullName %>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                 <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.UserName) %></label>:
                                   <%: Model.UserName %>
                                </div>
                            </div>
                        </div>
                      
                       
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.UserEmail )%></label>:
                                    <%: Model.UserEmail %>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model => model.UserAddress)%></label>:
                                    <%: Model.UserAddress %>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.MobileNo) %></label>:
                                 <%: Model.MobileNo %>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model => model.UserPhone)%></label>:
                                   <%: Model.UserPhone %>
                                </div>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/style_wizard.css" rel="stylesheet" type="text/css" />
      <link href="../../../../Content/css/slidedeck.skin.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/slidedeck.skin.ie.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .form-box1-row-content div span.field-validation-error
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
 <script src="../../../../Scripts/slidedeck.jquery.lite.js" type="text/javascript"></script>
  <script type="text/javascript">
      $('.extendBtn').live("click", function (event) {
          event.preventDefault();
          if ($('.balanceContent').css("display") == "none") {
              $('.balanceContent').css('display', 'block');
              $(this).addClass('expanded').removeClass('collapsed');
          }
          else {
              $('.balanceContent').css('display', 'none');
              $(this).addClass('collapsed').removeClass('expanded');
          }
      });
</script>
</asp:Content>