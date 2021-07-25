
$('#foo').change(function () {
    var el = $(this);
    if (el.val() === "cabania") {
        $('#cabania').show();
        $('#hotel').hide();
    } else {
        $('#hotel').show();
        $('#cabania').hide();
    }
});
