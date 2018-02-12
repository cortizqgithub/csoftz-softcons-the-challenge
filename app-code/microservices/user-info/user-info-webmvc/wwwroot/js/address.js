// File:     ADDRESS.JS
// Created:  Feb.12/2018
// Modified: Feb.12/2018

function loadInfo() {
    var options = {};
    options.url = urlAddress;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#address-list").empty();
        data.forEach(function (element) {
            $("#address-list").append("<li>"
                + element.id + "-"
                + element.name + "-"
                + element.cityData.name + "-"
                + element.cityData.stateData.name + "-"
                + element.cityData.stateData.countryData.name
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
        options.url = urlAddress;
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
        options.url = urlAddress + "/" + $("#id").val();
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
        options.url = urlAddress + "/" + $("#id").val();
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

    $("#countries").change(function () {
        var idCountry = $("#countries option:selected").val();
        loadStates(idCountry);
    });
    loadCountries();
    //loadStates(1);
    //loadCities(1, 1);

    loadInfo();
});