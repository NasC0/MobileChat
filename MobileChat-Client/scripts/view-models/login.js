var app = app || {};
app.viewmodels = app.viewmodels || {};

app.login = (function(scope){
	var loginLocation = baseApiUrl + 'token';

	scope.login = {
		title: 'Login',
		username: '',
		password: '',
		login: function(){
			var username = this.get('username'),
				password = this.get('password');
				data = {
					'grant_type': 'password',
					'username': username,
					'password': password
				};

			$.ajax({
				url: loginLocation,
				type: 'POST',
				data: data,
				success: function(response){
					console.log(response);
				},
				error: function(error){
					console.log(error);
				}
			});
		}
	};
}(app.viewmodels));