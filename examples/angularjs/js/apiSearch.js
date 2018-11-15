var app = angular.module('webApp', []);

app.filter('date', function($filter)
{
    return function(input)
    {
        if(input == null){ return ""; }
        var _date = $filter('date')(new Date(input), 'dd/MM/yyyy');
        return _date.toUpperCase();
    };
});

app.controller('searchForm', function($scope, $http) {
	$scope.searchById = function(cnId){
		if(!cnId){cnId = $scope.cnId;}else{$scope.cnId=cnId;}
		
		if(!cnId){
			$scope.errorMessage = "You must enter CN ID."
			$scope.showResults = false;
		}
		else{
			$scope.search(findByIdUrl + cnId);
			$scope.cnId = cnId;
		}
	}

	$scope.searchByPublishDate = function(){
		if(!$scope.dateStart || !$scope.dateEnd){
			$scope.errorMessage = "You must enter Publish Date."
			$scope.showResults = false;
		}
		else{
			 var startDate = $scope.formatDate($scope.dateStart);
			 var endDate = $scope.formatDate($scope.dateEnd);
			$scope.search(findByPublishDateUrl + startDate + "/" + endDate);
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
		}, function errorCallback(response) {
			$scope.showResults = true;
			$scope.data = response.data;
		}).finally(function() {
			$scope.loading = false;
		});
	};

	$scope.formatDate = function(strDate){
		var date = new Date(strDate);
		return date.getFullYear()+"-"+(date.getMonth()+1)+"-"+date.getDate()+"T00:00:00Z";
	}
});

app.filter("trustHtmlContent", ['$sce', $sce => htmlCode => $sce.trustAsHtml(htmlCode)]);




