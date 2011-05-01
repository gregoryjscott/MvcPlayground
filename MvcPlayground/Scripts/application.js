$(function () {
    // Models
    window.AccountUpdate = Backbone.Model.extend({
        // We will only be calling creating AccountUpdates.
        url: function () {
            return '/Security/AccountUpdates';
        }
    });

    window.Screen = Backbone.Model.extend({
        initialize: function () {
            _.bindAll(this, 'validate', 'save');

            // The Url should be passed into the constructor.
            // TODO - I assume this is necessary?
            this.url = this.get("url");
        },

        validate: function (attributes) {
        },

        save: function (attributes, options) {
            // Before saving, create/update the Backbone attribute that matches the Knockout observable.
            this.set("status") = this.status();

            // Call the original implementation now.
            Backbone.Model.prototype.save.call(this, attributes, options);
        }
    });

    window.Screens = Backbone.Collection.extend({
    });

    // Views
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
        // TODO - shouldn't this have a render function?

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
            var accountUpdate = new AccountUpdate({
                OldPassword: oldPassword,
                NewPassword: newPassword,
                ConfirmPassword: confirmPassword
            });

            accountUpdate.save();
        }
    });

    window.ApplicationView = Backbone.View.extend({
        // TODO - shouldn't this have a render function?

        el: $("#main"),

        initialize: function () {
            _.bindAll(this, 'showLogin', 'showMyAccount', 'showContent');

            this.loginView = new LoginView;
            this.securityMenuView = new SecurityMenuView;
            this.myAccountView = new MyAccountView;

            // TODO - fill this array on the server.
            this.area1 = new Screens([
                { title: "Screen 1", url: "/Area1/Screen1", status: ko.observable("New") },
                { title: "Screen 2", url: "/Area1/Screen2", status: ko.observable("New") },
                { title: "Screen 3", url: "/Area1/Screen3", status: ko.observable("New") }
            ]);

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
            // Add the module template to the DOM.
            $(this.el).empty();
            $("#moduleTemplate").tmpl().appendTo(this.el);

            // Setup the view model and apply bindings.
            var area1ViewModel = {
                screens: ko.observableArray()
            };
            this.area1.forEach(function (screen) {
                area1ViewModel.screens.push(screen.attributes);
            });
            ko.applyBindings(area1ViewModel);

            this.$("#accordion").accordion();
        }
    });

    // Create the application view.
    window.ApplicationView = new ApplicationView;
});
