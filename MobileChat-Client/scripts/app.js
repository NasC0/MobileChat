/* global kendo */

(function () {
    document.addEventListener('deviceready', function () {
      navigator.splashscreen.hide();

      var app = new kendo.mobile.Application(document.body, {
        transition: 'slide',
        initial: 'views/login.html'
      });

    }, false);
    window.baseApiUrl = 'http://localhost:62112/';
    $.get(baseApiUrl + 'api/users?name=nas', function(response){
      console.log(response);
    });
    
}());