$(document).ready(function () {
    searchByName();
    searchByPath();
});

var searchByName = function () {
    $('#searchButton').click(function (e) {
        var name = $('#search').val();
        var path = $('#path').val();
        var result = true;

        if (name === "") {
            alert("Invalid name.");
            result = false;
        }

        if (result === true) {
            var data = JSON.stringify({
                'path': $('#path').val(),
                'name': $('#search').val()
            });
            $.ajax({
                type: "POST",
                url: "/Directory/SearchFiles",
                contentType: "application/json; charset=utf-8",
                data: data,
                success: function (result) {
                    window.location.href = "/Directory/SearchFiles/" + $('#path').val() + "?name=" + $('#search').val();
                },
                error: function (result) {
                    alert("The file/folder doesn't create.");
                    window.location.href = "/Directory/Table/" + $('#path').val();
                }
            });
        }
    });
}

var searchByPath = function () {
    $("#path").keyup(function (e) {
        if (e.keyCode === 13) {
            var data = JSON.stringify({
                'path': $('#path').val()
            });
            $.ajax({
                type: "POST",
                url: "/Directory/Table",
                contentType: "application/json; charset=utf-8",
                data: data,
                success: function () {
                    window.location.href = "/Directory/Table/" + $('#path').val();
                },
                error: function () {
                    alert("The file/folder isn't exist.");
                    window.location.href = "/Directory/AllDrives";
                }
            });
        }
    });
}

function OnHidden() {
    alert("The access is denied");
}