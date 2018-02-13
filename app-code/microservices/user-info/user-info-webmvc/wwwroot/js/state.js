// File:     STATE.JS
// Created:  Feb.12/2018
// Modified: Feb.13/2018

function loadInfo() {
    var options = {};
    options.url = urlState;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#state-list").empty();
        data.forEach(function (element) {
            $("#state-list").append("<li>"
                + element.id + "-" + element.name + "-" + element.countryData.name + "</li>");
        });
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

$(document).ready(function () {
    $("#insert").click(function () {
        var stateName = $("#name").val();
        if (stateName === "") {
            alert("You must type a name for the State.");
            $("#name").focus();
        }
        else {
            var options = {};
            options.url = urlState;
            options.type = "POST";

            var obj = {};
            obj.stateName = stateName;
            obj.idCountry = $("#countries option:selected").val();
            obj.countryName = $("#countries option:selected").text();

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
        var idState = $("#id").val();
        var stateName = $("#name").val();
        var isValid = true;

        if (!isANumber(idState)) {
            alert("Required ID is not a number");
            $("#id").focus();
            isValid = false;
        }

        if (stateName === "") {
            alert("You must type a name for the State.");
            $("#name").focus();
            isValid = false;
        }

        if (isValid) {
            var options = {};
            options.url = urlState + "/" + idState;
            options.type = "PUT";

            var obj = {};
            obj.idState = idState;
            obj.stateName = stateName;
            obj.idCountry = $("#countries option:selected").val();
            obj.countryName = $("#countries option:selected").text();

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
        var idState = $("#id").val();

        if (isANumber(idState)) {
            var options = {};
            options.url = urlState + "/" + idState;
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
    loadCountries();
    loadInfo();
});