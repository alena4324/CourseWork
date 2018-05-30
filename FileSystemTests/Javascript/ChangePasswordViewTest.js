
describe("mocking ajax", function () {
    describe("A jQuery ajax request should be able to change password", function () {

        require('jasmine-ajax');

        beforeEach(function () {
            jasmine.Ajax.install();
        });

        afterEach(function () {
            jasmine.Ajax.uninstall();
        });

        it("should make an AJAX request to the correct URL", function () {

            loadFixtures('ChangePassword.html');

            // var doneFn = jasmine.createSpy("success");

            // var xhr = new XMLHttpRequest();
            // xhr.onreadystatechange = function (args) {
            //     if (this.readyState == this.DONE) {
            //         doneFn(this.responseText);
            //     }
            // };

            // xhr.open("GET", "/some/cool/url");
            // xhr.send();


            //expect(jasmine.Ajax.requests.mostRecent().url).toBe('/some/cool/url');
           // expect(doneFn).not.toHaveBeenCalled();

            spyOn($, "ajax");
            submitChangePassword();
            expect($.ajax.mostRecentCall.args[0]["url"]).toEqual("/Account/ChangePassword");
        });
    });
});

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