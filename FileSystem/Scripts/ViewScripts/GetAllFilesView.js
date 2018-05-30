$(document).ready(function () {
    sortFilesByDate();
    sortFilesByType();
    sortFilesByName();
});

var sortFilesByDate = function () {
    $("#sortByDate").click(function (e) {
        if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-up")) {
            $(this).find("span").removeClass("glyphicon glyphicon-chevron-up");
            $(this).find("span").addClass("glyphicon glyphicon-chevron-down");
        }
        else {
            $(this).find("span").removeClass("glyphicon glyphicon-chevron-down");
            $(this).find("span").addClass("glyphicon glyphicon-chevron-up");
        }

        var nodeList = [];
        for (var i = 1; i < document.getElementsByClassName('div-table-row').length; i++) {
            nodeList[i - 1] = document.getElementsByClassName('div-table-row')[i];
        };
        var itemsArray = [];
        var parent = document.getElementsByClassName('div-table')[0];
        for (var i = 0; i < nodeList.length; i++) {
            itemsArray.push(parent.removeChild(nodeList[i]));
        }
        itemsArray.sort(function (nodeA, nodeB) {
            var textA = nodeA.getElementsByClassName('div-table-col')[1].textContent;
            var textB = nodeB.getElementsByClassName('div-table-col')[1].textContent;
            var numberA = new Date(textA);
            var numberB = new Date(textB);
            if (numberA < numberB) return -1;
            if (numberA > numberB) return 1;
            return 0;
        });

        if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-down")) {
            itemsArray.reverse();
        }

        itemsArray.forEach(function (node) {
            if (node.getElementsByClassName('itemType')[0].textContent === 'folder')
                parent.appendChild(node);

        });
        itemsArray.forEach(function (node) {
            if (node.getElementsByClassName('itemType')[0].textContent !== 'folder')
                parent.appendChild(node);
        });
    });
};

var sortFilesByName = function () {
    $("#sortByName").click(function (e) {

        if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-up")) {
            $(this).find("span").removeClass("glyphicon glyphicon-chevron-up");
            $(this).find("span").addClass("glyphicon glyphicon-chevron-down");
        }
        else {
            $(this).find("span").removeClass("glyphicon glyphicon-chevron-down");
            $(this).find("span").addClass("glyphicon glyphicon-chevron-up");
        }

        var nodeList = [];
        for (var i = 1; i < document.getElementsByClassName('div-table-row').length; i++) {
            nodeList[i - 1] = document.getElementsByClassName('div-table-row')[i];
        };
        var itemsArray = [];
        var parent = document.getElementsByClassName('div-table')[0];
        for (var i = 0; i < nodeList.length; i++) {
            itemsArray.push(parent.removeChild(nodeList[i]));
        }
        itemsArray.sort(function (nodeA, nodeB) {
            var textA = nodeA.getElementsByClassName('div-table-col')[0].textContent.toLowerCase();
            var textB = nodeB.getElementsByClassName('div-table-col')[0].textContent.toLowerCase();
            if (textA < textB) return -1;
            if (textA > textB) return 1;
            return 0;
        });

        if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-down")) {
            itemsArray.reverse();
        }

        itemsArray.forEach(function (node) {
            if (node.getElementsByClassName('itemType')[0].textContent === 'folder')
                parent.appendChild(node);

        });
        itemsArray.forEach(function (node) {
            if (node.getElementsByClassName('itemType')[0].textContent !== 'folder')
                parent.appendChild(node);
        });
    });
};

var sortFilesByType = function () {
    $("#sortByType").click(function (e) {

        if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-up")) {
            $(this).find("span").removeClass("glyphicon glyphicon-chevron-up");
            $(this).find("span").addClass("glyphicon glyphicon-chevron-down");
        }
        else if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-down")) {
            $(this).find("span").removeClass("glyphicon glyphicon-chevron-down");
            $(this).find("span").addClass("glyphicon glyphicon-chevron-up");
        }

        var nodeList = [];
        for (var i = 1; i < document.getElementsByClassName('div-table-row').length; i++) {
            nodeList[i - 1] = document.getElementsByClassName('div-table-row')[i];
        };
        var itemsArray = [];
        var parent = document.getElementsByClassName('div-table')[0];
        for (var i = 0; i < nodeList.length; i++) {
            itemsArray.push(parent.removeChild(nodeList[i]));
        }

        itemsArray.sort(function (nodeA, nodeB) {
            var textA = nodeA.getElementsByClassName('div-table-col')[2].textContent;
            var textB = nodeB.getElementsByClassName('div-table-col')[2].textContent;
            if (textA < textB) return -1;
            if (textA > textB) return 1;
            return 0;
        });

        if ($(this).find("span").hasClass("glyphicon glyphicon-chevron-down")) {
            itemsArray.reverse();
        }

        itemsArray.forEach(function (node) {
            if (node.getElementsByClassName('itemType')[0].textContent === 'folder')
                parent.appendChild(node);

        });
        itemsArray.forEach(function (node) {
            if (node.getElementsByClassName('itemType')[0].textContent !== 'folder')
                parent.appendChild(node);
        });
    });
};