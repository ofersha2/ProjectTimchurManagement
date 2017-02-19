﻿$(function () {
    var notifications = $.connection.notificationsHub;
    notifications.client.sendMessage = function (id) {
        if (id == "-1") {
            alert("Error:Please Refer to database manager.")
            return;
        }
        setTimeout(function () {
            window.location = "EditSupplier/" + id;
        }, 1000);
    };
    $.connection.hub.start().done(function () {
        notifications.server.editSupplierOperation();

    }).fail(function () {
        alert("Connection failed");
    });

});