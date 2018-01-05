Sys.Mvc.FormContext.prototype = { $3: null, $4: null, $6: null, $7: null, $8: null, $9: null, replaceValidationSummary: false, addError: function (message) { this.addErrors([message]); }, addErrors: function (messages) { if (!Sys.Mvc._ValidationUtil.$0(messages)) { Array.addRange(this.$5, messages); this.$11(); } }, clearErrors: function () { Array.clear(this.$5); this.$11(); }, $A: function () { if (this.$7) { if (this.$8) { Sys.Mvc._ValidationUtil.$3(this.$8); for (var $0 = 0; $0 < this.$5.length; $0++) { var $1 = document.createElement('li'); Sys.Mvc._ValidationUtil.$4($1, this.$5[$0]); this.$8.appendChild($1); } } Sys.UI.DomElement.removeCssClass(this.$7, 'validation-summary-valid'); Sys.UI.DomElement.addCssClass(this.$7, 'validation-summary-errors'); } }, $B: function () { var $0 = this.$7; if ($0) { var $1 = this.$8; if ($1) { $1.innerHTML = ''; } Sys.UI.DomElement.removeCssClass($0, 'validation-summary-errors'); Sys.UI.DomElement.addCssClass($0, 'validation-summary-valid'); } }, enableDynamicValidation: function () { Sys.UI.DomEvent.addHandler(this.$9, 'click', this.$3); Sys.UI.DomEvent.addHandler(this.$9, 'submit', this.$4); }, $C: function ($p0) { if ($p0.disabled) { return null; } var $0 = $p0.tagName.toUpperCase(); var $1 = $p0; if ($0 === 'INPUT') { var $2 = $1.type; if ($2 === 'submit' || $2 === 'image') { return $1; } } else if (($0 === 'BUTTON') && ($1.type === 'submit')) { return $1; } return null; }, $D: function ($p0) { this.$6 = this.$C($p0.target); }, $E: function ($p0) { var $0 = $p0.target; var $1 = this.$6; if ($1 && $1.disableValidation) { return; } var $2 = this.validate('submit'); if (!Sys.Mvc._ValidationUtil.$0($2)) { $p0.preventDefault(); } }, $11: function () { if (!this.$5.length) { this.$B(); } else { this.$A(); } },
    validate: function (eventName) {
        var $0 = this.fields;
        var $1 = [];
        for (var $2 = 0; $2 < $0.length; $2++) {
            var $3 = $0[$2];
            var fName = '#' + ($3.elements[0].name.replace(".", "_"));
            if ($(fName).is(':disabled') == false) {
                var $4 = $3.validate(eventName);
                if ($4) {
                    Array.addRange($1, $4);
                }
            }
        }
        if (this.replaceValidationSummary) {
            this.clearErrors();
            this.addErrors($1);
        }
        return $1;
    }
}