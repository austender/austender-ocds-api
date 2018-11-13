var app = angular.module('webApp', []);

app.controller('searchForm', function($scope, $http) {
	$scope.search = function(cnId) {
		if(!cnId){cnId = $scope.cnId;}else{$scope.cnId=cnId;}
		
		$scope.showResults = false;
		if(!cnId && !$scope.dateStart && !$scope.dateEnd){
			$scope.errorMessage = "You must enter CN ID or Publish Date."
		}
		else{
			$scope.errorMessage = ""
			$scope.loading = true;
			$http({
				method: 'GET',
				url: findByIdUrl + cnId
			}).then(function successCallback(response) {
				$scope.showResults = true;
				$scope.data = response.data;
				$scope.cnId = cnId;
			}, function errorCallback(response) {
				$scope.showResults = true;
				$scope.data = response.data;
			}).finally(function() {
				$scope.loading = false;
			});
		}
		
		
	};
});

app.filter("trustHtmlContent", ['$sce', $sce => htmlCode => $sce.trustAsHtml(htmlCode)]);