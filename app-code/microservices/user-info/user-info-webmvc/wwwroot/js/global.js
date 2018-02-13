// File:     GLOBAL.JS
// Created:  Feb.12/2018
// Modified: Feb.13/2018

var urlCountry = "http://localhost:5000/userinfo/api/v1/country";
var urlState = "http://localhost:5000/userinfo/api/v1/state";
var urlStateInCountry = "http://localhost:5000/userinfo/api/v1/state/all/country/";
var urlCity = "http://localhost:5000/userinfo/api/v1/city";
var urlCityInCountryState = "http://localhost:5000/userinfo/api/v1/city/all/country/{idCountry}/state/{idState}";
var urlAddress = "http://localhost:5000/userinfo/api/v1/address";
var urlUser = "http://localhost:5000/userinfo/api/v1/user";

function isANumber(s) {
    var numbers = /^[0-9]+$/;
    var isNum = s.match(numbers);
    return isNum;
}

function loadCountries() {
    var options = {};
    options.url = urlCountry;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#countries").empty();
        data.forEach(function (element) {
            $("#countries").append("<option value=" + element.id + ">" + element.name + "</option>");
        });
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function loadStates(idCountry) {
    var options = {};
    options.url = urlStateInCountry + idCountry;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#states").empty();
        data.forEach(function (element) {
            $("#states").append("<option value=" + element.id + ">" + element.name + "</option>");
        });
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function loadStatesAndCityDefault(idCountry) {
    var options = {};
    options.url = urlStateInCountry + idCountry;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#states").empty();
        data.forEach(function (element) {
            $("#states").append("<option value=" + element.id + ">" + element.name + "</option>");
        });
        var idState = $("#states option:selected").val();
        loadCities(idCountry, idState);
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function loadCities(idCountry, idState) {
    var options = {};
    var urlToSet = urlCityInCountryState;

    urlToSet = urlToSet.replace("{idCountry}", idCountry);
    urlToSet = urlToSet.replace("{idState}", idState);
    options.url = urlToSet;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#cities").empty();
        data.forEach(function (element) {
            $("#cities").append("<option value=" + element.id + ">" + element.name + "</option>");
        });
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function loadAddresses() {
    var options = {};
    options.url = urlAddress;
    options.type = "GET";
    options.dataType = "json";
    options.success = function (data) {
        $("#addresses").empty();
        data.forEach(function (element) {
            $("#addresses").append("<option value=" + element.id + ">" + element.name + "</option>");
        });
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}