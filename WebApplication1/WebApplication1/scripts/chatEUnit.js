﻿$(function () {
    var notifications = $.connection.notificationsHub;
    notifications.client.sendMessage = function (id) {
        if (id == "-1") {
            alert("Error:Please Refer to database manager.")
            return;
        }
        setTimeout(function () {
            window.location = "EditUnit/" + id;
        }, 1000);
    };
    $.connection.hub.start().done(function () {
        notifications.server.editUnitOperation();

    }).fail(function () {
        alert("Connection failed");
    });

});