<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.BankManagementsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm())
      {%>
    
    <div class="pageTitle">
        <div class="float-right">
            	<%:Html.ActionLink("Cancel", "Index", new { controller = "BankManagement" }, new { @class = "linkButton" })%>
            </div>
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Bank Management</strong>
        </h3>
    </div>

    <br />
    <div class="row-1">
    <h3><strong><%:ViewData["Bank"] %></strong> </h3>
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                   <div> <label>
                        Bank Name:</label>
                    <%:Model.BankName %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div> <label>
                        Bank Address:
                    </label>
                    <%:Model.BankAddress %></div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div> <label>
                        Phone No:</label>
                    <%:Model.PhoneNo %></div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div> <label>
                        Contact Person:
                    </label>
                    <%:Model.ContactPerson %></div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                   <div>  <label>
                        Contact Phone No:</label>
                    <%:Model.ContactPersonPhoneNo %></div>
                </div>
                <div class="form-box1-row-content float-right">
                   <div>  <label>
                        Contact Mobile No:
                    </label>
                    <%:Model.ContactPersonMobileNo %></div>
                </div>
            </div>
            <div class="form-box1-row border-btm">
                <div class="form-box1-row-content float-left">
                    <div> <label>
                        Email:</label>
                    <%:Model.ContactPersonEmail %></div>
                </div>
            </div>
        </div>
    </div>
    <%if (Model.GetAllBranch.Count() != 0)
      {
          foreach (var item in Model.GetAllBranch)
          { %>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    Branch:
                </label>
                <%:item.BranchName%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    Branch Address:
                </label>
                <%:item.BranchAddress%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    Branch Phone No:
                </label>
                <%:item.BranchPhoneNumber%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    Contact Person:
                </label>
                <%:item.BranchContactPerson%>
            </div>
        </div>
    </div>
    <div class="form-box1-row border-btm">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    Contact Phone No:
                </label>
                <%:item.BranchContactPhoneNo%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    Contact Email:
                </label>
                <%:item.BranchContactEmail%>
            </div>
        </div>
    </div>
    <%}
      } %>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
