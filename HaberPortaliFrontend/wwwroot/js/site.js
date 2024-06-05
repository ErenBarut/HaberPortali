// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*!
* Start Bootstrap - Clean Blog v6.0.9 (https://startbootstrap.com/theme/clean-blog)
* Copyright 2013-2023 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-clean-blog/blob/master/LICENSE)
*/


var token = localStorage.getItem("token")
var userRoles = [];
var apiUrl = "https://localhost:7033/";
var userId = ";"
if (token == null) {

    $(".NotLogined").show();
    $(".Logined").hide();

} else {

    $(".NotLogined").hide();
    $(".Logined").show();
    var payload = parseJwt(token);
    var username = payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    userRoles = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

    userId = payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    $("#UserName").html(username);
}
function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);

}
$("#Logout").click(function () {
    console.log("cıkıs yapılıyor");
    localStorage.removeItem("token");
    location.href = "/Home/Login";
});