// File:     COUNTRY.JS
// Created:  Feb.12/2018
// Modified: Feb.13/2018

function loadInfo() {
    var options = {};
    options.url = urlCountry;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#country-list").empty();
        data.forEach(function (element) {
            $("#country-list").append("<li>"
                + element.id + "-" + element.name + "</li>");
        });
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

$(document).ready(function () {
    $("#insert").click(function () {
        var countryName = $("#name").val();
        if (countryName === "") {
            alert("You must type a name for the Country.");
            $("#name").focus();
        }
        else {
            var options = {};
            options.url = urlCountry;
            options.type = "POST";

            var obj = {};
            obj.name = countryName;

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
        var idCountry = $("#id").val();
        var countryName = $("#name").val();
        var isValid = true;

        if (!isANumber(idCountry)) {
            alert("Required ID is not a number");
            $("#id").focus();
            isValid = false;
        }

        if (countryName === "") {
            alert("You must type a name for the Country.");
            $("#name").focus();
            isValid = false;
        }

        if (isValid) {
            var options = {};
            options.url = urlCountry + "/" + idCountry;
            options.type = "PUT";

            var obj = {};
            obj.id = idCountry;
            obj.name = countryName;

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
        var idCountry = $("#id").val();

        if (isANumber(idCountry)) {
            var options = {};
            options.url = urlCountry + "/" + idCountry;
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
        }
        else {
            alert("Required ID is not a number");
            $("#id").focus();
        }
    });
    loadInfo();
});