function treeController($scope, $http) {
    $http.get("/api/PageRecursiveNodes/")
     .then(function (response) {
         $scope.tree = response.data;
         console.log($scope.tree);
     });
}