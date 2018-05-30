$(document).ready(function () {
    submitDeletingFile();
    cancelDeletingFile();
});

var submitDeletingFile = function () {
    $('#submitDeletingFile').click(function (e) {
    var data = JSON.stringify({
        'path': $('#pathFile').val()
        //'type': $('#type').val()
    });
    $.ajax({
        type: "POST",
        url: "/Directory/DeleteFile/",
        contentType: "application/json; charset=utf-8",
        data: data,
        success: function (result) {
            //$("#creatingButton").val('Create new folder/file');
            //$("#creatingForm").prop('hidden', true);
            window.location.href = "/Directory/Table/" + $('#path').val();
        },
        error: function (result) {
            alert("The file/folder doesn't delete.");
            window.location.href = "/Directory/Table/" + $('#path').val();
        }
    });
    });
}

var cancelDeletingFile = function () {
    $('#cancelDeletingFile').click(function (e) {
        $('#modDialog').modal('hide');
    });
}