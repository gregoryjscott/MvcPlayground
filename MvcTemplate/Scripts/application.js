$(function () {
    window.ApplicationView = Backbone.View.extend({
        el: $("#main"),

        initialize: function () {
            _.bindAll(this, 'showLogin', 'showMyAccount');

            this.loginView = new LoginView;
            this.securityMenuView = new SecurityMenuView;
            this.myAccountView = new MyAccountView;

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
            else {
                this.showContent();
            }
        },

        showLogin: function () {
            this.loginView.render();
        },

        showMyAccount: function () {
            this.myAccountView.render();
        },

        showContent: function () {
            $(this.el).empty();
            $("#dummyContent").tmpl().appendTo(this.el);
            this.$("#accordion").accordion();
        }
    });

    window.LoginView = Backbone.View.extend({
        el: $("#loginDialog"),

        initialize: function () {
            _.bindAll(this, 'render', 'attemptLogin', 'processLoginAttemptResponse');

            this.loginDialog = $(this.el).dialog({
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

                window.ApplicationView.showContent();
            }
            else {
                alert("Fail!");
            }
        },

        // TODO - move this function to ApplicationView?
        createMyAccount: function (userName) {
            window.ApplicationView.myAccount = new MyAccount({ id: userName });
        }
    });

    window.SecurityMenuView = Backbone.View.extend({
        el: $("#securityMenu"),

        initialize: function () {
            _.bindAll(this, 'logout');

            $(this.el).buttonset();
        },

        events: {
            "click #myAccountMenuItem": "myAccount",
            "click #logoutMenuItem": "logout"
        },

        myAccount: function () {
            window.ApplicationView.showMyAccount();
        },

        logout: function () {
            $.post('/Security/Sessions/Delete', function () {
                window.ApplicationView.showLogin();
            });
        }
    });

    window.MyAccount = Backbone.Model.extend({
        // We will only be calling creating AccountUpdates.
        url: function () {
            return '/Security/AccountUpdates';
        },

        initialize: function () {
            _.bindAll(this, 'validate', 'somethingElse');
        },

        validate: function (attributes) {
        },

        somethingElse: function (attributes) {
        }
    });

    window.MyAccountView = Backbone.View.extend({
        el: $("#myAccountDialog"),

        initialize: function () {
            _.bindAll(this, 'save', 'render', 'setupDialog');

            this.myAccountDialog = $(this.el).dialog({
                autoOpen: false,
                modal: true,
                draggable: false,
                resizable: false,
                width: '548px',
                buttons: [
                    {
                        text: "Save",
                        click: this.save
                    }
                ],
                create: this.setupDialog
            });
        },

        setupDialog: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            this.$("#myAccountForm").clearForm();
        },

        render: function () {
            this.myAccountDialog.dialog("open");
        },

        save: function () {
            var oldPassword = this.$('#OldPassword').val();
            var newPassword = this.$('#NewPassword').val();
            var confirmPassword = this.$('#ConfirmPassword').val();
            var myAccount = new MyAccount({
                OldPassword: oldPassword,
                NewPassword: newPassword,
                ConfirmPassword: confirmPassword
            });

            myAccount.save();

            //            this.$("#myAccountForm").ajaxSubmit({
            //                dataType: 'json',
            //                success: function () {
            //                    if (data.Success) {
            //                        alert("Success!");
            //                    }
            //                    else {
            //                        alert("Fail!");
            //                    }
            //                }
            //            })
        }
    });

    window.ApplicationView = new ApplicationView;
});
