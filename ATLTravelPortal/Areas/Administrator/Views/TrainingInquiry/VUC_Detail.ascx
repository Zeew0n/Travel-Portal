<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Models.PackageModel>" %>
<%if (Model != null)
  { %>
<%var strippedString = Model.Description; %>

<div class="lftDiv">
    <div id="PackageDetailTab" style="display: none; height: 100%; padding: 7px; -webkit-border-radius: 4px;
        -moz-border-radius: 4px; border-radius: 4px; background: none;">
        <div class="tour">
            <div class="blockDetail">
                <img width="120" height="88" alt="<%=Model.Name %>" src="<%=Model.ImageURL %>" class="blockImage" />
                <div class="cont">
                    <h3>
                        <%=Model.Name %></h3>
                    <div class="blockFare">
                        <p>
                            Starting From</p>
                        <h3>
                            Rs
                            <%=Model.StartingPrice%>
                            <span>Per Person</span></h3>
                       
                        <div id="SendPackageInquiryDialog" title="Package Inquiry" style="display: none;">
                            <img src="/Content/images/loadingAnimation.gif" alt="loading..." style="text-align: center;
                                margin: 0 auto;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearboth">
        </div>
        <!-- the tabs -->
        <ul class="ntabs" style="background: none;">
            <li><a href="#PackageDetailTabs-1">Overview</a></li>
            <li><a href="#PackageDetailTabs-2">Rate</a></li>
            <li><a href="#PackageDetailTabs-3">Inclusive/Exclusive</a></li>
            <li><a href="#PackageDetailTabs-4">Itinerary </a></li>
            <li><a href="#PackageDetailTabs-5">Destination</a></li>
            <li><a href="#PackageDetailTabs-6">T&C</a></li>
            <li><a href="#PackageDetailTabs-7">Gallery</a></li>
        </ul>
        <!-- tab "panes" -->
        <div id="PackageDetailTabs-1">
            <%:MvcHtmlString.Create(Model.Overview)%>
        </div>
        <div id="PackageDetailTabs-2">
            <%:MvcHtmlString.Create(Model.Rate)%>
        </div>
        <div id="PackageDetailTabs-3">
            <%:  MvcHtmlString.Create(Model.InclusiveAndExclusive)%></div>
        <div id="PackageDetailTabs-4">
            <%: MvcHtmlString.Create(Model.Itineary) %></div>
        <div id="PackageDetailTabs-5">
            <%:  MvcHtmlString.Create(Model.Destination)%></div>
        <div id="PackageDetailTabs-6">
            <%:   MvcHtmlString.Create(Model.TermAndConditions)%></div>
        <div id="PackageDetailTabs-7" style="padding-top: 15px;">
            <%if (Model.ImageNameList != null)
              { %>
            <%Html.RenderPartial("Gallery", Model);%>
            <%} %>
        </div>
    </div>
</div>
<%}
  else
  { %>
Package Not Found!!
<%} %>

<style type="text/css">
    .ui-tabs .ui-tabs-panel
    {
        background: #fafbfc !important;
        padding: 8px;
        border-top: 2px solid #79B7E7 !important;
        border-bottom: 2px solid #79B7E7 !important;
        min-height: 350px;
        height: auto !important;
        height: 350px;
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
        border-radius: 3px;
    }
    
    .ui-tabs .ui-tabs-nav li
    {
        top: 2px !important;
    }
    span.current, span.pageActiveLink:hover, a.pageActiveLink:hover
    {
        border: 1px solid #ccc;
    }
    .ui-tabs .ui-tabs-nav li a
    {
        padding: 0.7em 1em;
    }
    .lftDiv
    {
        border: none;
    }
</style>
<script type="text/javascript">
    $(function () {
        $("#PackageDetailTab").tabs({ disabled: [] });
        $('#PackageDetailTab').css('display', 'block');
    });

</script>
