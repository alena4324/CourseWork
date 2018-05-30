$(document).ready(function () {
    submitDeletingDirectory();
    cancelDeletingDirectory();
});

var submitDeletingDirectory = function () {
    $('#submitDeleteDirectory').click(function (e) {
        var data = JSON.stringify({
            'path': $('#pathFolder').val()
        });
        $.ajax({
            type: "POST",
            url: "/Directory/DeleteFolder/",
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {
                window.location.href = "/Directory/Table/" + $('#pathParent').val();
            },
            error: function (result) {
                alert("The file/folder doesn't delete.");
                window.location.href = "/Directory/Table/" + $('#pathParent').val();
            }
        });
    });
}

var cancelDeletingDirectory = function () {
    $('#cancelDeletingDirectory').click(function (e) {
        $('#modDialog').modal('hide');
    });
}