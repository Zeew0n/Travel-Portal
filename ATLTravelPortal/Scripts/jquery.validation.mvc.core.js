/// <reference path="jquery-1.3.2.js">
/// <reference path="jquery.validate.js">

// register custom jQuery methods
// Checkbox Validation
//jQuery.validator.addMethod("checkrequired", function (value, element, params) {
//    alert($(params).val());
//    var checked = false;
//    checked = $(element).is(':checked');
//    return checked;
//}, '');


jQuery.validator.addMethod("regex", function (value, element, params) {
    if (this.optional(element)) {
        return true;
    }

    var match = new RegExp(params).exec(value);
    return (match && (match.index == 0) && (match[0].length == value.length));
});
//jQuery.validator.addMethod("regex", function (value, element, params) {
//    if (this.optional(element)) {
//        return true;
//    }

//    //    var match = new RegExp(params).exec(value);

//    var match = new RegExp(params);
//    return this.optional(element) || match.test(value);

//});

jQuery.validator.addMethod("price", function (value, element, params) {
    if (this.optional(element)) {
        return true;
    }

    if (value > params.min) {
        var cents = value - Math.floor(value);
        if (cents >= 0.99 && cents < 0.995) {
            return true;
        }
    }

    return false;
});

// glue

function __MVC_ApplyValidator_Range(object, min, max) {
    object["range"] = [min, max];
}

function __MVC_ApplyValidator_checkrequired(object, pattern) {
    object["checkrequired"] = pattern;
}

function __MVC_ApplyValidator_RegularExpression(object, pattern) {
    object["regex"] = pattern;
}

//function __MVC_ApplyValidator_Required(object) {
//    object["required"] = true;
//}
function __MVC_ApplyValidator_Required(object, validationParameters) {

    object["required"] = (validationParameters == "") ? true : validationParameters;
}
function __MVC_ApplyValidator_StringLength(object, maxLength) {
    object["maxlength"] = maxLength;
}

function __MVC_ApplyValidator_Unknown(object, validationType, validationParameters) {
    object[validationType] = validationParameters;
}

function __MVC_CreateFieldToValidationMessageMapping(validationFields) {
    var mapping = {};

    for (var i = 0; i < validationFields.length; i++) {
        var thisField = validationFields[i];
        mapping[thisField.FieldName] = "#" + thisField.ValidationMessageId;
    }

    return mapping;
}

function __MVC_CreateErrorMessagesObject(validationFields) {
    var messagesObj = {};

    for (var i = 0; i < validationFields.length; i++) {
        var thisField = validationFields[i];
        var thisFieldMessages = {};
        messagesObj[thisField.FieldName] = thisFieldMessages;
        var validationRules = thisField.ValidationRules;

        for (var j = 0; j < validationRules.length; j++) {
            var thisRule = validationRules[j];
            if (thisRule.ErrorMessage) {
                var jQueryValidationType = thisRule.ValidationType;
                switch (thisRule.ValidationType) {
                    case "regularExpression":
                        jQueryValidationType = "regex";
                        break;

                    case "stringLength":
                        jQueryValidationType = "maxlength";
                        break;
                }

                thisFieldMessages[jQueryValidationType] = thisRule.ErrorMessage;
            }
        }
    }

    return messagesObj;
}

function __MVC_CreateRulesForField(validationField) {
    var validationRules = validationField.ValidationRules;

    // hook each rule into jquery
    var rulesObj = {};
    for (var i = 0; i < validationRules.length; i++) {
        var thisRule = validationRules[i];
        //alert(fieldName + " ::" + validationField.toString())

        switch (thisRule.ValidationType) {
            case "range":
                __MVC_ApplyValidator_Range(rulesObj,
                    thisRule.ValidationParameters["minimum"], thisRule.ValidationParameters["maximum"]);
                break;
            case "checkrequired":
                __MVC_ApplyValidator_checkrequired(rulesObj,
                    thisRule.ValidationParameters["checkrequired"]);
                break;

            case "regularExpression":
                __MVC_ApplyValidator_RegularExpression(rulesObj,
                    thisRule.ValidationParameters["pattern"]);
                break;

            case "required":
                __MVC_ApplyValidator_Required(rulesObj, (thisRule.ValidationParameters["required"]) ? thisRule.ValidationParameters["required"] : true);
                break;

            case "stringLength":
                __MVC_ApplyValidator_StringLength(rulesObj,
                    thisRule.ValidationParameters["maximumLength"]);
                break;

            default:
                if (jQuery.validator.methods) {
                    var mObj = jQuery.validator.methods;
                    var isSet = false;
                    for (var obj in mObj) {
                        if (obj === thisRule.ValidationType) {

                            for (var ppt in thisRule.ValidationParameters) {

                                rulesObj[ppt] = thisRule.ValidationParameters[ppt]; isSet = true;
                            }
                            //rulesObj[thisRule.ValidationType] = thisRule.ValidationParameters[thisRule.ValidationType]; isSet = true; break;
                        }
                    }
                    if (isSet == false) __MVC_ApplyValidator_Unknown(rulesObj, thisRule.ValidationType, thisRule.ValidationParameters);
                } else {
                    __MVC_ApplyValidator_Unknown(rulesObj, thisRule.ValidationType, thisRule.ValidationParameters);
                }
        }
    }

    return rulesObj;
}

function __MVC_CreateValidationOptions(validationFields) {
    var rulesObj = {};
    for (var i = 0; i < validationFields.length; i++) {
        var validationField = validationFields[i];
        var fieldName = validationField.FieldName;
        rulesObj[fieldName] = __MVC_CreateRulesForField(validationField);
        for (var ppt in rulesObj[fieldName]) {

            ppt;
        }
    }

    return rulesObj;
}


// need to wait for the document to signal that it is ready
$(document).ready(function () {
    var validator = "";
    var allFormOptions = window.mvcClientValidationMetadata;
    if (allFormOptions) {
        while (allFormOptions.length > 0) {
            var thisFormOptions = allFormOptions.pop();
            __MVC_EnableClientValidation(thisFormOptions);
        }
    }
});  //</reference></reference>

