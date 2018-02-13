// File:     CITY.JS
// Created:  Feb.12/2018
// Modified: Feb.13/2018

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
        var cityName = $("#name").val();
        var stateName = $("#states option:selected").text();
        
        if (stateName === "") {
            alert("You must select one State.");
            $("#states").focus();
            return;
        }
        if (cityName === "") {
            alert("You must type a name for the City.");
            $("#name").focus();
        } else {
            var options = {};
            options.url = urlCity;
            options.type = "POST";

            var obj = {};
            obj.cityName = cityName;
            obj.idCountry = $("#countries option:selected").val();
            obj.countryName = $("#countries option:selected").text();
            obj.idState = $("#states option:selected").val();
            obj.stateName = $("#states option:selected").text();

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
        var idCity = $("#id").val();
        var cityName = $("#name").val();
        var isValid = true;
        var stateName = $("#states option:selected").text();
        
        if (!isANumber(idCity)) {
            alert("Required ID is not a number");
            $("#id").focus();
            isValid = false;
        }

        if (cityName === "") {
            alert("You must type a name for the City.");
            $("#name").focus();
            isValid = false;
        }

        if (stateName === "") {
            alert("You must select one State.");
            $("#states").focus();
            isValid = false;
        }

        if (isValid) {
            var options = {};
            options.url = urlCity + "/" + idCity;
            options.type = "PUT";

            var obj = {};
            obj.idCity = idCity;
            obj.cityName = cityName;
            obj.idCountry = $("#countries option:selected").val();
            obj.countryName = $("#countries option:selected").text();
            obj.idState = $("#states option:selected").val();
            obj.stateName = $("#states option:selected").text();

            options.data = JSON.stringify(obj);
            console.log(options.data);
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
        var idCity = $("#id").val();

        if (isANumber(idCity)) {
            var options = {};
            options.url = urlCity + "/" + idCity;
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

    $("#countries").change(function () {
        var idCountry = $("#countries option:selected").val();
        loadStates(idCountry);
    });
    loadCountries();
    loadStates(1);
    loadInfo();
});