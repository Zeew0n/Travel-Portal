<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirPackageGroupModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="loadingIndicator">
                    </div>
                </li>
                <li><a href="/Airline/AirPackageGroup/Index" class="new linkButton" title="New">Cancel</a>
                </li>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Package Management</a> <span>&nbsp;</span><strong>Package Details</strong>
            </h3>
        </div>
    </div>

   <div class="row-1">
   
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                   <div> <label>
                      </label>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div> <label>
                     
                    </label>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div> <label>
                    </label>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div> <label>
                    
                    </label>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                   <div>  <label>
                    </label>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                   <div>  <label>
                    
                    </label>
                    </div>
                </div>
            </div>
            <div class="form-box1-row border-btm">
                <div class="form-box1-row-content float-left">
                    <div> <label>
                    </label>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
