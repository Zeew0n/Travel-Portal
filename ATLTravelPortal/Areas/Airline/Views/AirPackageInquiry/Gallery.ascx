<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Models.PackageModel>" %>
<% if (Model.ImageNameList.Count() > 0)
   {
%>
<!-- Start Advanced Gallery Html Containers -->
<div id="thumbs" class="navigation">
    <ul class="thumbs noscript">
        <%  foreach (var item in Model.ImageNameList)
            {%>
        <li><a class="thumb" name="leaf" href="<%=Model.PackageImageRootURL + "/" + Model.ImageFolderName + "/Images/" + item %>"
            title="Title #0">
            <img src="<%=Model.PackageImageRootURL + "/" + Model.ImageFolderName + "/Thumbnail/" + item %>"
                width="55" height="55" alt="Title #0" />
        </a></li>
        <%} %>
    </ul>
</div>
<div id="gallery" class="gcontent">
    <div id="controls" class="controls">
    </div>
    <div class="slideshow-container">
        <div id="loading" class="loader">
        </div>
        <div id="slideshow" class="slideshow">
        </div>
    </div>
    <div id="caption" class="caption-container">
    </div>
</div>
<div style="clear: both;">
</div>
<link href="../../../../Content/galleriffic/galleriffic-2.css" rel="stylesheet" type="text/css" />
<script src="../../../../Scripts/galleriffic/jquery.galleriffic.js" type="text/javascript"></script>
<script src="../../../../Scripts/galleriffic/jquery.opacityrollover.js" type="text/javascript"></script>
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        // We only want these styles applied when javascript is enabled
        $('div.navigation').css({ 'width': '100%', 'float': 'left' });
        $('div.gcontent').css('display', 'block');

        // Initially set opacity on thumbs and add
        // additional styling for hover effect on thumbs
        var onMouseOutOpacity = 0.67;
        $('#thumbs ul.thumbs li').opacityrollover({
            mouseOutOpacity: onMouseOutOpacity,
            mouseOverOpacity: 1.0,
            fadeSpeed: 'fast',
            exemptionSelector: '.selected'
        });

        // Initialize Advanced Galleriffic Gallery
        var gallery = $('#thumbs').galleriffic({
            delay: 2500,
            numThumbs: 15,
            preloadAhead: 10,
            enableTopPager: false,
            enableBottomPager: true,
            maxPagesToShow: 2,
            imageContainerSel: '#slideshow',
            controlsContainerSel: '#controls',
            captionContainerSel: '#caption',
            loadingContainerSel: '#loading',
            renderSSControls: true,
            renderNavControls: true,
            playLinkText: 'Play Slideshow',
            pauseLinkText: 'Pause Slideshow',
            prevLinkText: '&lsaquo; Previous Photo',
            nextLinkText: 'Next Photo &rsaquo;',
            nextPageLinkText: 'Next &rsaquo;',
            prevPageLinkText: '&lsaquo; Prev',
            enableHistory: false,
            autoStart: false,
            syncTransitions: true,
            defaultTransitionDuration: 900,
            onSlideChange: function (prevIndex, nextIndex) {
                // 'this' refers to the gallery, which is an extension of $('#thumbs')
                this.find('ul.thumbs').children()
							.eq(prevIndex).fadeTo('fast', onMouseOutOpacity).end()
							.eq(nextIndex).fadeTo('fast', 1.0);
            },
            onPageTransitionOut: function (callback) {
                this.fadeTo('fast', 0.0, callback);
            },
            onPageTransitionIn: function () {
                this.fadeTo('fast', 1.0);
            }
        });
    });
</script>
<%} %>