$(document).ready(function () {
    creatingFile();
    creatingFolder();
    openCreatingForm();
    submitCreatingFile();
});

var creatingFile = function () {
    $("#creatingFile").click(function () {
        $("#itemExtension").prop('disabled', false);
        $("#itemExtension").prop('required', true);
        $("#creatingFolder").prop('checked', false);
    });
};

var creatingFolder = (function () {
    $("#creatingFolder").click(function () {
        $("#creatingFile").prop('checked', false);
        $("#itemExtension").prop('disabled', true);
        $("#itemExtension").prop('required', false);
    });
});

var openCreatingForm = (function () {
    $("#creatingButton").click(function () {
        if ($("#creatingForm").prop('hidden') === true) {
            $("#creatingButton").val('Close');
            $("#creatingForm").prop('hidden', false);
        }
        else {
            $("#creatingButton").val('Create new folder/file');
            $("#creatingForm").prop('hidden', true);
        }
    });
});

var submitCreatingFile = (function () {
    $('#submitCreatingFile').click(function (e) {
        var name = $('#itemName').val();
        var extension = $('#itemExtension').val();
        var folder = $('#creatingFolder').is(':checked');
        var file = $('#creatingFile').is(':checked');
        var result = false;

        if (folder === true) {
            if (name === "" || /[!#$%^&*()_]/.test(name) === true)
                alert("Invalid folder name.");
            else
                result = true;

        }
        else if (file === true) {
            if (name === "" || /[!#$%^&*()_]/.test(name) === true || extension === "" || /[\W]/.test(extension) === true)
                alert("Invalid file name or extension.");
            else
                result = true;
        }
        if (result === true) {
            var data = JSON.stringify({
                'pathA': $('#pathA').val(),
                'name': $('#itemName').val(),
                'type': $('#itemExtension').val()
            });
            $.ajax({
                type: "POST",
                url: "/Directory/CreateNewItem",
                contentType: "application/json; charset=utf-8",
                data: data,
                success: function (result) {
                    window.location.href = "/Directory/Table/" + $('#pathA').val();
                },
                error: function (result) {
                    alert("The file/folder doesn't create.");
                    window.location.href = "/Directory/Table/" + $('#pathA').val();
                }
            });
        }
    });
});