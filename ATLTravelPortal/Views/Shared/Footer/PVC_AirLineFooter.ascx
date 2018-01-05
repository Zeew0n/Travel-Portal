<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="footer">
    <a href="/Airline/InfoPages/InfoPages?id=Feedback" title="About Us" class="View">About Us</a> <span>|</span> 
    <a href="/Airline/InfoPages/InfoPages?id=PrivacyPolicy" title="Privacy Policy" class="View">Privacy Policy</a> <span>|</span> 
    <a href="/Airline/InfoPages/InfoPages?id=TermsandConditions" title="Terms and Conditions" class="View">Terms and Conditions</a> <span>|</span> 
    <a href="/Airline/InfoPages/InfoPages?id=ContactUs" title="Contact Us" class="View">Contact Us</a> <span>|</span> 
    <a href="/Airline/InfoPages/InfoPages?id=GetHelp" title="Get Help" class="View">Get Help</a> <span>|</span> 
  
    <%--<a href="#">FAQs</a> --%>
    <strong>Powered by <a href="http://www.arihanttech.com" target="_blank">Arihant Technologies Ltd.</a></strong>
    <%:Html.ActionLink("FAQs", "Index", "FAQ", new  {area="Airline"},null)%>
    <font style="display:block; margin-top:-9px;">&copy; 2010 Arihant Holidays.</font>
    
</div>
<script type="text/javascript">
    ///////////////////////////////// Pop Up /////////////////////////////////////////////////
    $(function () {
        $('a.View').live("click", function (event) {
            loadDialog(this, event, '#faqcontent');
        });
    }); /* end document.ready() */
    function loadDialog(tag, event, target) {
        event.preventDefault();
        var $loading = $('<img src="../../Content/images/loadingAnimation.gif" alt="loading" class="ui-loading-icon">');
        var $url = $(tag).attr('href');
        var $title = $(tag).attr('title');
        var $dialog = $('<div></div>');
        $dialog.empty();
        $dialog
            .append($loading)
            .load($url)
		    .dialog({
		        autoOpen: false
			    , title: $title
			    , width: 800
                , modal: true
			    , minHeight: 600
                , show: 'slide'
                , hide: 'slide'
		    });

        $dialog.dialog('open');
    };
    ////////////////////////////////////////////////////////////////////////////
</script>
