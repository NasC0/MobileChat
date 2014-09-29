var app = app || {};
app.viewmodels = app.viewmodels || {};

app.viewmodels.welcome = (function(){
	var friendsApiLocation = baseApiUrl + 'api/friends';

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

	var friendsSource = new kendo.data.DataSource({
		schema: {
			model: friendsModel
		},
		transport: {
			read: {
				url: friendsApiLocation,
				type: 'GET',
				beforeSend: function(request){
					request.setRequestHeader('Authorization', 'Bearer ' + window.localStorage.getItem('token'));
					request.setRequestHeader('Content-Type', 'application/json');
				}
			}
		}


	});

	return {
		title: 'Friends',
		friends: friendsSource
	};
}());