/*
 * Agent Management Wizard
 * a javascript wizard control
 */


(function ($) {
    $.fn.smartWizard = function (options) {
        var defaults = {
            selectedTab: 0,  //0 = first tab as default
            animation: ""
        };
        var options = $.extend(defaults, options);

        return this.each(function () {
            //Code Starts
            obj = $(this);
            var defaultTab = options.selectedTab;
            var wizcurrent = null;
            var tabs = null;
            tabs = $("#smartwizard > ul > li > a");
            hideallTabs();
            $(tabs).bind("click", function (e) {
                e.preventDefault();
            });
            selectTab(defaultTab);
            //Next Navigation
            $(".next").bind("click", function (e) {
                e.preventDefault();
                var nextIdx = tabs.index(wizcurrent) + 1;
                $(wizcurrent).removeClass("wiz-anc-default");
                $(wizcurrent).removeClass("wiz-anc-current");
                $(wizcurrent).addClass("wiz-anc-done");
                selectTab(nextIdx);
            });
            //Back Navigation
            $(".back").bind("click", function (e) {
                e.preventDefault();
                $(wizcurrent).removeClass("wiz-anc-default");
                $(wizcurrent).removeClass("wiz-anc-current");
                $(wizcurrent).addClass("wiz-anc-done");
                var prevIdx = tabs.index(wizcurrent) - 1;
                selectTab(prevIdx);
            });

            function selectTab(idx) {
                if (idx < tabs.length && idx >= 0) {
                    var selTabAnchor = tabs.eq(idx);
                    var selTabId = selTabAnchor.attr("href");
                    hideallTabs();
                    selTabAnchor.attr("isDone", "true");
                    $(selTabId).fadeIn(options.animation);
                    $(selTabAnchor).removeClass("wiz-anc-default");
                    $(selTabAnchor).removeClass("wiz-anc-done");
                    $(selTabAnchor).addClass("wiz-anc-current");
                    //suspicious code below   
                    $(selTabAnchor).bind("click", function (e) {
                        e.preventDefault();
                        var selIdx = tabs.index(this);
                        $(wizcurrent).removeClass("wiz-anc-default");
                        $(wizcurrent).removeClass("wiz-anc-current");
                        $(wizcurrent).addClass("wiz-anc-done");
                        selectTab(selIdx);
                    });
                    wizcurrent = selTabAnchor;
                }
            }

            function hideallTabs() {
                $(tabs).each(function () {
                    $(this).addClass("wiz-anc-default");
                    $($(this).attr("href")).hide();
                });
            }
            //Code Ends 
        });
    };
})(jQuery);  