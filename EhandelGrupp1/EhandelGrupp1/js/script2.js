$(document).ready(function () {
    $('#vatButton').click(function () {
        var vat = "false";
        if ($('#vatText').text() == 'Inkl. moms') {
            vat = "true";
        }

        $.get("services/svc-vat.aspx?vat=" + vat).
        done(function () { console.log("VAT: " + vat); });
    });
});