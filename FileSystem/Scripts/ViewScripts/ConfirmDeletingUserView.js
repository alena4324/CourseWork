$(document).ready(function () {
    submitDeletingUser();
    cancelDeletingUser();
});

var submitDeletingUser = function () {
    $('#submitDeleteUser').click(function (e) {
        var data = JSON.stringify({
            'login': $('#login').val()
        });
        $.ajax({
            type: "POST",
            url: "/Admin/DeleteUser/",
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {
                window.location.href = "/Admin/GetAllUsers/";
            },
            error: function (result) {
                alert("The file/folder doesn't create.");
                window.location.href = "/Admin/GetAllUsers/";
            }
        });
    });
};

var cancelDeletingUser = function () {
    $('#cancelDeleteUser').click(function (e) {
        $('#modDialog').modal('hide');
    });
};