// File:     CITY.JS
// Created:  Feb.12/2018
// Modified: Feb.12/2018

var url = "http://localhost:5000/userinfo/api/v1/city";
function loadInfo() {
    var options = {};
    options.url = urlCity;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#city-list").empty();
        data.forEach(function (element) {
            $("#city-list").append("<li>"
                + element.id + "-"
                + element.name + "-"
                + element.stateData.name + "-"
                + element.stateData.countryData.name
                + "</li>");
        });
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

$(document).ready(function () {
    $("#insert").click(function () {
        var options = {};
        options.url = urlCity;
        options.type = "POST";

        var obj = {};
        obj.name = $("#name").val();

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
    });

    $("#update").click(function () {
        var options = {};
        options.url = urlCity + "/" + $("#id").val();
        options.type = "PUT";

        var obj = {};
        obj.id = $("#id").val();
        obj.name = $("#name").val();

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
    });

    $("#delete").click(function () {
        var options = {};
        options.url = urlCity + "/" + $("#id").val();
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
    loadCountries();
    loadStates(1);
    loadInfo();
});