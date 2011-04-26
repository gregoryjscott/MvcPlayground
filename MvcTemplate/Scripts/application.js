$(function () {
    window.ApplicationView = Backbone.View.extend({
        initialize: function () {
            _.bindAll(this, 'showNewUser');

            this.loginView = new LoginView;
            this.securityMenuView = new SecurityMenuView;

            $.ajaxSetup({ cache: false });

            // Add a handler for anytime an ajax error occurs and see if its a 403 (that was thrown by an ajax controller action).
            $("body").ajaxError(function (event, request, ajaxOptions, thrownError) {
                if (request.status == 403) {
                    this.showLogin();
                }
                else {
                    alert('An unexpected error occurred on the server.  StatusCode: ' + request.status + ', Error: ' + request.responseText);
                }
            });

            // See if the user has been authenticated.
            var userIsAuthenticated = $("input[name*='userIsAuthenticated']").val();
            if (userIsAuthenticated != "True") {
                this.showLogin();
            }
        },

        showLogin: function () {
            this.loginView.render();
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

    window.LoginView = Backbone.View.extend({
        initialize: function () {
            _.bindAll(this, 'render', 'attemptLogin', 'processLoginAttemptResponse');

            this.loginDialog = $("#loginDialog").dialog({
                autoOpen: false,
                modal: true,
                draggable: false,
                resizable: false,
                width: '548px',
                buttons: [
                    {
                        text: "Login",
                        click: this.attemptLogin
                    }
                ],
                create: function () {
                    $(".ui-dialog-titlebar-close").hide();
                },
                open: function () {
                    $('#loginForm').clearForm();
                }
            });
        },

        render: function () {
            this.loginDialog.dialog("open");
        },

        attemptLogin: function () {
            $("#loginForm").ajaxSubmit({
                dataType: 'json',
                success: this.processLoginAttemptResponse
            })
        },

        processLoginAttemptResponse: function (data) {
            if (data.Success) {
                this.loginDialog.dialog('close');
            }
            else {
                alert("Fail!");
            }
        }
    });

    window.SecurityMenuView = Backbone.View.extend({
        el: $("#securityMenu"),

        initialize: function () {
            _.bindAll(this, 'logout');

            $("#securityMenu").buttonset();
        },

        events: {
            "click #logoutMenuItem": "logout"
        },

        logout: function () {
            $.post('/Security/Sessions/Delete', function () {
                window.ApplicationView.showLogin();
            });
        }
    });

    window.ApplicationView = new ApplicationView;
});
