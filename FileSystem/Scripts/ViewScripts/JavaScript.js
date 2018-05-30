//Directories
function OnHidden() {
    alert("The access is denied");
}

//CreateNewItem
$(document).ready(function () {



    //$("#creatingFile").click(function () {
    //    $("#itemExtension").prop('disabled', false);
    //    $("#itemExtension").prop('required', true);
    //    $("#creatingFolder").prop('checked', false);
    //});

    //$("#creatingFolder").click(function () {
    //    $("#creatingFile").prop('checked', false);
    //    $("#itemExtension").prop('disabled', true);
    //    $("#itemExtension").prop('required', false);
    //});

    //$("#creatingButton").click(function () {
    //    if ($("#creatingForm").prop('hidden') === true) {
    //        $("#creatingButton").val('Close');
    //        $("#creatingForm").prop('hidden', false);
    //    }
    //    else {
    //        $("#creatingButton").val('Create new folder/file');
    //        $("#creatingForm").prop('hidden', true);
    //    }
    //});


    //$('#submitCreatingFile').click(function (e) {
    //    var name = $('#itemName').val();
    //    var extension = $('#itemExtension').val();
    //    var folder = $('#creatingFolder').is(':checked');
    //    var file = $('#creatingFile').is(':checked');
    //    var result = false;

    //    if (folder === true) {
    //        if (name === "" || /[!#$%^&*()_]/.test(name) === true)
    //            alert("Invalid folder name.");
    //        else
    //            result = true;

    //    }
    //    else if (file === true) {
    //        if (name === "" || /[!#$%^&*()_]/.test(name) === true || extension === "" || /[\W]/.test(extension) === true)
    //            alert("Invalid file name or extension.");
    //        else
    //            result = true;
    //    }
    //    if (result === true) {
    //        var data = JSON.stringify({
    //            'pathA': $('#pathA').val(),
    //            'name': $('#itemName').val(),
    //            'type': $('#itemExtension').val()
    //        });
    //        $.ajax({
    //            type: "POST",
    //            url: "/Directory/CreateNewItem",
    //            contentType: "application/json; charset=utf-8",
    //            data: data,
    //            success: function (result) {
    //                window.location.href = "/Directory/Table/" + $('#pathA').val();
    //            },
    //            error: function (result) {
    //                alert("The file/folder doesn't create.");
    //                window.location.href = "/Directory/Table/" + $('#pathA').val();
    //            }
    //        });
    //    }


    //});


//ChangePassword
    //$('#submitChangePassword').click(function (e) {
    //    var login = $('#login').val();
    //    var password = $('#newPassword').val();
    //    var confirmPassword = $('#confirmPassword').val();

    //    var result = false;

    //    if (confirmPassword === password) {
    //        result = true;

    //    }
    //    if (result === true) {
    //        var data = JSON.stringify({
    //            'login': $('#login').val(),
    //            'password': $('#newPassword').val()
    //        });
    //        $.ajax({
    //            type: "POST",
    //            url: "/Account/ChangePassword",
    //            contentType: "application/json; charset=utf-8",
    //            data: data,
    //            success: function (result) {
    //                alert("Your password was changed.");
    //            },
    //            error: function (result) {
    //                alert("Your password wasn't changed.");
    //            }
    //        });
    //    }


    //});

//ConfirmDeletingUser

//$('#submitDeleteUser').click(function (e) {
//    var data = JSON.stringify({
//        'login': $('#login').val()
//    });
//    $.ajax({
//        type: "POST",
//        url: "/Admin/DeleteUser/",
//        contentType: "application/json; charset=utf-8",
//        data: data,
//        success: function (result) {
//            window.location.href = "/Admin/GetAllUsers/";
//        },
//        error: function (result) {
//            alert("The file/folder doesn't create.");
//            window.location.href = "/Admin/GetAllUsers/";
//        }
//    });
//});
//$('#cancelDeleteUser').click(function (e) {
//    $('#modDialog').modal('hide');
//});

//!!!ConfirmDeletingDirectory

//$('#submitDeleteDirectory').click(function (e) {
//    var data = JSON.stringify({
//        'path': $('#pathFolder').val()
//    });
//    $.ajax({
//        type: "POST",
//        url: "/Directory/DeleteFolder/",
//        contentType: "application/json; charset=utf-8",
//        data: data,
//        success: function (result) {
//            window.location.href = "/Directory/Table/" + $('#pathParent').val();
//        },
//        error: function (result) {
//            alert("The file/folder doesn't delete.");
//            window.location.href = "/Directory/Table/" + $('#pathParent').val();
//        }
//    });
//});
//$('#cancelDeletingDirectory').click(function (e) {
//    $('#modDialog').modal('hide');
//});

//!!!ConfirmDeletingFile

//$('#submitDeletingFile').click(function (e) {
//    var data = JSON.stringify({
//        'path': $('#pathFile').val()
//        //'type': $('#type').val()
//    });
//    $.ajax({
//        type: "POST",
//        url: "/Directory/DeleteFile/",
//        contentType: "application/json; charset=utf-8",
//        data: data,
//        success: function (result) {
//            //$("#creatingButton").val('Create new folder/file');
//            //$("#creatingForm").prop('hidden', true);
//            window.location.href = "/Directory/Table/" + $('#path').val();
//        },
//        error: function (result) {
//            alert("The file/folder doesn't delete.");
//            window.location.href = "/Directory/Table/" + $('#path').val();
//        }
//    });
//});
//$('#cancelDeletingFile').click(function (e) {
//    $('#modDialog').modal('hide');
//});


//GetAllFiles

    //$("#sortByDate").click(function (e) {
    //    if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-up")) {
    //        $(this).find("span").removeClass("glyphicon glyphicon-chevron-up");
    //        $(this).find("span").addClass("glyphicon glyphicon-chevron-down");
    //    }
    //    else {
    //        $(this).find("span").removeClass("glyphicon glyphicon-chevron-down");
    //        $(this).find("span").addClass("glyphicon glyphicon-chevron-up");
    //    }

    //    var nodeList = []; 
    //    for (var i = 1; i < document.getElementsByClassName('div-table-row').length; i++) {
    //        nodeList[i - 1] = document.getElementsByClassName('div-table-row')[i];
    //    };
    //    var itemsArray = [];
    //    var parent = document.getElementsByClassName('div-table')[0];
    //    for (var i = 0; i < nodeList.length; i++) {
    //        itemsArray.push(parent.removeChild(nodeList[i]));
    //    }
    //    itemsArray.sort(function (nodeA, nodeB) {
    //        var textA = nodeA.getElementsByClassName('div-table-col')[1].textContent;
    //        var textB = nodeB.getElementsByClassName('div-table-col')[1].textContent;
    //        var numberA = new Date(textA);
    //        var numberB = new Date(textB);
    //        if (numberA < numberB) return -1;
    //        if (numberA > numberB) return 1;
    //        return 0;
    //    });

    //    if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-down")) {
    //        itemsArray.reverse();
    //    }

    //    itemsArray.forEach(function (node) {
    //        if (node.getElementsByClassName('itemType')[0].textContent === 'folder')
    //            parent.appendChild(node);

    //    });
    //    itemsArray.forEach(function (node) {
    //        if (node.getElementsByClassName('itemType')[0].textContent !== 'folder')
    //            parent.appendChild(node);
    //    });
    //});


    //$("#sortByName").click(function (e) {

    //    if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-up")) {
    //        $(this).find("span").removeClass("glyphicon glyphicon-chevron-up");
    //        $(this).find("span").addClass("glyphicon glyphicon-chevron-down");
    //    }
    //    else {
    //        $(this).find("span").removeClass("glyphicon glyphicon-chevron-down");
    //        $(this).find("span").addClass("glyphicon glyphicon-chevron-up");
    //    }

    //    var nodeList = [];
    //    for (var i = 1; i < document.getElementsByClassName('div-table-row').length; i++) {
    //        nodeList[i - 1] = document.getElementsByClassName('div-table-row')[i];
    //    };
    //    var itemsArray = [];
    //    var parent = document.getElementsByClassName('div-table')[0];
    //    for (var i = 0; i < nodeList.length; i++) {
    //        itemsArray.push(parent.removeChild(nodeList[i]));
    //    }
    //    itemsArray.sort(function (nodeA, nodeB) {
    //        var textA = nodeA.getElementsByClassName('div-table-col')[0].textContent.toLowerCase();
    //        var textB = nodeB.getElementsByClassName('div-table-col')[0].textContent.toLowerCase();
    //        if (textA < textB) return -1;
    //        if (textA > textB) return 1;
    //        return 0;
    //    });

    //    if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-down")) {
    //        itemsArray.reverse();
    //    }

    //    itemsArray.forEach(function (node) {
    //        if (node.getElementsByClassName('itemType')[0].textContent === 'folder')
    //            parent.appendChild(node);

    //    });
    //    itemsArray.forEach(function (node) {
    //        if (node.getElementsByClassName('itemType')[0].textContent !== 'folder')
    //            parent.appendChild(node);
    //    });
    //});

    //$("#sortByType").click(function (e) {

    //    if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-up")) {
    //        $(this).find("span").removeClass("glyphicon glyphicon-chevron-up");
    //        $(this).find("span").addClass("glyphicon glyphicon-chevron-down");
    //    }
    //    else if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-down")) {
    //        $(this).find("span").removeClass("glyphicon glyphicon-chevron-down");
    //        $(this).find("span").addClass("glyphicon glyphicon-chevron-up");
    //    }

    //    var nodeList = [];
    //    for (var i = 1; i < document.getElementsByClassName('div-table-row').length; i++) {
    //        nodeList[i - 1] = document.getElementsByClassName('div-table-row')[i];
    //    };
    //    var itemsArray = [];
    //    var parent = document.getElementsByClassName('div-table')[0];
    //    for (var i = 0; i < nodeList.length; i++) {
    //        itemsArray.push(parent.removeChild(nodeList[i]));
    //    }

    //    itemsArray.sort(function (nodeA, nodeB) {
    //        var textA = nodeA.getElementsByClassName('div-table-col')[2].textContent;
    //        var textB = nodeB.getElementsByClassName('div-table-col')[2].textContent;
    //        if (textA < textB) return -1;
    //        if (textA > textB) return 1;
    //        return 0;
    //    });

    //    if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-down")) {
    //        itemsArray.reverse();
    //    }

    //    itemsArray.forEach(function (node) {
    //        if (node.getElementsByClassName('itemType')[0].textContent === 'folder')
    //            parent.appendChild(node);

    //    });
    //    itemsArray.forEach(function (node) {
    //        if (node.getElementsByClassName('itemType')[0].textContent !== 'folder')
    //            parent.appendChild(node);
    //    });
    //});


    //SearchFiles
    //$('#searchButton').click(function (e) {
    //    var name = $('#search').val();
    //    var path = $('#path').val();
    //    var result = true;

    //    if (name === "") {
    //        alert("Invalid name.");
    //        result = false;
    //    }

    //    if (result === true) {
    //        var data = JSON.stringify({
    //            'path': $('#path').val(),
    //            'name': $('#search').val()
    //        });
    //        $.ajax({
    //            type: "POST",
    //            url: "/Directory/SearchFiles",
    //            contentType: "application/json; charset=utf-8",
    //            data: data,
    //            success: function (result) {
    //                window.location.href = "/Directory/SearchFiles/" + $('#path').val() + "?name=" + $('#search').val();
    //            },
    //            error: function (result) {
    //                alert("The file/folder doesn't create.");
    //                window.location.href = "/Directory/Table/" + $('#path').val();
    //            }
    //        });
    //    }
    //});

    //$("#path").keyup(function (e) {
    //    if (e.keyCode === 13) {
    //        var data = JSON.stringify({
    //            'path': $('#path').val()
    //        });
    //        $.ajax({
    //            type: "POST",
    //            url: "/Directory/Table",
    //            contentType: "application/json; charset=utf-8",
    //            data: data,
    //            success: function () {
    //                window.location.href = "/Directory/Table/" + $('#path').val();
    //            },
    //            error: function () {
    //                alert("The file/folder isn't exist.");
    //                window.location.href = "/Directory/AllDrives";
    //            }
    //        });
    //    }
    //}); 
});




