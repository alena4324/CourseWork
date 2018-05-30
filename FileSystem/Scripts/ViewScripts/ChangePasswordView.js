$(document).ready(function () {
    submitChangePassword();
});

var submitChangePassword = function () {
    init: $('#submitChangePassword').click(this.handleChangePassword);
}

var handleChangePassword= function () {
    var login = $('#login').val();
    var password = $('#newPassword').val();
    var confirmPassword = $('#confirmPassword').val();

     var result = false;

        if (confirmPassword === password) {
            result = true;
        }
        if (result === true) {
            var data = JSON.stringify({
                'login': $('#login').val(),
                'password': $('#newPassword').val()
            });
        ajaxSender(data);
        }
}

var ajaxSender= function(data){
$.ajax({
                type: "POST",
                url: "/Account/ChangePassword",
                contentType: "application/json; charset=utf-8",
                data: data,
                success: function (result) {
                    alert("Your password was changed.");
                },
                error: function (result) {
                    alert("Your password wasn't changed.");
                }
            });
}