var app = app || {};
app.viewmodels = app.viewmodels || {};

app.viewmodels.findFriends = (function(){
	var friendsModel = {
		fields: {
			UserID: {
				field: 'UserID',
				defaultValue: ''
			},
			Username: {
				field: 'Username',
				defaultValue: ''
			},
			Email: {
				field: 'Email',
				defaultValue: ''
			}
		}
	};

	var find = function() {
		var username = this.get('username');
		app.navigate('views/friends-result.html?name=' + username);
	};

	return {
		title: 'Find friends',
		find: find,
		username: '',
	};
}());