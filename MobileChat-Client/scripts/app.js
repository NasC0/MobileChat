/* global kendo */

var app = (function() {
  document.addEventListener('deviceready', function() {
    navigator.splashscreen.hide();

    document.addEventListener('offline', function() {
      var currentConnection = navigator.connection.type;

      if (currentConnection === 'none' || currentConnection === 'unknown') {
        navigator.notification.alert('You are not connected to the internet!');
      } else {
        navigator.notification.alert('Please check your internet connection!');
      }

    }, false);

    document.addEventListener('online', function() {
      navigator.notification.vibrate();
      navigator.notification.alert('Connected to the internet.');
    });

  }, false);

  var mobileApp = new kendo.mobile.Application(document.body, {
    transition: 'slide',
    initial: 'views/login.html'
  });

  window.baseApiUrl = 'http://localhost:62112/';

  return mobileApp;
}());