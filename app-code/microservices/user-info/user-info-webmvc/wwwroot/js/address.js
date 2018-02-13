// File:     ADDRESS.JS
// Created:  Feb.12/2018
// Modified: Feb.13/2018

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
        var addressName = $("#name").val();
        var stateName = $("#states option:selected").text();
        var cityName = $("#cities option:selected").text();
       
        if (stateName === ""){
            alert("You must select one State.");
            $("#states").focus();
            return;
        }

        if (cityName === "") {
            alert("You must select one City.");
            $("#cities").focus();
            return;
        }

        if (addressName === "") {
            alert("You must type a name for the Address.");
            $("#name").focus();
        }
        else {
            var options = {};
            options.url = urlAddress;
            options.type = "POST";

            var obj = {};
            obj.addressName = addressName;
            obj.idCountry = $("#countries option:selected").val();
            obj.countryName = $("#countries option:selected").text();
            obj.idState = $("#states option:selected").val();
            obj.stateName = $("#states option:selected").text();
            obj.idCity = $("#cities option:selected").val();
            obj.cityName = $("#cities option:selected").text();

            options.data = JSON.stringify(obj);
            console.log(options.data);
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
        var idAddress = $("#id").val();
        var addressName = $("#name").val();
        var isValid = true;

        if (!isANumber(idAddress)) {
            alert("Required ID is not a number");
            $("#id").focus();
            isValid = false;
        }

        if (addressName === "") {
            alert("You must type a name for the Address.");
            $("#name").focus();
            isValid = false;
        }

        if (isValid) {
            var options = {};
            options.url = urlAddress + "/" + idAddress;
            options.type = "PUT";

            var obj = {};
            obj.idAddress = idAddress;
            obj.addressName = addressName;
            obj.idCountry = $("#countries option:selected").val();
            obj.countryName = $("#countries option:selected").text();
            obj.idState = $("#states option:selected").val();
            obj.stateName = $("#states option:selected").text();
            obj.idCity = $("#cities option:selected").val();
            obj.cityName = $("#cities option:selected").text();

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
        var idAddress = $("#id").val();

        if (isANumber(idAddress)) {
            var options = {};
            options.url = urlAddress + "/" + idAddress;
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
        $("#cities").empty();
        loadStatesAndCityDefault(idCountry);
    });

    $("#states").change(function () {
        var idCountry = $("#countries option:selected").val();
        var idState = $("#states option:selected").val();
        loadCities(idCountry, idState);
    });
    loadCountries();
    loadStates(1);
    loadCities(1, 1);

    loadInfo();
});