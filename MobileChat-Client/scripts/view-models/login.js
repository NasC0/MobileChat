/* global window */

var app = app || {};
app.viewmodels = app.viewmodels || {};

app.login = (function(scope) {
	var loginLocation = baseApiUrl + 'token';

	var loginSuccess = function(response) {
		window.localStorage.setItem('isLogged', true);
		window.localStorage.setItem('token', response['access_token']);
		app.navigate('views/welcome.html');
	};

	var error = function(response) {
		var errorObject = $.parseJSON(response.responseText);
		navigator.notification.alert(errorObject.error_description, function() {});
	};

	var isLogged = window.localStorage.getItem('isLogged');

	if (isLogged) {
		console.log(app);
		console.log(app.navigate);
		app.navigate('views/welcome.html');	
	}

	scope.login = {
		title: 'Login',
		username: '',
		password: '',
		login: function() {
			var username = this.get('username'),
				password = this.get('password');

			if (validationHelpers.validateUsername(username) === false ||
				validationHelpers.validatePassword(password) === false) {
				navigator.notification.alert('Invalid username or password.', function() {});

				return;
			}

			var data = {
				'grant_type': 'password',
				'username': username,
				'password': password
			};

			$.ajax({
				url: loginLocation,
				type: 'POST',
				data: data,
				success: loginSuccess,
				error: error
			});
		}
	};
}(app.viewmodels));