// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification

function chByNameClicked(chByName)
{    
   $('#chByPhoneNumber').prop('checked', !chByName.checked);
};
function chByPhoneClicked(chByPhone)
{
    $('#chByName').prop('checked', !chByPhone.checked);
};

$(function () {
    $("#_frmSubmitId").submit(function () {
        // event.preventDefault();    // Stops the default Beginform functionallity

        var formdata = $("#_frmSubmitId").serialize();    // Serializes the form
        $.ajax({
            url: "/Home/Index",
            type: 'POST',
            /*          contentType: "application/json; charset=utf-8",*/
            dataType: 'json',
            data: { parameterTxt: String(formdata) },
            async: false
        });

    });
});
function Search()
{
    $('#btnSearch').unbind('click');
    $('#btnSearch').on('click', function () {
        $.ajax({
            url: "/Home/SearchPersonData",
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: JSON.stringify({
                txtValue: $("#txtValue").val()
            }),
            async: false
        });
    });
}