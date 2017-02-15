angular.module("umbraco")
    .controller("My.PersonPickerController", function ($scope, personResource) {
        console.log("person list controller");
        personResource.getAll().then(function (response) {
            $scope.people = response;
        });
    });