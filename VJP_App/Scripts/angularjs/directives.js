angular.module('MyApp.directives',[])
    .directive('italicbold', function () {
        var directive = {};
        directive.restrice = "E";
        directive.transclude = true;
        directive.template = "<b><i ng-transclude></i></b>";
        return directive;
    });