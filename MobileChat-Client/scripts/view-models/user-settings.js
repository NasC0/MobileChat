/* global Camera */

var app = app || {};
app.viewmodels = app.viewmodels || {};

app.viewmodels.userSettings = (function() {
	var logout = function() {
		window.localStorage.clear();
		app.navigate('views/login.html');
	};

	function getPicture(cameraOptions) {
		navigator.camera.getPicture(function(pic) {
			console.log(pic);
		}, function(error) {
			navigator.notification.alert(error);
		}, cameraOptions);
	}

	var takeProfilePicture = function() {
		var cameraOptions = {
			quality: 75,
			destinationType: Camera.DestinationType.DATA_URL,
			sourceType: Camera.PictureSourceType.CAMERA,
			targetWidth: 150,
			targetHeight: 150,
			cameraDirection: Camera.Direction.FRONT
		};

		getPicture(cameraOptions);
	};

	var selectProfilePicture = function() {
		var cameraOptions = {
			destinationType: Camera.DestinationType.DATA_URL,
			sourceType: Camera.PictureSourceType.PHOTOLIBRARY,
			targetWidth: 150,
			targetHeight: 150
		};

		getPicture(cameraOptions);
	};

	return {
		title: 'User settings',
		logout: logout,
		takeProfilePicture: takeProfilePicture,
		selectProfilePicture: selectProfilePicture
	};
}());