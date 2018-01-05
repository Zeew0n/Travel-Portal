    function SelectFolder(thisElm, targetElm, url) {
        LoadSelectOptions(thisElm, targetElm, url);
        ResetImageBrowser();
    
    }
    function SelectImage(thisElm, elm1, targetElm) {
        if (thisElm.selectedIndex < 0) return false;
        var selValue = thisElm.options[thisElm.selectedIndex].value;
        var elm1Val = document.getElementById(elm1).options[document.getElementById(elm1).selectedIndex].value;
        var url = "/CKEditor/GetImageDetail/" + elm1Val + "/?ImageList=";
        var data = "";
        //data = $(thisForm).serialize();
        $.ajax({
            async: false,
            type: "POST",
            url: url + selValue,
            contentType: "text/json",
            data: ({ id: selValue }),
            beforeSend: function () {
                $("#ImagePreview").empty();
                $("#ResizeWidth").attr('disabled', 'disabled');
                $("#ResizeHeight").attr('disabled', 'disabled');
                $("#ResizeImageButton").attr('disabled', 'disabled');
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).addClass('ac_loading');
            },
            success: function (result) {

                $("#ImagePreview").empty().append('<img src="' + result.ImageHttpPath + '" alt="image" title="" id="ImageViewer" name="ImageViewer" />');
                $("#ImageHttpPath").val(result.ImageHttpPath);
                $("#ResizeWidth").val(result.ResizeWidth);
                $("#ResizeHeight").val(result.ResizeWidth);
                $("#ImageAspectRatio").val(result.ImageAspectRatio);
                

                $("#ResizeWidth").removeAttr('disabled');
                $("#ResizeHeight").removeAttr('disabled');
                $("#ResizeImageButton").removeAttr('disabled');
                $("#" + targetElm).removeClass('ac_loading');
                $("#" + targetElm).removeAttr('disabled');                
              
                //OkButton.OnClientClick = "window.top.opener.CKEDITOR.dialog.getCurrent().setValueOf('info', 'txtUrl', encodeURI('" + ImageFolder + ImageList.SelectedValue.Replace("'", "\\'") + "')); window.top.close(); window.top.opener.focus();";

            }

        });
    }
    function RenameImage(thisForm, targetElm) {        
        if (($("#" + targetElm + " option:selected").val() == "" || $("#" + targetElm + " option:selected").val() == undefined)) { alert('Please select the image to rename!!'); return false; }
        var selValue = document.getElementById(targetElm).options[document.getElementById(targetElm).selectedIndex].value;
        var pos = selValue.lastIndexOf('.');
        if (pos == -1) return false;
        var newName = prompt('Enter new filename:', selValue.substring(0, pos));
        if (newName == null || newName == '') return false;
        $("#NewImageName").val(newName + '.jpg');        
        var url = "/CKEditor/RenameImage/";
        var data = "";
        data = $(thisForm).serialize();

        $.ajax({
            async: false,
            type: "POST",
            url: url,
            data: data,
            beforeSend: function () {
                $("#ImagePreview").empty();

                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).addClass('ac_loading');
            },
            success: function (jsonResult) {
                var evlResult = JSON.retrocycle(jsonResult);
                var selOption = "";
                selOption = ParseJsonResultForSelectOptions(evlResult);
                $("#" + targetElm).empty().append(selOption);
                $("#" + targetElm).removeClass('ac_loading');
                $("#" + targetElm).removeAttr('disabled');
                $("#ImageList").change();
            }
        });        

    }
     function CreateFolder(thisForm) {
        var targetElm = 'DirectoryList';
        var newName = prompt('Enter name of folder:', "");
        if (newName == null || newName == '') return false;       
        $("#NewDirectoryName").val(newName);
        var url = "/CKEditor/CreateFolder/";
        var data = "";
        data = $(thisForm).serialize();

        $.ajax({
            async: false,
            type: "POST",
            url: url,
            data: data,
            beforeSend: function () {
                $("#ImagePreview").empty();


                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).addClass('ac_loading');
            },
            success: function (jsonResult) {
                var evlResult = JSON.retrocycle(jsonResult);
                var selOption = "";
                selOption = ParseJsonResultForSelectOptions(evlResult);
                $("#" + targetElm).empty().append(selOption);
                $("#" + targetElm).removeClass('ac_loading');
                $("#" + targetElm).removeAttr('disabled');
                $("#DirectoryList").change();
            }
        });

    }

    function DeleteFolder(thisForm, targetElm) {        
        if (confirm('Are you sure you want to delete this folder and all its contents?') == false) return false;
        var url = "/CKEditor/DeleteFolder/";
                
        data = $(thisForm).serialize();
        $.ajax({
            async: false,
            type: "POST",
            url: url,
            data: data,
            beforeSend: function () {
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).addClass('ac_loading');
            },
            success: function (result) {
                if (result == "true") {
                    $("#ImagePreview").empty();
                    $("#" + targetElm + " option:selected").remove();
                    $("#" + targetElm).removeClass('ac_loading');
                    $("#" + targetElm).removeAttr('disabled');

                }
                //                OkButton.OnClientClick = "window.top.opener.CKEDITOR.dialog.getCurrent().setValueOf('info', 'txtUrl', encodeURI('" + ImageFolder + ImageList.SelectedValue.Replace("'", "\\'") + "')); window.top.close(); window.top.opener.focus();";

            }

        });
    }

    function DeleteImage(thisForm, targetElm) {

        if (($("#" + targetElm + " option:selected").val() == "" || $("#" + targetElm + " option:selected").val() == undefined)) { alert('Please select the image to delete!!'); return false; }
        if (confirm('Are you sure you want to delete this image?') == false) return false;
        var url = "/CKEditor/DeleteImage/";

        data = $(thisForm).serialize();
        $.ajax({
            async: false,
            type: "POST",
            url: url,
            data: data,
            beforeSend: function () {
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).addClass('ac_loading');
            },
            success: function (result) {
                if (result == "true") {
                    $("#ImagePreview").empty();
                    $("#ResizeWidth").attr('disabled', 'disabled');
                    $("#ResizeHeight").attr('disabled', 'disabled');
                    $("#ResizeImageButton").attr('disabled', 'disabled');
                    $("#ResizeWidth").val();
                    $("#ResizeHeight").val();
                    $("#ImageAspectRatio").val();

                    $("#" + targetElm + " option:selected").remove();
                    $("#" + targetElm).removeClass('ac_loading');
                    $("#" + targetElm).removeAttr('disabled');

                }
                //                OkButton.OnClientClick = "window.top.opener.CKEDITOR.dialog.getCurrent().setValueOf('info', 'txtUrl', encodeURI('" + ImageFolder + ImageList.SelectedValue.Replace("'", "\\'") + "')); window.top.close(); window.top.opener.focus();";

            }

        });
    }

    function ResizeImage(thisForm) {
        var targetElm = 'ImagePreview';
        if (($("#ImageList option:selected").val() == "" || $("#ImageList option:selected").val() == undefined)) { alert('Please select the image to resize!!'); return false; }
        if (confirm('Are you sure to change the size of image?') == false) return false;
        var innerHtmlData = $("#ImagePreview").html(); 
        var url = "/CKEditor/ResizeImage/";
        var data = "";
        data = $(thisForm).serialize();
        $.ajax({
            async: false,
            type: "POST",
            url: url,
            data: data,
            beforeSend: function () {
                $("#ImagePreview").empty();
                $("#ResizeWidth").attr('disabled', 'disabled');
                $("#ResizeHeight").attr('disabled', 'disabled');
                $("#ResizeImageButton").attr('disabled', 'disabled');
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).addClass('ac_loading');
            },
            success: function (result) {
                
                if (result == "true") {
                    // $("#ImagePreview").empty().append('<img src="' + result.ImageURL + '" alt="image" title="" id="ImageViewer" name="ImageViewer" />');
                    $("#ResizeWidth").removeAttr('disabled');
                    $("#ResizeHeight").removeAttr('disabled');
                    $("#ResizeImageButton").removeAttr('disabled');
                    $("#" + targetElm).removeClass('ac_loading');
                    $("#" + targetElm).removeAttr('disabled');

                    $("#ImagePreview").empty().append(innerHtmlData);

                }
            }
        });

    }
    function SearchImage(thisForm) {
        var targetElm = 'ImageList';
        var url = "/CKEditor/SearchImage/";
        var data = "";
        data = $(thisForm).serialize();

        $.ajax({
            async: false,
            type: "POST",
            url: url,
            data: data,
            beforeSend: function () {
                $("#" + targetElm).empty();

                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).addClass('ac_loading');
            },
            success: function (jsonResult) {
                var evlResult = JSON.retrocycle(jsonResult);
                var selOption = "";
                selOption = ParseJsonResultForSelectOptions(evlResult);
                $("#" + targetElm).empty().append(selOption);
                $("#" + targetElm).removeClass('ac_loading');
                $("#" + targetElm).removeAttr('disabled');                
            }
        });

    }
    function UploadImage(thisForm) {
        thisForm.method = "POST";
        //thisForm.action = "/CKEditor/UploadImage/";
        thisForm.submit()

    }
    function SubmitSelectedImage() {
        if (($("#DirectoryList option:selected").val() == "" || $("#DirectoryList option:selected").val() == undefined)) { alert('Please select the folder!!'); return false; }
        if (($("#ImageList option:selected").val() == "" || $("#ImageList option:selected").val() == undefined)) { alert('Please select the image!!'); return false; }
        var folder = $("#DirectoryList option:selected").val();
        folder = (folder == "Root" ? "" : folder+"/");
        //var image = $("#ImageList option:selected").val();
        var image = $("#ImageHttpPath").val();
        //window.top.opener.CKEDITOR.dialog.getCurrent().setValueOf('info', 'txtUrl', encodeURI(ImageFolderRoot + folder + image)); window.top.close(); window.top.opener.focus();
        window.top.opener.CKEDITOR.dialog.getCurrent().setValueOf('info', 'txtUrl', encodeURI(image)); window.top.close(); window.top.opener.focus();
    }
    function ResetImageBrowser() {        
        $("#ResizeWidth").val("");
        $("#ResizeHeight").val("");
        $("#ImageAspectRatio").val("");
        $("#ResizeWidth").attr('disabled', 'disabled');
        $("#ResizeHeight").attr('disabled', 'disabled');
        $("#ResizeImageButton").attr('disabled', 'disabled');

    }
    function LoadSelectOptions(thisElm, targetElm, url) {
        var selValue = $("#" + thisElm.id).val();
        var jsonResult = JqueryAjaxLoadSelectOption(selValue, targetElm, url);

    }
    function JqueryAjaxLoadSelectOption(selValue, targetElm, url) {
        $.ajax({
            async: false,
            type: "POST",
            url: url + selValue,
            contentType: "text/json",
            data: ({ id: selValue }),
            beforeSend: function () {
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).addClass('ac_loading');
            },

            success: function (jsonResult) {

                var evlResult = JSON.retrocycle(jsonResult);
                var selOption = "";
                selOption = ParseJsonResultForSelectOptions(evlResult);
                tempTargetElm = targetElm.split(',');                
                for (var i = 0; i < tempTargetElm.length; i++) {
                    // alert(tempTargetElm.length + " : " + tempTargetElm[i]);
                    $("#" + tempTargetElm[i]).empty().append(selOption);
                    $("#" + tempTargetElm[i]).removeClass('ac_loading');
                    $("#" + tempTargetElm[i]).removeAttr('disabled');
                }


            },
            error: function (jsonResult) {
                // alert(jsonResult);
            }
        });

    }
    function ParseJsonResultForSelectOptions(evlResult) {
        var selOption = "";
        $.each(evlResult, function (key, item) {
            var isSelected = (item['Selected'].toString() == "true") ? "Selected='Selected'" : "";
            //var otherAttrib = (item['Attribs']!=undefined)? item['Attribs']:"";
            var otherAttrib = "";
            $.each(item, function (name, value) {
                if (name != 'Selected' && name != 'Value' && name != 'Text') {
                    otherAttrib += " " + name + '="' + value + '" ';
                }
            });
            selOption += "<option value='" + item['Value'] + "' " + isSelected + " " + otherAttrib + " >"
                + evlResult[key].Text + "</option>";
        });
        return selOption;
    }
    $(function () {
        $(window).load(function () {
            $("#ImageList").change();
        });
    });
