// File:     USER.JS
// Created:  Feb.12/2018
// Modified: Feb.13/2018

function loadInfo() {
    var options = {};
    options.url = urlUser;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#user-list").empty();
        data.forEach(function (element) {
            var userInfo = "<table><td><li>" + element.id + "-" + element.name + "</li></td>";

            userInfo += "<td>";
            element.addresses.forEach(function (addr) {
                userInfo += "<li>"
                    + addr.id
                    + "-"
                    + addr.name
                    + "-"
                    + addr.cityData.name
                    + "-"
                    + addr.cityData.stateData.name
                    + "-"
                    + addr.cityData.stateData.countryData.name
                    + "</li>";
            });
            userInfo += "</td>";

            $("#user-list").append(userInfo);
        });
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

$(document).ready(function () {
    $("#insert").click(function () {
        var userName = $("#name").val();

        if (userName === "") {
            alert("You must type a name for the User.");
            $("#name").focus();
        }
        else {
            var options = {};
            options.url = urlUser;
            options.type = "POST";

            var obj = {};
            obj.name = userName;

            options.data = JSON.stringify(obj);
            options.contentType = "application/json";
            options.dataType = "json";

            options.success = function (msg) {
                $("#msg").html(msg);
                loadInfo();
            };
            options.error = function () {
                $("#msg").html("Error while calling the Web API!");
            };
            $.ajax(options);
        }
    });

    $("#update").click(function () {
        var idUser = $("#id").val();
        var userName = $("#name").val();
        var isValid = true;

        if (!isANumber(idUser)) {
            alert("Required ID is not a number");
            $("#id").focus();
            isValid = false;
        }

        if (userName === "") {
            alert("You must type a name for the User.");
            $("#name").focus();
            isValid = false;
        }

        if (isValid) {
            var options = {};
            options.url = urlUser + "/" + idUser;
            options.type = "PUT";

            var obj = {};
            obj.id = idUser;
            obj.name = userName;

            options.data = JSON.stringify(obj);
            options.contentType = "application/json";
            options.dataType = "json";
            options.success = function (msg) {
                $("#msg").html(msg);
                loadInfo();
            };
            options.error = function (a, b, c) {
                $("#msg").html("Error while calling the Web API!");
            };
            $.ajax(options);
        }
    });

    $("#delete").click(function () {
        var idUser = $("#id").val();

        if (isANumber(idUser)) {
            var options = {};
            options.url = urlUser + "/" + idUser;
            options.type = "DELETE";
            options.datatype = "json";
            options.success = function (msg) {
                $("#msg").html(msg);
                loadInfo();
            };
            options.error = function (a, b, c) {
                $("#msg").html("Error while calling the Web API!");
            };
            $.ajax(options);
        } else {
            alert("Required ID is not a number");
            $("#id").focus();
        }
    });

    $("#link").click(function () {
        var idUser = $("#id").val();

        if (!isANumber(idUser)) {
            alert("Required ID User is not a number");
            $("#id").focus();
            return;
        }
        var options = {};
        options.url = urlUser + "/link";

        var obj = {};
        obj.idUser = idUser;
        obj.idAddress = $("#addresses option:selected").val();

        options.data = JSON.stringify(obj);
        console.log(options.data);
        console.log(options.url);
        options.contentType = "application/json";
        options.type = "POST";
        options.datatype = "json";
        options.success = function (msg) {
            $("#msg").html(msg);
            loadInfo();
        };
        options.error = function (a, b, c) {
            $("#msg").html("Error while calling the Web API!");
        };
        $.ajax(options);
    });

    $("#unlink").click(function () {
        var idUser = $("#id").val();
        var idAddress = $("#idAddress").val();

        if (!isANumber(idUser)) {
            alert("Required ID User is not a number");
            $("#id").focus();
            return;
        }

        if (!isANumber(idAddress)) {
            alert("Required ID Address is not a number");
            $("#idAddress").focus();
            return;
        }
        var options = {};
        options.url = urlUser + "/unlink/user/" + $("#id").val() +
            "/address/" + $("#idAddress").val();
        console.log(options.url);
        options.type = "DELETE";
        options.datatype = "json";
        options.success = function (msg) {
            $("#msg").html(msg);
            loadInfo();
        };
        options.error = function (a, b, c) {
            $("#msg").html("Error while calling the Web API!");
        };
        $.ajax(options);
    });
    loadAddresses();
    loadInfo();
});
