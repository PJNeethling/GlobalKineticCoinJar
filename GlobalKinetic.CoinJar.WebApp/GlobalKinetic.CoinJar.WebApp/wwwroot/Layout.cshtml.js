(function () {

    'use strict';

    $(function () {
        Layout.initialize();
    });

}).apply(this, [jQuery]);


var Layout = {

    initialize: function () {
        this
            .build()
            .events();
    },

    build: function () {
        //this.initMessenger();
        return this;
    },

    events: function () {

    },
};

Layout.InfoMessage = {
    Show: function (title, result) {
        if (result == null || !result.message)
            return;

        //Make use of a jquery plugin (EasyAlert) to display a message.
    }
};

Layout.Notification = {
    Show: function (message) {

        if (message) {
            //Make use of a jquery plugin (EasyAlert) to display a notification.
        }
    }
}

Layout.ErrorDialog = {
    Show: function (title, error) {
        var jsonResponse = JSON.parse(error.responseText);
        var message = jsonResponse.message;

        //Make use of a jquery plugin (Bootbox or EasyAlert) to display a error message.
    }
};

Layout.MVC = {

    // gets data and execute callbacks
    get: function (controllerName, viewName, model, callbacks) {
        var url;

        url = '/' + controllerName + '/' + viewName;

        // ajax load
        $.ajax({
            method: "GET",
            url: url,
            cache: false,
            dataType: 'json',
            data: model,
            success: function (result) {
                if (callbacks != null && typeof callbacks.success === 'function') {
                    callbacks.success(result);
                }
            },
            error: function (error) {
                Layout.ErrorDialog.Show('Load failed', error);
                if (callbacks != null && typeof callbacks.error === 'function') {
                    callbacks.error(error);
                }
            }
        });
    },
    
    // post action
    post: function (controllerName, actionName, model, callbacks) {
        var url;

        url = '/' + controllerName + '/' + actionName;
        // ajax post
        $.ajax({
            method: 'POST',
            url: url,
            dataType: 'json',
            traditional: true,
            data: model,
            success: function (result) {
                Layout.InfoMessage.Show(result.success == null ? 'Info' : result.success == true ? 'Success' : 'Error', result);
                if (callbacks != null && typeof callbacks.success === 'function') {
                    callbacks.success(result);
                }
            },
            error: function (error) {
                Layout.ErrorDialog.Show('Failed', error);
                if (callbacks != null && typeof callbacks.error === 'function') {
                    callbacks.error(error);
                }
            }
        });
    },

    postJson: function (controllerName, actionName, model, callbacks) {
        var url;

        url = '/' + controllerName + '/' + actionName;

        $.ajax({
            method: 'POST',
            url: url,
            dataType: 'json',
            data: JSON.stringify(model),
            traditional: true,
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                Layout.InfoMessage.Show(result.success == null ? 'Info' : result.success == true ? 'Success' : 'Error', result);
                if (callbacks != null && typeof callbacks.success === 'function') {
                    callbacks.success(result);
                }
            },
            error: function (error) {
                Layout.ErrorDialog.Show('Failed', error);
                if (callbacks != null && typeof callbacks.error === 'function') {
                    callbacks.error(error);
                }
            }
        });
    },

    // redirects to an action
    action: function (controllerName, actionName, id) {

        window.location.href = '/' + controllerName + '/' + actionName + '/' + id;
    }
};