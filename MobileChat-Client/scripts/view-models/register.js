/* global validationHelpers, baseApiUrl */

var app = app || {};
app.viewmodels = app.viewmodels || {};

(function(scope){
	var registerUrl = baseApiUrl + 'api/account/register';

	var successRegister = function() {
		app.navigate('views/login.html');
	};

	var errorRegister = function(response) {
		var errorObject = $.parseJSON(response.responseText);
		navigator.notification.alert(errorObject.error_description, function() {});
	};

	scope.register = {
		title: 'Register',
		email: '',
		username: '',
		password: '',
		confirmPassword: '',
		register: function(){
			var username = this.get('username'),
				email = this.get('email'),
				password = this.get('password'),
				confirmPassword = this.get('confirmPassword');

			if (validationHelpers.validateUsername(username) === false ||
				validationHelpers.validatePassword(password) === false ||
				validationHelpers.validateEmail(email) === false) {
				navigator.notification.alert('Invalid registration data supplied', function() {
				});

				return;
			}

			var	data = {
					username: username,
					email: email,
					password: password,
					confirmPassword: confirmPassword
				};

			$.post(registerUrl, data)
				.done(successRegister)
				.fail(errorRegister);
		}
	};
}(app.viewmodels));