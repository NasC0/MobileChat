var app = app || {};
app.viewmodels = app.viewmodels || {};

app.viewmodels.friendsResult = (function(){
	function showData(e){
		console.log(e.view.params);
	}

	return {
		title: 'Search results'
	};
}());