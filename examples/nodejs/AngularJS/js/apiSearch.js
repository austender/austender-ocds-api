var app = angular.module('webApp', []);

app.controller('searchForm', function($scope, $http) {
	$scope.searchById = function(cnId){
		if(!cnId){cnId = $scope.cnId;}else{$scope.cnId=cnId;}
		
		if(!cnId){
			$scope.errorMessage = "You must enter CN ID."
		}
		else{
			$scope.search(findByIdUrl + cnId);
			$scope.cnId = cnId;
		}
	}

	$scope.searchByPublishDate = function(){
		if(!$scope.dateStart || !$scope.dateEnd){
			$scope.errorMessage = "You must enter Publish Date."
		}
		else{
			$scope.search(findByPublishDateUrl + $scope.dateStart + "/" + $scope.dateEnd);
		}
		
	}
	$scope.search = function(url) {
		$scope.showResults = false;
		$scope.errorMessage = ""
		$scope.loading = true;
		$http({
			method: 'GET',
			url: url
		}).then(function successCallback(response) {
			$scope.showResults = true;
			$scope.data = response.data;
			console.log(response.data);
		}, function errorCallback(response) {
			$scope.showResults = true;
			$scope.data = response.data;
		}).finally(function() {
			$scope.loading = false;
		});
	};
});

app.filter("trustHtmlContent", ['$sce', $sce => htmlCode => $sce.trustAsHtml(htmlCode)]);