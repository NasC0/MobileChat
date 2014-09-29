var validationHelpers = (function() {
	var validatePassword = function(password) {
		if (password.length <= 4) {
			return false;
		}

		return true;
	};

	var validateUsername = function(username) {
		if (username.length <= 4) {
			return false;
		}

		return true;
	};

	var validateEmail = function(email) {
		var regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		return regex.test(email);
	};

	return {
		validatePassword: validatePassword,
		validateUsername: validateUsername,
		validateEmail: validateEmail
	};
}());