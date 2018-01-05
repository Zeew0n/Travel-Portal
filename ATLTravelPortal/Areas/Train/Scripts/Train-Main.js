function RedirectPath(url) {
    var rowPageValue = $('#recordDisplayCount').val();
    document.location.href = url + "&pageRow=" + rowPageValue;
}


$(document).ready(function () {
    $(function () {
        var dates = $("#FromDate, #ToDate").datepicker({
            defaultDate: "+1d",
            changeMonth: true,
            changeYear: true,
            constrainInput: true,
            numberOfMonths: 2,
            //minDate: Date(),
            onSelect: function (selectedDate) {
                var option = this.id == "FromDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                dates.not(this).datepicker("option", option, date);
            }
        });

    });
});
