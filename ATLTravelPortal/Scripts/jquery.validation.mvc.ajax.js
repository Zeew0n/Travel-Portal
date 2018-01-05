/// <reference path="jquery-1.3.2.js">
/// <reference path="jquery.validate.js">
/// <reference path="jquery.validation.mvc.core.js">

// register custom jQuery methods
// Checkbox Validation
//addJavascript('/Scripts/jquery.validation.mvc.core.js', 'head');
function __MVC_EnableClientValidation(validationContext) {
    // this represents the form containing elements to be validated   
    var theForm = $("#" + validationContext.FormId);    
    var fields = validationContext.Fields;
    var rulesObj = __MVC_CreateValidationOptions(fields);
    var fieldToMessageMappings = __MVC_CreateFieldToValidationMessageMapping(fields);
    var errorMessagesObj = __MVC_CreateErrorMessagesObject(fields);

    var options = {
        errorClass: "input-validation-error",
        errorElement: "em",
        //        errorPlacement: function (error, element) {
        //            var messageSpan = fieldToMessageMappings[element.attr("name")];
        //           // alert(messageSpan)
        //            $(messageSpan).empty();
        //            $(messageSpan).removeClass("field-validation-valid");
        //            $(messageSpan).addClass("field-validation-error");
        //            error.removeClass("input-validation-error");
        //            error.attr("_for_validation_message", messageSpan);
        //            error.appendTo(messageSpan);
        //        },
        errorPlacement: function (error, element) {
            var errors = validator.numberOfInvalids();
            var errMsg = "<strong>" + errors + "</strong> "
                + "invalid field(s) are found. Please fix them first in order to submit your request.";

            if (validator.numberOfInvalids() > 0) {

                $("#myMessageBox").hide();
                $("#myErrorBox").html(errMsg).slideDown(1000);
                setTimeout("SlideUpElementView('myErrorBox')", 5000);

            } else {
                $("#myErrorBox").hide();
            }
            //error.insertAfter( element.siblings("em1") );
            //error.appendTo( element.siblings("em") );
        },
        messages: errorMessagesObj,
        ignore: "",
        rules: rulesObj,
        success: function (label) {
            var messageSpan = $(label.attr("_for_validation_message"));
            $(messageSpan).empty();
            $(messageSpan).addClass("field-validation-valid");
            $(messageSpan).removeClass("field-validation-error");
        },
        submitHandler: function (theForm) {           
            jqueryPost(theForm, "contentFormUpdatePanel");
        }
    };

    // register callbacks with our AJAX system
    var formElement = document.getElementById(validationContext.FormId);
    var registeredValidatorCallbacks = formElement.validationCallbacks;
    if (!registeredValidatorCallbacks) {
        registeredValidatorCallbacks = [];
        formElement.validationCallbacks = registeredValidatorCallbacks;
    }
    registeredValidatorCallbacks.push(function () {
        theForm.validate();
        return theForm.valid();
    });

    validator = theForm.validate(options);
}