var app = angular.module("app", ['ngRoute']).config(
    function ($routeProvider, $locationProvider) {
        $routeProvider.when('/', { templateUrl: '/app/views/home/home.template.html', controller: 'home' })
        if (window.history && window.history.pushState) {
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });
        }
    }
);