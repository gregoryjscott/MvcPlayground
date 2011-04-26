$(function () {
    window.ApplicationView = Backbone.View.extend({
        initialize: function () {
            $.ajaxSetup({ cache: false });

            // Add a handler for anytime an ajax error occurs and see if its a 403 (that was thrown by an ajax controller action).
            $("body").ajaxError(function (event, request, ajaxOptions, thrownError) {
                if (request.status == 403) {
                    // todo - not sure if "this." is going to work here
                    this.showLogin();
                }
                else {
                    alert('An unexpected error occurred on the server.  StatusCode: ' + request.status + ', Error: ' + request.responseText);
                }
            });

            $("#securityMenu").buttonset();

            // See if the user has been authenticated.
            var userIsAuthenticated = $("input[name*='userIsAuthenticated']").val();
            if (userIsAuthenticated != "True") {
                this.showLogin();
            }
        },

        showLogin: function () {
            $("#loginDialog").dialog({
                modal: true,
                draggable: false,
                resizable: false,
                width: '548px',
                buttons: [
                                {
                                    text: "Login",
                                    click: function () {
                                        var dialog = $(this);
                                        $("#loginForm").ajaxSubmit({
                                            dataType: 'json',
                                            success: function (data) {
                                                if (data.Success) {
                                                    dialog.dialog('close');
                                                }
                                                else {
                                                    alert("Fail!");
                                                }
                                            }
                                        })
                                    }
                                }
                            ],
                create: function () {
                    $(".ui-dialog-titlebar-close").hide();
                },
                open: function () {
                    $('#loginForm').clearForm();
                }
            })
        },

        showNewUser: function () {
            $("#newUserDialog").dialog({
                modal: true,
                draggable: false,
                resizable: false,
                width: '548px',
                buttons: [
                                {
                                    text: "Create User",
                                    click: function () {
                                        $("#newUserForm").ajaxSubmit({
                                            dataType: 'json',
                                            beforeSubmit: function () {
                                            },
                                            success: function (data) {
                                                if (data.Success) {
                                                    alert("Success!");
                                                }
                                                else {
                                                    alert("Fail!");
                                                }
                                            }
                                        })
                                    }
                                }
                            ],
                create: function (event, ui) {
                    $(".ui-dialog-titlebar-close").hide();
                    $("#newUserForm").clearForm();
                }
            });
        }
    });

    window.ApplicationView = new ApplicationView;
});
