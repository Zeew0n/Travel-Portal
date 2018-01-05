/*
* Jquery Dialog POPUP
*Created By-Madan Tamang
*Arihant Technologies Ltd.
*/
/*///////////////////////////////////////////////////////////////////////////*/




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
			    , width: 500
                , modal: true
			    , minHeight: 500
                , show: 'slide'
                , hide: 'slide'
		    });

    //blind,bounce,clip,drop,explode,fold,highlight,puff,pulsate,scale,shake,size,transfer

    $dialog.dialog('open');
};

function loadEditDialog(tag, event, target) {
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
			    , width: 700
                , modal: true
			    , minHeight: 150
                , show: 'explode'
                , hide: 'scale'
		    });

    //blind,bounce,clip,drop,explode,fold,highlight,puff,pulsate,scale,shake,size,transfer

    $dialog.dialog('open');
};
function loadDetailsDialog(tag, event, target) {
   
//    $dialog.dialog('close');
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
			    , width: 500
                , modal: true
			    , minHeight: 500
                , show: 'slide'
                , hide: 'slide'
                 
		    });

    //blind,bounce,clip,drop,explode,fold,highlight,puff,pulsate,scale,shake,size,transfer

		    $dialog.dialog('open',10000);
		    
		   

};


function displayError(message, status) {
    var $dialog = $(message);
    $dialog
                .dialog({
                    modal: true,
                    title: status + ' Error',
                    buttons: {
                        Ok: function () {
                            $(this).dialog("close");
                        }
                    }
                });
    return false;
};

function confirmDelete(message, callback) {
    var $deleteDialog = $('<div>Are you sure you want to delete ' + message + '?</div>');

    $deleteDialog
            .dialog({
                resizable: false,
                height: 140,
                title: "Delete Record?",
                modal: true,
                buttons: {
                    "Delete": function () {
                        $(this).dialog("close");
                        callback.apply();
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            });
};

function deleteRow($btn) {
    $.ajax({
        url: $btn.attr('href'),
        //type: 'POST',
        success: function (response) {
            $("#ajaxResult").hide().html(response).fadeIn(300, function () {
                var e = this;
                setTimeout(function () { $(e).fadeOut(400); }, 2500);
            });
        },
        error: function (xhr) {
            displayError(xhr.responseText, xhr.status); /* display errors in separate dialog */
        }
    });
    return false;
};

